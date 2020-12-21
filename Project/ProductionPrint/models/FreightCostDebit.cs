using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class FreightCostDebit
    {
        public Guid buyerIdx { get; set; }  
        public Guid awbIdx { get; set; }
        public decimal weight { get; set; }
        public decimal frghCost { get; set; }
        public decimal addiCost { get; set; }
        public decimal fuelSurcharge { get; set; }
        public decimal exWrkChrg { get; set; }
        public decimal otherCost { get; set; }
        public decimal totalCost { get; set; }
        public string dbNtNo{ get; set; }
        public decimal dbtAmount { get; set; }
        public decimal defference { get; set; }
        public Guid CreatedBy { get; set; }
        private string Connection { get; set; }
        
        public FreightCostDebit(string conn)
        {
            buyerIdx = new Guid();
            awbIdx = new Guid();
            weight = 0;
            frghCost = 0;
            addiCost = 0;
            fuelSurcharge = 0;
            exWrkChrg = 0;
            otherCost = 0;
            totalCost = 0;
            dbNtNo = "";
            dbtAmount = 0;
            defference = 0;
            CreatedBy = new Guid();
            Connection = conn;
        }
       
        public DataTable LoadBuyerByFreght()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT DISTINCT([buyer]),[BuyerName] FROM [dbo].[VIEW_Shipment_AWB]");
        }
        public DataTable GetFreghtDebit()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT [Idx],[BuyerIdx],[Buyer] ,[AWB_NoByIdx] ,[awbNo]  ,[Freight_Cost] ,[Add_Cost],[Fuel_Surcharge] ,[Ex_wrk_Chrge] ,[Other_Cost] ,[Total_Cost],[Debit_Note_No] ,[Deb_Note_Amnt],[Difference],[Ship_wght],[IsActive],[CreatedDate] FROM [dbo].[VIEW_Shipment_FreightDebit]");
        }
        public DataTable GetFreghtDebitDtBy(string SaerchDt,string FrmDt)
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT [Idx],[BuyerIdx],[Buyer] ,[AWB_NoByIdx] ,[awbNo]  ,[Freight_Cost] ,[Add_Cost],[Fuel_Surcharge] ,[Ex_wrk_Chrge] ,[Other_Cost] ,[Total_Cost],[Debit_Note_No] ,[Deb_Note_Amnt],[Difference],[Ship_wght],[IsActive],[CreatedDate] FROM [dbo].[VIEW_Shipment_FreightDebit] where CONVERT(DATE,[CreatedDate]) between '" + FrmDt.ToString() + "' and '" + SaerchDt.ToString() + "'");
        }
        public DataTable Save_FreightDebit()
        {
            {
                var objDIc = new Dictionary<string, object> {

                    { "buyerIdx",buyerIdx},
                    { "awbIdx",awbIdx},
                    { "weight",weight},
                    { "frghCost",frghCost},
                    { "addiCost",addiCost},
                    { "fuelSurcharge",fuelSurcharge},
                    { "exWrkChrg",exWrkChrg},
                    { "otherCost",otherCost},
                    { "totalCost",totalCost},
                    { "dbNtNo",dbNtNo},
                    { "dbtAmount",dbtAmount},
                    { "defference",defference},
                    { "CreatedBy",CreatedBy}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_Freight_Debit", objDIc);
            }
        }
    }
}
