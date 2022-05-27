using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class HourlyProduction
    {
        public int trns_id { get; set; }
        public DateTime date { get; set; }
        public bool day { get; set; }
        public bool night { get; set; }
        public string prod_shift { get; set; }
        public int plant_id { get; set; }
        public int sec_id { get; set; }
        public int sub_sec_id { get; set; }
        public int ods_id { get; set; }
        public int qnty { get; set; }
        public string commnt { get; set; }
        public int typ { get; set; }
        public Guid usr { get; set; }

        public HourlyProduction()
        {
            trns_id = 0;
            date = DateTime.Now;
            day = true;
            night = false;
            prod_shift = "DAY";
            plant_id = 0;
            sec_id = 0;
            sub_sec_id = 0;
            ods_id = 0;
            qnty = 0;
            commnt = "";
            typ = 0;
            usr = new Guid();
        }
        public DataTable Load_production_all()
        {
            {
                var objDIc = new Dictionary<string, object>();
               
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_load_production_all", objDIc);
            }
        }
        public DataTable Save_Production()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"trns_id",trns_id},
                    {"date",date},
                    {"prod_shift",prod_shift},
                    //{"night",night},
                    {"plant_id",plant_id},
                    {"sec_id",sec_id},
                    {"sub_sec_id",sub_sec_id},
                    {"ods_id",ods_id},
                    {"qnty",qnty},
                    {"commnt",commnt},
                    {"usr",usr},
                    {"typ",typ}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("_save_production", objDIc);
            }
        }
    }

}

