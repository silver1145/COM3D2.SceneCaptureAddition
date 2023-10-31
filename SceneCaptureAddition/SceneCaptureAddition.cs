using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

[assembly: AssemblyVersion(COM3D2.SceneCaptureAddition.Plugin.PluginInfo.PLUGIN_VERSION + ".*")]

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]


namespace COM3D2.SceneCaptureAddition.Plugin
{
    public static class PluginInfo
    {
        public const string PLUGIN_GUID = "COM3D2.SceneCaptureAddition";
        public const string PLUGIN_NAME = "SceneCaptureAddition";
        public const string PLUGIN_VERSION = "1.0";
    }

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public sealed class SceneCaptureAddition : BaseUnityPlugin
    {
        public static SceneCaptureAddition Instance { get; private set; }

        internal static new ManualLogSource Logger => Instance?._Logger;
        private ManualLogSource _Logger => base.Logger;
        public static bool HDREnabled = false;

        private void Awake()
        {
            Instance = this;
            Harmony.CreateAndPatchAll(typeof(EffectManagerPatch));
            Harmony.CreateAndPatchAll(typeof(EffectWindowPatch));
            Harmony.CreateAndPatchAll(typeof(SCInstancesPatch));
        }
    }
}
