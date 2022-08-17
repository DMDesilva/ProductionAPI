using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class Shipment
    {
        public Guid idx { get; set; }
        public DateTime shipdate { get; set; }
        public int typ { get; set; }
        public string mode { get; set; }
        public Guid modeId { get; set; }
        public int IsActive { get; set; }
        public Guid mrchndisrId { get; set; }
        public string mrchndisr { get; set; }
        public int gender { get; set; }
        public Guid frght_ForwrdId { get; set; }
        public string frght_Forwrd { get; set; }
        public Guid CountryId { get; set; }
        public string Country { get; set; }
        public Guid SuppOrBuyId { get; set; }
        public string SuppOrBuy{ get; set; }
        public Guid buyerId { get; set; }
        public string buyer { get; set; }
        public Guid Cost_SecId { get; set; }
        public string Cost_Sec { get; set; }
        public string awbNo { get; set; }
        public string InvNo { get; set; }
        public string remark { get; set; }
        public Guid CreatedBy { get; set; }
        private string Connection { get; set; }
        public int uptyp { get; set; }
        public Shipment(string Conn)
        {
            idx= new Guid();
            shipdate = DateTime.Now;
            typ = 0;
            mode = "";
            modeId = new Guid();
            IsActive = 0;
            mrchndisrId =new Guid();
            mrchndisr = "";
            gender = 0;
            frght_ForwrdId = new Guid();
            frght_Forwrd = "";
            Connection = Conn;
            CountryId = new Guid();
            Country = "";
            SuppOrBuyId = new Guid();
            SuppOrBuy = "";
            Cost_SecId = new Guid();
            Cost_Sec = "";
            awbNo = "";
            InvNo = "";
            buyerId = new Guid();
            buyer = "";
            remark = "";
            CreatedBy = new Guid();
            uptyp = 0;
        }

        public DataSet LoadData()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("LoadShipment", objDIc);
            }
        }
        
        public DataTable GetAllAWB()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT [awbNo] FROM [dbo].[Ex_Im_Shipment_AWB_Details]");
        }
        public DataTable MastModeAdd()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"mode",mode}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_MAST_Mode", objDIc);
            }
        }
        public DataTable MastCountryAdd()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"country",Country}
                    
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_MAST_Contry", objDIc);
            }
        }
        
        public DataTable MastSuppBuyerAdd()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"SuppOrBuy",SuppOrBuy},
                    {"CountryId",CountryId}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_MAST_SuppBuyer", objDIc);
            }
        }
        public DataTable MastSuppBuyerDelete()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"Idx",SuppOrBuyId}
                   // {"CountryId",CountryId}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("ShipmentMaster_Delete", objDIc);
            }
        }
        public DataTable MastFreightAdd()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"Freight",frght_Forwrd}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_MAST_Freight", objDIc);
            }
        }

        public DataTable MastMerchAdd()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"mrchndisr",mrchndisr},
                    {"gender",gender}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_MAST_Merch", objDIc);
            }
        }

        public DataTable MastCostSecAdd()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"Cost_Sec",Cost_Sec}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_MAST_CostSec", objDIc);
            }
        }
        public DataTable MastBuyerAdd()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"Buyer",buyer }
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_MAST_Buyer", objDIc);
            }
        }
        public DataTable Save_AWB()
        {
            {
                var objDIc = new Dictionary<string, object> {
                    {"idx",idx},
                    {"shipdate",shipdate},
                    { "typ",typ},
                    { "modeId",modeId},
                    { "SuppOrBuyId",SuppOrBuyId},
                    { "CountryId",CountryId},
                    { "frght_ForwrdId",frght_ForwrdId},
                    { "awbNo",awbNo},
                    { "InvNo",InvNo},
                    { "mrchndisrId",mrchndisrId},
                    { "Cost_SecId",Cost_SecId},
                    { "buyerId",buyerId},
                    { "remark",remark},
                    { "CreatedBy",CreatedBy},
                    { "uptyp",uptyp}
                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Shipment_AWB_Save", objDIc);
            }
        }
        public DataTable GetAWB() 
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT  [Idx],[awbNo],[Shipdate],[type],[suppBuy],[SuppOrBuy] ,[SuppBuyCntry],[county],[fforwrdIdx],[Frght_Forwrd] ,[ExIm_Inv_No],[merchandiser] ,[mrchndisr],[costSec] ,[Cost_Sec],[remark],[modeId] ,[mode],[IsActive],[buyer],[BuyerName] FROM [dbo].[VIEW_Shipment_AWB]");
        }
        public DataTable GetAWBFilter(Guid FrgtIdx)
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT  [Idx],[awbNo],[Shipdate],[type],[suppBuy],[SuppOrBuy] ,[SuppBuyCntry],[county],[fforwrdIdx],[Frght_Forwrd] ,[ExIm_Inv_No],[merchandiser] ,[mrchndisr],[costSec] ,[Cost_Sec],[remark],[modeId] ,[mode],[IsActive],[buyer],[BuyerName] FROM [dbo].[VIEW_Shipment_AWB] where [fforwrdIdx]='"+ FrgtIdx.ToString()+ "' and [IsActive]=1 or [IsActive]=3");
        }
        public DataTable GetAWBDetails()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT [Idx],[awbNo],[Shipdate],[type] ,[suppBuy] ,[SuppOrBuy] ,[SuppBuyCntry],[county],[fforwrdIdx] ,[Frght_Forwrd]  ,[ExIm_Inv_No]  ,[merchandiser] ,[mrchndisr] ,[costSec] ,[Cost_Sec]  ,[remark],[modeId] ,[mode],[buyer] ,[BuyerName],[IsActive] FROM [dbo].[VIEW_Shipment_AWB] where [IsActive]=1 order by Shipdate desc");
        }

        public DataTable GetAWBDetailsDateBy(string SrchDt,string FrmDt)
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT [Idx],[awbNo],[Shipdate],[type] ,[suppBuy] ,[SuppOrBuy] ,[SuppBuyCntry],[county],[fforwrdIdx] ,[Frght_Forwrd]  ,[ExIm_Inv_No]  ,[merchandiser] ,[mrchndisr] ,[costSec] ,[Cost_Sec]  ,[remark],[modeId] ,[mode],[buyer] ,[BuyerName],[IsActive] FROM [dbo].[VIEW_Shipment_AWB] where [IsActive]=1 and CONVERT(date,[Shipdate]) between '" + FrmDt.ToString() + "' and '" + SrchDt.ToString()+ "' ");
        }
        //-------------------------------freight forword---------
        public DataTable GetFrieghtByAwb()
        {
            return (new DbAccess(Connection)).FillDataTable("SELECT DISTINCT([fforwrdIdx]) ,[Frght_Forwrd] FROM [ORACLE].[dbo].[VIEW_Shipment_AWB] where [IsActive]=1 OR [IsActive]=3");
        }
  
      
        public DataSet GetAllInvoice()
        {
            {
                var objDIc = new Dictionary<string, object>();
                return (new DbAccess(CommonData.ConStr())).LoadDataSetBySP("AllInvBill", objDIc);
            }
        }

    }

}
