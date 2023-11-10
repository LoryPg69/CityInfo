namespace BankomatApi.Model
{
    public class Utenti : ContoCorrente
    {
        private int _tentativiDiAccessoErrati = 0;
        private bool _bloccato = false;
        private const int _tentativiDiAccessoPermessi = 3;
        public string NomeUtente { get;  set; }
        public string Password { get;  set; }
        public bool Bloccato { get => _bloccato;  set => _bloccato = value; }
        public long Id { get;  internal set; }

        public int TentativiDiAccessoResidui
        {
            get
            {
                return _tentativiDiAccessoPermessi - _tentativiDiAccessoErrati;
            }
        }

        public int TentativiDiAccessoErrati
        {
            get => _tentativiDiAccessoErrati;
            internal set
            {
                _tentativiDiAccessoErrati = value;
                if (_tentativiDiAccessoErrati >= _tentativiDiAccessoPermessi)
                {
                    _bloccato = true;
                }
            }
        }
    }
}
