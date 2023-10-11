namespace CityInfo.Models
{
    public class CitiesDataStorage
    {
        public List<CityDto> Cities { get; set; }
        public static CitiesDataStorage Current { get;} = new CitiesDataStorage();

        public CitiesDataStorage() {

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
    }
}
