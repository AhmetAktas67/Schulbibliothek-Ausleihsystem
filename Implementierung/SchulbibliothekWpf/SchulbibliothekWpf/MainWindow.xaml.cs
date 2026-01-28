using SchulbibliothekWpf.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchulbibliothekWpf;
using SchulbibliothekWpf.Views;
using SchulbibliothekWpf.Data;
using SchulbibliothekWpf.Models;


namespace SchulbibliothekWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            PruefeMahnungen();
        }

        private void Buch_Hinzufügen(object sender, RoutedEventArgs e)
        {
            BuchHinzufügen Fenster = new BuchHinzufügen();
            Fenster.Owner=this;

            bool? result = Fenster.ShowDialog();

            if (result == true) 
            {
                DataContext = new MainWindowViewModel();
            }
        }

       
        
        private void Buch_Löschen(object sender, RoutedEventArgs e)
        {
           var vm =  DataContext as MainWindowViewModel;

            if (vm == null || vm.SelectedBuch ==  null) 
            {
                MessageBox.Show("Bitte zuerst ein Buch auswählen.");
                return;
            }



            var result = MessageBox.Show(
           $"Möchten Sie das Buch \"{vm.SelectedBuch.Titel}\" wirklich löschen?",
           "Buch löschen",
            MessageBoxButton.YesNo,
            MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;



            using (var db = new BibliothekContext())
            {
                var buch = db.Buecher.Find(vm.SelectedBuch.BuchID);

                if (buch != null)
                {
                    db.Buecher.Remove(buch);
                    db.SaveChanges();
                }

                DataContext= new MainWindowViewModel();

            }
        }

        
        
        private void Suchen_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainWindowViewModel;


            if (string.IsNullOrWhiteSpace(SucheTextbox.Text))
            {
                DataContext = new MainWindowViewModel();
            }
           
            string suchtext = SucheTextbox.Text.ToLower();

            
            using (var db = new BibliothekContext())
            {
                var gefiltertebuecher =db.Buecher.Where
                    (b=>
                    b.Titel.ToLower().Contains(suchtext) ||
                    b.ISBN.ToLower().Contains(suchtext))
                    
                    .Select(b => new BuchAnzeige
                    {
                      BuchID = b.BuchID,
                      Titel = b.Titel,
                      ISBN = b.ISBN,
                      Autor = b.Autor,
                      Erscheinungsjahr = b.Erscheinungsjahr
                    })
                    .ToList();


               

                vm.Buecher.Clear();

               
                foreach (var buch in gefiltertebuecher)
                {
                    vm.Buecher.Add(buch);
                }

            }
        }

       
        private void Ausleihen_Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainWindowViewModel;
            if (vm == null || vm.SelectedBuch == null) 
            {
                MessageBox.Show("Bitte zuerst ein Buch auswählen.");
                return;
            }

            if (vm.SelectedBuch.AktuellerStand == "Ausgeliehen")
            {
                MessageBox.Show("Dieses Buch ist bereits ausgeliehen.");
                return;
            }

            using (var db = new BibliothekContext())
            {
                var buch = db.Buecher.Find(vm.SelectedBuch.BuchID);

                if (buch != null)
                {
                    buch.IstAusgeliehen = true;


                    db.Ausleihen.Add(new Ausleihe
                    {
                        BuchID =buch.BuchID,
                        BenutzerID=1,
                        DatumAusleihe=DateTime.Now,
                    });

                    // Mahnung Test
                   /*
                    db.Ausleihen.Add(new Ausleihe
                    {
                        BuchID = buch.BuchID,
                        BenutzerID = 1, 
                        DatumAusleihe = DateTime.Now.AddDays(-20) 
                    });
                   */

                    db.SaveChanges();
                    PruefeMahnungen();
                }
            }

            DataContext = new MainWindowViewModel();

        }

        private void Zurückgeben_Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainWindowViewModel;
            if (vm == null || vm.SelectedBuch == null)
            {
                MessageBox.Show("Bitte zuerst ein Buch auswählen.");
                return;
            }

            if (vm.SelectedBuch.AktuellerStand == "Verfügbar")
            {
                MessageBox.Show("Dieses Buch ist nicht ausgeliehen.");
                return;
            }


            using (var db = new BibliothekContext())
            {
                var buch = db.Buecher.Find(vm.SelectedBuch.BuchID);

                if (buch != null)
                {
                    buch.IstAusgeliehen = false;

                    var ausleihe = db.Ausleihen
                   .Where(a => a.BuchID == buch.BuchID && a.DatumRueckgabe == null)
                   .FirstOrDefault();

                    if (ausleihe != null)
                    {
                        ausleihe.DatumRueckgabe = DateTime.Now;
                    }




                    db.SaveChanges();
                    PruefeMahnungen();
                }
            }

            DataContext = new MainWindowViewModel();

        }

        private void HistorieButton_Click(object sender, RoutedEventArgs e)
        {
           
                HistorieFenster Fenster = new HistorieFenster();
                 Fenster.Owner = this;

            bool? result = Fenster.ShowDialog();

           

        }

        private void MahnungenButton_Click(object sender, RoutedEventArgs e)
        {
            MahnungenFenster fenster = new MahnungenFenster();
            fenster.Owner = this;
            fenster.ShowDialog();
        }

        private void PruefeMahnungen()
        {
            using (var db = new BibliothekContext())
            {
                bool gibtMahnungen = db.Ausleihen.Any(a =>
                    a.DatumRueckgabe == null &&
                    a.DatumAusleihe.AddDays(14) < DateTime.Now);

                MahnungenButton.Visibility = gibtMahnungen
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }


    }
}