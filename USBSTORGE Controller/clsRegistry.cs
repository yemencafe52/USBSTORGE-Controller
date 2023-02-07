namespace USBSTORGController
{
    using Microsoft.Win32;
    using System;

    public class Registry
    {
        public bool ReadValue(RegistryHive hive,string key,string valueName,ref object value)
        {
            bool res = false;
            value = null;
            try
            {
                RegistryKey hKey = RegistryKey.OpenBaseKey(hive, RegistryView.Default);

                if (hKey is null)
                {
                    return res;
                }

                RegistryKey hkey2 = hKey.OpenSubKey(key);

                if (hkey2 is null)
                {
                    hKey.Close();
                    return res;
                }

                value = hkey2.GetValue(valueName);

                if (value is null)
                {
                    hKey.Close();
                    hkey2.Close();
                    return res;
                }

                hKey.Close();
                hkey2.Close();
                res = true;
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }

            return res;
        }

        public bool WriteValue(RegistryHive hive, string key, string valueName, object value)
        {
            bool res = false;

            try
            {
                RegistryKey hKey = RegistryKey.OpenBaseKey(hive, RegistryView.Registry32);

                if (hKey is null)
                {
                    return res;
                }

                RegistryKey hKey2 = hKey.OpenSubKey(key,true); //:)

                if(hKey2 is null)
                {
                    hKey.Close();
                    return res;
                }

                string tmp = Convert.ToString((byte)value);
                hKey2.SetValue(valueName, tmp);
                hKey.Close();
                hKey2.Close();
                res = true;
                return res;

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return res;

        }
    }
}
