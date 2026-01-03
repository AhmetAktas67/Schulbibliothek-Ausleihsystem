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

        public MainWindowViewModel() 
        {
            using var db = new BibliothekContext();

            foreach (var b in db.Buecher)
            {
                Buecher.Add(new BuchAnzeige
                {
                    Titel = b.Titel,
                    Autor = b.Autor,
                    ISBN = b.ISBN,
                    Erscheinungsjahr = b.Erscheinungsjahr,

                     AktuellerStand = "Verfügbar",
                    Nutzername = "-"
                });
            }
        }
    }
}
