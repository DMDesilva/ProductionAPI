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
    public class AuthUserApiController : ControllerBase
    {
        [HttpPost("registerNewUsers")]
        public DataTable RegisterNewUsers(Users usr)
        {
           // Users usr = new Users(CommonData.ConStr());
            return usr.RegisterUser();
        }

        [HttpPost("loginUser")]
        public DataTable LoginUser(ClsPrm prm)
        {
            Users usr = new Users(CommonData.ConStr());
            return usr.LoginUser(prm.stPram1,prm.stPram2);
        }
        [HttpPost("changePass")]
        public DataTable changePass(Users usr)
        {
           // Users usr = new Users(CommonData.ConStr());
            return usr.ChangePassword();
        }
       
        [HttpPost("changePassAdmin")]
        public DataTable changePassAdmin(Users usr)
        {
            // Users usr = new Users(CommonData.ConStr());
            return usr.ChangePasswordAdmin();
        }
        [HttpGet("getAllUsers")]
        public DataTable GetAllUsers()
        {
             Users usr = new Users(CommonData.ConStr());
            return usr.LoadUsers();
        }
        [HttpPost("editUser")]
        public DataTable EditUser(Users usr)
        {
            // Users usr = new Users(CommonData.ConStr());
            return usr.EditUser();
        }
    }
}