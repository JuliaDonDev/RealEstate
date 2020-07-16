using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using RealEstate.Models;

namespace RealEstate.Parsers
{
    /// <summary>
    /// SoldEstateJsonParser parses Json data to SoldEstate object 
    /// </summary>
    public static class SoldEstateJsonParser
    {
        /// <summary>
        /// Method converts Json string to SoldEstate object
        /// </summary>
        /// <param name="jsonData">Json string</param>
        /// <returns>List of SoldEstate objects</returns>
        public static List<SoldEstate> ConvertJsonData(string jsonData)
        {
            const string requiredAttributes = "searchResults.listResults";
            JObject jObject = JObject.Parse(jsonData);
            List<SoldEstate> soldEstates = jObject.SelectToken(requiredAttributes)?.ToObject<SoldEstate[]>()?.ToList();
            return soldEstates;
        }
    }
}
