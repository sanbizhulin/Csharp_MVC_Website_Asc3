using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trytest.Models
{
    public class Friend
    {
        public int FriendID { get; set; }
        public string FriendName { get; set; }
        public string FriendNickname { get; set; }
        public string FriendPassword { get; set; }
        public string FriendEmail { get; set; }
        public int FriendAge { get; set; }
        public string FriendSex { get; set; }

      

  
        public virtual ICollection<EventInProject> EventInProjectTable { get; set; }
    }
}