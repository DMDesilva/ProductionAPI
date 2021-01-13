using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class Sectionproduction
    {
        public int ord_Id { get; set; }
        public int plant_Id { get; set; }
        public int sec_Id { get; set; }
        public int qnty { get; set; }
        public DateTime workdate { get; set; }
        public Guid UsrId { get; set; }
        private string connection { get; set; }
    public  Sectionproduction(string Conn)
        {
            ord_Id = 0;
            plant_Id = 0;
            sec_Id = 0;
            qnty = 0;
            workdate = DateTime.Now;
            UsrId = new Guid();
            connection = Conn;
        }
        public DataTable SaveProduction()
        {

            {
                var objDIc = new Dictionary<string, object> {

                   {"ord_Id",ord_Id},
                   {"plant_Id",plant_Id},
                   {"sec_Id",sec_Id },
                   {"qnty",qnty},
                   { "workdate",workdate},
                   { "UsrId",UsrId},
            };

                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("WorkHourReport", objDIc);
            }
        }
    }
}
