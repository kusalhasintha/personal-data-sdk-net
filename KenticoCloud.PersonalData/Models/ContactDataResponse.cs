using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenticoCloud.PersonalData.Models
{
    /// <summary>
    /// Represents collection of data about a contact stored in Kentico Cloud.
    /// </summary>
    public class ContactDataResponse
    {
        /// <summary>
        /// Collection of data about a contact.
        /// </summary>
        [JsonProperty("contactData")]
        public IEnumerable<ContactData> ContactData { get; }

        /// <summary>
        /// All ids which were used to track a contact.
        /// </summary>
        [JsonProperty("trackedIds")]
        public IEnumerable<string> TrackedIds { get; }
    }
}