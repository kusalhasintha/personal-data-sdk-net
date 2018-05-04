using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenticoCloud.PersonalData.Models
{
    /// <summary>
    /// Represents data about a contact stored in Kentico Cloud.
    /// </summary>
    public class ContactData
    {
        /// <summary>
        /// Contact's user id.
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        /// <summary>
        /// Project Id to which the contact belongs.
        /// </summary>
        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Contact's email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Contact's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Contact's company.
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Contact's website.
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// Contact's phone.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Contact's time of their first visit.
        /// </summary>
        [JsonProperty("firstVisit")]
        public DateTimeOffset FirstVisit { get; set; }

        /// <summary>
        /// Time when the contact was created.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Time of the latest visit of the contact.
        /// </summary>
        [JsonProperty("lastVisit")]
        public DateTimeOffset LastVisit { get; set; }

        /// <summary>
        /// Time of the latest update of the contact.
        /// </summary>
        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        /// <summary>
        /// True for contacts who haven't revealed any information about themselves yet.
        /// </summary>
        [JsonProperty("anonymous")]
        public bool Anonymous { get; set; }

        /// <summary>
        /// Source of the contact.
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// Source application of the contact.
        /// </summary>
        [JsonProperty("sourceApp")]
        public string SourceApp { get; set; }

        /// <summary>
        /// Url with a photo of the contact.
        /// </summary>
        [JsonProperty("photoUrl")]
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Session records of the contact.
        /// </summary>
        [JsonProperty("sessionRecords")]
        public Dictionary<Guid, UserSession> SessionRecords { get; set; }

        /// <summary>
        /// Hash obtained from contact's email.
        /// </summary>
        [JsonProperty("emailHash")]
        public Guid EmailHash { get; set; }

        /// <summary>
        /// Raw uid of the contact.
        /// </summary>
        [JsonProperty("rawUid")]
        public string RawUid { get; set; }
    }
}