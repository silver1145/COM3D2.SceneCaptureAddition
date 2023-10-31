using COM3D2.SceneCaptureAddition.Plugin;

namespace CM3D2.SceneCapture.Plugin
{
    internal class HDRDef
    {
        public static HDR hdrEffect;

        static HDRDef()
        {
            bool flag = hdrEffect == null;
            if (flag)
            {
                hdrEffect = Util.GetComponentVar<HDR, HDRDef>(hdrEffect);
            }
        }

        public static void ClearEffect()
        {
            hdrEffect = null;
            hdrEffect = Util.GetComponentVar<HDR, HDRDef>(hdrEffect);
        }

        public static void InitMemberByInstance(HDR lb)
        {
        }

        public static void Update(HDRPane hdrPane)
        {
            bool needEffectWindowReload = Instances.needEffectWindowReload;
            if (needEffectWindowReload)
            {
                hdrPane.IsEnabled = hdrEffect.enabled;
            }
            else
            {
                hdrEffect.enabled = hdrPane.IsEnabled;
            }
        }
    }
}
