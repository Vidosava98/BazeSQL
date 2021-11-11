using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdrzavanjePuteva.Entiteti
{
    public class AngazovanjeRM
    {
        public virtual DateTime Pocetak { get; set; }
        public virtual DateTime Kraj { get; set; }
        public virtual RadneMasine RadnaMasina { get; set; }
        public virtual Deonica Deonica { get; set; }
        public virtual int IdAngazovanjeRM { get; set; }
    }

}
