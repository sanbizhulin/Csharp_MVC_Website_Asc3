using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace trytest.Models
{
    public class Contribution
    {
        public int ContributionID { get; set; }
        public string ContributionName { get; set; }
        public string ContributionQuantity { get; set; }
        public int ContributionTypeID { get; set; }
        public virtual ContributionType contributiontype { get; set; }
    }
}