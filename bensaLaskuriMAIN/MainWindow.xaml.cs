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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bensaLaskuriMAIN
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
        

        private void laskeNappi_Click(object sender, RoutedEventArgs e)
        {
            
            List<double> bensanHinnat = new List<double>(); //Lista, johon kaikki laskut menee ja tallentuu ohjelman päällä ollessa
            
            //Asetetaan ohjelman alussa arvot nolliksi, jotka myöhemmin muutetaan syötettyjen arvojen perusteella
            int matka = 0;
            decimal satanen = 100;
            decimal kulutus = 0;
            decimal hinta = 0;
            decimal bensanHinta;
            try //Tarkistetaan että annetut arvot ovat numeroita
            {
                matka = Convert.ToInt32(matkaBoksi.Text);
                kulutus = Convert.ToDecimal(kulutusBoksi.Text);
                hinta = Convert.ToDecimal(hintaBoksi.Text);
            }
            catch //Jos ei ole oikea arvo, popup viesti ja puhdistetaan kentät
            {
                MessageBox.Show("Voi ei! Syötit väärän arvon, yritä uudelleen!", "VIRHE", MessageBoxButton.OK, MessageBoxImage.Error);
                matkaBoksi.Clear();
                kulutusBoksi.Clear();
                hintaBoksi.Clear();
                
            }

            bensanHinta = Math.Round(matka / satanen * kulutus * hinta, 3); //Laskukaava polttoaineen hinnalle
            if (bensanHinta == 0)
            {

                MessageBox.Show("VOI EI");
                matkaBoksi.Text = "";
                kulutusBoksi.Text = "";
                hintaBoksi.Text = "";
            }
            else
            {

                //bensanHintaBoksi.Text = Convert.ToString(bensanHinta);
                bensanHintaBoksi.Text = $"{matka}KM ({kulutus}L/100KM) \n{hinta}€/L \n{bensanHinta}€";

                bensanHinnat.Add(Convert.ToDouble(bensanHinta));
                historiaMenu.SelectedItem = bensanHinta;
                historiaMenu.SelectedIndex = 0;
                historiaMenu.Visibility = Visibility.Visible;

                matkaBoksi.Text = "";
                kulutusBoksi.Text = "";
                hintaBoksi.Text = "";

                foreach (double s in bensanHinnat)
                {
                    historiaMenu.Items.Add(s);
                }

            }



        }

        private void clearNappi_Click(object sender, RoutedEventArgs e)
        {
            matkaBoksi.Text = "";
            kulutusBoksi.Text = "";
            hintaBoksi.Text = "";
            bensanHintaBoksi.Text = "";
        }
    }
}
