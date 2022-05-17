using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUnturnedPlugin
{

    // основной класс плагина
    public class Plugin : RocketPlugin<Configuration>
    {
        //не трогайте
        public static Plugin Instance;

        // Сюда дописывать ивенты и так далее, вызывается при загрузке плагина
        protected override void Load()
        {
            Instance = this;
            //ивент когда игрок заходит
            U.Events.OnPlayerConnected += Events_OnPlayerConnected;
        }

        //когда игрок заходит вызываем для него уи вот таким не хитрым способом
        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            YourUI ui = new YourUI(player);
        }

        // Определение переводов, не трогать
        public override TranslationList DefaultTranslations => Translation.DefaultTranslations;

        
        // вызывается при выгрузке плагина (тут отписываться от ивентов), обнулять списки и т.д.
        protected override void Unload()
        {
            U.Events.OnPlayerConnected -= Events_OnPlayerConnected;
            Instance = null;
            
        }
    }
}
