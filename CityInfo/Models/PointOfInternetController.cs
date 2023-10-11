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

        [HttpGet("{pointId:int}", Name = "getPointOfInternet")]
        [Consumes("application/xml")]

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

        [HttpPost]
        public IActionResult CreatePointOfInternet(int cityId, [FromBody] PointOfInternetDTO poi)        
        {

            var city = CitiesDataStorage.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();

            }

            var maxPointOfInternetId = CitiesDataStorage.Current.Cities.SelectMany(c => c.PointsOfInternet).Max(p => p.Id);

            var finalPointOfInternet = new NumberOfPointsOfInterest()
            {
                Id = ++maxPointOfInternetId,
                Name = poi.Name,
                Description = poi.Description,
            
            };

            city.PointsOfInternet.Add(finalPointOfInternet);

            return CreatedAtRoute(nameof(GetPointOfInternet),
                routeValues: new
                {
                    cityId = cityId,
                    pointId = finalPointOfInternet.Id
                },
                finalPointOfInternet);
            
        }
        [HttpPut ("{pointId:int}")]
        public ActionResult UpdatePointOfInternet(int cityId, int pointId, [FromBody] PointOfInternetDTO pointOfInternet)
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


            point.Name = pointOfInternet.Name;
            point.Description = pointOfInternet.Description;

            return NoContent();
        }

        [HttpDelete("{pointId:int}")]

        public ActionResult DeletePointOfInternet(int cityId, int pointId)
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

            city.PointsOfInternet.Remove(point);
            return NoContent();
        }


        }
}
