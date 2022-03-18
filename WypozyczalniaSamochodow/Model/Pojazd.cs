namespace WypozyczalniaSamochodow.Model
{
    /// <summary>
    /// Abstrakcyjna klasa przedsatwiająca Pojazd. Pojazd nie jest niczym fizycznym i stanowi bazę pod bardziej szczegółowe obiekty- dlatego jest abstrakcyjny
    /// </summary>
    public abstract class Pojazd
    {
        /// <summary>
        /// Licznik ID
        /// </summary>
        private static uint counter;

        /// <summary>
        /// Identyfikator pojazdu
        /// </summary>
        public uint ID { get;  set; }

        /// <summary>
        /// Ilość kół
        /// </summary>
        public ushort IloscKol { get; set; }

        /// <summary>
        /// Rodzaj napędu pojazdu
        /// </summary>
        public SilnikType TypSilnika { get; set; }


        /// <summary>
        /// Konstruktor który tworzy ID
        /// </summary>
        public Pojazd()
        {
            this.ID = counter++;
        }
    }

    
}
