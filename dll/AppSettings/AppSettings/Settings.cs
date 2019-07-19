using System.Configuration;

namespace AppSettings
{
    //класс "Настройки конфигурации"
    public static class Settings
    {
        //возвращает или устанавливает значение для поля "Переключатель типа сохранения данных"
        public static bool SaveData { get; set; } = bool.Parse(ConfigurationManager.AppSettings["SaveData"]);
    }
}
