using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SchulbibliothekWpf.Data;
using SchulbibliothekWpf.Models;

namespace SchulbibliothekWpf.ViewModels
{
    public class MainWindowViewModel
    { 
       public ObservableCollection<BuchAnzeige> Buecher {  get; } = new ObservableCollection<BuchAnzeige>();

        public BuchAnzeige? SelectedBuch { get; set; }
        public MainWindowViewModel() 
        {
            using var db = new BibliothekContext();

           

            foreach (var b in db.Buecher)
            {

                var ausleihe = db.Ausleihen
                  .Where(a => a.BuchID == b.BuchID && a.DatumRueckgabe == null)
                  .Select(a => a.Benutzer.Vorname + " " + a.Benutzer.Nachname)
                  .FirstOrDefault();


                Buecher.Add(new BuchAnzeige
                {

                    BuchID = b.BuchID,
                    Titel = b.Titel,
                    Autor = b.Autor,
                    ISBN = b.ISBN,
                    Erscheinungsjahr = b.Erscheinungsjahr,

                    AktuellerStand = b.IstAusgeliehen ? "Ausgeliehen" : "Verfügbar",
                    Nutzername = ausleihe ?? "-"
                });
            }
        }
    }
}
