using Rocket.API.Collections;


namespace ExampleUnturnedPlugin
{
    public static class Translation
    {
        public static TranslationList DefaultTranslations = new TranslationList()
        {

            //key_name - имя в вызове перевода, текст перевода - то что будет писаться, текст можно менять в файле, {0} {1} - аргументы, если нужно
            // выводить какие то значения
            {"key_name", "текст перевода (0 и 1, 2, 3... аргументы если нужны) {0} {1} " },
            {"key_name2", "текст перевода2 (0 и 1, 2, 3... аргументы если нужны) {0} {1} " }
        };
    }
}