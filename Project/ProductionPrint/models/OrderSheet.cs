using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class OrderSheet
    {
        public int ods_id { get; set; }

        public OrderSheet()
        {
            ods_id = 0;
        }

        public DataSet ViewOrdersheet()
        {
            {
                var objDIc = new Dictionary<string, object> {

                    {"ods_id",ods_id}
                };
                var dt = new DataSet();
                dt = (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("_order_sheet_details", objDIc);

                //DataTable ds = new DataTable();
                //ds= dt.Tables[3];
                //string[] myary= new string[ds.Rows.Count];
                //for (int i = 0; i < ds.Rows.Count; i++)
                //{
                //    myary[i] = ds.Rows[i][columnIndex:i].ToString();
                //}

                //             //   var myary = ds; select * from dbo.load_view_mercha_poprod
                //    Console.WriteLine(myary);
                //for (int i = 0; i < myary.Length; i++)
                //{
                //    if (!myary[i].Equals(string.Empty))
                //    {
                //        string[] Arry = myary[i].Split('/');
                //        dt.Tables["Table3"].Rows.Add(Arry[0].Trim(), Arry[1].Trim());

                //    }
                //}

                return dt;
            }
        }

        public DataTable GetOrderpo()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("select ods_id ,CONCAT(po_no,' - ',product_no) as po from dbo.load_view_mercha_poprod");
        }
    }
}
