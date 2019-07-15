using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    ////класс модели Settings
    public static class Settings
    {
        private static bool _switchsave = Boolean.Parse(ConfigurationManager.AppSettings["switchsave"]);

        ////возвращает или устанавливает значение для поля "Переключатель типа сохранения данных"
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
