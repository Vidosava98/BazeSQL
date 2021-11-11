using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OdrzavanjePuteva.Entiteti;

namespace OdrzavanjePuteva.Mapiranja
{
    class DeonicaMapiranja : ClassMap<Deonica>
    {
        public DeonicaMapiranja()
        {

            //Mapiranje tabele
            Table("DEONICA");

            //mapiranje primarnog kljuca
            Id(x => x.IdDeonice, "ID_DEONICE").GeneratedBy.TriggerIdentity().UnsavedValue(-1);

            //mapiranje svojstava
            Map(x => x.Kraj, "KRAJ");
            Map(x => x.Pocetak, "POCETAK");
            Map(x => x.Grad1, "GRAD1");
            Map(x => x.Grad2, "GRAD2");
            Map(x => x.DoKilometra, "DO_KILOMETARA");
            Map(x => x.OdKilometra, "OD_KILOMETARA");



            References(x => x.Gradiliste).Column("ID_GRADILISTA");

            References(x => x.Izvrsilac).Column("ID_IZVRSIOCA");

            HasMany(x => x.AngazovaneRM).KeyColumn("ID_DEONICE").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.AngazovanaVozilaT).KeyColumn("ID_DEONICE").LazyLoad().Cascade.All().Inverse();




        }
    }
}