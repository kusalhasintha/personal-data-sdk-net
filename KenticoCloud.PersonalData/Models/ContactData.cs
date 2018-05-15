using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenticoCloud.PersonalData.Models
{
    /// <summary>
    /// Represents data about a visitor stored in Kentico Cloud.
    /// </summary>
    public class ContactData
    {
        /// <summary>
        /// Visitor's user id.
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        /// <summary>
        /// Project Id of the project the visitor belongs to.
        /// </summary>
        [JsonProperty("projectId")]
        public Guid ProjectId { get; set; }

        /// <summary>
        /// Visitor's email.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Visitor's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Visitor's company.
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// Visitor's website.
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        /// Visitor's phone.
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Time of the visitor's first visit.
        /// </summary>
        [JsonProperty("firstVisit")]
        public DateTimeOffset FirstVisit { get; set; }

        /// <summary>
        /// Time when the visitor was created.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Time of the latest visit of the visitor.
        /// </summary>
        [JsonProperty("lastVisit")]
        public DateTimeOffset LastVisit { get; set; }

        /// <summary>
        /// Time of the latest update of the visitor.
        /// </summary>
        [JsonProperty("lastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        /// <summary>
        /// True for visitors who haven't revealed their email yet.
        /// </summary>
        [JsonProperty("anonymous")]
        public bool Anonymous { get; set; }

        /// <summary>
        /// Source of the visitor.
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        /// Source application of the visitor.
        /// </summary>
        [JsonProperty("sourceApp")]
        public string SourceApp { get; set; }

        /// <summary>
        /// Url of the photo of the visitor.
        /// </summary>
        [JsonProperty("photoUrl")]
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Session records of the visitor.
        /// </summary>
        [JsonProperty("sessionRecords")]
        public Dictionary<Guid, UserSession> SessionRecords { get; set; }

        /// <summary>
        /// Hash obtained from the contact's email.
        /// </summary>
        [JsonProperty("emailHash")]
        public Guid EmailHash { get; set; }

        /// <summary>
        /// Raw uid of the visitor.
        /// </summary>
        [JsonProperty("rawUid")]
        public string RawUid { get; set; }
    }
}