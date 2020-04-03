using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppliancesWEB.Models
{
    public class DataUserForReg
    {
        public AuthUsers AuthUser { get; set; }
        public DataUsers DataUser { get; set; }
        public PayData PayData { get; set; }
        public DataUserForReg()
        {
            AuthUser = new AuthUsers();
            DataUser = new DataUsers();
            PayData = new PayData();
        }
    }
}