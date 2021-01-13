using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class DesignerWrkSheet
    {
        public int ods_Id { get; set; }
        public Guid userId { get; set; }
        public DateTime wrkDate { get; set; }
        public decimal plength { get; set; }
        public string comment { get; set; }
        private string connection { get; set; }

        public DesignerWrkSheet()
        {
            ods_Id = 0;
            userId = new Guid();
            wrkDate = DateTime.Now;
            plength = 0;
            comment = "";
        }

        public DataTable SaveDesignWrkSheet()
        {
            {
                var objDIc = new Dictionary<string, object>
                {
                    {"ods_Id",ods_Id},
                    {"userId",userId},
                    {"wrkDate",wrkDate},
                    {"plength",plength},
                    {"comment",comment}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("SaveDesignWrkSheet", objDIc);
            }
        }
    }
}
