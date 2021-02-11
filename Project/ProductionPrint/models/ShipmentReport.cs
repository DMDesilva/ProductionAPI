using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class ShipmentReport
    {

        private string Connection { get; set; }
        public ShipmentReport(string conn)
        {
            Connection = conn;
        }

        public DataTable LoadDebitCostReport()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT  [Idx],[BuyerIdx] ,[Buyer],[AWB_NoByIdx] ,[awbNo],[Freight_Cost],[Add_Cost],[Fuel_Surcharge],[Ex_wrk_Chrge],[Other_Cost],[Total_Cost],[Debit_Note_No] ,[Deb_Note_Amnt],[Difference],[Ship_wght] ,[IsActive],[CreatedDate],[Frght_Forwrd],[Cost_Sec],[mode] ,[type] FROM [dbo].[VIEW_Shipment_FreightDebit]");
        }

    }
}
