using Core.DTO_s;
using Core.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.ItemsMapping
{
    public class MappingProfile
    {
        // TypeAdapterConfig => the Global configuration in Mapsetr that help me to configur and manage the mapping rolls between the models and dto's 
        public static readonly TypeAdapterConfig config = new TypeAdapterConfig();

        static MappingProfile()
        {
            config.NewConfig<Items, ItemsDTO>()
                .Map(des => des.ItemUnits, src => src.ItemsUnits.Select(iu => iu.Units.Name).ToList())
                .Map(des => des.Stores, src => src.InvItemStores.Select(store => store.Stores.Name).ToList());
            // becaue i have the relations in the endpoint to take itemUnit name and storeName we need to use this way
            // here we need for 2 things , first destination to access on ItesmDTO attributes 
            // second Sourse and here we need to do the relation to access on the name of stroe and unit
        }
    }
}
