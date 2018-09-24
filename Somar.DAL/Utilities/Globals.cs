using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace Somar.DAL.Utilities
{
    public static class Globals
    {
        public static string path
        {
            get
            {
                return ConfigurationManager.AppSettings["ConfigPath"];
            }
        }

        public static string stringConn
        {
            get
            {
                return ConnectionDB.xml_conn(path);
                //return ConfigurationManager.ConnectionStrings["SomarDatabase"].ConnectionString;
            }
        }

        /*
        public static string stringConn
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SomarDatabase"].ConnectionString;
            }
        }
        */
    }
}
