using CityInfo.Models;

namespace CityInfo.NewFolder
{
    public class CityRepository : ICityRepository
    {
        private List<CityDto> Cities { get; set; }
        public CityRepository()
        
        {
      
            Cities = new List<CityDto>()
            {
                new CityDto() {
                Id = 1,
                Name = "Rome",
                Description = "The capital of Italy",
                PointsOfInternet = new List<NumberOfPointsOfInterest>()
                {
                    new NumberOfPointsOfInterest()
                    {
                        Id = 1,
                        Name="Colosseum",
                        Description = "ROMANI",
                    },
                    new NumberOfPointsOfInterest()
                    {
                        Id = 2,
                        Name="Circus Maximun",
                        Description = "TRa",
                    }

                }
                },

            new CityDto()
            {
                Id = 2,
                Name = "Paris",
                Description = "The capital of France",

                 PointsOfInternet = new List<NumberOfPointsOfInterest>()
                {
                    new NumberOfPointsOfInterest()
                    {
                        Id = 1,
                        Name="Tour Eiffel",
                        Description = "pezzo di latta",
                    },
                    new NumberOfPointsOfInterest()
                    {
                        Id = 2,
                        Name="arc the triomphe ",
                        Description = "Napoleone",
                    }

                }
            },

            new CityDto()
            {
                Id = 3,
                Name = "Berlin",
                Description = "The capital of Germany",
                PointsOfInternet = new List<NumberOfPointsOfInterest>()
                {
                    new NumberOfPointsOfInterest()
                    {
                        Id = 1,
                        Name="Brandenburg Gate",
                        Description = "porta",
                    },
                    new NumberOfPointsOfInterest()
                    {
                        Id = 2,
                        Name="Neuschwanstein Castle ",
                        Description = "castello",
                    }

                }
            },

        };
        }

        public IEnumerable<CityDto> GetCities()
        {
            return Cities;
        }

        public bool AddCity(CityDto city)
        {
            Cities.Add(city);
            return true;
        }

        public bool RemoveCity(CityDto city)
        {
            Cities.Remove(city);
            return true;
        }

        public bool UpdateCity(CityDto city)
        {
            return true;
        }

        public bool AddPoint(PointOfInternetDTO point, CityDto city)
        {
            //Cities. Add(point);+
            return true;
        }
    }
}
