using CityInfo.Models;

namespace CityInfo.NewFolder
{
    public interface ICityRepository
    {
        IEnumerable<CityDto> GetCities();

        bool AddCity(CityDto city);

        bool RemoveCity(CityDto city);

    }
}
