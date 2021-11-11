using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OdrzavanjePuteva.Entiteti;

namespace OdrzavanjePuteva.Mapiranja
{
    class SpoljniSaradnikMapiranja : ClassMap<SpoljniSaradnik>
    {
        public SpoljniSaradnikMapiranja()
        {
            Table("SPOLJNI_SARADNIK");

            Id(x => x.IdSpoljnogSaradnika, "ID_SPOLJNOG_SARADNIKA").GeneratedBy.TriggerIdentity();

            Map(x => x.BrojUgovora, "BR_UGOVORA");

            References(x => x.Nadzornik).Column("ID_NADZORNIKA").LazyLoad();
        }
    }
}
