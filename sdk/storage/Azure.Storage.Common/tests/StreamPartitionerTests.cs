﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Common.Test
{
    [TestFixture]
    public class StreamPartitionerTests
    {
        [Test]
        public async Task ReadAsync()
        {
            var expected = TestHelper.GetRandomBuffer(10 * Constants.MB);
            _ = new ReadOnlyMemory<byte>(expected);
            var actual = new byte[expected.Length];

            Assert.AreNotSame(expected, actual);

            using (var expectedStream = new NonSeekableStream(expected))
            using (var reader = new StreamPartitioner(expectedStream))
            {
                Assert.IsTrue(expectedStream.CanRead);
                Assert.IsFalse(expectedStream.CanSeek);

                do
                {
                    var position = expectedStream.Position;
                    using (var buffer = await reader.ReadAsync())
                    {
                        if (buffer.Length == 0)
                        {
                            Assert.AreEqual(expectedStream.Length, expectedStream.Position);
                            break;
                        }
                        else
                        {
                            Assert.IsTrue(buffer.CanRead);
                            Assert.IsTrue(buffer.CanSeek);

                            await buffer.ReadAsync(actual, (int)position, (int)buffer.Length);
                        }
                    }
                }
                while (true);

                TestHelper.AssertSequenceEqual(expected, actual);
            }
        }

        [Test]
        public async Task Read_WithReadOnlyMemory()
        {
            var expected = TestHelper.GetRandomBuffer(10 * Constants.MB);
            _ = new ReadOnlyMemory<byte>(expected);
            var actual = new byte[expected.Length];

            Assert.AreNotSame(expected, actual);

            using (var expectedStream = new NonSeekableStream(expected))
            using (var reader = new StreamPartitioner(expectedStream))
            {
                Assert.IsTrue(expectedStream.CanRead);
                Assert.IsFalse(expectedStream.CanSeek);

                do
                {
                    var position = expectedStream.Position;
                    using (var buffer = await reader.ReadAsync())
                    {
                        if (buffer.Length == 0)
                        {
                            Assert.AreEqual(expectedStream.Length, expectedStream.Position);
                            break;
                        }
                        else
                        {
                            Assert.IsTrue(buffer.CanRead);
                            Assert.IsTrue(buffer.CanSeek);

                            buffer.Read(out var memory, (int)buffer.Length);

                            memory.CopyTo(new Memory<byte>(actual, (int)position, (int)buffer.Length));
                        }
                    }
                }
                while (true);

                TestHelper.AssertSequenceEqual(expected, actual);
            }
        }

        [Test]
        [NonParallelizable]
        public async Task ReadAsync_1GB()
        {
            long memoryStart;
            long memoryEnd;
            var buffersRead = 0L;

            var length = (1L * Constants.GB) - (1 * Constants.MB) - (1 * Constants.KB);

            using (var expectedStream = new MockNonSeekableStream(length))
            using (var reader = new StreamPartitioner(expectedStream))
            {
                memoryStart = GC.GetTotalMemory(true);

                Assert.IsTrue(expectedStream.CanRead);
                Assert.IsFalse(expectedStream.CanSeek);

                do
                {
                    var position = expectedStream.Position;
                    using (var buffer = await reader.ReadAsync())
                    {
                        if (buffer.Length == 0)
                        {
                            Assert.AreEqual(expectedStream.Length, expectedStream.Position);
                            break;
                        }
                        else
                        {
                            buffersRead++;

                            Assert.IsTrue(buffer.CanRead);
                            Assert.IsTrue(buffer.CanSeek);
                        }
                    }

                    Assert.IsTrue(GC.GetTotalMemory(true) - memoryStart < 8 * Constants.DEFAULT_BUFFER_SIZE); // TODO Assuming at most 8 buffers allocated
                }
                while (true);
            }

            memoryEnd = GC.GetTotalMemory(true);

            //logger.LogInformation($"{buffersRead} buffers read");
            //logger.LogInformation($"{nameof(memoryStart)} = {memoryStart}; {nameof(memoryEnd)} = {memoryEnd}");
            //logger.LogInformation($"delta = {memoryEnd - memoryStart}");

            Assert.AreEqual(Math.Ceiling(1d * length / Constants.DEFAULT_BUFFER_SIZE), buffersRead);
            Assert.IsTrue(memoryEnd - memoryStart < 8 * Constants.DEFAULT_BUFFER_SIZE); // TODO Assuming at most 8 buffers allocated
        }

        [Test]
        [NonParallelizable]
        public async Task ReadAsync_1GB_WithReadOnlyMemory()
        {
            long memoryStart;
            long memoryEnd;
            var buffersRead = 0L;

            var length = (1L * Constants.GB) - (1 * Constants.MB) - (1 * Constants.KB);

            using (var expectedStream = new MockNonSeekableStream(length))
            using (var reader = new StreamPartitioner(expectedStream))
            {
                memoryStart = GC.GetTotalMemory(true);

                Assert.IsTrue(expectedStream.CanRead);
                Assert.IsFalse(expectedStream.CanSeek);

                do
                {
                    var position = expectedStream.Position;
                    using (var buffer = await reader.ReadAsync())
                    {
                        if (buffer.Length == 0)
                        {
                            Assert.AreEqual(expectedStream.Length, expectedStream.Position);
                            break;
                        }
                        else
                        {
                            buffersRead++;

                            Assert.IsTrue(buffer.CanRead);
                            Assert.IsTrue(buffer.CanSeek);
                            
                            buffer.Read(out var memory, (int)buffer.Length);

                            Assert.AreEqual((int)buffer.Length, memory.Length);
                        }
                    }

                    Assert.IsTrue(GC.GetTotalMemory(true) - memoryStart < 8 * Constants.DEFAULT_BUFFER_SIZE); // TODO Assuming at most 8 buffers allocated
                }
                while (true);
            }

            memoryEnd = GC.GetTotalMemory(true);

            //logger.LogInformation($"{buffersRead} buffers read");
            //logger.LogInformation($"{nameof(memoryStart)} = {memoryStart}; {nameof(memoryEnd)} = {memoryEnd}");
            //logger.LogInformation($"delta = {memoryEnd - memoryStart}");

            Assert.AreEqual(Math.Ceiling(1d * length / Constants.DEFAULT_BUFFER_SIZE), buffersRead);
            Assert.IsTrue(memoryEnd - memoryStart < 8 * Constants.DEFAULT_BUFFER_SIZE); // TODO Assuming at most 8 buffers allocated
        }

        class NonSeekableStream : MemoryStream
        {
            public NonSeekableStream(byte[] buffer) : base(buffer)
            {
            }

            public override bool CanSeek => false;

            public override long Position
            {
                get => base.Position;
                set => throw new InvalidOperationException();
            }

            public override long Seek(long offset, SeekOrigin loc) => throw new InvalidOperationException();
        }

        class MockNonSeekableStream : Stream
        {
            public MockNonSeekableStream(long length, bool randomizeData = false)
            {
                this.Length = length;
                this.position = 0;
                this.randomizeData = randomizeData;
            }

            public override bool CanRead => true;

            public override bool CanSeek => false;

            public override bool CanWrite => false;

            public override long Length { get; }

            long position;

            readonly bool randomizeData;

            public override long Position
            {
                get => this.position;
                set => throw new InvalidOperationException();
            }

            public override void Flush()
            {
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (this.randomizeData)
                {
                    lock (this)
                    {
                        var i = 0;

                        for (i = 0; i < count && this.position < this.Length; i++)
                        {
                            buffer[offset + i] = (byte)Constants.Random.Next(256);
                            Interlocked.Increment(ref this.position);
                        }

                        return i;
                    }
                }
                else
                {
                    lock (this)
                    {
                        var i = (int)Math.Min(count, this.Length - this.position);

                        Interlocked.Add(ref this.position, i);

                        return i;
                    }
                }
            }

            public override long Seek(long offset, SeekOrigin origin) => throw new InvalidOperationException();

            public override void SetLength(long value) => throw new InvalidOperationException();

            public override void Write(byte[] buffer, int offset, int count) => throw new InvalidOperationException();
        }
    }
}
