namespace M320_SmartHome {
    /// <summary>
    /// Diese Klasse dekoriert die entsprechenden Zimmer mit einem Heizungsventil
    /// </summary>
    public class ZimmerMitHeizungsventil : ZimmerMitAktor {
        public ZimmerMitHeizungsventil(Zimmer zimmer) : base(zimmer) {
        }

        public bool HeizungsventilOffen { get; private set; }

        /// <summary>
        /// Öffnet oder schliesst Heizungsventil
        /// </summary>
        /// <param name="wetterdaten">Nimmt Daten des Wettersensors als Parameter</param>
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            if(wetterdaten.Aussentemperatur < this.Zimmer.Temperaturvorgabe) {
                if(!this.HeizungsventilOffen) {
                    Console.WriteLine($"{this.Name}: Heizungsventil wird geöffnet.");
                    HeizungsventilOffen = true;
                }
            } else {
                if (this.HeizungsventilOffen) {
                    Console.WriteLine($"{this.Name}: Heizungsventil wird geschlossen.");
                    HeizungsventilOffen= false;
                }
            }

            base.VerarbeiteWetterdaten(wetterdaten);
        }
    }
}
