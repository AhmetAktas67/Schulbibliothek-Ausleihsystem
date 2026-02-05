using Microsoft.EntityFrameworkCore;
using SchulbibliothekWpf.Data;
using SchulbibliothekWpf.Models;
using SchulbibliothekWpf.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;


namespace SchulbibliothekWpf.Views
{
    
    public partial class HistorieFenster : Window
    {
        public ObservableCollection<Ausleihe> Ausleihen { get; } = new();

        public HistorieFenster()
        {
            InitializeComponent();

            DataContext = this;   // wichtig für Binding
            LadeAusleihen();
        }

        private void LadeAusleihen()
        {
            Ausleihen.Clear();

            using (var db = new BibliothekContext())
            {
                var liste = db.Ausleihen
                              .Include(a => a.Buch)
                              .Include(a => a.Benutzer)
                              .ToList();

               

                foreach (var a in liste)
                {
                    Ausleihen.Add(a);
                }
            }
        }

        private void Button_Suche_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SucheTextbox.Text))
            {
                LadeAusleihen();
                return;
            }

            string suchtext = SucheTextbox.Text.ToLower();

            using (var db = new BibliothekContext())
            {
                var gefilterteAusleihen = db.Ausleihen
                    .Include(a => a.Buch)
                    .Include(a => a.Benutzer)
                    .Where(a =>
                        a.Buch.Titel.ToLower().Contains(suchtext) ||
                        a.Benutzer.Vorname.ToLower().Contains(suchtext)
                    )
                    .ToList();

                Ausleihen.Clear();

                foreach (var ausleihe in gefilterteAusleihen)
                {
                    Ausleihen.Add(ausleihe);
                }
            }
        }
    }
 } 
    

