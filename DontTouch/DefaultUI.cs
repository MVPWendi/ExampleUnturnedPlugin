using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleUnturnedPlugin
{

    // Не трогайте
    public class DefaultUI
    {
        public CSteamID TargetPlayerID { get; private protected set; }
        private protected DateTime LastButtonTime;
        public ushort EffectID { get; protected set; }
        public short LayerID { get; protected set; }
        public string TipText { get; protected set; }
        public DefaultUI(UnturnedPlayer player)
        {
            this.TargetPlayerID = player.CSteamID;
            this.LastButtonTime = DateTime.Now;
            Load();
        }
        protected virtual void SendTip(string tip)
        {
            EffManagerEx.SendText(LayerID, TargetPlayerID, TipText, tip);
        }
        private void Load()
        {
            EffectManager.onEffectButtonClicked += OnButton;
            EffectManager.onEffectTextCommitted += OnText;
            U.Events.OnPlayerDisconnected += Events_OnPlayerDisconnected;
        }
        private void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            Unload();
        }
        protected void SendUI(bool BlockMouse)
        {
            EffManagerEx.SendUI(EffectID, LayerID, TargetPlayerID);
            UpdateUI();
            UnturnedPlayer.FromCSteamID(TargetPlayerID).Player.setPluginWidgetFlag(EPluginWidgetFlags.Modal, BlockMouse);
        }
        protected virtual void UpdateUI()
        {

        }
        protected virtual void OnText(Player player, string buttonName, string text)
        {

        }
        protected virtual void OnButton(Player player, string buttonName)
        {

        }
        protected bool CanUseButton(Player player)
        {
            if ((DateTime.Now - LastButtonTime).TotalSeconds <= 0.09f)
            {
                return false;
            }
            if (player.channel.owner.playerID.steamID != TargetPlayerID)
            {
                return false;
            }
            LastButtonTime = DateTime.Now;
            return true;
        }
        protected virtual void Unload()
        {
            EffectManager.onEffectButtonClicked -= OnButton;
            EffectManager.onEffectTextCommitted -= OnText;
            U.Events.OnPlayerDisconnected -= Events_OnPlayerDisconnected;
            RemoveUI(true);
        }
        protected virtual void RemoveUI(bool RemoveMouseBlock)
        {
            EffManagerEx.ClearEffect(EffectID, TargetPlayerID);
            if (UnturnedPlayer.FromCSteamID(TargetPlayerID) != null)
                UnturnedPlayer.FromCSteamID(TargetPlayerID)?.Player?.setPluginWidgetFlag(EPluginWidgetFlags.Modal, !RemoveMouseBlock);
        }

    }
}
