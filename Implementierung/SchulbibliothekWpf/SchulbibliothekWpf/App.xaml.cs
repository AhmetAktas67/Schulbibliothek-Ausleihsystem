using SchulbibliothekWpf.Data;
using System.Configuration;
using System.Data;
using System.Windows;
using SchulbibliothekWpf.Views;

namespace SchulbibliothekWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DbInitalizer.Initalize();
            
            var login = new LoginFenster();


            bool?result= login.ShowDialog();


            if (result == true)
            {
                MainWindow mw = new MainWindow();
               mw.Show();
            }
            else
            {
                Shutdown();
            }



               
        }
    }

}
