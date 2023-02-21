using M320_SmartHome;

namespace SmartHomeSimulation.Test
{
    [TestClass]
    public class TestHeizungsventil
    {
        [TestMethod]
        public void Test19Degrees()
        {
            // Arrange
            int numberOfIterations = 30;
            var wettersensor = new WettersensorMock(19, 16, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Küche", 20);
            wohnung.PersonsPresent("Küche", true);
            wohnung.GetWetterdaten(numberOfIterations);

            // Act
            var kueche = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Küche");

            // Assert
            Assert.AreEqual(kueche.HeizungsventilOffen, true);
        }

        [TestMethod]
        public void Test21Degrees()
        {
            // Arrange
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(21, 16, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Küche", 20);
            wohnung.PersonsPresent("Küche", true);
            wohnung.GetWetterdaten(zeitdauerMinuten);

            // Act
            var kueche = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Küche");

            // Assert
            Assert.AreEqual(kueche.HeizungsventilOffen, false);
        }

        [TestMethod]
        public void TestMinus50Degrees()
        {
            // Arrange
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(-20, 16, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Küche", 20);
            wohnung.PersonsPresent("Küche", true);
            wohnung.GetWetterdaten(zeitdauerMinuten);

            // Act
            var kueche = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Küche");

            // Assert
            Assert.AreEqual(kueche.HeizungsventilOffen, true);
        }

        [TestMethod]
        public void Test100Degrees()
        {
            // Arrange
            int zeitdauerMinuten = 30;
            var wettersensor = new WettersensorMock(500, 16, true);
            var wohnung = new Wohnung(wettersensor);

            wohnung.DesiredTemperature("Küche", 20);
            wohnung.PersonsPresent("Küche", true);
            wohnung.GetWetterdaten(zeitdauerMinuten);

            // Act
            var kueche = wohnung.GetZimmer<ZimmerMitHeizungsventil>("Küche");

            // Assert
            Assert.AreEqual(kueche.HeizungsventilOffen, false);
        }
    }
}