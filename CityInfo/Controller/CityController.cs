using CityInfo.Models;
using CityInfo.NewFolder;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CityInfo.Controller
{

    [ApiController]
    [Route("api/cities")]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepo;

        public CityController(ICityRepository repo)
        {
            _cityRepo = repo;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities() {

            return Ok(_cityRepo.GetCities());

            }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id) {

            var cityToReturn = _cityRepo.GetCities().FirstOrDefault(c => c.Id == id);

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

