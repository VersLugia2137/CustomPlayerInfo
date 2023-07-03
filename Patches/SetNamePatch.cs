using HarmonyLib;
using PluginAPI.Core;

namespace CustomPlayerInfo.Patches
{
    #pragma warning disable all
    
    [HarmonyPatch(typeof(NicknameSync), nameof(NicknameSync.Network_displayName), MethodType.Setter)]
    [HarmonyPriority(Priority.Low)]
    internal static class SetNamePatch
    {
        [HarmonyPostfix]
        public static void Postfix(ReferenceHub ____hub)
        {
            Player player = Player.Get(____hub);
            
            EventHandlers.TrySetCustomInfo(player, player.RoleBase.RoleTypeId);
        }
    } 
}