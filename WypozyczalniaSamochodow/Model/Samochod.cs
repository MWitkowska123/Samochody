using System;
using System.IO;
using System.Xml.Serialization;

namespace WypozyczalniaSamochodow.Model
{
    /// <summary>
    /// Klasa samochodu
    /// </summary>
    public class Samochod : Pojazd
    {
        public string MarkaSamochodu { get; set; }
        public string ModelSamochodu { get; set; }
        public ushort RokProdukcji { get; set; }
        public uint Przebieg { get; set; }
        public NadwozieType TypNadwozia { get; set; }
        public ushort IloscDrzwi { get; set; }
        public float Pojemnosc { get; set; }

        /// <summary>
        /// Metoda do zapisu obiektu do XMLa
        /// </summary>
        /// <param name="_nazwa">ścieżka</param>
        public void ZapiszXML(string _nazwa)
        {
            XmlSerializer sr = new XmlSerializer(typeof(Samochod));
            string sciezka = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sciezka = String.Concat(sciezka, "\\", _nazwa);
            using (StreamWriter sw = new StreamWriter($"{sciezka}.xml"))
            {
                sr.Serialize(sw, this);
            }
        }

        /// <summary>
        /// Odczyt z XML'a 
        /// </summary>
        /// <param name="nazwa">ściezka</param>
        /// <returns></returns>
        public static Samochod OdczytajXML(string nazwa)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Samochod));
            Samochod odczytany;
            using (StreamReader reader = new StreamReader($"{nazwa}.xml"))
            {
                odczytany = (Samochod)serializer.Deserialize(reader);
            }
            return odczytany;
        }
    }
}
