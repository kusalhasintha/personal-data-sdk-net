﻿using Newtonsoft.Json;
using System;

namespace KenticoCloud.PersonalData.Models
{
    /// <summary>
    /// Represents a custom activity defined by a user in Kentico cloud.
    /// </summary>
    public class CustomActivity
    {
        /// <summary>
        /// Id of the contact who performed the activity.
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        /// <summary>
        /// Id of the session in which the activity was performed.
        /// </summary>
        [JsonProperty("sid")]
        public Guid Sid { get; set; }

        /// <summary>
        /// Custom activity's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Time when the activity was performed.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }
    }
}