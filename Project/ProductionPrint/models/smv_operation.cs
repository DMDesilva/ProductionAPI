using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class smv_operation
    {
        public int id { get; set; }
        public string op_name { get; set; }
        public Guid pttn_idx { get; set; }
        public decimal totl_smv { get; set; }
        public decimal chking { get; set; }
        public decimal irn { get; set; }
        public decimal pcking { get; set; }
        public decimal totl_fnsh { get; set; }
        public decimal cal_smv { get; set; }
        public decimal add_smv { get; set; }
        public decimal grmnt_smv { get; set; }
        public List<smvop> smvop { get; set; }
        public Guid usr { get; set; }
        private string connection { get; set; }
        public smv_operation(string conn)
        {
            id = 0;
            op_name = "";
            pttn_idx = new Guid();
            totl_smv = 0;
            chking = 0;
            irn = 0;
            pcking = 0;
            totl_fnsh = 0;
            cal_smv = 0;
            add_smv = 0;
            grmnt_smv = 0;
            smvop = new List<smvop>();
            usr = new Guid();
            connection = conn;
        }

        public DataTable LoadOperation()
        {
            {
            
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [id] ,[op_name] ,[isActive], 0 as smv,0 as mtype,0 as foot, 0 as att1,0 as att2,'' as remk  FROM [dbo].[_Merchandiser_MAST_SMV_operation]");
            }
        }

        public DataSet Load_MAST_Type()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("_Get_Merch_MAST_SMVData", objDIc);
            }
        }

        public DataTable Save_SMV_OP_dt()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"pttn_idx",pttn_idx},
                {"totl_smv",totl_smv},
                {"chking",chking},
                {"irn",irn},
                {"pcking",pcking},
                {"totl_fnsh",totl_fnsh},
                {"cal_smv",cal_smv},
                {"add_smv",add_smv},
                {"grmnt_smv",grmnt_smv},
                {"smvop",new smvop("").InvItemListToDataTable(smvop)},
                {"usr",usr}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Save_smv_op_details", objDIc);
            }
        }

    }

    public class smvop
    {
        public int id { get; set; }
        public int mtype { get; set; }
        public decimal foot { get; set; }
        public int att1 { get; set; }
        public int att2 { get; set; }
        public string op_name { get; set; }
        public decimal smv { get; set; }
        public string remk { get; set; }

        public smvop(string v)
        {
            id = 0;
            mtype = 0;
            foot = 0;
            att1 = 0;
            att2 = 0;
            op_name = "";
            smv = 0;
            remk = "";
        }
        public DataTable InvItemListToDataTable(List<smvop> lst)
        {
            var dt1 = new DataTable();
            dt1.Clear();
            dt1.Columns.Add("id", typeof(int));
            dt1.Columns.Add("mtype", typeof(int));
            dt1.Columns.Add("foot", typeof(decimal));
            dt1.Columns.Add("att1", typeof(int));
            dt1.Columns.Add("att2", typeof(int));
            dt1.Columns.Add("op_name", typeof(string));
            dt1.Columns.Add("smv", typeof(decimal));
            dt1.Columns.Add("remk", typeof(string));
          


            foreach (var item in lst)
            {

                DataRow _plan = dt1.NewRow();
                _plan["id"] = item.id;
                _plan["mtype"] = item.mtype;
                _plan["foot"] = item.foot;
                _plan["att1"] = item.att1;
                _plan["att2"] = item.att2;
                _plan["op_name"] = item.op_name;
                _plan["smv"] = item.smv;
                _plan["remk"] = item.remk;

                dt1.Rows.Add(_plan);
            }
            return dt1;
        }
    }
}
