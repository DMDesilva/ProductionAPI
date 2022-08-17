using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class freightInvoice
    {
        public Guid idx{ get; set; }
        public Guid freightforwd { get; set; }
        public string freightInv { get; set; }
        public DateTime InvDate { get; set; }
        public Guid awbIdx { get; set; }
        public decimal weight { get; set; }
        public decimal frghCost { get; set; }
        public decimal addiCost { get; set; }
        public decimal fuelSurcharge { get; set; }
        public decimal exWrkChrg { get; set; }
        public decimal otherCost { get; set; }
        public decimal totalCost { get; set; }
        public Guid CreatedBy { get; set; }
        public int uptyp { get; set; }
       
        private string Connection { get; set; }

        public freightInvoice(string conn)
        {
            idx = new Guid();
            freightforwd = new Guid();
            freightInv = "";
            InvDate = DateTime.Now;
            awbIdx = new Guid();
            weight = 0;
            frghCost = 0;
            addiCost = 0;
            fuelSurcharge = 0;
            exWrkChrg = 0;
            otherCost = 0;
            totalCost = 0;
            CreatedBy = new Guid();
            uptyp = 0;
            Connection = conn;
        }

        public DataTable Save_FreightInv()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"idx",idx},
                    {"freightforwd",freightforwd},
                    {"freightInv",freightInv},
                    {"InvDate",InvDate},
                    {"awbIdx",awbIdx},
                    {"weight",weight},
                    {"frghCost",frghCost},
                    {"addiCost",addiCost},
                    {"fuelSurcharge",fuelSurcharge},
                    {"exWrkChrg",exWrkChrg},
                    {"otherCost",otherCost},
                    {"totalCost",totalCost},
                    {"CreatedBy",CreatedBy},
                    {"uptyp",uptyp}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_FreightInv", objDIc);
            }
        }

        public DataTable GetFreiInv()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT  [Idx],[AWBFreForwrdIdx] ,[Frght_Forwrd]  ,[Frwrd_InvNo] ,[InvDate],[AWB_No],[awbNo],[Ship_wght],[FCost] ,[AddCost] ,[Fuel_Surcharge],[Ex_wrk_Chrg] ,[Othr_Cost],[Totalcost],[IsActive],[AWBIsAc] FROM [dbo].[VIEW_Shipment_FreightInvoice] order by  [InvDate] DESC");

        }
        public DataTable GetFreiInvDateBy(string SrchDt , string FrmDt)
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT  [Idx],[AWBFreForwrdIdx] ,[Frght_Forwrd]  ,[Frwrd_InvNo] ,[InvDate],[AWB_No],[awbNo],[Ship_wght],[FCost] ,[AddCost] ,[Fuel_Surcharge],[Ex_wrk_Chrg] ,[Othr_Cost],[Totalcost],[IsActive] FROM [dbo].[VIEW_Shipment_FreightInvoice] where CONVERT(date,[InvDate]) between '" + FrmDt.ToString() + "' and '" + SrchDt.ToString()+ "' order by  [InvDate] DESC ");

        }
    }
}
