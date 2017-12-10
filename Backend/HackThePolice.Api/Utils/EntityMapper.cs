using System.Linq;
using ExpressMapper;

namespace HackThePolice.Api.Utils
{
    public interface IEntityMapper
    {
        TDest Map<TDest>(params object[] sources) where TDest : class;
        void Map<TSrc, TDest>(TDest dest, params TSrc[] sources);
    }

    public class EntityMapper : IEntityMapper
    {
        public TDest Map<TDest>(params object[] sources) where TDest : class
        {
            if (!sources.Any())
            {
                return default(TDest);
            }
            var initialSource = sources[0];
            var mappingResult = Map<TDest>(initialSource);
            // Now map the remaining source objects
            if (sources.Count() > 1)
            {
                Map(mappingResult, sources.Skip(1).ToArray());
            }
            return mappingResult;
        }

        public void Map<TSrc, TDest>(TDest dest, params TSrc[] sources)
        {
            if (!sources.Any())
            {
                return;
            }
            var destType = dest.GetType();
            foreach (var source in sources)
            {
                Mapper.Map(source, dest, source.GetType(), destType);
            }
        }

        private TDest Map<TDest>(object source) where TDest : class
        {
            var destinationType = typeof(TDest);
            var sourceType = source.GetType();
            var mappingResult = Mapper.Map(source, sourceType, destinationType);
            return mappingResult as TDest;
        }
    }
}
