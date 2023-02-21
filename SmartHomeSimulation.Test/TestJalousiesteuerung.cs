using M320_SmartHome;

namespace SmartHomeSimulation.Test
{
    [TestClass]
    public class TestJalousiesteuerung
    {
        [TestMethod]
        public void TestHigherOutdoortemperature()
        {
            // Arrange
            int numberOfIterations = 30;
            var wettersensor = new WettersensorMock(21, 20, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Küche", 20);
            wohnung.PersonsPresent("Küche", false);
            wohnung.GetWetterdaten(numberOfIterations);

            // Act
            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");

            // Assert
            Assert.AreEqual(kueche.JalousieHeruntergefahren, true);
        }

        [TestMethod]
        public void TestLowerOutdoortemperature()
        {
            // Arrange
            int numberOfIterations = 30;
            var wettersensor = new WettersensorMock(19, 20, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Küche", 20);
            wohnung.PersonsPresent("Küche", false);
            wohnung.GetWetterdaten(numberOfIterations);

            // Act
            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");

            // Assert
            Assert.AreEqual(kueche.JalousieHeruntergefahren, false);
        }

        [TestMethod]
        public void TestWithoutPersons()
        {
            // Arrange
            int numberOfIterations = 30;
            var wettersensor = new WettersensorMock(25, 20, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Küche", 20);
            wohnung.PersonsPresent("Küche", false);
            wohnung.GetWetterdaten(numberOfIterations);

            // Act
            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");

            // Assert
            Assert.AreEqual(kueche.JalousieHeruntergefahren, true);
        }

        // working
        [TestMethod]
        public void TestHigherOutdoorTemperatureAndPersons()
        {
            // Arrange
            int numberOfIterations = 30;
            var wettersensor = new WettersensorMock(25, 20, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Küche", 20);
            wohnung.PersonsPresent("Küche", true);
            wohnung.GetWetterdaten(numberOfIterations);

            // Act
            var kueche = wohnung.GetZimmer<ZimmerMitJalousiesteuerung>("Küche");

            // Assert
            Assert.AreEqual(kueche.JalousieHeruntergefahren, false);
        }
    }
}