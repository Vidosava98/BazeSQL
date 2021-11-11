using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdrzavanjePuteva.Entiteti
{
    public class Deonica
    {
        public virtual int IdDeonice { get; protected set; }
        public virtual int OdKilometra { get; set; }
        public virtual int DoKilometra { get; set; }
        public virtual String Grad1 { get; set; }
        public virtual String Grad2 { get; set; }

        public virtual DateTime Pocetak { get; set; }
        public virtual DateTime Kraj { get; set; }

        //mapiranje 1:N
        public virtual Gradiliste Gradiliste { get; set; }
        public virtual Radnik Izvrsilac { get; set; }

        public virtual IList<AngazovanjeRM> AngazovaneRM { get; set; }
        public virtual IList<AngazovanjeT> AngazovanaVozilaT { get; set; }

        public Deonica()
        {
            AngazovaneRM = new List<AngazovanjeRM>();
            AngazovanaVozilaT = new List<AngazovanjeT>();
        }
    }

    }

