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
    public class BuyerCatApiController : ControllerBase
    {
        [HttpGet("getLoadBuyercat")]
        public DataTable GetLoadBuyercat()
        {
            BuyerCatergory buy = new BuyerCatergory(CommonData.ConStr());
            return buy.LoadBuyerCatergory();
        }

        [HttpGet("getShipTerms")]
        public DataTable GetShipTerms()
        {
            BuyerCatergory buy = new BuyerCatergory(CommonData.ConStr());
            return buy.LoadingShipmentTerms();
        }
        [HttpGet("getInvTyp")]
        public DataTable GetInvTyp()
        {
            BuyerCatergory buy = new BuyerCatergory(CommonData.ConStr());
            return buy.LoadingInvTyp();
        }
        [HttpGet("getPymntTrms")]
        public DataTable GetPymntTrms()
        {
            BuyerCatergory buy = new BuyerCatergory(CommonData.ConStr());
            return buy.LoadingPaymntTrms();
        }

        [HttpPost("saveBuyer")]
        public DataTable SaveBuyer(BuyerCatergory buy)
        {
            //BuyerCatergory buy = new BuyerCatergory(CommonData.ConStr());
            return buy.Save_BuyerCat();
        }
        
    }
}