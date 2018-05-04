﻿using System;
using Newtonsoft.Json;

namespace KenticoCloud.PersonalData.Models
{
    /// <summary>
    /// Represents an action done by a user.
    /// </summary>
    public class UserAction
    {
        /// <summary>
        /// Action's type.
        /// </summary>
        [JsonProperty("actionType")]
        public string ActionType { get; set; }

        /// <summary>
        /// Page url where the action was performed.
        /// </summary>
        [JsonProperty("pageUrl")]
        public string PageUrl { get; set; }

        /// <summary>
        /// Page title where the action was performed.
        /// </summary>
        [JsonProperty("pageTitle")]
        public string PageTitle { get; set; }

        /// <summary>
        /// Time when the action was performed.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Session id where the action was performed.
        /// </summary>
        [JsonProperty("sid")]
        public Guid Sid { get; set; }

        /// <summary>
        /// Id of the user who performed the action.
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }
    }
}