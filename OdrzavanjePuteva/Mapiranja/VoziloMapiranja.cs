using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdrzavanjePuteva.Entiteti;
using FluentNHibernate.Mapping;

namespace odrzavanjePuteva.Mapiranja
{
    public class VoziloMapiranja : ClassMap<Vozilo>
    {
        public VoziloMapiranja()
        {
            Table("VOZILO");
            DiscriminateSubClassesOnColumn("TIP_VOZILA");

            //mapiranje primarnog kljuca
            Id(x => x.IdVozila, "ID_VOZILA").GeneratedBy.TriggerIdentity();

            //mapiranje svojstava

            Map(x => x.Registracija, "REGISTRACIJA");
            Map(x => x.Boja, "BOJA");
            Map(x => x.TipGoriva, "TIP_GORIVA");          
            Map(x => x.ZapreminaMotora, "ZAPREMINA_MOTORA");
            Map(x => x.Nosivost, "NOSIVOST");
            Map(x => x.BrojOsovina, "BROJ_OSOVINA");
            Map(x => x.BrojMesta, "BROJ_MESTA");
            Map(x => x.TipRadneMasine, "TIP_RADNE_MASINE");
            Map(x => x.TipPogonaRadneMasine, "TIP_POGONA");


            HasMany(x => x.RadniciVoze).KeyColumn("ID_PUTNICKOG").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.UpravljaIzvrsilac).KeyColumn("ID_VOZILA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.AngazovaneRM).KeyColumn("ID_RADNE_MASINE").LazyLoad().Cascade.All().Inverse();


        }


    }

    public class PutnickaMapiranja : SubclassMap<Putnicka>
    {
        public PutnickaMapiranja()
        {
            DiscriminatorValue("putnicka");
        }

    }
    public class TeretnaMapiranja : SubclassMap<Teretne>
    {
        public TeretnaMapiranja()
        {
            DiscriminatorValue("teretna");
        }

    }
    public class RadneMasineMapiranja : SubclassMap<RadneMasine>
    {
        public RadneMasineMapiranja()
        {
            DiscriminatorValue("radne masine");
        }

    }
}