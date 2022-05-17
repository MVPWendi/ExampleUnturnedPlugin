using Rocket.API;
using System;
namespace ExampleUnturnedPlugin
{
    // класс конфига вашего плагина, значения которые тут есть можно заменить на свои
    public class Configuration : IRocketPluginConfiguration
    {
        // определение переменной
        public int TestValue;


        // метод который вызывается при создании файла конфига (при первом запуске), удалять нельзя
        public void LoadDefaults()
        {
            TestValue = 10;
        }
    }
}