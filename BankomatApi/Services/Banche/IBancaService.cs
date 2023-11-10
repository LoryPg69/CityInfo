using BankomatApi.Model;

namespace BankomatApi.Services.Banche
{
    public interface IBancaService
    {
        IEnumerable<Banca> GetBanca();
      
        //bool PutUser(long userId, Utenti utenti);
        //bool DeleteUser(Utenti user);

        //bool BloccaUtente(Utenti user);

        //bool SbloccaUtente(Utenti user);
    }
}
