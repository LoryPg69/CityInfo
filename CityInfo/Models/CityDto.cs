namespace CityInfo.Models
{
    public class CityDto
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public int NumberOfPointsOfInternet {

            get {
                    return PointsOfInternet.Count;
                }
                
                    }

        public ICollection<NumberOfPointsOfInternet> PointsOfInternet { get; set; } = new List<NumberOfPointsOfInternet>();

        }
    
}
