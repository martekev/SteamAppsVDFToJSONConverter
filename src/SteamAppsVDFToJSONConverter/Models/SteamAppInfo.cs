namespace SteamAppsVDFToJSONConverter.Models
{
    public class SteamAppInfo
    {
        #region Properties

        public int AppId { get; set; }

        public DateTimeOffset? LastPlayed { get; set; }

        public TimeSpan? Playtime { get; set; }

        #endregion
    }
}
