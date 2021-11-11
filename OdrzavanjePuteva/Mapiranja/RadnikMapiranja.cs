using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OdrzavanjePuteva.Entiteti;


namespace OdrzavanjePuteva.Mapiranja
{
    public class RadnikMapiranja : ClassMap<OdrzavanjePuteva.Entiteti.Radnik>
    {
        public RadnikMapiranja()
        {
            Table("RADNIK");

            Id(x => x.Id_Radnika).Column("ID_RADNIKA").GeneratedBy.TriggerIdentity();

            DiscriminateSubClassesOnColumn("TIP_RADNIKA");
            Map(x => x.Godina_Rodj).Column("GODINA_RODJ");
            Map(x => x.Adresa).Column("ADRESA");
            Map(x => x.Jmbg).Column("JMBG");
            Map(x => x.Prezime).Column("PREZIME");
            Map(x => x.Ime).Column("IME");
            Map(x => x.Ime_Oca).Column("IME_OCA");
            Map(x => x.Specijalnost).Column("SPECIJALNOST");
            Map(x => x.DatumPostavljanja).Column("DATUM_POSTAVLJANJA");
            Map(x => x.Id_Nadredjenog).Column("ID_NADREDJENOG");

            HasMany(x => x.UpravljaVozilima).KeyColumn("ID_IZVRSIOCA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.VozeVozila).KeyColumn("ID_NADZORNIKA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.Deonice).KeyColumn("ID_IZVRSIOCA").LazyLoad().Cascade.All().Inverse();
            HasMany(x => x.SpoljniSaradnici).KeyColumn("ID_NADZORNIKA").LazyLoad().Cascade.All().Inverse();
        
        }
    }


    public class NadredjeniMapiranja : SubclassMap<Nadredjeni>
    {
        public NadredjeniMapiranja()
        {
            DiscriminatorValue(1);

            HasMany(x => x.NadredjeniRadnik).KeyColumn("ID_NADREDJENOG").LazyLoad().Cascade.All().Inverse();

        }

    }

    public class NadzornikMapiranja : SubclassMap<Nadzornik>
    {
        public NadzornikMapiranja()
        {
            DiscriminatorValue("nadzornik");
        }
    }

    public class IzvrsilacMapiranja : SubclassMap<Izvrsilac>
    {
        public IzvrsilacMapiranja()
        {
            DiscriminatorValue("izvrsioc");


        }
    }

}
