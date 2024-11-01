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
        public class Glowa //klasa głowa reprezentuje model głowy oraz zawiera metody  i właściwości niezbedne do obliczeń powierzchni głowy i liczby włosów
        {
            private const double SREDNIA_GESTOSC = 150; //ustawienie domyślnej średniej gęstości włosów
            private const double SREDNI_OBWOD = 56; //ustawienie średniego obwodu głowy
            private const double SREDNIA_WYSOKOSC = 7; //ustawienie średniej wysokości czoła

            //zmienne do przechowywania wartośći domyślnych powyżej
            private double gest; 
            private double obwodglowy;
            private double wysok;
            private double powierzchniaglowy;

            public Glowa() //konstruktor Glowa nadający wartości domyślne
            {
                gest = SREDNIA_GESTOSC;
                obwodglowy = SREDNI_OBWOD;
                wysok = SREDNIA_WYSOKOSC;
                UstawPowierzchnieGlowy(); //wywołanie metody obliczającą powierzchnie głowy
            }

            public void UstawGestosc(double gest) //ustawienie gęstości włosów
            {
                this.gest = gest;
            }
            public void UstawObwod(double obwodglowy) //ustawienie obwodu głowy
            {
                this.obwodglowy = obwodglowy;
                UstawPowierzchnieGlowy();
            }

            public void UstawWysokoscCzola(double wysok) //ustawienie wysokości czoła
            {
                this.wysok = wysok;
                UstawPowierzchnieGlowy();
            }

            public void UstawPowierzchnieGlowy() //obliczenie powierzchni głowy
            {
                double promien = obwodglowy / (2 * Math.PI);
                powierzchniaglowy = 4 * Math.PI * Math.Pow(promien, 2);
            }

            public double ObliczLiczbeWlosow() //obliczenie liczby włosów
            {
                return gest * powierzchniaglowy;
            }

            public double ObliczliczbeWlosow(double gestosc, double obwod, double wysokoscCzola) //obliczenie liczby włosów na nowych danych wejściowych
            {
                double promien = obwodglowy / (2 * Math.PI);
                double powierzchniaglowy = 4 * Math.PI * Math.Pow(promien, 2);
                return gest * powierzchniaglowy;
            }
        }
        private Glowa glowa;


        private const double domyslnailoscwlosow = 150000; //ustawienie domyslnej ilosc włosów, która będzie porównywana z ilością włosów użytkownika
        public MainWindow()
        {
            InitializeComponent();
            glowa = new Glowa();
        }

        private void Obliczaniewlosow(object sender, RoutedEventArgs e) // obliczanie liczby włosów przez wprowadzone dane przez użytkownika
        {
            if (double.TryParse(Gestosc.Text, out double gestosc) && // zmiana tekstu na liczby zmiennoprzecinkowe
                            double.TryParse(obwod.Text, out double obw) &&
                            double.TryParse(wysokosc.Text, out double wys))
            {
                glowa.UstawGestosc(gestosc);
                glowa.UstawObwod(obw);
                glowa.UstawWysokoscCzola(wys);

                double liczbawlosow = glowa.ObliczLiczbeWlosow();

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