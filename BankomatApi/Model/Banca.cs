namespace BankomatApi.Model
{
    public class Banca
    {
        public long Id { get; internal set; }
        public string Nome { get; internal set; }


        public SortedList<long, Funzionalita> elencoFunzionalita { get; internal set; }

        public List <Funzionalita> Funzionalitas {  get;  set; }

        public class Funzionalita
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }

    }
}

