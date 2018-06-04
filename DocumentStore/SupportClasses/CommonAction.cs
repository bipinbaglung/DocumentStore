using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentStore
{
    public static class ConfigValues
    {
        public static string FileSaveRootLocation = @"S:\DocumentStore";
        public static int TimeOut = 12000;
        public static string DBUserName = "sa";
        public static string DBPassword = "password";
        public static string DBServerName = "localhost";
        public static string DBName="DocumentStore";
        public static bool DBWindowsAuthentication = false;
    }
    public enum Mode
    {
        ADD,
        UPDATE,
        VIEW
    }
}
