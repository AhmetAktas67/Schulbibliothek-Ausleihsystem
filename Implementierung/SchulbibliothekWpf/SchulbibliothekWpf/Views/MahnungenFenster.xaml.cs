using SchulbibliothekWpf.Data;
using SchulbibliothekWpf.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;


namespace SchulbibliothekWpf.Views
{
    /// <summary>
    /// Interaktionslogik für MahnungenFenster.xaml
    /// </summary>
    public partial class MahnungenFenster : Window
    {
        public ObservableCollection<Ausleihe> Mahnungen { get; } = new();

        public MahnungenFenster()
        {
            InitializeComponent();
            DataContext = this;      
            LadeMahnungen();        
        }

        private void LadeMahnungen()
        {
            using (var db = new BibliothekContext())
            {
                var heute = DateTime.Now;

                var liste = db.Ausleihen
                    .Include(a => a.Buch)
                    .Include(a => a.Benutzer)
                    .Where(a =>
                        a.DatumRueckgabe == null &&
                        a.DatumAusleihe.AddDays(14) < heute)
                    .ToList();

                foreach (var a in liste)
                {
                    Mahnungen.Add(a);
                }
            }
        }
    }

}
