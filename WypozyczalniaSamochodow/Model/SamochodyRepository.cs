using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WypozyczalniaSamochodow.Model
{
    public class SamochodyRepository : ISamochodyRepository
    {
        /// <summary>
        /// lista samochodów
        /// </summary>
        public List<Samochod> Samochody { get; private set; }

        /// <summary>
        /// Funkcja dodająca samochód do listy samochodów
        /// </summary>
        public void DodajSamochod(Samochod _samochod)
        {
            /*
             Walidacja danych
             */
            if (Samochody == null)
            {
                throw new NiezaimplementowanaKolekcjaException("Kolekcja samochodów nie została zaimplementowana");
            }

            if (_samochod == null)
            {
                throw new BrakSamochoduException("Samochod do usuniecia nie moze być nullem!");
            }

            Samochody.Add(_samochod);
        }

        /// <summary>
        /// Funkcja inicjalizująca kolekcję samochodów
        /// </summary>
        public void InicjalizujKolekcje()
        {
            // Inicjalizacja Listy
            Samochody = new List<Samochod>();

            /// <summary>
            /// dodawanie samochodów startowych
            /// </summary>
            Samochody.Add(new Samochod
            {
                IloscDrzwi = 5,
                IloscKol = 4,
                MarkaSamochodu = "OPEL",
                ModelSamochodu = "VECTRA",
                Pojemnosc = 1.997f,
                Przebieg = 234414,
                RokProdukcji = 2003,
                TypNadwozia = NadwozieType.Sedan,
                TypSilnika = SilnikType.Benzynowy
            });

            Samochody.Add(new Samochod
            {
                IloscDrzwi = 3,
                IloscKol = 4,
                MarkaSamochodu = "FORD",
                ModelSamochodu = "MUSTANG",
                Pojemnosc = 4.997f,
                Przebieg = 34414,
                RokProdukcji = 2020,
                TypNadwozia = NadwozieType.Coupe,
                TypSilnika = SilnikType.Benzynowy
            });

            Samochody.Add(new Samochod
            {
                IloscDrzwi = 5,
                IloscKol = 4,
                MarkaSamochodu = "DACIA",
                ModelSamochodu = "DUSTER",
                Pojemnosc = 1.997f,
                Przebieg = 100,
                RokProdukcji = 2022,
                TypNadwozia = NadwozieType.SUV,
                TypSilnika = SilnikType.Benzynowy
            });

            Samochody.Add(new Samochod
            {
                IloscDrzwi = 3,
                IloscKol = 4,
                MarkaSamochodu = "BMW",
                ModelSamochodu = "i8",
                Pojemnosc = 1.497f,
                Przebieg = 13200,
                RokProdukcji = 2020,
                TypNadwozia = NadwozieType.Coupe,
                TypSilnika = SilnikType.Hybryda
            });
        }

        /// <summary>
        /// Funkcja wyszukująca i zwracająca pożądany samochód
        /// </summary>
        public Samochod PobierzSamochod(uint _id)
        {
            if (Samochody == null)
            {
                throw new NiezaimplementowanaKolekcjaException("Kolekcja samochodów nie została zaimplementowana");
            }
            return Samochody.FirstOrDefault(f => f.ID == _id);
        }

        /// <summary>
        /// Funkcja zwracająca całą listę samochodów
        /// </summary>
        public IEnumerable<Samochod> PobierzSamochody()
        {
            if (Samochody == null)
            {
                throw new NiezaimplementowanaKolekcjaException("Kolekcja samochodów nie została zaimplementowana");
            }

            return Samochody;
        }
        /// <summary>
        /// Funkcja usuwająca samochód z listy
        /// </summary>
        public bool UsunSamochod(Samochod _samochod)
        {
            /*
             Walidacja danych
             */
            if (Samochody == null)
            {
                throw new NiezaimplementowanaKolekcjaException("Kolekcja samochodów nie została zaimplementowana");
            }

            if (_samochod == null)
            {
                throw new BrakSamochoduException("Samochod do usuniecia nie moze być nullem!");
            }

            try
            {
                Samochody.Remove(_samochod);// usuwanie samochodu
                return true;// zakończenie pracy pomyślnie
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Aktualizacja danych w samochodzie
        /// </summary>
        public bool ZaktualizujSamochod(Samochod _samochod)
        {

           
            if (Samochody == null)
            {
                throw new NiezaimplementowanaKolekcjaException("Kolekcja samochodów nie została zaimplementowana");
            }
            if (_samochod == null)
            {
                throw new BrakSamochoduException("Samochod do aktualizacji nie moze być nullem!");
            }

            try
            {
                var tmp = Samochody.FirstOrDefault(x => x.ID == _samochod.ID);//pobranie obiektu do usunięcia
                Samochody.Remove(tmp);//usnięcie
                Samochody.Add(_samochod);// wstawienei nowego (zaktualizowanego obiektu)                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
      
    }   
}
