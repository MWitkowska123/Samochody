using System.Collections.Generic;

namespace WypozyczalniaSamochodow.Model
{
    /// <summary>
    /// Interfejst definiujący metody do obsługi Modeli Samochodów
    /// </summary>
    public interface ISamochodyRepository
    {
        /// <summary>
        /// Metoda inicjijąca
        /// Wywoływana jako pierwsza w kolejności
        /// </summary>
        void InicjalizujKolekcje();

        /// <summary>
        /// Metoda odpowiedzialna za pobranie wszystkich samochodów
        /// </summary>
        /// <returns>Lista samochodów, konieczna poźniej do rzutowania na konkretną kolekcję</returns>
        IEnumerable<Samochod> PobierzSamochody();

        /// <summary>
        /// Pobiera konkretny rekord samochodu
        /// </summary>
        /// <param name="_id">Identyfikator</param>
        Samochod PobierzSamochod(uint _id);

        /// <summary>
        /// Aktualizuje rekord o samochodzie 
        /// </summary>
        /// <param name="_samochod">Obiekt samochodu. Musi zawierać w sobie Id pojazdu</param>
        /// <returns>true - zaktualizowane pomyslenie, false- błąd </returns>
        bool ZaktualizujSamochod(Samochod _samochod);

        /// <summary>
        /// Usuwa wybrany rekord z kolekcji
        /// </summary>
        /// <param name="_samochod">elekment do usuniecia</param>
        /// <returns>true - usunięte pomyslenie, false- błąd + Exception</returns>
        bool UsunSamochod(Samochod _samochod);

        /// <summary>
        /// Dodaje samochod do listy
        /// </summary>
        void DodajSamochod(Samochod _samochod);
    }
}
