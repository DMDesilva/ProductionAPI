using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class FreeCostSheet
    {

        private string connection { get; set; }

        public FreeCostSheet(string conn)
        {
            connection = conn;
        }

        public DataTable Get_Cttn_Fab()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [idx],[_option],[_hieght],[_area],[_strokes] ,[_imp],[_ttl_ink_us],[_width],[_ink_us_per_imp] FROM [PRO-SPR].[dbo].[_spr_cst_rel_cttn_fab]");
        }
        public DataTable Get_Cttn_Fab_Anti()
        {
            return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [idx],[_option],[_hieght],[_area],[_strokes] ,[_imp],[_ttl_ink_us],[_width],[_ink_us_per_imp] FROM [PRO-SPR].[dbo].[_spr_cst_rel_cttn_fab_anti]");
        }
    }
}
