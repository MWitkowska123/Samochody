using System;
using System.Windows;
using System.Windows.Controls;
using WypozyczalniaSamochodow.Model;
using WypozyczalniaSamochodow.ViewModel;

namespace WypozyczalniaSamochodow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm;
        public MainWindow()
        {
            InitializeComponent();

            // Binding widoku z logiką widoku
            this.DataContext = new MainViewModel();
            vm = this.DataContext as MainViewModel;
        }
        /// <summary>
        /// Wybieranie samochodu
        /// </summary>
        private void samochodyListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.WybranySamochod = (sender as ListView).SelectedItem as Samochod;
            vm.UstawWidocznoscPrzycisku();

        }
        /// <summary>
        /// Eksport do XML
        /// </summary>
        private void exportBtn_Click(object sender, RoutedEventArgs e)
        {
            string name = String.Concat(vm.WybranySamochod.MarkaSamochodu, vm.WybranySamochod.ModelSamochodu, DateTime.Now.ToString("HHmmss"));
            vm.WybranySamochod.ZapiszXML(name);
            MessageBox.Show($"Wyeksportowano na pulpit. {name}");
        }
        /// <summary>
        /// Dodawanie pojazdu
        /// </summary>
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             walidacja, czy wszystkie niezbędnbe informacje zostały podane
             */
            if (!String.IsNullOrEmpty(markaTextBox.Text)
                || !String.IsNullOrEmpty(modelTextBox.Text)
                || !String.IsNullOrEmpty(rokTextBox.Text)
                || !String.IsNullOrEmpty(pojemnoscTextBox.Text)
                || !String.IsNullOrEmpty(doorsTextBox.Text)
                || !String.IsNullOrEmpty(wheelsTextBox.Text)
                || !String.IsNullOrEmpty(typNadwoziaCombo.Text)
                || !String.IsNullOrEmpty(przebiegTextBox.Text)
                || !String.IsNullOrEmpty(typSilnikaCombo.Text))
            {
                try
                {
                    vm.DodajSamochod(new Samochod
                    {
                        IloscDrzwi = Convert.ToUInt16(doorsTextBox.Text),
                        IloscKol = Convert.ToUInt16(wheelsTextBox.Text),
                        MarkaSamochodu = markaTextBox.Text,
                        ModelSamochodu = modelTextBox.Text,
                        Pojemnosc = (float)Convert.ToDecimal(pojemnoscTextBox.Text),
                        Przebieg = Convert.ToUInt32(przebiegTextBox.Text),
                        RokProdukcji = Convert.ToUInt16(rokTextBox.Text),
                        TypNadwozia = (NadwozieType)Enum.Parse(typeof(NadwozieType), typNadwoziaCombo.Text),
                        TypSilnika = (SilnikType)Enum.Parse(typeof(SilnikType), typSilnikaCombo.Text)
                    });

                    markaTextBox.Text = "";
                    modelTextBox.Text = "";
                    rokTextBox.Text = "";
                    pojemnoscTextBox.Text = "";
                    doorsTextBox.Text = "";
                    wheelsTextBox.Text = "";
                    typNadwoziaCombo.Text = "";
                    przebiegTextBox.Text = "";
                    typSilnikaCombo.Text = "";

                    MessageBox.Show("DODANO POJAZD", "KOMUNIKAT!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "BŁĄD!");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Uzypełnij wartości", "BŁĄD!");
            }
        }
        /// <summary>
        /// Usuwanie pojazdu
        /// </summary>
        private void usunBtn_Click(object sender, RoutedEventArgs e)
        {
            vm.UsunSamochod();
            MessageBox.Show("USNIĘTO POJAZD", "KOMUNIKAT!");
        }
    }
}
