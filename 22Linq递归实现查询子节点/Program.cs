using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22Linq递归实现查询子节点
{
    internal class Program
    {
        //参考：https://blog.csdn.net/smartsmile2012/article/details/81317327
        private static void Main(string[] args)
        {
            //关于Datatable中的树形结构的建立关系并查询父子节点
            //DatatableFindSons.Demo();

            //使用Linq实现
            List<Region> regions = GetSons(GetListRegion(), 5).ToList();
            regions.ForEach(n => Console.WriteLine($"Id:{n.Id},PId:{n.PId},Name:{n.Name}"));
            Console.ReadKey();
        }

        #region 获取所有下级

        /// <summary>
        /// 获取指定的节点其所有的子节点（包含指定节点本身）
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        public static IEnumerable<Region> GetSonsWithSelf(IEnumerable<Region> list, int pId)
        {
            var query = list.Where(p => p.Id == pId).ToList();
            return query.Concat(GetSons(list, pId));
        }

        /// <summary>
        /// 获取指定的节点其所有的子节点
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        public static IEnumerable<Region> GetSons(IEnumerable<Region> list, int pId)
        {
            var query = list.Where(p => p.PId == pId).ToList();
            return query.ToList().Concat(query.ToList().SelectMany(t => GetSons(list, t.Id)));
        }

        #endregion

        #region 获取所有上级

        public static IEnumerable<Region> GetFatherList(IEnumerable<Region> list, int Id)
        {
            var query = list.Where(p => p.Id == Id).ToList();
            return query.ToList().Concat(query.ToList().SelectMany(t => GetFatherList(list, t.PId)));
        }

        #endregion

        /// <summary>
        /// 树形表实体对象
        /// </summary>
        public class Region
        {
            public int Id { get; set; }
            public int PId { get; set; }
            public string Name { get; set; }
        }

        /// <summary>
        /// 模拟数据源
        /// </summary>
        /// <returns></returns>
        public static List<Region> GetListRegion()
        {
            List<Region> listRegion = new List<Region>()
            {
                new Region (){Id=1, PId=0,Name="中国"    },
                new Region (){Id=2, PId=1,Name="江苏省"  },
                new Region (){Id=3, PId=2,Name="苏州市"  },
                new Region (){Id=4, PId=3,Name="吴中区"  },
                new Region (){Id=5, PId=1,Name="山东省"  },
                new Region (){Id=6, PId=5,Name="济南市"  },
                new Region (){Id=7, PId=5,Name="青岛市"  },
                new Region (){Id=8, PId=5,Name="烟台市"  },
                new Region (){Id=9, PId=2,Name="南京市"  },
                new Region (){Id=11,PId=9,Name="玄武区"  },
                new Region (){Id=12,PId=4,Name="越溪街道"},
                new Region (){Id=13,PId=4,Name="横泾街道"}
            };
            return listRegion;
        }
    }
}
