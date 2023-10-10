using CityInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CityInfo.Controller
{

    [ApiController]
    [Route("api/cities")]
    public class CityController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities() {

            return Ok(CitiesDataStorage.Current.Cities);

            }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id) {

            var cityToReturn =  CitiesDataStorage.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }
                
                return Ok(cityToReturn);
                }

        //public JsonResult GetCities()
        //{
        //    return new JsonResult(new List<object>
        //    {
        //        new {id=1, name="Paris"},
        //        new {id=2, name="Oslo"},
        //    });
        }
    }

