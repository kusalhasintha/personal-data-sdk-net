using System;
using Newtonsoft.Json;

namespace KenticoCloud.PersonalData.Models
{
    /// <summary>
    /// Represents a tracked session of a user.
    /// </summary>
    public class UserSession
    {
        /// <summary>
        /// Id of the visitor who established the session.
        /// </summary>
        [JsonProperty("uid")]
        public Guid Uid { get; set; }

        /// <summary>
        /// Id of the session.
        /// </summary>
        [JsonProperty("sid")]
        public Guid Sid { get; set; }

        /// <summary>
        /// Time when the session was established.
        /// </summary>
        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        /// <summary>
        /// Referrer of the session.
        /// </summary>
        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        /// <summary>
        /// Language of the session.
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
        /// Source application of the session.
        /// </summary>
        [JsonProperty("sourceApp")]
        public string SourceApp { get; set; }

        /// <summary>
        /// Hash optained from the session's IP address.
        /// </summary>
        [JsonProperty("ipHash")]
        public Guid IpHash { get; set; }

        /// <summary>
        /// Visitor's actions done during the session.
        /// </summary>
        [JsonProperty("actions")]
        public UserAction[] Actions { get; set; }

        /// <summary>
        /// Visitor's custom activities done during the session.
        /// </summary>
        [JsonProperty("customActivities")]
        public CustomActivity[] CustomActivities { get; set; }

        /// <summary>
        /// Tracking IP address of the session.
        /// </summary>
        [JsonProperty("trackingIp")]
        public TrackingIp TrackingIp { get; set; }

        /// <summary>
        /// Raw format of the session's id.
        /// </summary>
        [JsonProperty("rawSid")]
        public string RawSid { get; set; }
    }
}