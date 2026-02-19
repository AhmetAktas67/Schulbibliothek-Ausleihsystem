 KI-Nutzung – Schulbibliothek Ausleihsystem
Autor: Ahmet Aktas  
Projekt: Schulbibliothek – Ausleihsystem  
Datum: 25.11.2025



Verwendete KI-Tools
Im Rahmen des Projekts wurden folgende KI-Systeme eingesetzt:

- ChatGPT (OpenAI) – Haupttool für Planung, Code-Hilfe und Dokumentation  
- GitHub Copilot – Unterstützung direkt in Visual Studio bei der Code-Vervollständigung  



Einsatzgebiete der KI im Projekt

Die KI wurde bei folgenden Aufgaben genutzt:

1. Generierung funktionaler Anforderungen  
   – KI generierte zunächst 10 mögliche Anforderungen.

2. Erstellen von Code-Vorschlägen  
   – Hilfestellung beim Schreiben des Console-Prototyps (Menü, Dateiverarbeitung, Fehlerbehandlung).

3. Datenbank-Design 
   – Unterstützung bei ER-Diagramm-Struktur (Tabellen, Beziehungen, Datentypen).

4. Git-Hilfe  
   – Korrektur von Commits, Bereinigung des Repositories und Erstellen der .gitignore.

---

Verwendete Prompts (mindestens 3 Beispiele)

 Prompt 1 – Funktionale Anforderungen
> „Erstelle mir eine Liste von mindestens 10 funktionalen Anforderungen für ein Schulbibliothek-Ausleihsystem.“

 Prompt 2 – Console-Prototyp
> „Schreibe mir einen einfachen Console-Prototyp in C#, der Bücher anzeigt und Ausleihe und Rückgabe simuliert.“

 Prompt 3 – Datenbank
> „Hilf mir, für mein Schulbibliothekssystem ein ER-Diagramm mit Chen-Notation zu planen. Mindestens zwei Tabellen und eine Beziehung.“

---

 4. Beispiel mit mehreren Prompt-Iterationen

Erster Prompt (zu unpräzise):
> „Mach mir eine Benutzungsoberfläche.“

Verbesserter Prompt:
> „Erstelle einen handgezeichneten Papierprototyp für ein Ausleihsystem mit folgenden Fenstern:  
> – Login  
> – Startmenü (Bücherliste, Suche, Buttons oben rechts)  
> – Buchdetails  
> – Mahnungsliste.“

Diese Präzisierung führte zu deutlich besseren Ergebnissen, da die KI genau wusste, welche Elemente benötigt werden trotzdem habe ich das Design selber angepasst so wie es mir gefällt.

---

5. Übernommene, modifizierte und verworfene KI-Inhalte

Übernommen:
- Grundstruktur der funktionalen Anforderungen  
- Code-Gerüst für Console-Prototyp  
- Aufbau der README.md Vorlage  
- Vorschläge für Git-Befehle  
- Wireframe-Layouts (Papierprototyp)

Modifiziert:
- Formulierungen der finalen Anforderungen (wegen Klarheit + Lehrerformat)  
- SQL-Tabellenstruktur (angepasst an persönliches ER-Diagramm)  
- Console-Menü-Struktur (vereinfacht für Projektphase)

Verworfen:
- KI-Vorschlag für vollständiges WPF-Design (zu komplex für Prototyp)  
- Zu umfangreiche Code-Beispiele (nicht projektkonform)  
- KI-generierte alternative Datenbank mit 6 Tabellen (Projekt fordert weniger)

---

6. Reflexion – Was ich durch den KI-Einsatz gelernt habe

Durch die Nutzung verschiedener KI-Tools habe ich gelernt:

