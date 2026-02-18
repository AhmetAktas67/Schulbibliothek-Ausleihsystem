Testfall T01 – Anmeldung als Bibliothekar

ID: T01  

Beschreibung:
Überprüfung, ob sich ein Bibliothekar erfolgreich anmelden kann und Zugriff auf Verwaltungsfunktionen erhält.

Vorbedingungen: 
- Das Programm ist gestartet  
- Das Anmeldefenster wird angezeigt  
- Ein Bibliothekar-Account existiert in der Datenbank  

Test-Schritte:  
1. Im Feld „E-Mail“ wird die E-Mail eines Bibliothekars eingegeben.  
2. Im Feld „Passwort“ wird das korrekte Passwort eingegeben.  
3. Der Button „Anmelden“ wird gedrückt.  

Erwartetes Resultat: 
- Die Anmeldung ist erfolgreich.  
- Das Hauptfenster wird geöffnet.  
- Buttons zum Hinzufügen und Löschen von Büchern sind sichtbar.

---

Testfall T02 – Buch ausleihen (Schüler)

ID: T02  

Beschreibung:  
Überprüfung, ob ein Schüler ein verfügbares Buch ausleihen kann.

Vorbedingungen:  
- Der Benutzer ist als Schüler eingeloggt  
- Mindestens ein Buch ist verfügbar  
- Das Hauptfenster ist geöffnet  

Test-Schritte: 
1. Ein verfügbares Buch wird in der Tabelle ausgewählt.  
2. Der Button „Ausleihen“ wird gedrückt.  

Erwartetes Resultat:  
- Das Buch wird als „Ausgeliehen“ markiert.  
- Ein Eintrag in der Ausleihtabelle wird erstellt.  
- Das Buch erscheint in der Historie des Schülers.