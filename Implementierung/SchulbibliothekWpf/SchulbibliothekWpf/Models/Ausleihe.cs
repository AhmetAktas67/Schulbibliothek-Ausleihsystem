using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchulbibliothekWpf.Models
{
    public class Ausleihe
    {
        public int AusleiheID { get; set; }
        public int BenutzerID { get; set; }
        public int BuchID { get; set; }
        public DateTime DatumAusleihe { get; set; }
        public DateTime? DatumRueckgabe { get; set; }

        public Benutzer? Benutzer { get; set; }
        public Buch? Buch { get; set; }

        public int TageImVerzug
        {
            get
            {
                if (DatumRueckgabe != null)
                    return 0;

                int leihfrist = 14;
                int tage = (DateTime.Now - DatumAusleihe.AddDays(leihfrist)).Days;

                return tage > 0 ? tage : 0;
            }
        }
    }
}
