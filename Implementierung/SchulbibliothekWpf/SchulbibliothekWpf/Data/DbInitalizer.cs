using SchulbibliothekWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulbibliothekWpf.Data
{
    public static  class DbInitalizer
    {
        public static void Initalize() 
        {
          
            using var db = new BibliothekContext();
            db.Database.EnsureCreated();

            if (!db.Benutzer.Any())
            {
                db.Benutzer.AddRange(
                    new Benutzer { Vorname = "Max", Nachname = "Mustermann", Email = "max@schule.de", Rolle = "Schüler" },
                    new Benutzer { Vorname = "Anna", Nachname = "Müller", Email = "anna@schule.de", Rolle = "Schüler" },
                    new Benutzer { Vorname = "Lena", Nachname = "Schmidt", Email = "lena@schule.de", Rolle = "Lehrer" },
                    new Benutzer { Vorname = "Tim", Nachname = "Wagner", Email = "tim@schule.de", Rolle = "Lehrer" },
                    new Benutzer { Vorname = "Sarah", Nachname = "Becker", Email = "becker@schule.de", Rolle = "Bibliothekar" }
                );
            }

            if (!db.Buecher.Any())
            {
                db.Buecher.AddRange(
                    new Buch { Titel = "Die Welle", Autor = "Morton Rhue", ISBN = "9783453210427", Erscheinungsjahr = 1981 },
                    new Buch { Titel = "Tschick", Autor = "Wolfgang Herrndorf", ISBN = "9783462046271", Erscheinungsjahr = 2010 },
                    new Buch { Titel = "Harry Potter und der Stein der Weisen", Autor = "J.K. Rowling", ISBN = "9783551551672", Erscheinungsjahr = 1997 },
                    new Buch { Titel = "Der Vorleser", Autor = "Bernhard Schlink", ISBN = "9783257229530", Erscheinungsjahr = 1995 },
                    new Buch { Titel = "Der Hobbit", Autor = "J.R.R. Tolkien", ISBN = "9783608939811", Erscheinungsjahr = 1937 }
                );
            }

            db.SaveChanges();
        }
    }

}
    
