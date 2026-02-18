# GitHub Action – Automatische Unittests

## Ziel

Ziel dieser GitHub Action ist es, die Unittests des Projekts automatisch
bei jedem Push und Pull Request auszuführen.
Dadurch wird sichergestellt, dass neue Änderungen den bestehenden Code nicht
beschädigen.

## Einrichtung

Im Repository wurde der Ordner .github/workflows angelegt.
In diesem Ordner befindet sich die Datei dotnet-tests.yml.

Die GitHub Action ist wie folgt konfiguriert:

Die Action nutzt einen Windows-Runner (windows-latest), da es sich
um ein WPF-Projekt (net7.0-windows) handelt.

.NET 7 wird installiert.

Das Projekt wird mit dotnet restore wiederhergestellt.

Der Code wird mit dotnet build kompiliert.

Alle Unittests werden mit dotnet test ausgeführt.

## Ergebnis

Bei jedem Push in den main-Branch sowie bei Pull Requests werden die
Unittests automatisch gestartet.

Der Status der Tests ist:

im GitHub-Repository im Tab „Actions“

sowie über einen Status-Badge in der README.md

sichtbar.

## Fazit

Die GitHub Action ermöglicht eine automatische Qualitätssicherung.
Fehler in der Implementierung werden frühzeitig erkannt, was die
Stabilität und Wartbarkeit des Projekts verbessert.
