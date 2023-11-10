using BankomatApi.Model;
using BankomatApi.Services.Utente;
using Microsoft.AspNetCore.Mvc;

namespace BankomatApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtentiController : ControllerBase
    {

        IUtentiService _utenti;

        public UtentiController(IUtentiService utenti)
        {
            _utenti = utenti;
        }



        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok(_utenti.GetUser());
        }

        [HttpGet("{userid:int}")]
        public IActionResult GetUserById(int userid)
        {
            try
            {
                return Ok(_utenti.GetUser().Where(x => x.Id == userid));
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

        [HttpPost]
        public IActionResult PostUser([FromBody] Utenti user)
        {
            try
            {
                var res = _utenti.PostUser(user);
                return CreatedAtRoute(nameof(GetUser), new { userId = res.Id }, res);
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

        [HttpPut("userId:int")]
        public IActionResult PutUser(long userid, Utenti utenti)
        {
            var res = (_utenti.GetUser().Where(x => x is Utenti).First(x => x.Id == userid));

            res.Bloccato = utenti.Bloccato;
            res.NomeUtente = utenti.NomeUtente;
            res.Password = utenti.Password;
            res.TentativiDiAccessoErrati = utenti.TentativiDiAccessoErrati;
            return Ok(res);
        }

        [HttpDelete("userId:long")]
        public IActionResult DeleteUser(long userid)
        {
            try
            {
                var x = _utenti.GetUser().First(x => x.Id == userid);
                _utenti.DeleteUser(x);
                return NoContent();
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

        [HttpGet("SbloccaUtente:long")]
        public bool SbloccaUtente(long userid)
        {
            var x = _utenti.GetUser().First(x => x.Id == userid);
            if (x.Bloccato == true)
            {
                Console.WriteLine("utente sbloccato");
                return x.Bloccato = false;


            }
            else Console.WriteLine("utente non è sbloccato");
            return x.Bloccato;
        }

            [HttpGet("Blocca:long")]
            public bool BloccaUtente(long userid)
            {
                var x = _utenti.GetUser().First(x => x.Id == userid);
                if (x.Bloccato == true)
                {
                    Console.WriteLine("utente già bloccato");


                }
                return x.Bloccato= true;

            }
    }
}
