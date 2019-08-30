using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonsOperations.Mappers
{
    public class MapperConfigurationCentral<T, T1>
                                                  where T : class, new()
                                                  where T1 : class, new()
    {

        private static MapperConfiguration configMap;

        public static IMapper Mapper()
        {
            configMap = new MapperConfiguration(cfg => cfg.CreateMap<T, T1>());
            return configMap.CreateMapper();
        }

        public static IReadOnlyList<T1> MapList(IReadOnlyList<T> obj)
        {
            return Mapper().Map<IReadOnlyList<T>, IReadOnlyList<T1>>(obj);
        }

        public static List<T1> MapListList(List<T> obj)
        {
            return Mapper().Map<List<T>, List<T1>>(obj);
        }

        public static T1 MapEntity(T obj)
        {
            return Mapper().Map<T1>(obj);
        }

        public static IMapper MapperCustomer(MapperConfiguration conf)
        {
            configMap = conf;

            return configMap.CreateMapper();
        }

        public static T1 MapEntityCustomer(T obj, MapperConfiguration conf)
        {
            return MapperCustomer(conf).Map<T1>(obj);
        }

        public static IReadOnlyList<T1> MapListCustomer(IReadOnlyList<T> obj, MapperConfiguration conf)
        {
            return MapperCustomer(conf).Map<IReadOnlyList<T>, IReadOnlyList<T1>>(obj);

        }
        public static List<T1> MapListCustomerList(List<T> obj, MapperConfiguration conf)
        {
            return MapperCustomer(conf).Map<List<T>, List<T1>>(obj);
        }


    }
}
