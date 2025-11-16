-- Datenbank anlegen (falls nicht vorhanden)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'Schulbibliothek')
BEGIN
    CREATE DATABASE Schulbibliothek;
END
GO

USE Schulbibliothek;
GO

-- Tabellen löschen (richtige Reihenfolge wegen FK)
IF OBJECT_ID('Ausleihe', 'U') IS NOT NULL DROP TABLE Ausleihe;
IF OBJECT_ID('Buch', 'U') IS NOT NULL DROP TABLE Buch;
IF OBJECT_ID('Benutzer', 'U') IS NOT NULL DROP TABLE Benutzer;
GO

-- Tabelle: Benutzer
CREATE TABLE Benutzer (
    BenutzerID INT IDENTITY(1,1) PRIMARY KEY,
    Vorname VARCHAR(50) NOT NULL,
    Nachname VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Rolle VARCHAR(20) NOT NULL
);
GO

-- Tabelle: Buch
CREATE TABLE Buch (
    BuchID INT IDENTITY(1,1) PRIMARY KEY,
    Titel VARCHAR(100) NOT NULL,
    Autor VARCHAR(100) NOT NULL,
    ISBN VARCHAR(20),
    Erscheinungsjahr INT
);
GO

-- Tabelle: Ausleihe (1:n von Benutzer und 1:n von Buch)
CREATE TABLE Ausleihe (
    AusleiheID INT IDENTITY(1,1) PRIMARY KEY,
    BenutzerID INT NOT NULL,
    BuchID INT NOT NULL,
    DatumAusleihe DATE NOT NULL,
    DatumRueckgabe DATE NULL,
    FOREIGN KEY (BenutzerID) REFERENCES Benutzer(BenutzerID),
    FOREIGN KEY (BuchID) REFERENCES Buch(BuchID)
);
GO

-- Beispiel-Daten: Benutzer (mind. 5)
INSERT INTO Benutzer (Vorname, Nachname, Email, Rolle) VALUES
('Max', 'Mustermann', 'max@schule.de', 'Schüler'),
('Anna', 'Müller', 'anna@schule.de', 'Schüler'),
('Lena', 'Schmidt', 'lena@schule.de', 'Lehrer'),
('Tim', 'Wagner', 'tim@schule.de', 'Lehrer'),
('Sarah', 'Becker', 'becker@schule.de', 'Bibliothekar');
GO

-- Beispiel-Daten: Buch (mind. 5)
INSERT INTO Buch (Titel, Autor, ISBN, Erscheinungsjahr) VALUES
('Die Welle', 'Morton Rhue', '9783453210427', 1981),
('Tschick', 'Wolfgang Herrndorf', '9783462046271', 2010),
('Harry Potter und der Stein der Weisen', 'J.K. Rowling', '9783551551672', 1997),
('Der Vorleser', 'Bernhard Schlink', '9783257229530', 1995),
('Der Hobbit', 'J.R.R. Tolkien', '9783608939811', 1937);
GO

-- Beispiel-Daten: Ausleihe (mind. 5)
INSERT INTO Ausleihe (BenutzerID, BuchID, DatumAusleihe, DatumRueckgabe) VALUES
(1, 1, '2024-11-20', NULL),
(2, 2, '2024-11-18', '2024-11-26'),
(3, 3, '2024-11-15', NULL),
(4, 4, '2024-11-10', '2024-11-17'),
(1, 5, '2024-11-22', NULL);
GO

-- JOIN-Beispielabfrage
SELECT 
    A.AusleiheID,
    B.Vorname + ' ' + B.Nachname AS Benutzer,
    K.Titel AS Buch,
    A.DatumAusleihe,
    A.DatumRueckgabe
FROM Ausleihe A
JOIN Benutzer B ON A.BenutzerID = B.BenutzerID
JOIN Buch K ON A.BuchID = K.BuchID;
GO
