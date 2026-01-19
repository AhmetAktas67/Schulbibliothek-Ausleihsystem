using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulbibliothekWpf.Models
{
    public class Buch
    {
        public int BuchID { get; set; }
        public string Titel { get; set; } = "";
        public string Autor { get; set; } = "";
        public string ISBN { get; set; } = "";
        public int Erscheinungsjahr { get; set; }

        public bool IstAusgeliehen { get; set; }


        public ICollection<Ausleihe> Ausleihen { get; set; } = new List<Ausleihe>();
    }
}
