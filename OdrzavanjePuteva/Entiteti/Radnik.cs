using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdrzavanjePuteva.Entiteti
{
    public class Radnik
    {
        public virtual int Id_Radnika { get; protected set; }
        public virtual String Godina_Rodj { get; set; }
        public virtual String Adresa { get; set; }
        public virtual String Jmbg { get; set; }
        public virtual String Ime { get; set; }
        public virtual String Prezime { get; set; }
        public virtual String Ime_Oca { get; set; }
        public virtual String Tip_Radnika { get; set; }  
        public virtual String Specijalnost { get; set; }
        public virtual DateTime DatumPostavljanja { get; set; }
        public virtual int Id_Nadredjenog { get; set; }
        public virtual IList<Upravlja> UpravljaVozilima { get; set; }
        public virtual IList<Vozi> VozeVozila { get; set; }
        public virtual IList<Deonica> Deonice { get; set; }
        public virtual IList<SpoljniSaradnik> SpoljniSaradnici { get; set; }

        public Radnik()
        {
            VozeVozila = new List<Vozi>();

            UpravljaVozilima = new List<Upravlja>();

            Deonice = new List<Deonica>();

            SpoljniSaradnici = new List<SpoljniSaradnik>();

        }

    }


    public class Nadredjeni : Radnik
    {
        public virtual IList<Radnik> NadredjeniRadnik { get; set; }

        public Nadredjeni()
        {
            NadredjeniRadnik = new List<Radnik>();
        }

    }
    public class Izvrsilac : Radnik
    {

    }

    public class Nadzornik : Radnik
    {

    }
}
