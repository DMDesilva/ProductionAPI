using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class Items
    {
        public Guid idx { get; set; }
        public Guid typ_idx { get; set; }
        public Guid itm_idx { get; set; }
        public string itm_name { get; set; }
        public string sub_itm_name { get; set; }
        public string type_name { get; set; }
        public decimal machin_smv { get; set; }
        public string descr { get; set; }
        public string description { get; set; }
        public int typ { get; set; }

        public Items()
        {
            idx = new Guid();
            typ_idx = new Guid();
            itm_idx = new Guid();
            itm_name = "";
            sub_itm_name = "";
            type_name = "";
            machin_smv = 0;
            descr = "";
            description = "";
            typ =0;

        }

        public DataTable Save_Itms()
        {
            {
                var objDIc = new Dictionary<string, object> {
                {"itm_name",itm_name},
                {"typ_idx",typ_idx},
                {"sub_itm_name",sub_itm_name},
                {"type_name",type_name},
                {"machin_smv",machin_smv},               
                {"itm_idx",itm_idx},
                {"description",description},
                {"descr",descr},
                {"typ",typ}
            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Merchandiser_itms", objDIc);
            }
        }
    }
}
