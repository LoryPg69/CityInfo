using BankomatApi.Model;

namespace BankomatApi.Services.Banche
{
    public class LocalBancaService : IBancaService
    {
        List<Banca> _bancaList;

        public LocalBancaService()
        {
            _bancaList = new List<Banca>()
            {
                new Banca()
                {
                    Id = 1,
                    Nome = "Intesa San Paolo",
                    Funzionalitas = new List<Banca.Funzionalita>()
                        {
                          new Banca.Funzionalita()
                          {
                              Id=1,
                              Name = "Funzionalità Base"
                          },

                            new Banca.Funzionalita()
                          {
                              Id=2,
                              Name = "Prelievo"
                          },
                        },
                },

                    new Banca()
                {
                    Id = 1,
                    Nome = "Credit Agricole",
                    Funzionalitas = new List<Banca.Funzionalita>()
                        {
                          new Banca.Funzionalita()
                          {
                              Id=1,
                              Name = "Funzionalità Base"
                          },  
                        },
                },

                        new Banca()
                {
                    Id = 3,
                    Nome = "Che Banca",
                    Funzionalitas = new List<Banca.Funzionalita>()
                        {
                          new Banca.Funzionalita()
                          {
                              Id=1,
                              Name = "Funzionalità Base"
                          },

                            new Banca.Funzionalita()
                          {
                              Id=2,
                              Name = "Report Saldo"
                          },
                        },
                },

                            new Banca()
                {
                    Id = 4,
                    Nome = "BPM",
                    Funzionalitas = new List<Banca.Funzionalita>()
                        {
                          new Banca.Funzionalita()
                          {
                              Id=1,
                              Name = "Funzionalità Base"
                          },

                            new Banca.Funzionalita()
                          {
                              Id=2,
                              Name = "Prelievo"
                          },

                              new Banca.Funzionalita()
                          {
                              Id=2,
                              Name = "ReportSaldo"
                          },
                        },
                },

                new Banca()
                {
                    Id = 5,
                    Nome = "Fineco",
                    Funzionalitas = new List<Banca.Funzionalita>()
                        {
                          new Banca.Funzionalita()
                          {
                              Id=1,
                              Name = "Funzionalità Base"
                          },

                            new Banca.Funzionalita()
                          {
                              Id=2,
                              Name = "Report Saldo"
                          },

                             new Banca.Funzionalita()
                          {
                              Id=3,
                              Name = "Prelievo"
                          },
   
                               new Banca.Funzionalita()
                          {
                              Id=4,
                              Name = "Registro Operazioni"
                          },
                        },
                },


            };
    }

        public IEnumerable<Banca> GetBanca()
        {
            return _bancaList;
        }

    }
}
