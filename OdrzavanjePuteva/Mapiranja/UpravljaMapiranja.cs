using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdrzavanjePuteva.Entiteti;
using FluentNHibernate.Mapping;

namespace OdrzavanjePuteva.Mapiranja
{
    class UpravljaMapiranja : ClassMap<Upravlja>
    {

        public UpravljaMapiranja()
        {
            Table("UPRAVLJA");

            //mapiranje primarnog kljuca
            Id(x => x.IdUpravlja, "ID_UPRAVLJA").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava.
            Map(x => x.Pocetak, "POCETAK");
            Map(x => x.Kraj, "KRAJ");

            //mapiranje veza
            References(x => x.Vozilo).Column("ID_VOZILA");
            References(x => x.Izvrsilac).Column("ID_IZVRSIOCA");

        }
    }
}
