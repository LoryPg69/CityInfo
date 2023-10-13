using CityInfo.NewFolder;
using CityInfo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.Models
{ 
    [Route("api/cities/{cityId}/pointofinternet")]
    [ApiController]

    public class PointOfInternetController : ControllerBase
    {

        private readonly ICityRepository _cityRepo;     

        private readonly ILogger<PointOfInternetController> _logger;

        private readonly IMailService _mailService;

        public PointOfInternetController(ILogger<PointOfInternetController> logger, ICityRepository cityRepo, IMailService s)
        {

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _cityRepo = cityRepo;
            _mailService = s;
            _mailService.Send("jdjdj", "ciao");
        }

        [HttpGet]

        public ActionResult <IEnumerable<PointOfInternetController>> GetPointsOfInternet(int cityId)
        {
            try
            {
                var city = _cityRepo.GetCities().FirstOrDefault(c => c.Id == cityId);

                if (city == null)
                {

                    _logger.LogInformation("city not found");
                    return NotFound();

                }
                return Ok(city.PointsOfInternet);
            }
            catch (Exception ex)
            {

                _logger.LogCritical($"{ex.Message} \n {ex.StackTrace}");
                return StatusCode(500, "something critical happens");
            }
        }

        [HttpGet("{pointId:int}", Name = "getPointOfInternet")]
        [Consumes("application/xml")]

        public ActionResult<IEnumerable<PointOfInternetController>> GetPointOfInternet(int cityId, int pointId)
        {
            var city = _cityRepo.GetCities().FirstOrDefault(c => c.Id == cityId);
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

            var city = _cityRepo.GetCities().FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();

            }

            var maxPointOfInternetId = _cityRepo.GetCities().SelectMany(c => c.PointsOfInternet).Max(p => p.Id);

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
            var city = _cityRepo.GetCities().FirstOrDefault(c => c.Id == cityId);
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
            var city = _cityRepo.GetCities().FirstOrDefault(c => c.Id == cityId);
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
