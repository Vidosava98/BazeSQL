using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdrzavanjePuteva.Entiteti
{
    public class Upravlja
    {
        public virtual int IdUpravlja { get; protected set; }
        public virtual DateTime Pocetak { get; set; }
        public virtual DateTime Kraj { get; set; }
        public virtual Radnik Izvrsilac { get; set; }
        public virtual Vozilo Vozilo { get; set; }


    }
}
