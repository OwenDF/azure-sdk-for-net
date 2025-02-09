// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ManagedServices.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Registration assignment.
    /// </summary>
    public partial class RegistrationAssignment : IResource
    {
        /// <summary>
        /// Initializes a new instance of the RegistrationAssignment class.
        /// </summary>
        public RegistrationAssignment()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RegistrationAssignment class.
        /// </summary>
        /// <param name="properties">Properties of a registration
        /// assignment.</param>
        /// <param name="id">The fully qualified path of the registration
        /// assignment.</param>
        /// <param name="type">Type of the resource.</param>
        /// <param name="name">Name of the registration assignment.</param>
        public RegistrationAssignment(RegistrationAssignmentProperties properties = default(RegistrationAssignmentProperties), string id = default(string), string type = default(string), string name = default(string))
        {
            Properties = properties;
            Id = id;
            Type = type;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets properties of a registration assignment.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public RegistrationAssignmentProperties Properties { get; set; }

        /// <summary>
        /// Gets the fully qualified path of the registration assignment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets type of the resource.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; private set; }

        /// <summary>
        /// Gets name of the registration assignment.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Properties != null)
            {
                Properties.Validate();
            }
        }
    }
}
