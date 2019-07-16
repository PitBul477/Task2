using System.Configuration;

namespace Task1
{
    //класс "Настройки конфигурации"
    public static class Settings
    {
        //возвращает или устанавливает значение для поля "Переключатель типа сохранения данных"
        public static bool SaveData { get; set; } = bool.Parse(ConfigurationManager.AppSettings["SaveData"]);
    }
}
