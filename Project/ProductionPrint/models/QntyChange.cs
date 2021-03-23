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
        private string connection { get; set; }

        public QntyChange(string conn)
        {
            po_no = "";
            qnty = 0;
            connection = conn;
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
    }
}
