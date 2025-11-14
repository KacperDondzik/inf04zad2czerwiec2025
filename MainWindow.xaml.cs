using Microsoft.Win32;
using System.Security.Claims;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace inf04zad2czerwiec2025
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSzyfruj_Click(object sender, RoutedEventArgs e)
        {
            int klucz;

            if (!int.TryParse(txtKlucz.Text, out klucz))
                klucz = 0;

            txtWynik.Text = Szyfruj(txtTekst.Text, klucz);
        }


        private void btnZapis_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog okno = new SaveFileDialog();
            okno.Filter = "Pliki tekstowe (*.txt)|*.txt";

            if (okno.ShowDialog() == true)
            {
                File.WriteAllText(okno.FileName, txtWynik.Text);
            }
        }



        public string Szyfruj(string tekst, int klucz)
        {
            string wynik = "";
            klucz = klucz % 26;

            foreach (char c in tekst)
            {
                if (c == ' ')
                {
                    wynik += ' ';
                }
                else
                {
                    int kod = c - 'a';
                    int nowyKod = (kod + klucz + 26) % 26;
                    char nowaLitera = (char)('a' + nowyKod);
                    wynik += nowaLitera;
                }
            }

            return wynik;
        }
    }
}



