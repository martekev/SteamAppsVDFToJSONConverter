[English](README.md) | [Français](README.fr.md)

# SteamAppsVDFToJSONConverter

Un utilitaire permettant de convertir les données d’applications Steam au format VDF (présent dans le fichier localconfig.vdf de Steam) en JSON. C'est une application console écrite en .NET 10 et qui utilise la librairie Gameloop.Vdf.

Chemin typique du fichier Steam :

```C:\Program Files (x86)\Steam\userdata\XXXXXXXX\config\localconfig.vdf```

Le convertisseur extrait uniquement les informations minimales des applications Steam :

| Propriété    | Type              | Description                                                      |
| ------------ | ----------------- | ---------------------------------------------------------------- |
| `AppId`      | `integer`         | Identifiant unique du jeu                                        |
| `LastPlayed` | `nullable string` | Date de dernière utilisation (Convertie en DateTimeOffset?)      |
| `Playtime`   | `nullable string` | Temps de jeu total au format `HH:mm:ss` (Converti en TimeSpan?) |

Deux méthodes sont possibles pour générer le JSON :
- Glisser-déposer directement le fichier `.vdf` sur l’application (le plus simple) (voir Utilisation ci-dessous)
- Extraire manuellement la section `SOFTWARE` du fichier `localconfig.vdf`, la copier dans un nouveau fichier, puis le glisser-déposer dans l’application (voir Utilisation ci-dessous)

## Utilisation

### Via l’invite de commandes

1. Ouvrir un terminal (cmd / PowerShell)
2. Se placer dans le dossier contenant l’exécutable
3. Exécuter la commande :
```SteamAppsVDFToJSONConverter.exe chemin_du_fichier.vdf```
4. Le fichier JSON est généré automatiquement

### Via glisser-déposer

1. Glisser le fichier `.vdf` directement sur `SteamAppsVDFToJSONConverter.exe`
2. Le fichier JSON est généré automatiquement