// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.ManagedServices.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Properties of a registration assignment.
    /// </summary>
    public partial class RegistrationAssignmentProperties
    {
        /// <summary>
        /// Initializes a new instance of the RegistrationAssignmentProperties
        /// class.
        /// </summary>
        public RegistrationAssignmentProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the RegistrationAssignmentProperties
        /// class.
        /// </summary>
        /// <param name="registrationDefinitionId">Fully qualified path of the
        /// registration definition.</param>
        /// <param name="provisioningState">Current state of the registration
        /// assignment. Possible values include: 'NotSpecified', 'Accepted',
        /// 'Running', 'Ready', 'Creating', 'Created', 'Deleting', 'Deleted',
        /// 'Canceled', 'Failed', 'Succeeded', 'Updating'</param>
        /// <param name="registrationDefinition">Registration definition inside
        /// registration assignment.</param>
        public RegistrationAssignmentProperties(string registrationDefinitionId, string provisioningState = default(string), RegistrationAssignmentPropertiesRegistrationDefinition registrationDefinition = default(RegistrationAssignmentPropertiesRegistrationDefinition))
        {
            RegistrationDefinitionId = registrationDefinitionId;
            ProvisioningState = provisioningState;
            RegistrationDefinition = registrationDefinition;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets fully qualified path of the registration definition.
        /// </summary>
        [JsonProperty(PropertyName = "registrationDefinitionId")]
        public string RegistrationDefinitionId { get; set; }

        /// <summary>
        /// Gets current state of the registration assignment. Possible values
        /// include: 'NotSpecified', 'Accepted', 'Running', 'Ready',
        /// 'Creating', 'Created', 'Deleting', 'Deleted', 'Canceled', 'Failed',
        /// 'Succeeded', 'Updating'
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState { get; private set; }

        /// <summary>
        /// Gets registration definition inside registration assignment.
        /// </summary>
        [JsonProperty(PropertyName = "registrationDefinition")]
        public RegistrationAssignmentPropertiesRegistrationDefinition RegistrationDefinition { get; private set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (RegistrationDefinitionId == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "RegistrationDefinitionId");
            }
            if (RegistrationDefinition != null)
            {
                RegistrationDefinition.Validate();
            }
        }
    }
}
