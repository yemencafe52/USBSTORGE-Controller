using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBSTORGController
{
    class clsTest
    {
        public static void Test()
        {

            object obj = null;
            string key = @"SYSTEM\CurrentControlSet\Services\USBSTOR";
           // bool res = new Registry().ReadValue(Microsoft.Win32.RegistryHive.LocalMachine, key, "Start", ref obj);
            bool res = new Registry().WriteValue(Microsoft.Win32.RegistryHive.LocalMachine, key, "Start", USBState.DISABLED);
            Console.Read();


        }
    }
}
