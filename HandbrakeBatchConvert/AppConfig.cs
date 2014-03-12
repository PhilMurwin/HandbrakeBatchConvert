using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandbrakeBatchConvert
{
    public static class AppConfig
    {
        public static string Source
        {
            get
            {
                return ConfigurationManager.AppSettings["Source"];
            }

            set
            {
                ConfigurationManager.AppSettings["Source"] = value;
            }
        }

        public static string Destination
        {
            get
            {
                return ConfigurationManager.AppSettings["Destination"];
            }

            set
            {
                ConfigurationManager.AppSettings["Destination"] = value;
            }
        }

        public static string Query
        {
            get
            {
                return ConfigurationManager.AppSettings["Query"];
            }

            set
            {
                ConfigurationManager.AppSettings["Query"] = value;
            }
        }
    }
}
