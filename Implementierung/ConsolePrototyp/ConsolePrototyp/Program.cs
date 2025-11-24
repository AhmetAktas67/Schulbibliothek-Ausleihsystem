using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;




namespace ConsolePrototyp
{
    class Program
    {
        static string booksFile = "books.txt";

        static void Main(string[] args)
        {
            InitializeFiles();

            Console.WriteLine("=======================================");
            Console.WriteLine("   Schulbibliothek – Console-Prototyp");
            Console.WriteLine("=======================================");
            Console.WriteLine("Dieser Prototyp zeigt zwei Funktionen:");
            Console.WriteLine("1. Bücher suchen");
            Console.WriteLine("2. Buch hinzufügen");
            Console.WriteLine();
            Console.WriteLine("Alle Daten werden in einer Textdatei gespeichert.");
            Console.WriteLine("Drücken Sie ENTER zum Starten...");
            Console.ReadLine();
            Console.Clear();

            ShowMenu();
        }

        
        // Datei initialisieren
        
        static void InitializeFiles()
        {
            if (!File.Exists(booksFile))
            {
                File.WriteAllLines(booksFile, new string[]
                {
                "Der Hobbit;Tolkien;123456",
                "Harry Potter;Rowling;987654",
                "Die Welle;Strasser;192837"
                });
            }
        }

        // Hauptmenü
       
        static void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("===== Hauptmenü =====");
                Console.WriteLine("1) Bücher suchen");
                Console.WriteLine("2) Buch hinzufügen");
                Console.WriteLine("3) Beenden");
                Console.Write("Auswahl: ");

                string input = Console.ReadLine();
                Console.Clear();

                switch (input)
                {
                    case "1":
                        SearchBooks();
                        break;

                    case "2":
                        AddBook();
                        break;

                    case "3":
                        Console.WriteLine("Programm wird beendet...");
                        return;

                    default:
                        Console.WriteLine("Ungültige Eingabe! Bitte 1–3 wählen.");
                        break;
                }
            }
        }

       
        // Bücher suchen
     
        static void SearchBooks()
        {
            Console.WriteLine("=== Bücher suchen ===");
            Console.Write("Suchbegriff (Titel/Autor/ISBN): ");

            string search = Console.ReadLine().ToLower();

            var results = new List<string>();

            foreach (string line in File.ReadAllLines(booksFile))
            {
                if (line.ToLower().Contains(search))
                    results.Add(line);
            }

            if (results.Count == 0)
            {
                Console.WriteLine("Keine Treffer gefunden.");
            }
            else
            {
                Console.WriteLine("Gefundene Bücher:");
                foreach (var r in results)
                {
                    var parts = r.Split(';');
                    Console.WriteLine($"- Titel: {parts[0]}, Autor: {parts[1]}, ISBN: {parts[2]}");
                }
            }

            Console.WriteLine("\nENTER drücken zum Fortfahren...");
            Console.ReadLine();
            Console.Clear();
        }

       
        // Buch hinzufügen
      
        static void AddBook()
        {
            Console.WriteLine("=== Neues Buch hinzufügen ===");

            Console.Write("Titel: ");
            string title = Console.ReadLine();

            Console.Write("Autor: ");
            string author = Console.ReadLine();

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(title) ||
                string.IsNullOrWhiteSpace(author) ||
                string.IsNullOrWhiteSpace(isbn))
            {
                Console.WriteLine("Fehler: Alle Felder müssen ausgefüllt sein!");
            }
            else
            {
                File.AppendAllText(booksFile, $"{title};{author};{isbn}\n");
                Console.WriteLine("Buch erfolgreich hinzugefügt!");
            }

            Console.WriteLine("\nENTER drücken zum Fortfahren...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}