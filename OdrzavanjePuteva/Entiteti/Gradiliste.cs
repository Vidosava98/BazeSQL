using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdrzavanjePuteva.Entiteti
{
    public class Gradiliste
    {
        public virtual int IdGradilista { get; protected set; }
        public virtual String TipGradilista { get; set; }

        public virtual IList<Deonica> Deonice { get; set; }

        public Gradiliste()
        {
            Deonice = new List<Deonica>();
        }
    }
}
