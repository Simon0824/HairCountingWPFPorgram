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

namespace Iloscwlosow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const double domyslnailoscwlosow = 150000;
        public MainWindow()
        {
            InitializeComponent();
        }
        
private void Obliczaniewlosow(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Gestosc.Text, out double gestosc) &&
                            double.TryParse(obwod.Text, out double obw) &&
                            double.TryParse(wysokosc.Text, out double wys))
            {
                double radius = obw / (2 * Math.PI);
                double powierzchnia = 4 * Math.PI * Math.Pow(radius, 2);


                double liczbawlosow = gestosc * powierzchnia;

                double roznicaprocent = ((liczbawlosow - domyslnailoscwlosow) / domyslnailoscwlosow) * 100;

                Wynik.Text = $"Twoja przybliżona Liczba włosów:\n{liczbawlosow:F0} ({roznicaprocent:F2}% w stosunku do średniej)";
            }
            else
            {
                MessageBox.Show("Proszę wpropwadzić prawidłowe dane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
       

        private void Reset(object sender, RoutedEventArgs e)
        {
            Gestosc.Text = string.Empty;
            obwod.Text = string.Empty;
            wysokosc.Text = string.Empty;
            Wynik.Text = "Twoja przybliżona liczba włosów:";
        }
    }
}