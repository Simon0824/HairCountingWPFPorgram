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
    public partial class MainWindow : Window
    {
        private const double domyslnailoscwlosow = 150000; //ustawienie domyslnej ilosc włosów, która będzie porównywana z ilością włosów użytkownika
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Obliczaniewlosow(object sender, RoutedEventArgs e) // obliczanie liczby włosów przez wprowadzone dane przez użytkownika
        {
            if (double.TryParse(Gestosc.Text, out double gestosc) && // zmiana tekstu na liczby zmiennoprzecinkowe
                            double.TryParse(obwod.Text, out double obw) &&
                            double.TryParse(wysokosc.Text, out double wys))
            {
                double promien = obw / (2 * Math.PI); // oblicza promień
                double powierzchnia = 4 * Math.PI * Math.Pow(promien, 2); //oblicza powierzchnie głowy


                double liczbawlosow = gestosc * powierzchnia; // oblicza liczbę włosow przez podaną liczbe włosów na cm2 oraz obliczoną wcześniej powierzchnie

                double roznicaprocent = ((liczbawlosow - domyslnailoscwlosow) / domyslnailoscwlosow) * 100; //oblicza rożnice między obliczoną ilością włosów a średnią w procentach

                Wynik.Text = $"Twoja przybliżona Liczba włosów:\n{liczbawlosow:F0} ({roznicaprocent:F2}% w stosunku do średniej)"; //wyświetlenie wyniku oraz róznicy
            }
            else
            {
                MessageBox.Show("Proszę wpropwadzić prawidłowe dane.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error); //wyskakuje błąd jeśli użytkownik nie wprowadził danych
            }
        }


        private void Reset(object sender, RoutedEventArgs e) //działanie przycisku resetującego obliczenia
        {
            Gestosc.Text = string.Empty;
            obwod.Text = string.Empty;
            wysokosc.Text = string.Empty;
            Wynik.Text = "Twoja przybliżona liczba włosów:";
        }
    }
}