namespace M320_SmartHome {
    /// <summary>
    /// Diese Klasse dekoriert die entsprechenden Zimmer mit einer Markise
    /// </summary>
    public class ZimmerMitMarkisensteuerung : ZimmerMitAktor {
        public ZimmerMitMarkisensteuerung(Zimmer zimmer) : base(zimmer) {
        }
        /// <summary>
        /// Zeigt ob die Markise aktuell geöffnet ist oder nicht
        /// </summary>
        public bool MarkiseOffen { get; private set; }
        /// <summary>
        /// Öffnet oder schliesst die Markise
        /// </summary>
        /// <param name="wetterdaten">Nimmt Daten des Wettersensors als Parameter</param>
        public override void VerarbeiteWetterdaten(Wetterdaten wetterdaten) {
            if(wetterdaten.Aussentemperatur > this.Zimmer.Temperaturvorgabe) {
                if(this.MarkiseOffen) {
                    if (wetterdaten.Regen) {
                        Console.WriteLine($"{this.Name}: Markise kann nicht geschlossen werden weils regnet.");
                    } else {
                        Console.WriteLine($"{this.Name}: Markise wird geschlossen.");
                        MarkiseOffen = false;
                    }
                } else if(wetterdaten.Regen) {
                    Console.WriteLine($"{this.Name}: Markise wird geöffnet weils regnet.");
                    MarkiseOffen = true;
                }
            } else {
                if (!this.MarkiseOffen) {
                    Console.WriteLine($"{this.Name}: Markise wird geöffnet.");
                    MarkiseOffen = true;
                }
            }

            base.VerarbeiteWetterdaten(wetterdaten);
        }
    }
}
