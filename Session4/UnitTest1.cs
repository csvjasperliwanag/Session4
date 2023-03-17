using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Session4
{
    [TestClass]
    public class CountryRoad
    {
        private readonly ServiceReference1.CountryInfoServiceSoapTypeClient countryList =
            new ServiceReference1.CountryInfoServiceSoapTypeClient(ServiceReference1.CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

    [TestMethod]
    public void CountryCodeList()
        {
            var ListCountryCode = countryList.ListOfCountryNamesByCode();
            var AscListCountryCode = ListCountryCode.OrderBy(isoCode => isoCode.sISOCode);

            Assert.IsTrue(Enumerable.SequenceEqual(ListCountryCode, AscListCountryCode), "Country Code is currently NOT in Ascending order.");
        }

    [TestMethod]
    public void CountryCodeName()
        {
            var CountryName = countryList.CountryName("ZA");

            var NonExistCountryName = countryList.CountryName("YU");

            Assert.AreEqual("South Africa", CountryName, "Country currently does not exist in the database");
            Assert.AreEqual("Country not found in the database", NonExistCountryName, "Country is present in database");
        }
    [TestMethod]
    public void LastCountryCode()
        {
            var LastCountryInList = countryList.ListOfCountryNamesByCode().Last();

            var LastCountry = countryList.CountryName(LastCountryInList.sISOCode);

            Assert.AreEqual(LastCountryInList.sName, LastCountry, "");
        }
    }
}
