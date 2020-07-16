using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using RealEstate.Models;
using RealEstate.Parsers;
using RealEstate.Providers.Interfaces;

namespace RealEstate.Providers
{
    /// <summary>
    /// ZillowDataProvider gathers data from Zillow.com
    /// </summary>
    public class ZillowDataProvider : IZillowDataProvider
    {
        private readonly HttpClient httpClient;
        private const string BaseZillowUrl = "https://www.zillow.com";
        private const string AuthenticationHeaderScheme = "Bearer";
        private const string AuthenticationHeaderParameter = "Auth token";

        public ZillowDataProvider()
        {
            httpClient = new HttpClient();
        }

        /// <summary>
        /// Method sends GET request to Zillow.com with provided parameters
        /// </summary>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <returns>Sold estate data gathered from Zillow.com</returns>
        public List<SoldEstate> GetSoldRealEstateData(string city, string state)
        {
            if(string.IsNullOrEmpty(city) || string.IsNullOrEmpty(state))
                return new List<SoldEstate>();

            if(!Regex.IsMatch(city, @"^[A-Z]+[a-zA-Z ]*$") || !Regex.IsMatch(state, @"^[A-Z]+[a-zA-Z ]*$"))
                return new List<SoldEstate>();

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationHeaderScheme, AuthenticationHeaderParameter);

            string jsonResponse = httpClient.GetAsync(String.Concat(BaseZillowUrl,
                $"/search/GetSearchPageState.htm?searchQueryState={{\"pagination\":{{}},\"usersSearchTerm\":\"{city}, {state}\",\"mapBounds\":{{\"west\":-95.30356273828126,\"east\":-93.84787426171876,\"south\":38.61866456286261,\"north\":39.56300597182533}},\"regionSelection\":[{{\"regionId\":18795,\"regionType\":6}}],\"isMapVisible\":true,\"mapZoom\":9,\"filterState\":{{\"pmf\":{{\"value\":false}},\"fore\":{{\"value\":false}},\"auc\":{{\"value\":false}},\"nc\":{{\"value\":false}},\"rs\":{{\"value\":true}},\"fsbo\":{{\"value\":false}},\"cmsn\":{{\"value\":false}},\"pf\":{{\"value\":false}},\"fsba\":{{\"value\":false}}}},\"isListVisible\":true}}")).Result.Content.ReadAsStringAsync().Result;

            return SoldEstateJsonParser.ConvertJsonData(jsonResponse);
        }
    }
}
