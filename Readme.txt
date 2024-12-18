Zum Zeitpunkt dieser Arbeit (17.12.2024 bis 18.12.2024) war die Webseite https://swapi.dev/ nicht erreichbar (404 Not Found). Daher wurde die vom archive.org revisionierte Dokumentation genutzt: https://web.archive.org/web/20241113211619/https://swapi.dev/documentation

Damit die Anwendung trotzdem verwendbar ist, wurde als Alternative eine SQLite-Datenbank mit ein paar Werten aus archive.org verwendet. Ob der HttpClient oder die SQLite-Datenbank genutzt werden soll, lässt sich im Serviceprojekt in appsettings.json konfigurieren: "UseSqliteDb": true (SQLite) oder "UseSqliteDb": false (swapi.dev)

Für das Projekt wurde .NET 9, ASP.NET Core und WPF genutzt. Es ist auch auf GitHub verfügbar: https://github.com/sungaila/WpfSampleApp

Der Service kann mit Docker gebaut werden. Dazu folgendes im Stammverzeichnis ausführen:
docker compose up --build