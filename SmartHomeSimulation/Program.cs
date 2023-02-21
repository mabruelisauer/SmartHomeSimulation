namespace M320_SmartHome {
    internal class Program {
        static void Main(string[] args) {
            int zeitdauerMinuten = 30;

            var wettersensor = new Wettersensor();
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("BadWC", 23);
            wohnung.DesiredTemperature("Kueche", 22);
            wohnung.DesiredTemperature("Schlafen", 19);
            wohnung.DesiredTemperature("Wohnen", 22);
            wohnung.DesiredTemperature("Wintergarten", 20);

            wohnung.PersonsPresent("Kueche", true);
            wohnung.PersonsPresent("Schlafen", false);
            wohnung.PersonsPresent("Wohnen", true);
            wohnung.PersonsPresent("Wintergarten", true);

            for(var i = 0; i<zeitdauerMinuten; i++) {
                wohnung.GetWetterdaten(i+1);
            }
        }
    }
}