using System.Reflection;
using CustomPlayerInfo.Patches;
using HarmonyLib;
using PluginAPI.Core.Attributes;
using PluginAPI.Enums;
using PluginAPI.Events;

namespace CustomPlayerInfo
{
    sealed class Plugin
    {
        #region Consts
        
        internal const string PluginName = "CustomPlayerInfo";
        internal const string Version = "1.0.0";
        internal const string Description = "SCP:SL Plugin that allows to set custom player's info.";
        internal const string Author = "VersLugia";
        
        #endregion

        #region Fields

        [PluginConfig]
        public static Config _config;
        private static Harmony _harmony;
        
        #endregion
        
        #region Methods
        
        [PluginEntryPoint(nameof(CustomPlayerInfo), null, null, null)]
        [PluginPriority(LoadPriority.Medium)]
        private void Load()
        {
            if (!_config.EnablePlugin)
                return;
            
            EventManager.RegisterEvents<EventHandlers>(this);
            _harmony = new Harmony(PluginName);
            MethodInfo originalMethod = typeof(NicknameSync).GetProperty(nameof(NicknameSync.Network_displayName)).SetMethod;
            HarmonyMethod postfixPatchMethod = new HarmonyMethod(typeof(SetNamePatch).GetMethod(nameof(SetNamePatch.Postfix)));
            _harmony.Patch(originalMethod, postfix: postfixPatchMethod);
        }

        [PluginUnload]
        private void Unload()
        {
            EventManager.UnregisterEvents<EventHandlers>(this);
            
            MethodInfo originalMethod = typeof(NicknameSync).GetProperty(nameof(NicknameSync.Network_displayName)).SetMethod;
            _harmony.Unpatch(originalMethod, HarmonyPatchType.Postfix);
            _harmony = null;
        }
        
        #endregion
    }
}