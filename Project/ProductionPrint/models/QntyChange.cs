using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class QntyChange
    {
        public string po_no { get; set; }
        public int qnty { get; set; }
        public int design_id { get; set; }
        public int subli_cat_id { get; set; }
        private string connection { get; set; }

        public QntyChange(string conn)
        {
            po_no = "";
            qnty = 0;
            design_id = 0;
            subli_cat_id = 0;
            connection = conn;
        }
        public DataSet LoadSubCat()
        {
            {
                var objDIc = new Dictionary<string, object>();
           
            return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("LoadProductSubCat", objDIc);
             }
        }
        public DataTable ChangeQnty()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"po_no",po_no},
                   {"qnty",qnty}

            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Change_Qnty", objDIc);
            }
        }

        public DataTable SaveSubliCat()
        {
            {
                var objDIc = new Dictionary<string, object> {

                   {"design_id",design_id},
                   {"subli_cat_id",subli_cat_id}

            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Save_SubliCat", objDIc);
            }
        }
    }
}
