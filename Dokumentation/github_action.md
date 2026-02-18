# GitHub Action – Automatische Unittests

## Ziel
Ziel dieser GitHub Action ist es, die Unittests des Projekts automatisch
bei jedem Push und Pull Request auszuführen.

## Einrichtung

1. Im Repository wurde der Ordner `.github/workflows` angelegt.
2. In diesem Ordner wurde die Datei `dotnet-tests.yml` erstellt.
3. Die Action nutzt einen Ubuntu-Runner von GitHub.
4. .NET 7 wird installiert.
5. Das Projekt wird gebaut.
6. Alle Unittests werden mit `dotnet test` ausgeführt.

## Ergebnis
Bei jedem Push in den `main`-Branch werden die Unittests automatisch gestartet.
Der Status der Tests ist im GitHub-Repository im Tab „Actions“ sichtbar.
