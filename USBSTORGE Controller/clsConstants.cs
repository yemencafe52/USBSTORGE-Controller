using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBSTORGController
{
    public class Constants
    {
        private static string key = @"SYSTEM\CurrentControlSet\Services\USBSTOR";
        private static string valueName = "Start";

        public static string Key
        {
            get
            {
                return key;
            }
        }

        public static string Value
        {
            get
            {
                return valueName;
            }
        }
    }
}
