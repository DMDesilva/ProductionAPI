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
    public class ProductPrintApiController : ControllerBase
    {
        [HttpGet("printDash")]
        public DataTable PrintDashboard()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.PrintDash();
        }
        [HttpGet("GetPlants")]
        public DataTable GetPlants()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadPlants();
        }


        [HttpGet("getPrintOrdList")]
        public DataSet GetPrintOrdList()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadPrintOrderList();
        }


        [HttpGet("getRooms")]
        public DataTable GetRooms()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadRooms();
        }
       
        [HttpPost("getAssignMachine")]
        public DataTable GetAssignMachine(ClsPrm prm)
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadAssignMachine(prm.iPram1);
        }
        //
        [HttpPost("getMachine")]
        public DataTable GetMachine(ClsPrm prm)
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadMachine(prm.iPram1);
        }
        [HttpPost("disableMachine")]
        public DataTable DisableMachine(ProductPrint pro)
        {
           // ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.DisableMach();
        }
        [HttpGet("loadUserGrps")]
        public DataTable LoadUserGrps()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadUserGrp();
        }

        [HttpGet("GetPRintMachine")]
        public DataTable GetPRintMachine()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadPRintMachine();
        }
        
        [HttpGet("GetPrinterOption")]
        public DataTable GetPrinterOption()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadPrintOption();
        }

        [HttpGet("GetProdData")]
        public DataTable GetProdData()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadProdData();
        }

        [HttpGet("GetPrintprodHistry")]
        public DataTable GetPrintprodHistry()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadPrintProdHisrty();
        }

        [HttpPost("SearchData")]
        public DataTable SearchData(ClsPrm prm)
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.SaerchPrdDt(prm.stPram1);
        }
        //LoadOrdersDt
        [HttpPost("GetProdDt")]
        public DataTable GetProdDt(ClsPrm prm)
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadOrdersDt(prm.DtPram1);
        }
        //
        [HttpGet("getPrintData")]
        public DataTable getPrintData()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadPrintData();
        }
        [HttpPost("savePrint")]
        public DataTable SavePrint(ProductPrint pro)
        {
            return pro.SavePrintDt();
        }
        //DeactivePrintProd

        [HttpPost("deactivePrint")]
        public DataTable DeactivePrint(ClsPrm prm)
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.DeactivePrintProd(prm.stPram1);
        }

        //CompletedPrint
        [HttpGet("completedPrint")]
        public DataTable CompletedPrint()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.CompletedPrint();
        }

        //
        [HttpGet("heatPressPending")]
        public DataTable HeatPressPending()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.HeatPressPending();
        }
        [HttpPost("searchheatPrint")]
        public DataTable SearchheatPrint(ClsPrm prm)
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.SearchHeat(prm.DtPram1,prm.DtPram2);
        }
        //
        [HttpGet("loadSizes")]
        public DataTable LoadSizes()
        {
            ProductPrint pro = new ProductPrint(CommonData.ConStr());
            return pro.LoadSizes();
        }
        //----------
        [HttpPost("save_Production")]
        public DataTable Save_Production(HourlyProduction hwrk)
        {
            //PlanBoard plan = new PlanBoard(CommonData.ConStr());
            return hwrk.Save_Production();
        }

      

        [HttpGet("load_production_all")]
        public DataTable Load_production_all()
        {
            HourlyProduction pro = new HourlyProduction();
            return pro.Load_production_all();
        }

        [HttpGet("getOrderpo")]
        public DataTable GetOrderpo()
        {
            OrderSheet ods = new OrderSheet();
            return ods.GetOrderpo();
        }

        [HttpGet("getCmntCat")]
        public DataTable GetCmntCat()
        {
            OrderSheet ods = new OrderSheet();
            return ods.GetCmntCat();
        }

        [HttpPost("viewOrdersheet")]
        public DataSet ViewOrdersheet(OrderSheet ods)
        {
            return ods.ViewOrdersheet();
        }

        [HttpPost("commentsave")]
        public DataTable Commentsave(OrderSheet ods)
        {
            return ods.commentsave();
        }

        [HttpPost("comment_cat")]
        public DataTable comment_cat(OrderSheet ods)
        {
            return ods.comment_cat();
        }

    }
}