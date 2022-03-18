using System;

namespace WypozyczalniaSamochodow.Model
{
    /// <summary>
    /// Wyjątek niezaimplementowanej kolekcji
    /// </summary>
    public class NiezaimplementowanaKolekcjaException : Exception
    {
        public NiezaimplementowanaKolekcjaException(string _message) : base(_message)
        {

        }

    }

    /// <summary>
    /// Wyjątek kiedy nie został przesłany obiekt samochodu
    /// </summary>
    public class BrakSamochoduException : Exception
    {
        public BrakSamochoduException(string _message) : base(_message)
        {

        }
    }
}
