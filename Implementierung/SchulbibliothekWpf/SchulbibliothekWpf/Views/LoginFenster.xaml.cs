using SchulbibliothekWpf.Data;
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
using SchulbibliothekWpf.Models;

namespace SchulbibliothekWpf.Views
{
    /// <summary>
    /// Interaktionslogik für LoginFenster.xaml
    /// </summary>
    public partial class LoginFenster : Window
    {

        public static Benutzer? AktuellerBenutzer { get; private set; }

        public LoginFenster()
        {
            InitializeComponent();


        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new BibliothekContext())
            {
                string hash = PasswordHelfer.Hash(PasswortBox.Password);

                var benutzer = db.Benutzer.FirstOrDefault(b =>
                    b.Email == EmailBox.Text &&
                    b.PasswortHash == hash);

                if (benutzer == null)
                {
                    MessageBox.Show("E-Mail oder Passwort falsch.");
                    return;
                }

                AktuellerBenutzer = benutzer;

                DialogResult = true;
                Close();
            }
        }
    }
}