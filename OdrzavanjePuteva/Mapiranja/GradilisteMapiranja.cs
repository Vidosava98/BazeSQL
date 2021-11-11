using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using OdrzavanjePuteva.Entiteti;

namespace OdrzavanjePuteva.Mapiranja
{
    class GradilisteMapiranja : ClassMap<Gradiliste>
    {
        public GradilisteMapiranja()
        {

            //Mapiranje tabele
            Table("GRADILISTE");

            //mapiranje primarnog kljuca
            Id(x => x.IdGradilista, "ID_GRADILISTA").GeneratedBy.TriggerIdentity();//.UnsavedValue(-1);

            //mapiranje svojstava
            Map(x => x.TipGradilista, "TIP_GRADILISTA");

            //mapiranje 1:N
            HasMany(x => x.Deonice).KeyColumn("ID_GRADILISTA").LazyLoad().Cascade.All().Inverse();
        }

    }
}
