using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdrzavanjePuteva.Entiteti;
using FluentNHibernate.Mapping;

namespace OdrzavanjePuteva.Mapiranja
{
    class AngazovanjeRMMapiranja : ClassMap<AngazovanjeRM>
    {
        public AngazovanjeRMMapiranja()
        {
            Table("ANGAZOVANJE_RM");

            Id(x => x.IdAngazovanjeRM, "ID_ANGAZOVANJE_RM").GeneratedBy.TriggerIdentity();

            Map(x => x.Pocetak, "POCETAK");

            Map(x => x.Kraj, "KRAJ");

            References(x => x.RadnaMasina).Column("ID_RADNE_MASINE");

            References(x => x.Deonica).Column("ID_DEONICE");
        }
    }
}
