using SteamAppsVDFToJSONConverter.Models;
using System.Text.Json.Serialization;

namespace SteamAppsVDFToJSONConverter.Serialization
{
    [JsonSerializable(typeof(List<SteamAppInfo>))]
    public partial class JsonContext : JsonSerializerContext
    {
    }
}
