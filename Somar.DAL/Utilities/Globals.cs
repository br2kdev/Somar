using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Somar.DAL.Utilities
{
    public static class Globals
    {
        public static string stringConn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SomarDatabase"].ConnectionString;
            }
        }
    }
}
