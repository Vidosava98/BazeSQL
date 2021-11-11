using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdrzavanjePuteva.Entiteti
{
    public class Vozilo
    {
        public virtual int IdVozila { get; protected set; }
        public virtual string Registracija { get; set; }
        public virtual string Boja { get; set; }
        public virtual string TipGoriva { get; set; }
        public virtual int ZapreminaMotora { get; set; }
        public virtual string TipVozila { get; set; }
        public virtual int Nosivost { get; set; }
        public virtual int BrojOsovina { get; set; }
        public virtual int BrojMesta { get; set; }
        public virtual string TipRadneMasine { get; set; }
        public virtual string TipPogonaRadneMasine { get; set; }

        public virtual IList<Vozi> RadniciVoze { get; set; }
        public virtual IList<Upravlja> UpravljaIzvrsilac { get; set; }
        public virtual IList<AngazovanjeRM> AngazovaneRM { get; set; }
        public virtual IList<AngazovanjeT> AngazovanaVozilaT { get; set; }

        public Vozilo()
        {
            RadniciVoze = new List<Vozi>();

            UpravljaIzvrsilac = new List<Upravlja>();

            AngazovaneRM = new List<AngazovanjeRM>();

            AngazovanaVozilaT = new List<AngazovanjeT>();

        }

    }

    public class Putnicka : Vozilo
    {

    }

    public class RadneMasine : Vozilo
    {

    }
    public class Teretne : Vozilo
    {

    }
}
