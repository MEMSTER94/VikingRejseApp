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

namespace VikingRejseApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RejseFunc Func = new RejseFunc();
        WeatherClass Weather = new WeatherClass();
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = this;
            DataContext = Func;
        }

        private void btnOpret_Click(object sender, RoutedEventArgs e)
        {
                try
                {
                    Func.NyKunde(navn.Text, adresse.Text, int.Parse(telefon.Text));


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Fejl i oprettelsen");
                }
        }

        private void btnOpretRej_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Func.NyRejse(titelBox.Text, byBox.Text, DateTime.Parse(startBox.Text), DateTime.Parse(slutBox.Text), decimal.Parse(prisBox.Text), int.Parse(antalBox.Text), beskrivelseBox.Text);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i oprettelsen");
            }
        }

        private void tilknyt_Click(object sender, RoutedEventArgs e)
        {
            Kunder kunde = dg_kunder.SelectedItem as Kunder;
            Rejsearrangement rejse = dg_rejser.SelectedItem as Rejsearrangement;
            
            Func.NyTilmelding(rejse, kunde);
        }

        private void sletKun_Click(object sender, RoutedEventArgs e)
        {
            Func.SletKunde(dg_kunder.SelectedItem as Kunder);
        }

        private void sletR_Click(object sender, RoutedEventArgs e)
        {
            Func.SletRejse(rejser.SelectedItem as Rejsearrangement);
        }

        private void sletTil_Click(object sender, RoutedEventArgs e)
        {
            Func.SletTilmeld(Tilmeldte.SelectedItem as Tilmelding);
        }

        private void tOpretbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Func.NyTransportører(tNavn.Text, tAdresse.Text, int.Parse(tTelefon.Text), tBeskrivelseBox.Text);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fejl i oprettelsen");
            }
        }

        private void tSletbtn_Click(object sender, RoutedEventArgs e)
        {
            Func.SletTransportør(dg_transportører.SelectedItem as Transportører);
        }

        private void tTilbtn_Click(object sender, RoutedEventArgs e)
        {
            Transportører transportør = dg_transportører.SelectedItem as Transportører;
            Rejsearrangement rejse = dg_tRejser.SelectedItem as Rejsearrangement;
            Func.TilknytTransportør(rejse, transportør);
        }

        private void comboBy_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string city = comboBy.Text;
            Weather ChoosedCity = Weather.CityWeather(city);

            gnsntBox.Text = ChoosedCity.Gennemsnit;
            minBox.Text = ChoosedCity.Mininum;
            maxBox.Text = ChoosedCity.Maxinum;
            hastigBox.Text = ChoosedCity.Hastighed;
            unitBox.Text = ChoosedCity.Unit;
            retningBox.Text = ChoosedCity.Retning;
            whereBox.Text = ChoosedCity.Where;
            progBox.ItemsSource = Weather.WeatherForecasts;
            progBox.Items.Refresh();
        }

    }
}
