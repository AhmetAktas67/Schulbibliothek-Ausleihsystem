# Datenbank-Design – Schulbibliothek Ausleihsystem

## 1. Überblick
Das Datenbankmodell basiert auf drei zentralen Entitäten:
- **Benutzer**
- **Buch**
- **Ausleihe**

Das Ziel ist es, Ausleihvorgänge einer Schulbibliothek übersichtlich, nachvollziehbar und relational korrekt abzubilden. Grundlage des Designs ist das zuvor erstellte ER-Diagramm in Chen-Notation.

---

## 2. Tabellen und deren Begründung

### **Benutzer**
Enthält alle Personen, die das System nutzen: Schüler, Lehrer und Bibliothekare.  
Ich habe folgende Attribute gewählt:
- **BenutzerID** (PK) – eindeutige Identifikation
- **Vorname, Nachname** – klare Zuordnung von Personen
- **Email** – Kontakt und Identifikation
- **Rolle** – wichtig, weil Bibliothekare mehr Rechte besitzen

### **Buch**
Verwaltet den Medienbestand der Bibliothek.  
Attribute:
- **BuchID** (PK)
- **Titel** – nötig für die Buchsuche
- **Autor** – wichtig für Filter und Suchfunktion
- **ISBN** – eindeutige Buchnummer
- **Erscheinungsjahr** – zusätzliche Information

### **Ausleihe**
Repräsentiert **jeden Ausleihvorgang**.  
Attribute:
- **AusleiheID** (PK)
- **BenutzerID** (FK) – verweist auf den Entleiher
- **BuchID** (FK) – verweist auf das ausgeliehene Buch
- **DatumAusleihe**
- **DatumRueckgabe**

---

## 3. Beziehungen und deren Typ

### **Benutzer – Ausleihe (1:n)**
Ein Benutzer kann:
- 0, 1 oder mehrere Bücher ausleihen  
Jede Ausleihe gehört jedoch **genau einem Benutzer**.

➡ **Daher: 1:n**

### **Buch – Ausleihe (1:n)**
Ein Buch kann:
- mehrfach ausgeliehen werden  
- aber nur einmal pro Ausleihvorgang erscheinen

➡ **Daher: 1:n**

Das System benötigt **keine n:m Beziehung**, weil ein Ausleihvorgang immer **nur ein Buch und einen Benutzer** hat.

---

## 4. Datentypen und deren Begründung

### **INT + IDENTITY**
Für Primärschlüssel:
- schnell
- eindeutig
- automatisch inkrementierend

### **VARCHAR**
Für Textdaten wie Titel, Namen und E-Mails:
- flexibel
- effizient
- notwendige Länge ohne Speicher zu verschwenden

### **DATE**
Für Ausleih- und Rückgabedatum:
- keine Uhrzeit nötig
- übersichtlich und korrekt für Ausleihsysteme

---

## 5. KI-Unterstützung
Zur Unterstützung wurde ChatGPT verwendet für:
- Vorschläge für Tabellenstruktur
- Validieren der Beziehungstypen
- Optimierung des SQL-Codes

Die finalen Entscheidungen wurden jedoch inhaltlich selbst getroffen.

---

## 6. Fazit
Das Datenbankmodell ist:
- übersichtlich  
- logisch aufgebaut  
- auf reale Bibliotheksprozesse übertragbar  
- einfach erweiterbar (z. B. Mahnungen, Reservierungen)

Damit erfüllt es alle Anforderungen der Projektaufgabe.
