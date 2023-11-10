using BankomatApi.Model;
using BankomatApi.Services.Utente;
using Microsoft.AspNetCore.Mvc;

namespace BankomatApi.Services.User
{


    public class LocalUtentiServices :  IUtentiService
    {
        List<Utenti> _user;

        public LocalUtentiServices()
        {
            _user = new List<Utenti>()
            {
                new Utenti()
                {
                    Id = 1,
                    Bloccato = false,
                    NomeUtente = "lollo04",
                    Password = "password",
                },

                new Utenti()
                {
                    Id = 2,
                    Bloccato = false,
                    NomeUtente = "fede04",
                    Password = "12344",
                },

                new Utenti()
                {
                    Id = 3,
                    Bloccato = false,
                    NomeUtente = "mattia03",
                    Password = "ciao",
                },
            };
        }

        public bool BloccaUtente(Utenti user)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(Utenti user)
        {
            foreach (var item in _user)
            {
                item.Id.CompareTo(user.Id);

            }
            return _user.Remove(user);
        }

        public IEnumerable<Utenti> GetUser()
        {
            return _user;
        }


        public Utenti PostUser(Utenti utenti)
        {
            var res = new Utenti()
            {
                NomeUtente = utenti.NomeUtente,
                Password = utenti.Password,
                Bloccato = utenti.Bloccato,
                TentativiDiAccessoErrati = utenti.TentativiDiAccessoErrati,
            };

            res.Id = _user.Where(x => x is Utenti).Max(x => x.Id) +1;
            //_utenti.GetUser().Where(x => x is Utenti).First(x => x.Id == userid);
            _user.Add(res);
            return res;
        }
      



        public bool PutUser(long userId, Utenti utenti)
        {
            var res = (_user.Where(x => x is Utenti).First(x => x.Id == userId));

            res.Bloccato = utenti.Bloccato;
            res.NomeUtente = utenti.NomeUtente;
            res.Password = utenti.Password;
            res.TentativiDiAccessoErrati = utenti.TentativiDiAccessoErrati;
            return true;
        }

        public bool SbloccaUtente(Utenti user)
        {
            throw new NotImplementedException();
        }
    }
    }

