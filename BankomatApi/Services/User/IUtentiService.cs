using BankomatApi.Model;

namespace BankomatApi.Services.Utente
{
    public interface IUtentiService
    {
        IEnumerable<Utenti> GetUser();
        Utenti PostUser(Utenti user);
        bool PutUser(long userId, Utenti utenti);
        bool DeleteUser(Utenti user);

        bool BloccaUtente(Utenti user);

        bool SbloccaUtente(Utenti user);

    }
}
