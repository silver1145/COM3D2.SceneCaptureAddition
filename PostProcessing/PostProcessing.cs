using BeautifyForPPS;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


[assembly: AssemblyVersion(COM3D2.PostProcessing.Plugin.PluginInfo.PLUGIN_VERSION + ".*")]

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]


namespace COM3D2.PostProcessing.Plugin
{
    public static class PluginInfo
    {
        public const string PLUGIN_GUID = "COM3D2.PostProcessing";
        public const string PLUGIN_NAME = "PostProcessing";
        public const string PLUGIN_VERSION = "1.0";
    }

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public sealed class PostProcessing : BaseUnityPlugin
    {
        public static PostProcessing Instance { get; private set; }
        internal static new ManualLogSource Logger => Instance?._Logger;
        private ManualLogSource _Logger => base.Logger;
        public static PostProcessVolume PostVolume;
        public static GameObject PostVolumeObj;

        private void Awake()
        {
            Instance = this;
            PostVolumeObj = new GameObject("PostVolumeObj");
            DontDestroyOnLoad(PostVolumeObj);
            PostVolume = PostVolumeObj.AddComponent<PostProcessVolume>();
            PostVolume.name = "PostVolume";
            PostVolume.profile = NewProfile();
            PostVolume.isGlobal = true;
            Utils.AssetLoader.LoadAsset();
            Harmony.CreateAndPatchAll(typeof(PostProcessing));
        }

        private static PostProcessProfile NewProfile()
        {
            PostProcessProfile postProcessProfile = ScriptableObject.CreateInstance<PostProcessProfile>();
            postProcessProfile.name = "PostProcess Global Volume Profile";
            Beautify beautify = ScriptableObject.CreateInstance<Beautify>();
            beautify.enabled.overrideState = true;
            beautify.enabled.value = true;
            postProcessProfile.AddSettings(beautify);
            return postProcessProfile;
        }
    }
}
