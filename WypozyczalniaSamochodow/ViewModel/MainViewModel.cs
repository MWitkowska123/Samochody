using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WypozyczalniaSamochodow.Model;

namespace WypozyczalniaSamochodow.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Prywatne pola
        /// </summary>
        private ISamochodyRepository _SamochodyRepository = new SamochodyRepository();
        private ObservableCollection<Samochod> samochodyCollection;

        
        public ObservableCollection<Samochod> SamochodyCollection
        {
            get { return samochodyCollection; }
            set { samochodyCollection = value; NotifyPropertyChanged(); }
        }

        /// <summary>
        /// Właściwości
        /// </summary>
        public NadwozieType TypNadwozia { get; set; }
        public SilnikType TypSilnika { get; set; }
        public List<Samochod> Samochody { get; set; }
        public Samochod WybranySamochod { get; set; }

        /// <summary>
        /// Określa czy można użyc przycisku do eksportu XML
        /// </summary>
        public bool BtnEnabled { get; set; }

        //Metody

        /// <summary>
        /// Ustawienie widoczności przyciskow na true
        /// </summary>
        public void UstawWidocznoscPrzycisku()
        {
            BtnEnabled = true;
            NotifyPropertyChanged("BtnEnabled");
        }

        /// <summary>
        /// Dodanie samochodu do listy
        /// </summary>
        /// <param name="_samochod">Obiekt samochodu</param>
        public void DodajSamochod(Samochod _samochod)
        {
            _SamochodyRepository.DodajSamochod(_samochod);
            AktualizujListe();
        }

        /// <summary>
        /// Aktualizacja listy
        /// </summary>
        private void AktualizujListe()
        {
            Samochody = _SamochodyRepository.PobierzSamochody().ToList();
            SamochodyCollection = new ObservableCollection<Samochod>(Samochody);
            //SamochodyCollection = new ObservableCollection<Samochod>(_SamochodyRepository.PobierzSamochody());
        }

        /// <summary>
        /// Usuwanie samochodu z listy i aktualizacja listy
        /// </summary>
        public void UsunSamochod()
        {
            _SamochodyRepository.UsunSamochod(WybranySamochod);
            AktualizujListe();
        }


        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainViewModel()
        {
            _SamochodyRepository.InicjalizujKolekcje();
            AktualizujListe();
        }
    }
}
