using Exiled.Events.EventArgs;
using Exiled.API.Features;
using System;
using PlayerHandler = Exiled.Events.Handlers.Player;

namespace PainkillerResetStamina
{
    public class MainClass : Plugin<Config>
    {
        public override string Author => "xNexus-ACS";
        public override string Name => "PainkillerResetStamina";
        public override string Prefix => "paikiller_reset_stamina";
        public override Version Version { get; } = new Version(0, 1, 0);
        public override Version RequiredExiledVersion { get; } = new Version(5, 1, 3);

        public override void OnEnabled()
        {
            PlayerHandler.UsedItem += OnUsedItem;
            
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            PlayerHandler.UsedItem -= OnUsedItem;
            
            base.OnDisabled();
        }

        public void OnUsedItem(UsedItemEventArgs ev)
        {
            if (ev.Item.Type == ItemType.Painkillers)
                ev.Player.ResetStamina();
        }
    }
}