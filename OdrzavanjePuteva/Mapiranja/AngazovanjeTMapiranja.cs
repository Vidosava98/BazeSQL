using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdrzavanjePuteva.Entiteti;
using FluentNHibernate.Mapping;

namespace odrzavanjePuteva.Mapiranja
{
    class AngazovanjeTMapiranja : ClassMap<AngazovanjeT>
    {
        public AngazovanjeTMapiranja()
        {
            Table("ANGAZOVANJE_T");

            Id(x => x.IdAngazovanjeT, "ID_ANGAZOVANJE_T").GeneratedBy.TriggerIdentity();

            Map(x => x.Pocetak, "POCETAK");

            Map(x => x.Kraj, "KRAJ");

            References(x => x.Teretno).Column("ID_TERETNOG");

            References(x => x.Deonica).Column("ID_DEONICE");
        }
    }
}
