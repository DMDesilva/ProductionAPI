using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class SectionProductionOut
    {
        private string Connection { get; set; }


        public SectionProductionOut(string conn)
        {
            Connection = conn;
        }

        public DataSet GetProduction()
        {
            {
                var objDIc = new Dictionary<string, object>();

                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("GetPlanInfo", objDIc);
            }

        }



    }
}
