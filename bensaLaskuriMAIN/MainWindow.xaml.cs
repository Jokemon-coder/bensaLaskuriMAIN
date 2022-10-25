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
            
            List<double> bensanHinnat = new List<double>();
            
            int matka = 0;
            double kulutus = 0;
            double hinta = 0;
            try
            {
                matka = Convert.ToInt32(matkaBoksi.Text);
                kulutus = Convert.ToDouble(kulutusBoksi.Text);
                hinta = Convert.ToDouble(hintaBoksi.Text);
            }
            catch
            {
                MessageBox.Show("Voi ei! Syötit väärän arvon, yritä uudelleen!", "VIRHE", MessageBoxButton.OK, MessageBoxImage.Error);
                matkaBoksi.Clear();
                kulutusBoksi.Clear();
                hintaBoksi.Clear();
                
            }

            double bensanHinta = Math.Round(matka / 100 *kulutus * hinta, 2);
            if (bensanHinta == 0)
            {
                bensanHintaBoksi.Text = "";
                historiaMenu.Visibility = Visibility.Hidden;
            }
            else
            

            bensanHintaBoksi.Text = Convert.ToString(bensanHinta);

           
            
            bensanHinnat.Add(Convert.ToDouble(bensanHinta));
            historiaMenu.SelectedItem = bensanHinta;
            historiaMenu.SelectedIndex = 0;

            foreach (double s in bensanHinnat)
            {
                historiaMenu.Items.Add(s);
            }
            
            
           
           


            if (bensanHinta != 0)
            {
                historiaMenu.Visibility = Visibility.Visible;
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
