using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22Linq递归实现查询子节点
{
    public static class DatatableFindSons
    {
        public static void Demo()
        {
            DataTable dtRegion = GetDtRegion();

            DataSet ds = new DataSet();
            ds.Tables.Add(dtRegion);

            //DataSet的Relations属性主要是用于建立主子表关系，这里我们将一张树形结构的表建立自连接
            ds.Relations.Add("TreeRelation", ds.Tables[0].Columns["Id"], ds.Tables[0].Columns["PId"], false);

            //获取指定的节点的所有下一级子节点（注意根据我们的关联关系，我们只能查找到一个节点的所有二级节点）
            DataRow[] drSons = dtRegion.Select("Name='中国'")[0].GetChildRows("TreeRelation");
            DataRow[] drParents = dtRegion.Select("Name='越溪街道'")[0].GetParentRows("TreeRelation");

            //使用递归获取江苏省节点下的所有子节点
            List<DataRow> listDr = GetSons(dtRegion.Select("Name='江苏省'")[0]);
            List<DataRow> listDra = GetParents(dtRegion.Select("Name='越溪街道'")[0]);

            listDr.ForEach(n => Console.WriteLine($"Id:{n["Id"]},PId:{n["PId"]},Name:{n["Name"]}"));
            Console.WriteLine("---------------");
            listDra.ForEach(n => Console.WriteLine($"Id:{n["Id"]},PId:{n["PId"]},Name:{n["Name"]}"));
        }

        /// <summary>
        /// 广度遍历：获取指定的父节点的所有层级的子节点
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static List<DataRow> GetSons(DataRow dr)
        {
            List<DataRow> drSons = dr.GetChildRows("TreeRelation").ToList();
            List<DataRow> result = new List<DataRow>(drSons);
            foreach (DataRow row in drSons)
            {
                result.AddRange(GetSons(row));
            }
            return result;
        }

        /// <summary>
        /// 获取指定的节点的所有上级父节点
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static List<DataRow> GetParents(DataRow dr)
        {
            List<DataRow> drParents = dr.GetParentRows("TreeRelation").ToList();
            List<DataRow> result = new List<DataRow>(drParents);
            foreach (DataRow row in drParents)
            {
                result.AddRange(GetParents(row));
            }
            return result;
        }

        /// <summary>
        /// 创建测试数据
        /// </summary>
        /// <returns></returns>
        private static DataTable GetDtRegion()
        {
            //建表
            DataTable dtRegion = new DataTable("Region");
            //建列
            DataColumn dcId = new DataColumn("Id", typeof(int));
            DataColumn dcPId = new DataColumn("PId", typeof(int));
            DataColumn dcName = new DataColumn("Name", typeof(string));
            DataColumn[] aryDc = { dcId, dcPId, dcName };
            dtRegion.Columns.AddRange(aryDc);
            //设置主键
            //dcId.AllowDBNull = false;
            //dtRegion.PrimaryKey = new DataColumn[] { dcId };
            dtRegion.Rows.Add(new object[] { "1", "0", "中国" });
            dtRegion.Rows.Add(new object[] { "2", "1", "江苏省" });
            dtRegion.Rows.Add(new object[] { "3", "2", "苏州市" });
            dtRegion.Rows.Add(new object[] { "4", "3", "吴中区" });
            dtRegion.Rows.Add(new object[] { "5", "1", "山东省" });
            dtRegion.Rows.Add(new object[] { "6", "5", "济南市" });
            dtRegion.Rows.Add(new object[] { "7", "5", "青岛市" });
            dtRegion.Rows.Add(new object[] { "8", "5", "烟台市" });
            dtRegion.Rows.Add(new object[] { "9", "2", "南京市" });
            dtRegion.Rows.Add(new object[] { "11", "9", "玄武区" });
            dtRegion.Rows.Add(new object[] { "12", "4", "越溪街道" });
            dtRegion.Rows.Add(new object[] { "13", "4", "横泾街道" });
            return dtRegion;
        }
    }
}
