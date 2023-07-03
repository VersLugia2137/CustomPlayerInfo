using PlayerRoles;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace CustomPlayerInfo
{
    sealed class EventHandlers
    {
        [PluginEvent(ServerEventType.PlayerChangeRole)]
        private void OnPlayerChangeRole(PlayerChangeRoleEvent ev)
        {
            if (Plugin._config.DisablePowerStatusInfo)
                ev.Player.PlayerInfo.IsPowerStatusHidden = true;

            if (Plugin._config.DisableUnitsInfo)
                ev.Player.PlayerInfo.IsUnitNameHidden = true;

            if (TrySetCustomInfo(ev.Player, ev.NewRole))
                return;

            ev.Player.PlayerInfo.IsNicknameHidden = false;
            ev.Player.PlayerInfo.IsRoleHidden = false;
            ev.Player.CustomInfo = string.Empty;
        }
        
        public static bool TrySetCustomInfo(Player player, RoleTypeId roleTypeId)
        {
            if (!Plugin._config.CustomInfo.TryGetValue(roleTypeId, out string customInfo))
                return false;

            if (customInfo.Contains("{unit}"))
                player.PlayerInfo.IsUnitNameHidden = true;

            player.PlayerInfo.IsNicknameHidden = true;
            player.PlayerInfo.IsRoleHidden = true;
            player.PlayerInfo.IsCustomInfoHidden = false;
            player.CustomInfo = customInfo
                .Replace("{nick}", player.DisplayNickname)
                .Replace("{unit}", player.UnitName);

            return true;
        }
    }
}