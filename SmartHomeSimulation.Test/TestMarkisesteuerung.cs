using M320_SmartHome;

namespace SmartHomeSimulation.Test
{
    [TestClass]
    public class TestMarkisesteuerung
    {
        [TestMethod]
        public void TestRainAndWind()
        {
            // Arrange
            int numberOfIterations = 30;
            var wettersensor = new WettersensorMock(21, 30, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Wintergarten", 20);
            wohnung.PersonsPresent("Wintergarten", false);
            wohnung.GetWetterdaten(numberOfIterations);

            // Act
            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");

            // Assert
            Assert.AreEqual(wintergarten.MarkiseOffen, true);
        }

        [TestMethod]
        public void TestWithoutWind()
        {
            // Arrange
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(21, 30, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Wintergarten", 20);
            wohnung.PersonsPresent("Wintergarten", false);
            wohnung.GetWetterdaten(zeitdauerMinuten);

            // Act
            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");

            // Assert
            Assert.AreEqual(wintergarten.MarkiseOffen, false);
        }

        [TestMethod]
        public void TestHigherOutdoorTemperature()
        {
            // Arrange
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(21, 20, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Wintergarten", 20);
            wohnung.PersonsPresent("Wintergarten", false);
            wohnung.GetWetterdaten(zeitdauerMinuten);

            // Act
            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");

            // Assert
            Assert.AreEqual(wintergarten.MarkiseOffen, false);
        }

        [TestMethod]
        public void TestWithoutWindAndRain()
        {
            // Arrange
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(15, 30, false);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Wintergarten", 20);
            wohnung.PersonsPresent("Wintergarten", false);
            wohnung.GetWetterdaten(zeitdauerMinuten);

            // Act
            var wintergarten = wohnung.GetZimmer<ZimmerMitMarkisensteuerung>("Wintergarten");

            // Assert
            Assert.AreEqual(wintergarten.MarkiseOffen, true);
        }
    }
}