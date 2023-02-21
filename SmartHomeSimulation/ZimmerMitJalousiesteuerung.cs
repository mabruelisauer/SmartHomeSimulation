namespace M320_SmartHome {
    /// <summary>
    /// Diese Klasse dekoriert die entsprechenden Zimmer mit einer Jalousie
    /// </summary>
    public class ZimmerMitJalousiesteuerung : ZimmerMitAktor {
        public ZimmerMitJalousiesteuerung(Zimmer zimmer) : base(zimmer) {
        }

        public bool JalousieHeruntergefahren { get; private set; }
        /// <summary>
        /// Öffnet oder schliesst die Jalousie
        /// </summary>
        /// <param name="wetterdaten">Nimmt Daten des Wettersensors als Parameter</param>
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            if(wetterdaten.Aussentemperatur > this.Zimmer.Temperaturvorgabe) {
                // Jalousie schliessen
                if(!this.JalousieHeruntergefahren) {
                    if (this.Zimmer.PersonenImZimmer) {
                        Console.WriteLine($"{this.Name}: Jalousie kann nicht geschlossen werden weil Personen im Zimmer sind.");
                    } else {
                        Console.WriteLine($"{this.Name}: Jalousie wird geschlossen.");
                        JalousieHeruntergefahren = true;
                    }
                }
            } else {
                // Jalousie öffnen
                if (this.JalousieHeruntergefahren) {
                    Console.WriteLine($"{this.Name}: Jalousie wird geöffnet.");
                    JalousieHeruntergefahren = false;
                }
            }

            base.VerarbeiteWetterdaten(wetterdaten);
        }
    }
}
