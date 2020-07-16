using System.Collections.Generic;
using RealEstate.Models;

namespace RealEstate.Providers.Interfaces
{
    public interface IZillowDataProvider
    {
        public List<SoldEstate> GetSoldRealEstateData(string city, string state);
    }
}
