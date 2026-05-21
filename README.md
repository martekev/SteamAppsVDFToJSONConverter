[English](README.md) | [Français](README.fr.md)

# SteamAppsVDFToJSONConverter

A utility for converting Steam application data from VDF format (found in Steam's localconfig.vdf file) to JSON. It's a console application written in .NET 10 and that uses the Gameloop.Vdf library.

Typical Steam file path :

```C:\Program Files (x86)\Steam\userdata\XXXXXXXX\config\localconfig.vdf```

The converter extracts only the minimum information from Steam applications :

| Property     | Type              | Description                                                      |
| ------------ | ----------------- | ---------------------------------------------------------------- |
| `AppId`      | `integer`         | Unique game identifier                                           |
| `LastPlayed` | `nullable string` | Date of last played (Parsed into DateTimeOffset?)                |
| `Playtime`   | `nullable string` | Total playtime in `HH:mm:ss` format (Parsed into TimeSpan?)      |

Two methods are possible to generate the JSON :
- Drag and drop the `.vdf` file directly onto the application (the easiest way) (see Usage below)
- Manually extract the `SOFTWARE` section from the `localconfig.vdf` file, copy it into a new file, and then drag and drop it into the application (see Usage below).

## Usage

### Via the command prompt

1. Open a terminal (cmd / PowerShell)
2. Navigate to the folder containing the executable
3. Run command :
```SteamAppsVDFToJSONConverter.exe chemin_du_fichier.vdf```
4. The JSON file is generated automatically

### Via drag and drop

1. Drag the `.vdf` file directly onto `SteamAppsVDFToJSONConverter.exe`
2. The JSON file is generated automatically