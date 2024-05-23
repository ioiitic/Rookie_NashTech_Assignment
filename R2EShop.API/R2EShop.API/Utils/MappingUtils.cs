using MapsterMapper;
using System.Drawing.Text;

namespace R2EShop.API.Utils
{
    public static class MappingUtils
    {
        public static IList<TDes> MapList<TDes, TSrc>(IList<TSrc> list, IMapper mapper)
        {
            return list.Select(T => mapper.Map<TDes>(T)).ToList();
        }
    }
}
