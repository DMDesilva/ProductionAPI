using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductionPrint.models;

namespace ProductionPrint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentApiController : ControllerBase
    {
        [HttpGet("loadAllAWBNo")]
        public DataTable LoadAllAWBNo()
        {
            Shipment shps = new Shipment(CommonData.ConStr());
            return shps.GetAllAWB();
        }
        [HttpGet("loadAllData")]
        public DataSet LoadAllData()
        {
            Shipment shps = new Shipment(CommonData.ConStr());
            return shps.LoadData();
        }

        [HttpPost("masterModeadd")]
        public DataTable MasterModeadd(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.MastModeAdd();
        }
        [HttpPost("masterCountryadd")]
        public DataTable MasterCountryadd(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.MastCountryAdd();
        }

        [HttpPost("masterSuppBuyeradd")]
        public DataTable MasterSuppBuyeradd(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.MastSuppBuyerAdd();
        }
        [HttpPost("mastSuppBuyerDelete")]
        public DataTable MasterSuppBuyerDelete(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.MastSuppBuyerDelete();
        }
        [HttpPost("masterFreightadd")]
        public DataTable MasterFreightadd(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.MastFreightAdd();
        }

        [HttpPost("masterMerchadd")]
        public DataTable MasterMerchadd(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.MastMerchAdd();
        }

        [HttpPost("masterCostSecadd")]
        public DataTable MasterCostSecadd(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.MastCostSecAdd();
        }

        [HttpPost("masterBuyeradd")]
        public DataTable MasterBuyeradd(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.MastBuyerAdd();
        }
        //
        [HttpPost("save_AWBDetails")]
        public DataTable Save_AWBDetails(Shipment shps)
        {
            //Shipment shps = new Shipment(CommonData.ConStr());
            return shps.Save_AWB();
        }
        
        [HttpGet("getAWBLoad")]
        public DataTable GetAWBLoad()
        {
           Shipment shps = new Shipment(CommonData.ConStr());
            return shps.GetAWB();
        }
        
        [HttpGet("getAllInvoice")]
        public DataSet getAllInvoice()
        {
            Shipment shps = new Shipment(CommonData.ConStr());
            return shps.GetAllInvoice();
        }
        [HttpPost("gettAWBFilterLoad")]
        public DataTable GetAWBFilterLoad(ClsPrm prm)
        {
            Shipment shps = new Shipment(CommonData.ConStr());
            return shps.GetAWBFilter(prm.gPram1);
        }
        [HttpPost("getAWBDetasDtBy")]
        public DataTable GetAWBDetasDtBy(ClsPrm prm)
        {
            Shipment shps = new Shipment(CommonData.ConStr());
            return shps.GetAWBDetailsDateBy(prm.stPram1,prm.stPram2);
        }
        //------------------Freight Forword----------------
        [HttpGet("getFrightByAwb")]
        public DataTable GetFrightByAwb()
        {
            Shipment shps = new Shipment(CommonData.ConStr());
            return shps.GetFrieghtByAwb();
        }
        [HttpGet("getAwbDetails")]
        public DataTable GetAwbDetails()
        {
            Shipment shps = new Shipment(CommonData.ConStr());
            return shps.GetAWBDetails();
        }
        [HttpPost("save_FreightInv")]
        public DataTable Save_FreightInv(freightInvoice frght)
        {
            //freightInvoice frght = new freightInvoice(CommonData.ConStr());
            return frght.Save_FreightInv();
        }
        [HttpPost("getFreightInvDateBy")]
        public DataTable GetFreightInvDateBy(ClsPrm prm)
        {
            freightInvoice frght = new freightInvoice(CommonData.ConStr());
            return frght.GetFreiInvDateBy(prm.stPram1, prm.stPram2);
        }
        [HttpGet("getFrightInv")]
        public DataTable GetFrightInv()
        {
            freightInvoice frght = new freightInvoice(CommonData.ConStr());
            return frght.GetFreiInv();
        }

        //------------Freight Debit----------
        [HttpGet("getBuyer")]
        public DataTable GetBuyer()
        {
            FreightCostDebit frghtDbt = new FreightCostDebit(CommonData.ConStr());
            return frghtDbt.LoadBuyerByFreght();
        }
        [HttpPost("save_FreightDebit")]
        public DataTable Save_FreightDebit(FreightCostDebit frghtDbt)
        {
            //FreightCostDebit frghtDbt = new FreightCostDebit(CommonData.ConStr());
            return frghtDbt.Save_FreightDebit();
        }
        [HttpGet("getFreightDebitData")]
        public DataTable GetFreightDebitData()
        {
            FreightCostDebit frghtDbt = new FreightCostDebit(CommonData.ConStr());
            return frghtDbt.GetFreghtDebit();
        }
        [HttpPost("getFreightDebitDataByDate")]
        public DataTable GetFreightDebitDataByDate(ClsPrm prm)
        {
            FreightCostDebit frghtDbt = new FreightCostDebit(CommonData.ConStr());
            return frghtDbt.GetFreghtDebitDtBy(prm.stPram1, prm.stPram2);
        }


      
        [HttpGet("getPayAccount")]
        public DataTable GetPayAccount()
        {
            PaymentRelese payment = new PaymentRelese(CommonData.ConStr());
            return payment.LoadPayAccount();
        }

      
        [HttpPost("savePaymentRelese")]
        public DataTable SavePaymentRelese(PaymentRelese payment)
        {
         //   PaymentRelese payment = new PaymentRelese(CommonData.ConStr());
            return payment.SavePaymentRelese();

        }


        //Report View ----------------------------

        [HttpGet("getDebitCostReport")]
        public DataTable GetDebitCostReport()
        {
            ShipmentReport rprt = new ShipmentReport(CommonData.ConStr());
            return rprt.LoadDebitCostReport();
        }

    }
}