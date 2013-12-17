// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Management.Compute
{
    /// <summary>
    /// Operations for determining the version of the Windows Azure Guest
    /// Operating System on which your service is running.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/ff684169.aspx for
    /// more information)
    /// </summary>
    public static partial class OperatingSystemOperationsExtensions
    {
        /// <summary>
        /// The List Operating Systems operation lists the versions of the
        /// guest operating system that are currently available in Windows
        /// Azure. The 2010-10-28 version of List Operating Systems also
        /// indicates what family an operating system version belongs to.
        /// Currently Windows Azure supports two operating system families:
        /// the Windows Azure guest operating system that is substantially
        /// compatible with Windows Server 2008 SP2, and the Windows Azure
        /// guest operating system that is substantially compatible with
        /// Windows Server 2008 R2.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ff684168.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.Compute.IOperatingSystemOperations.
        /// </param>
        /// <returns>
        /// The List Operating Systems operation response.
        /// </returns>
        public static OperatingSystemListResponse List(this IOperatingSystemOperations operations)
        {
            try
            {
                return operations.ListAsync().Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1)
                {
                    throw;
                }
                else
                {
                    throw ex.InnerException;
                }
            }
        }
        
        /// <summary>
        /// The List Operating Systems operation lists the versions of the
        /// guest operating system that are currently available in Windows
        /// Azure. The 2010-10-28 version of List Operating Systems also
        /// indicates what family an operating system version belongs to.
        /// Currently Windows Azure supports two operating system families:
        /// the Windows Azure guest operating system that is substantially
        /// compatible with Windows Server 2008 SP2, and the Windows Azure
        /// guest operating system that is substantially compatible with
        /// Windows Server 2008 R2.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ff684168.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.Compute.IOperatingSystemOperations.
        /// </param>
        /// <returns>
        /// The List Operating Systems operation response.
        /// </returns>
        public static Task<OperatingSystemListResponse> ListAsync(this IOperatingSystemOperations operations)
        {
            return operations.ListAsync(CancellationToken.None);
        }
        
        /// <summary>
        /// The List OS Families operation lists the guest operating system
        /// families available in Windows Azure, and also lists the operating
        /// system versions available for each family. Currently Windows Azure
        /// supports two operating system families: the Windows Azure guest
        /// operating system that is substantially compatible with Windows
        /// Server 2008 SP2, and the Windows Azure guest operating system that
        /// is substantially compatible with Windows Server 2008 R2.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/gg441291.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.Compute.IOperatingSystemOperations.
        /// </param>
        /// <returns>
        /// The List Operating System Families operation response.
        /// </returns>
        public static OperatingSystemListFamiliesResponse ListFamilies(this IOperatingSystemOperations operations)
        {
            try
            {
                return operations.ListFamiliesAsync().Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerExceptions.Count > 1)
                {
                    throw;
                }
                else
                {
                    throw ex.InnerException;
                }
            }
        }
        
        /// <summary>
        /// The List OS Families operation lists the guest operating system
        /// families available in Windows Azure, and also lists the operating
        /// system versions available for each family. Currently Windows Azure
        /// supports two operating system families: the Windows Azure guest
        /// operating system that is substantially compatible with Windows
        /// Server 2008 SP2, and the Windows Azure guest operating system that
        /// is substantially compatible with Windows Server 2008 R2.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/gg441291.aspx
        /// for more information)
        /// </summary>
        /// <param name='operations'>
        /// Reference to the
        /// Microsoft.WindowsAzure.Management.Compute.IOperatingSystemOperations.
        /// </param>
        /// <returns>
        /// The List Operating System Families operation response.
        /// </returns>
        public static Task<OperatingSystemListFamiliesResponse> ListFamiliesAsync(this IOperatingSystemOperations operations)
        {
            return operations.ListFamiliesAsync(CancellationToken.None);
        }
    }
}
