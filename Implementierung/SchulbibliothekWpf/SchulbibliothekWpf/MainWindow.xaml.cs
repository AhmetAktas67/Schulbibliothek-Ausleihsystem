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
    }
}