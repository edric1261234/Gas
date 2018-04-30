using System;
using System.Collections.Generic;
using System.Text;

namespace HengXu
{
    public enum ConfigType { boolType,intType,doubleType,stringType};
   
    public class ConfigObj
    {

        private static INIClass iniclass = null;


        public object getValue(string name, ConfigType type) 
        {
            if (iniclass == null)
            {
                iniclass = new INIClass(System.Windows.Forms.Application.StartupPath + "//1.ini");
            }
            string value = iniclass.IniReadValue("config", name);
            try
            {
                if (type == ConfigType.boolType)
                {
                    if (value == "true")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (type == ConfigType.intType)
                {
                    return Convert.ToInt32(value);
                }
                else if (type == ConfigType.doubleType)
                {
                    return Convert.ToDouble(value);
                }
                else if (type == ConfigType.stringType)
                {
                    return value;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public void setValue(string name, object value, ConfigType type)
        {
            if (iniclass == null)
            {
                iniclass = new INIClass(System.Windows.Forms.Application.StartupPath + "//1.ini");
            }
            if (type == ConfigType.boolType)
            {
                if ((bool)value)
                {
                    iniclass.IniWriteValue("config", name, "true");
                }
                else
                {
                    iniclass.IniWriteValue("config", name, "false");
                }
            }
            else if (type == ConfigType.intType)
            {
                iniclass.IniWriteValue("config", name, value.ToString());
            }
            else if (type == ConfigType.doubleType)
            {
                iniclass.IniWriteValue("config", name, ((double)value).ToString("f2"));
            }
            else if (type == ConfigType.stringType)
            {
                iniclass.IniWriteValue("config", name, value.ToString());
            }
        }
    }
}
