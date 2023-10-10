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
                },

            new CityDto()
            {
                Id = 1,
                Name = "Paris",
                Description = "The capital of France",
            },

            new CityDto()
            {
                Id = 1,
                Name = "Berlin",
                Description = "The capital of Germany",
            },
        };

}
    }
}
