using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class Bincard
    {
        public int sb_itm_id { get; set; }


        public Bincard()
        {
            sb_itm_id = 0;
        }
        public DataTable LoadItems()
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT itm_id,CONCAT(sup_item_code,'  -  ' ,sup_item_nme) as itmnms , sup_item_code,sup_item_nme FROM [erpWarehouse].[dbo].[itm_lgr_transa_stock] WHERE (isdeleted = 0) AND (actve = 1)  order by itm_id");
            }
        }

        public DataTable LoadSubItems(int itm_id)
        {
            {
                //var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT sb_itm_id, word FROM  [erpWarehouse].[dbo].[load_view_itmsub] WHERE  (itm_id= '"+ itm_id.ToString()+ "')");
            }
        }

        public DataSet LoadBincard(int sb_itm_id)
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                     {"sb_itm_id",sb_itm_id}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("load_bincard", objDIc);

            }
        }

     


    }
}
