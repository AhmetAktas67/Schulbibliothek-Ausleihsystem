using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulbibliothekWpf.Models
{
    public class BuchAnzeige
    {
        public int BuchID { get; set; }
        public string Titel { get; set; } = "";
        public string Autor { get; set; } = "";
        public string ISBN { get; set; } = "";
        public int Erscheinungsjahr { get; set; }

        public string AktuellerStand { get; set; } = "";
        public string Nutzername { get; set; } = "";
    }
}
