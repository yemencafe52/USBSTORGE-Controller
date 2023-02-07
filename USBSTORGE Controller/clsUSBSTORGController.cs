using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USBSTORGController
{

    public enum USBState : byte
    {
        ENABLED = 3,
        DISABLED =4,
        UNKNOW

    }

    public class USBSTORGController
    {

        public bool Enable()
        {
            bool res = false;

            try
            {
                res = new Registry().WriteValue(Microsoft.Win32.RegistryHive.LocalMachine, Constants.Key, Constants.Value, USBState.ENABLED);

            }
            catch
            {

            }
            return res;
        }

        public bool Disable()
        {
            bool res = false;

            try
            {
                res = new Registry().WriteValue(Microsoft.Win32.RegistryHive.LocalMachine, Constants.Key, Constants.Value, USBState.DISABLED);
            }
            catch { }
            return res;
        }

        public USBState GetState()
        {
            USBState res = USBState.UNKNOW;

            try
            {
                object obj = null;

                if (new Registry().ReadValue(Microsoft.Win32.RegistryHive.LocalMachine, Constants.Key, Constants.Value, ref obj))
                {
                    if (Convert.ToByte(obj) == (byte)3)
                    {
                        res = USBState.ENABLED;
                    }
                    else if (Convert.ToByte(obj) == (byte)4)
                    {
                        res = USBState.DISABLED;
                    }
                }
            }
            catch { }

            return res;
        }

    }
}
