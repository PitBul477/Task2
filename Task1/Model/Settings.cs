using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    public static class Settings
    {
        private static bool _switchsave = Boolean.Parse(ConfigurationManager.AppSettings["switchsave"]);

        public static bool SwitchSave
        {
            get { return _switchsave; }
            set
            {
                _switchsave = value;
            }
        }
    }
}
