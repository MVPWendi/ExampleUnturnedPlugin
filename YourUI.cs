
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleUnturnedPlugin
{

    //Ваш уи
    public class YourUI : DefaultUI
    {
        // конструктор, тут настраивает айди эффекта, слой TIP - это подсказка, можно без него, и вызывается уи SendUI(true) - true/false - блокировать мышку или нет
        public YourUI(UnturnedPlayer player) : base(player)
        {
            base.EffectID = 12555;
            base.LayerID = 12555;
            base.TipText = "VineRegTip";
            base.SendUI(true);
        }

        
        //когда жмёт кнопку
        override protected void OnButton(Player uplayer, string buttonname)
        {
            if (CanUseButton(uplayer) == false) return;
            //Если кнопка называется CloseUI - вызывает UNLOAD() - анлоад закрывает уи
            if(buttonname=="CloseUI")
            {
                Unload();
            }
        }

        //когда вводит текст
        override protected void OnText(Player uplayer, string buttonname, string text)
        {
            if (CanUseButton(uplayer) == false) return;
        }
    }
}