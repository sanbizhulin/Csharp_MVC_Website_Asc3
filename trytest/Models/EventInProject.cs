using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace trytest.Models
{
    public class EventInProject
    
    {
          public int EventInProjectID { get; set; }
        [Required]
        public string EventName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public string Time { get; set; }

        public int FriendID { get; set; }
        public virtual Friend friend { get; set; }

        public int EventInProjectTypeID { get; set; }
        public virtual EventInProjectType eventinprojecttype { get; set; }

        public int EventInProjectStatusID { get; set; }
        public virtual EventInProjectStatus eventinprojectstatus { get; set; }
        

        //public int ActivityTypeID { get; set; }
        //public virtual ActivityType ActivityType { get; set; }

        //public int ActivityStatusID { get; set; }
        //public virtual ActivityStatus ActivityStatus { get; set; }

        //public int PersonID { get; set; }
        //public string PersonName { get; set; }
    }
}