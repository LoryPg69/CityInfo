using BankomatApi.Model;
using BankomatApi.Services.Banche;
using Microsoft.AspNetCore.Mvc;

namespace BankomatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FunzionalitaBancaController : ControllerBase
    {
        IBancaService _banche;
        public FunzionalitaBancaController(IBancaService banca)
        {
            _banche = banca;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_banche.GetBanca());
        }

        [HttpGet("{bancaid:int}")]
        public IActionResult GetUserById(int bancaid)
        {
            try
            {
                return Ok(_banche.GetBanca().Where(x => x.Id == bancaid));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
    
    }

