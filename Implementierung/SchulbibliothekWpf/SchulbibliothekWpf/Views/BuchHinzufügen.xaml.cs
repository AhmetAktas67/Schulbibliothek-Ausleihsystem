using System;
using System.Collections.Generic;
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
using SchulbibliothekWpf.Data;
using SchulbibliothekWpf.Models;

namespace SchulbibliothekWpf.Views
{
    /// <summary>
    /// Interaktionslogik für BuchHinzufügen.xaml
    /// </summary>
    public partial class BuchHinzufügen : Window
    {
        public BuchHinzufügen()
        {
            InitializeComponent();
        }

        private void Bestätigen_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitelBox.Text) || string.IsNullOrWhiteSpace(AutorBox.Text))
            {
                MessageBox.Show("Titel und Autor müssen ausgefüllt sein.");
            }

            if (!int.TryParse(JahrBox.Text, out int jahr))
            {
                MessageBox.Show("Bitte ein gültiges Erscheinungsjahr eingeben.");
                return;
            }

            Buch neuesBuch = new Buch()
            {
                Titel = TitelBox.Text,
                Autor = AutorBox.Text,
                ISBN = IsbnBox.Text,
                Erscheinungsjahr = jahr,
            };

            using (var db = new BibliothekContext())
            {
                db.Buecher.Add(neuesBuch);
                db.SaveChanges();
            }

           this.DialogResult=true; 
            
            this.Close();

            

        }
    }
}