- wie man Prompts präzise formuliert, damit bessere Ergebnisse entstehen  
- dass KI eine wertvolle Unterstützung ist, aber niemals unverändert übernommen werden sollte  
- dass man Inhalte kritisch prüfen und an das Projekt anpassen muss  
- wie KI helfen kann, Zeit zu sparen (z. B. schnelle Ideensammlung, Vorlagen)  
- wie KI beim Debuggen und bei Git-Problemen helfen kann  
- dass KI-Tools keine Projektarbeit ersetzen, sondern nur unterstützen dürfen

Die Arbeit mit KI hat meine Planung und Strukturierung verbessert und mich gelehrt, wie man diese Tools verantwortungsvoll einsetzt.

---
## Ergänzende KI-Nutzung (Dokumentation & Datenbankanpassung)

Datum der Ergänzung: 19.02.2026

Zusätzlich zu den bereits genannten Einsatzgebieten wurde KI auch unterstützend
bei folgenden Punkten genutzt:

## Debugging und Problemlösung

Die KI wurde außerdem zur Unterstützung beim Debugging eingesetzt.
Dabei wurden Fehlermeldungen (z. B. aus Visual Studio, Entity Framework oder GitHub Actions)
analysiert und erklärt.

Die KI half insbesondere bei:
- dem Verständnis von Compiler- und Laufzeitfehlern
- der Erklärung von Entity-Framework-Fehlern (z. B. fehlende Spalten, Migrationsprobleme)
- Problemen mit Git, Branches, Merges und GitHub Actions
- der Erklärung von WPF-Bindings und DataGrid-Anzeigeproblemen

Die eigentlichen Fehlerbehebungen und Code-Anpassungen
wurden anschließend eigenständig umgesetzt.

### Anpassung der Datenbank (SQL → SQLite)

Zu Beginn des Projekts lag eine SQL-Datenbankstruktur vor, die ursprünglich
für ein klassisches SQL-Server-System gedacht war.  
Die KI wurde genutzt, um:

- die bestehende SQL-Struktur zu analysieren
- Vorschläge zur Anpassung an SQLite zu erhalten
- typische Unterschiede zwischen SQL Server und SQLite zu verstehen
  (z. B. Datentypen, AUTOINCREMENT, Einschränkungen)

Die finale SQLite-Datenbankstruktur wurde anschließend selbst umgesetzt
und an das Projekt angepasst.

### Unterstützung bei Code-Stil & Struktur

Die KI wurde außerdem genutzt, um:
- Rückfragen zu sauberem C#-Code-Stil zu stellen
- bessere Namensgebung für Variablen und Methoden zu finden
- Hinweise zu übersichtlicher Struktur in ViewModels, Views und Datenklassen zu erhalten

Dabei wurden keine kompletten Lösungen blind übernommen,
sondern Vorschläge geprüft, angepasst oder bewusst vereinfacht.

### Unterstützung bei textbasierten Aufgaben (README, Tests, Dokumentation)

Die KI wurde auch bei der Bearbeitung von textbasierten Aufgaben eingesetzt,
z. B. bei:

- README.md
- Testfallbeschreibungen
- Testprotokollen
- dieser KI-Dokumentation

Ich habe jeweils selbst festgelegt:
- welche Inhalte beschrieben werden müssen
- welche Funktionen des Programms relevant sind
- welche Abweichungen vom Prototyp dokumentiert werden sollen

Die KI lieferte daraufhin:
- Strukturvorschläge
- Gliederungen
- sprachliche Formulierungen

Die Inhalte basieren auf meiner eigenen Projektarbeit
und wurden von mir überprüft, angepasst und ergänzt.

### Reflexion (Erweiterung)

Durch diese zusätzliche Nutzung der KI habe ich gelernt,
dass KI besonders hilfreich ist bei:
- Strukturierung von Texten
- Umformulieren technischer Inhalte
- Nachfragen zu bestehenden Lösungen

Gleichzeitig wurde deutlich,
dass KI kein Ersatz für eigene Umsetzung ist,
sondern ein Werkzeug zur Unterstützung.

Ende der KI-Dokumentation

