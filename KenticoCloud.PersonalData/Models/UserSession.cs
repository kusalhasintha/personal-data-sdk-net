using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenticoCloud.PersonalData.Models
{
    /// <summary>
    /// Represents a tracked session of the user.
    /// </summary>
    public class UserSession
    {
        /// <summary>
        /// Id of the user who established the session.
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        /// <summary>
        /// Session id.
        /// </summary>
        [JsonProperty("sid")]
        public Guid Sid { get; set; }

        /// <summary>
        /// Time when the ssession was established.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Session's referrer.
        /// </summary>
        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        /// <summary>
        /// Session's language.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        /// True if the session was established via a mobile device.
        /// </summary>
        [JsonProperty("mobile")]
        public bool Mobile { get; set; }

        /// <summary>
        /// Resolution of the device which established the session.
        /// </summary>
        [JsonProperty("resolution")]
        public string Resolution { get; set; }

        /// <summary>
        /// Platform of the device which established the session.
        /// </summary>
        [JsonProperty("platform")]
        public string Platform { get; set; }

        /// <summary>
        /// True if cookies were enabled during the session.
        /// </summary>
        [JsonProperty("cookiesEnabled")]
        public bool CookiesEnabled { get; set; }

        /// <summary>
        /// Browser which was used for the session.
        /// </summary>
        [JsonProperty("browserName")]
        public string BrowserName { get; set; }

        /// <summary>
        /// Browser version which was used for the session.
        /// </summary>
        public string BrowserVersion { get; set; }

        /// <summary>
        /// Operational system of the device which established the session.
        /// </summary>
        [JsonProperty("osName")]
        public string OSName { get; set; }

        /// <summary>
        /// Operational system version of the device which established the session.
        /// </summary>
        [JsonProperty("osVersion")]
        public string OSVersion { get; set; }

        /// <summary>
        /// Session's source application.
        /// </summary>
        [JsonProperty("sourceApp")]
        public string SourceApp { get; set; }

        /// <summary>
        /// Hash optained from the session's IP.
        /// </summary>
        [JsonProperty("ipHash")]
        public Guid IpHash { get; set; }

        /// <summary>
        /// User's actions done during the session.
        /// </summary>
        [JsonProperty("actions")]
        public List<UserAction> Actions { get; set; }

        /// <summary>
        /// User's custom activities done during the session.
        /// </summary>
        [JsonProperty("customActivities")]
        public List<CustomActivity> CustomActivities { get; set; }

        /// <summary>
        /// Session's tracking IP.
        /// </summary>
        [JsonProperty("trackingIp")]
        public TrackingIp TrackingIp { get; set; }

        /// <summary>
        /// Session's raw id.
        /// </summary>
        [JsonProperty("rawSid")]
        public string RawSid { get; set; }
    }
}