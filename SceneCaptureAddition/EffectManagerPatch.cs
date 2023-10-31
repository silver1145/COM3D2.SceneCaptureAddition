using CM3D2.SceneCapture.Plugin;
using HarmonyLib;

namespace COM3D2.SceneCaptureAddition.Plugin
{
    internal static class EffectManagerPatch
    {
        internal static HDRDef hdr;
        internal static BeautifyDef beautify;

        [HarmonyPatch(typeof(EffectManager), MethodType.Constructor)]
        [HarmonyPostfix]
        private static void EffectManagerConstructorPostfix()
        {
            if (hdr == null)
            {
                hdr = new HDRDef();
            }
            if (beautify == null)
            {
                beautify = new BeautifyDef();
            }
        }

        [HarmonyPatch(typeof(EffectManager), nameof(EffectManager.Clear))]
        [HarmonyPostfix]
        private static void EffectManagerClearPostfix()
        {
            HDRDef.ClearEffect();
            BeautifyDef.ClearEffect();
        }
    }
}
