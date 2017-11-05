using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trytest.Models
{
    public class User
    {
        public int UserID { get; set; }


        public string UserName { get; set; }


        public string UserNickname { get; set; }


        public string UserPassword { get; set; }

        public string UserEmail { get; set; }
        public int UserAge { get; set; }
        public string UserSex { get; set; }

        public int UserRoleID { get; set; }
        public virtual  UserRole userrole {get;set;}

    }
}