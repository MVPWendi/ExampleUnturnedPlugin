using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;

namespace ExampleUnturnedPlugin
{

    // Не трогайте
    public static class EffManagerEx
    {

        public static void SendUI(ushort effectid, short layerid, UnturnedPlayer player)
        {
            SendUI(effectid, layerid, player.CSteamID);
        }

        public static void SendVisibility(short layerid, CSteamID steamID, string prefabname, bool visible)
        {
            var val = Provider.findTransportConnection(steamID);
            EffectManager.sendUIEffectVisibility(layerid, val, true, prefabname, visible);
        }
        public static void SendUI(ushort effectid, short layerid, CSteamID steamID)
        {
            var val = Provider.findTransportConnection(steamID);
            EffectManager.sendUIEffect(effectid, layerid, val, true);
        }
        public static void SendText(short layerid, UnturnedPlayer player, string prefabname, string text)
        {
            SendText(layerid, player.CSteamID, prefabname, text);
        }

        public static void ClearEffect(ushort effectid, CSteamID steamid)
        {
            var val = Provider.findTransportConnection(steamid);
            EffectManager.askEffectClearByID(effectid, val);
        }
        public static void SendText(short layerid, CSteamID steamID, string prefabname, string text)
        {
            var val = Provider.findTransportConnection(steamID);
            EffectManager.sendUIEffectText(layerid, val, true, prefabname, text);
        }
    }
}