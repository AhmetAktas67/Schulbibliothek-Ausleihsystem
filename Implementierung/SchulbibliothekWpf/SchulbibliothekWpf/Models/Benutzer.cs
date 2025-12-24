using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulbibliothekWpf.Models
{
    public class Benutzer
    {
        public int BenutzerID { get; set; }
        public string Vorname { get; set; } = "";
        public string Nachname { get; set; } = "";
        public string Email { get; set; } = "";
        public string Rolle { get; set; } = "";


        public ICollection<Ausleihe> Ausleihen { get; set; } = new List<Ausleihe>();
    }
}
