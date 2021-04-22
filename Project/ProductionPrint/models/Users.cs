using Online_Portal_Api.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ProductionPrint.models
{
    public class Users
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Fname { get; set; }
        public string lname { get; set; }
        public int groupId { get; set; }
        public int plant_Id { get; set; }
        public int EpfNo { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid usrId { get; set; }
        private string Connection { get; set; }
        private List<UsersList> _users = new List<UsersList>();

        public Users(string Conn)
        {
            Id = 0;
            username = "";
            password = "";
            groupId = 0;
            plant_Id=0;
            Fname = "";
            lname = "";
            EpfNo = 0;
            CreatedBy = new Guid();
            usrId = new Guid();
            Connection = Conn;
        }


        public DataTable RegisterUser()
        {
            //  var list3 = (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT [Idx],FName,CusIdx,[PasswordHash] ,[UserName],[Position] FROM [dbo].[OOP_Users]");
           // string HashPwd = SecurePasswordHasher.Hash(password);
            string HashPwd = BCrypt.Net.BCrypt.HashPassword(password);
            {
                var objDIc = new Dictionary<string, object> {

                   {"username",username},
                   {"password",HashPwd},
                   { "EpfNo",EpfNo},
                   {"fname",Fname},
                   {"lname",lname},
                   {"plant_Id",plant_Id},
                   {"groupId",groupId},
                   {"CreatedBy",CreatedBy}

            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Auth_CreateUser",objDIc);
            }
        }
        public DataTable EditUser()
        {   
            {
                var objDIc = new Dictionary<string, object> {
                    
                   {"Idx",usrId},
                   {"fname",Fname},
                   {"lname",lname},
                   {"username",username}

            };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Edit_Syst_User", objDIc);
            }
        }
        public DataTable LoginUser(string username, string password)
             {

            var list = (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT Idx,[Id] ,[fname],[Username],[password] ,[SectionId] ,[IsActive] FROM [dbo].[Auth_Users]");

            for (int i = 0; i < list.Rows.Count; i++)
            {
                UsersList ac = new UsersList();
                ac.Idx=Guid.Parse( list.Rows[i]["Idx"].ToString());
                ac.Id = Int32.Parse(list.Rows[i]["Id"].ToString());
                ac.Fname = list.Rows[i]["fname"].ToString();
                ac.username = list.Rows[i]["Username"].ToString();
                ac.password = list.Rows[i]["password"].ToString();
                _users.Add(ac);
            }
            var user = _users.SingleOrDefault(x => x.username == username);
            if (user != null)
            {
                var hashpwd = BCrypt.Net.BCrypt.Verify(password, user.password);
                //SecurePasswordHasher.Verify(password, user.password);
                if (hashpwd == true)
                {
                    var list2 = (new DbAccess(CommonData.ConStr())).FillDataTable("SELECT Idx, [Id] ,[fname],[Username],[SectionId] ,[IsActive] FROM [dbo].[Auth_Users] where Id='" + user.Id.ToString()+"'");
                    return list2;
                }
            }
            //else
            //{
            //    DataTable dt = new DataTable();
            //    dt=["RateTable"].Rows[0][0];  
            //}


            return null;
        }

        public DataTable ChangePassword()
        {
            string HashPwd = BCrypt.Net.BCrypt.HashPassword(password);
            {
                var objDIc = new Dictionary<string, object>
                {

                   {"user_Id",usrId},
                   { "password",HashPwd}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Change_UserPswd", objDIc);
            }
        }

        public DataTable ChangePasswordAdmin()
        {
            string HashPwd = BCrypt.Net.BCrypt.HashPassword("abc@1234");
            {
                var objDIc = new Dictionary<string, object>
                {
                   {"user_Id",usrId},
                   { "password",HashPwd}

                };
                return (new DbAccess(CommonData.ConStr())).LoadDatatableBySP("Change_UserPswd", objDIc);
            }
        }

        public DataTable LoadUsers()
        {
            
         return (new DbAccess(CommonData.ConStr())).FillDataTable(" SELECT [Idx],[Id] ,[fname], [lname],[Username],[SectionId],[Plant_Id] ,[IsActive] FROM [dbo].[Auth_Users]");
            
        }

    }


    public class UsersList
    {
        public Guid Idx { get; set; }
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Fname { get; set; }
       // public string section { get; set; }

    } 
}
