using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdrzavanjePuteva.Entiteti
{
    public class Vozi
    {
        public virtual DateTime Pocetak { get; set; }
        public virtual DateTime Kraj { get; set; }
        public virtual Radnik Nadzornik { get; set; }
        public virtual Vozilo Vozilo { get; set; }
        public virtual int IdKoriste { get; set; }
    }
}
