using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class DevelopmentDeprtment
    {
        public int pattern_id { get; set; }
        public List<fabric> fabric { get; set; }
        public Guid usr { get; set; }
        private string connection { get; set; }

        public DevelopmentDeprtment(string conn)
        {
            pattern_id = 0;
            fabric = new List<fabric>();
            usr = new Guid();
            connection = conn; 
        }
        public DataTable LoadingPatten()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [pattern_id] ,CONCAT( [pattern_name],' - ',[pattern_description]) as pttn FROM [dbo].[develp_master_pattern] where [isdeleted]=0");
            }
        }
        public DataSet LoadAllData()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("LoadPttnAndFab", objDIc);

            }
        }
        public DataSet LoadFabByPttn()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("FabConsumBypttn", objDIc);

            }
        }
        public DataTable SaveFabConsum()
        {
            {
                var objDIc = new Dictionary<string, object> {

                    {"pattern_id",pattern_id},
                    {"fabric",new fabric("").InvItemListToDataTable(fabric) },
                    {"usr",usr},

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveFabConsumByPttn", objDIc);

            }
        }

        public DataTable LoadFabForPO()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("LoadForFabCon", objDIc);

            }
        }
    }

    public class fabric
    {
        public int itm_id { get; set; }
        public string sup_item_code { get; set; }
        public decimal consum { get; set; }
        public string sup_item_nme { get; set; }
       
        public fabric(string v)
        {
            itm_id = 0;
            sup_item_code = "";
            consum = 0;
            sup_item_nme = "";
        }
        public DataTable InvItemListToDataTable(List<fabric> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("itm_id", typeof(int));
            dt1.Columns.Add("sup_item_code", typeof(string));
            dt1.Columns.Add("consum", typeof(decimal));
            dt1.Columns.Add("sup_item_nme", typeof(string));


            foreach (var item in lst)
            {

                DataRow _plan = dt1.NewRow();
                _plan["itm_id"] = item.itm_id;
                _plan["sup_item_code"] = item.sup_item_code;
                _plan["consum"] = item.consum;
                _plan["sup_item_nme"] = item.sup_item_nme;
                //  _plan["NewNic"] = item.NewNic;




                dt1.Rows.Add(_plan);
            }
            return dt1;
        }

    }


}
