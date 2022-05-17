using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUnturnedPlugin.Commands
{

    //Тестовая команда, можете скопировать целый файл справа ->>>>>>>>>>>>
    //Сменить TestCommand - на имя вашей команды и изменить ее как хотите
    public class TestCommand : IRocketCommand
    {

        // кто может юзать команду принимает значения: Player, Console, Both -   Игрок, Консоль, и тот и другой
        public AllowedCaller AllowedCaller => AllowedCaller.Player;
        
        // имя по которой команда вызывается в нашем случае /testcom
        public string Name => "testcom";

        // игнорируйте
        public string Help => "";
        // игнорируйте
        public string Syntax => "";
        // аллиасы, тоже самое что Name, этими значениями можно вызвать команду, то есть /testcom /tes /testcommand /tc - вызовет эту комманду
        public List<string> Aliases => new List<string> {"tes", "testcommand", "tc" };

        // пермишен для пермишенов, чтоб чел мог юзать команду
        public List<string> Permissions => new List<string> { "testcom" };


        // метод который вызывается при использовании команды, в нашем случае просто в чат выведем сообщение что игрок использовал команду
        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer player = (UnturnedPlayer)caller;

            UnturnedChat.Say("Игрок " + player.CharacterName + " использовал команду");
        }
    }
}
