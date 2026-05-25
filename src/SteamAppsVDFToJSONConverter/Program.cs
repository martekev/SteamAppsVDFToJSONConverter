using Gameloop.Vdf;
using Gameloop.Vdf.Linq;
using SteamAppsVDFToJSONConverter.Models;
using SteamAppsVDFToJSONConverter.Serialization;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SteamAppsVDFToJSONConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];

            var text = File.ReadAllText(filePath);
            var root = VdfConvert.Deserialize(text, new VdfSerializerSettings
            {
                MaximumTokenSize = 65536,
                UsesEscapeSequences = true
            });

            var key = root.Key;

            VToken? apps = null;

            if (key == "Software")
            {
                apps = root?.Value?["Valve"]?["Steam"]?["apps"];
            }
            else if (key == "UserLocalConfigStore")
            {
                apps = root?.Value?["Software"]?["Valve"]?["Steam"]?["apps"];
            }

            if (apps == null)
            {
                throw new InvalidOperationException($"Unable to find the 'apps' node for the root '{key}'.");
            }

            var steamAppInfos = new List<SteamAppInfo>();

            foreach (var app in apps.Children<VProperty>())
            {
                if (!int.TryParse(app.Key, out var appId))
                    continue;

                var data = app.Value;

                DateTimeOffset? lastPlayed = null;
                TimeSpan? playtime = null;

                if (long.TryParse(data["LastPlayed"]?.ToString(), out var unix))
                    lastPlayed = DateTimeOffset.FromUnixTimeSeconds(unix);

                if (int.TryParse(data["Playtime"]?.ToString(), out var minutes))
                    playtime = TimeSpan.FromMinutes(minutes);

                steamAppInfos.Add(new SteamAppInfo
                {
                    AppId = appId,
                    LastPlayed = lastPlayed,
                    Playtime = playtime
                });
            }

            var json = JsonSerializer.Serialize(steamAppInfos, new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                TypeInfoResolver = JsonContext.Default
            });

            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var fileName = Path.GetFileNameWithoutExtension(filePath);

            var outputFilePath = Path.Combine(currentDirectory, fileName + ".json");
            File.WriteAllText(outputFilePath, json, Encoding.UTF8);
        }
    }
}
