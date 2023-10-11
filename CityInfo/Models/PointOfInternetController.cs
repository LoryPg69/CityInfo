using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Models
{ 
    [Route("api/cities/{cityId}/pointofinternet")]
    [ApiController]

    public class PointOfInternetController : ControllerBase
    {
        [HttpGet]

        public ActionResult <IEnumerable<PointOfInternetController>> GetPointsOfInternet(int cityId)
        {
            var city = CitiesDataStorage.Current.Cities.FirstOrDefault( c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();

            }
            return Ok(city.PointsOfInternet);
        }

        [HttpGet("{pointId:int}")]

        public ActionResult<IEnumerable<PointOfInternetController>> GetPointOfInternet(int cityId, int pointId)
        {
            var city = CitiesDataStorage.Current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();

            }
            var point = city.PointsOfInternet.FirstOrDefault(p => p.Id == pointId);

            if (point == null)
            {
                return NotFound();

            }
            return Ok(point);
        }

    }
}
