using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class Screenprint
    {
        public int sty_id { get; set; }
        public string sty_nme { get; set; }
        public int so_id { get; set; }
        public string so_no { get; set; }
        public string fab_color { get; set; }
        public int impress { get; set; }
        public int ups { get; set; }

        public Screenprint()
        {
            sty_id = 0;
            sty_nme = "";
            so_no = "";
            fab_color = "";
            impress =0;
            ups = 0;

        }

        public DataSet Load_spr_details()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("Spr_style", objDIc);
            }
        }

        public DataSet Load_Dashbord()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("_Secreen_print_dashbord", objDIc);
            }
        }

        public DataTable Save_spr()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"sty_id",sty_id},
                {"sty_nme",sty_nme},
                {"so_id",so_id},
                {"so_no",so_no},
                {"fab_color",fab_color},
                {"impress",impress},
                {"ups",ups}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_Spr_Save_sale_ord", objDIc);
            }
        }
    }


}
