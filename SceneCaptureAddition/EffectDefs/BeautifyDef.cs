using BeautifyForPPS;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.Rendering.PostProcessing.PostProcessLayer;

namespace CM3D2.SceneCapture.Plugin
{
    internal class BeautifyDef
    {
        public static Beautify beautifyEffect;
        public static bool loadPreset { get; set; }
        public static PostProcessLayer.Antialiasing antialiasing { get; set; }
        public static bool enableCompare { get; set; }
        #region Compare settings
        public static bool compareMode { get; set; }
        public static float compareLineAngle { get; set; }
        public static float compareLineWidth { get; set; }
        #endregion
        public static bool enableSharpen { get; set; }
        #region Sharpen settings
        public static float sharpenIntensity { get; set; }
        public static float sharpenDepthThreshold { get; set; }
        public static float sharpenMinDepth { get; set; }
        public static float sharpenMaxDepth { get; set; }
        public static float sharpenRelaxation { get; set; }
        public static float sharpenClamp { get; set; }
        public static float sharpenMotionSensibility { get; set; }
        #endregion
        public static bool enableColorTweaks { get; set; }
        #region Color tweaks
        public static float daltonize { get; set; }
        public static float sepia { get; set; }
        public static float saturate { get; set; }
        public static float brightness { get; set; }
        public static float contrast { get; set; }
        public static Color tintColor { get; set; }
        public static BeautifyTonemapOperator tonemap { get; set; }
        public static float tonemapExposurePre { get; set; }
        public static float tonemapBrightnessPost { get; set; }
        #endregion
        public static bool enableLut { get; set; }
        #region Lut
        public static bool lut { get; set; }
        public static float lutIntensity { get; set; }
        public static Texture2D lutTexture { get; set; }
        public static string lutTextureFile { get; set; }
        #endregion
        public static bool enableBloomFlares { get; set; }
        #region Bloom & Flares effects
        public static float bloomIntensity { get; set; }
        public static float bloomThreshold { get; set; }
        public static float bloomMaxBrightness { get; set; }
        public static float bloomDepthAtten { get; set; }
        public static bool bloomAntiflicker { get; set; }
        public static bool bloomUltra { get; set; }
        public static bool bloomDebug { get; set; }
        public static bool bloomCustomize { get; set; }
        public static float bloomWeight0 { get; set; }
        public static float bloomWeight1 { get; set; }
        public static float bloomWeight2 { get; set; }
        public static float bloomWeight3 { get; set; }
        public static float bloomWeight4 { get; set; }
        public static float bloomWeight5 { get; set; }
        public static float bloomBoost0 { get; set; }
        public static float bloomBoost1 { get; set; }
        public static float bloomBoost2 { get; set; }
        public static float bloomBoost3 { get; set; }
        public static float bloomBoost4 { get; set; }
        public static float bloomBoost5 { get; set; }
        public static float anamorphicFlaresIntensity { get; set; }
        public static float anamorphicFlaresThreshold { get; set; }
        public static bool anamorphicFlaresVertical { get; set; }
        public static float anamorphicFlaresSpread { get; set; }
        public static float anamorphicFlaresDepthAtten { get; set; }
        public static bool anamorphicFlaresAntiflicker { get; set; }
        public static bool anamorphicFlaresUltra { get; set; }
        public static Color anamorphicFlaresTint { get; set; }
        public static float sunFlaresIntensity { get; set; }
        public static Color sunFlaresTint { get; set; }
        public static float sunFlaresSolarWindSpeed { get; set; }
        public static bool sunFlaresRotationDeadZone { get; set; }
        public static int sunFlaresDownsampling { get; set; }
        public static int sunFlaresLayerMask { get; set; }
        public static float sunFlaresSunIntensity { get; set; }
        public static float sunFlaresSunDiskSize { get; set; }
        public static float sunFlaresSunRayDiffractionIntensity { get; set; }
        public static float sunFlaresSunRayDiffractionThreshold { get; set; }
        //Corona Rays Group 1
        public static float sunFlaresCoronaRays1Length { get; set; }
        public static float sunFlaresCoronaRays1Streaks { get; set; }
        public static float sunFlaresCoronaRays1Spread { get; set; }
        public static float sunFlaresCoronaRays1AngleOffset { get; set; }
        //Corona Rays Group 2
        public static float sunFlaresCoronaRays2Length { get; set; }
        public static float sunFlaresCoronaRays2Streaks { get; set; }
        public static float sunFlaresCoronaRays2Spread { get; set; }
        public static float sunFlaresCoronaRays2AngleOffset { get; set; }
        //Ghost 1
        public static float sunFlaresGhosts1Size { get; set; }
        public static float sunFlaresGhosts1Offset { get; set; }
        public static float sunFlaresGhosts1Brightness { get; set; }
        //Ghost 2"
        public static float sunFlaresGhosts2Size { get; set; }
        public static float sunFlaresGhosts2Offset { get; set; }
        public static float sunFlaresGhosts2Brightness { get; set; }
        //Ghost 3
        public static float sunFlaresGhosts3Size { get; set; }
        public static float sunFlaresGhosts3Brightness { get; set; }
        public static float sunFlaresGhosts3Offset { get; set; }
        //Ghost 4
        public static float sunFlaresGhosts4Size { get; set; }
        public static float sunFlaresGhosts4Offset { get; set; }
        public static float sunFlaresGhosts4Brightness { get; set; }
        //Halo
        public static float sunFlaresHaloOffset { get; set; }
        public static float sunFlaresHaloAmplitude { get; set; }
        public static float sunFlaresHaloIntensity { get; set; }
        #endregion
        public static bool enableLensDirt { get; set; }
        #region Lens Dirt
        public static float lensDirtIntensity { get; set; }
        public static float lensDirtThreshold { get; set; }
        public static Texture2D lensDirtTexture { get; set; }
        public static string lensDirtTextureFile { get; set; }
        public static int lensDirtSpread { get; set; }
        #endregion
        public static bool enableEyeAdaptation { get; set; }
        #region Eye Adaptation
        public static bool eyeAdaptation { get; set; }
        public static float eyeAdaptationMinExposure { get; set; }
        public static float eyeAdaptationMaxExposure { get; set; }
        public static float eyeAdaptationSpeedToLight { get; set; }
        public static float eyeAdaptationSpeedToDark { get; set; }
        #endregion
        public static bool enablePurkinje { get; set; }
        #region Purkinje effect
        public static bool purkinje { get; set; }
        public static float purkinjeAmount { get; set; }
        public static float purkinjeLuminanceThreshold { get; set; }
        #endregion
        public static bool enableVignetting { get; set; }
        #region Vignetting
        public static float vignettingOuterRing { get; set; }
        public static float vignettingInnerRing { get; set; }
        public static float vignettingFade { get; set; }
        public static bool vignettingCircularShape { get; set; }
        public static float vignettingAspectRatio { get; set; }
        public static float vignettingBlink { get; set; }
        public static Color vignettingColor { get; set; }
        public static Texture2D vignettingMask { get; set; }
        public static string vignettingMaskFile { get; set; }
        #endregion
        public static bool enableDepthOfField { get; set; }
        #region Depth of Field
        public static bool depthOfField { get; set; }
        public static bool depthOfFieldDebug { get; set; }
        public static BeautifyDoFFocusMode depthOfFieldFocusMode { get; set; }
        public static float depthOfFieldAutofocusMinDistance { get; set; }
        public static float depthOfFieldAutofocusMaxDistance { get; set; }
        public static float depthofFieldAutofocusViewportPoint_X { get; set; }
        public static float depthofFieldAutofocusViewportPoint_Y { get; set; }
        public static int depthOfFieldAutofocusLayerMask { get; set; }
        public static int depthOfFieldExclusionLayerMask { get; set; }
        public static float depthOfFieldExclusionLayerMaskDownsampling { get; set; }
        public static bool depthOfFieldTransparencySupport { get; set; }
        public static int depthOfFieldTransparencyLayerMask { get; set; }
        public static float depthOfFieldTransparencySupportDownsampling { get; set; }
        public static float depthOfFieldExclusionBias { get; set; }
        public static float depthOfFieldDistance { get; set; }
        public static float depthOfFieldFocusSpeed { get; set; }
        public static int depthOfFieldDownsampling { get; set; }
        public static int depthOfFieldMaxSamples { get; set; }
        public static float depthOfFieldFocalLength { get; set; }
        public static float depthOfFieldAperture { get; set; }
        public static bool depthOfFieldForegroundBlur { get; set; }
        public static bool depthOfFieldForegroundBlurHQ { get; set; }
        public static float depthOfFieldForegroundDistance { get; set; }
        public static bool depthOfFieldBokeh { get; set; }
        public static float depthOfFieldBokehThreshold { get; set; }
        public static float depthOfFieldBokehIntensity { get; set; }
        public static float depthOfFieldMaxBrightness { get; set; }
        public static float depthOfFieldMaxDistance { get; set; }
        public static FilterMode depthOfFieldFilterMode { get; set; }
        #endregion
        public static bool enableOutline { get; set; }
        #region Outline
        public static bool outline { get; set; }
        public static Color outlineColor { get; set; }
        #endregion

        static BeautifyDef()
        {
            if (beautifyEffect == null)
            {
                beautifyEffect = Util.GetComponentVar<Beautify, BeautifyDef>(beautifyEffect);
            }
            enableCompare = false;
            #region Compare settings
            compareMode = false;
            compareLineAngle = 1.4f;
            compareLineWidth = 0.002f;
            #endregion
            enableSharpen = false;
            #region Sharpen settings
            sharpenIntensity = 4f;
            sharpenDepthThreshold = 0.035f;
            sharpenMinDepth = 0f;
            sharpenMaxDepth = 0.999f;
            sharpenRelaxation = 0.08f;
            sharpenClamp = 0.45f;
            sharpenMotionSensibility = 0.5f;
            #endregion
            enableColorTweaks = false;
            #region Color tweaks
            daltonize = 0f;
            sepia = 0f;
            saturate = 0f;
            brightness = 1f;
            contrast = 1f;
            tintColor = new Color(1, 1, 1, 0);
            tonemap = BeautifyTonemapOperator.Linear;
            tonemapExposurePre = 1f;
            tonemapBrightnessPost = 1f;
            #endregion
            enableLut = false;
            #region Lut
            lut = false;
            lutIntensity = 1f;
            lutTexture = null;
            lutTextureFile = "";
            #endregion
            enableBloomFlares = false;
            #region Bloom & Flares effects
            bloomIntensity = 0f;
            bloomThreshold = 0.75f;
            bloomMaxBrightness = 1000f;
            bloomDepthAtten = 0f;
            bloomAntiflicker = false;
            bloomUltra = false;
            bloomDebug = false;
            bloomCustomize = false;
            bloomWeight0 = 0.5f;
            bloomWeight1 = 0.5f;
            bloomWeight2 = 0.5f;
            bloomWeight3 = 0.5f;
            bloomWeight4 = 0.5f;
            bloomWeight5 = 0.5f;
            bloomBoost0 = 0f;
            bloomBoost1 = 0f;
            bloomBoost2 = 0f;
            bloomBoost3 = 0f;
            bloomBoost4 = 0f;
            bloomBoost5 = 0f;
            anamorphicFlaresIntensity = 0f;
            anamorphicFlaresThreshold = 0.75f;
            anamorphicFlaresVertical = false;
            anamorphicFlaresSpread = 1f;
            anamorphicFlaresDepthAtten = 0f;
            anamorphicFlaresAntiflicker = false;
            anamorphicFlaresUltra = false;
            anamorphicFlaresTint = new Color(0.5f, 0.5f, 1f, 0f);
            sunFlaresIntensity = 0.0f;
            sunFlaresTint = new Color(1, 1, 1);
            sunFlaresSolarWindSpeed = 0.01f;
            sunFlaresRotationDeadZone = false;
            sunFlaresDownsampling = 1;
            sunFlaresLayerMask = -1;
            sunFlaresSunIntensity = 0.1f;
            sunFlaresSunDiskSize = 0.05f;
            sunFlaresSunRayDiffractionIntensity = 3.5f;
            sunFlaresSunRayDiffractionThreshold = 0.13f;
            // Corona Rays Group 1
            sunFlaresCoronaRays1Length = 0.02f;
            sunFlaresCoronaRays1Streaks = 12;
            sunFlaresCoronaRays1Spread = 0.001f;
            sunFlaresCoronaRays1AngleOffset = 0f;
            // Corona Rays Group 2
            sunFlaresCoronaRays2Length = 0.05f;
            sunFlaresCoronaRays2Streaks = 12f;
            sunFlaresCoronaRays2Spread = 0.1f;
            sunFlaresCoronaRays2AngleOffset = 0f;
            // Ghost 1
            sunFlaresGhosts1Size = 0.03f;
            sunFlaresGhosts1Offset = 1.04f;
            sunFlaresGhosts1Brightness = 0.037f;
            // Ghost 2
            sunFlaresGhosts2Size = 0.1f;
            sunFlaresGhosts2Offset = 0.71f;
            sunFlaresGhosts2Brightness = 0.03f;
            // Ghost 3
            sunFlaresGhosts3Size = 0.24f;
            sunFlaresGhosts3Brightness = 0.025f;
            sunFlaresGhosts3Offset = 0.31f;
            // Ghost 4
            sunFlaresGhosts4Size = 0.016f;
            sunFlaresGhosts4Offset = 0f;
            sunFlaresGhosts4Brightness = 0.017f;
            // Halo
            sunFlaresHaloOffset = 0.22f;
            sunFlaresHaloAmplitude = 15.1415f;
            sunFlaresHaloIntensity = 0.01f;
            #endregion
            enableLensDirt = false;
            #region Lens Dirt
            lensDirtIntensity = 0f;
            lensDirtThreshold = 0.5f;
            lensDirtTexture = null;
            lensDirtTextureFile = "";
            lensDirtSpread = 3;
            #endregion
            enableEyeAdaptation = false;
            #region Eye Adaptation
            eyeAdaptation = false;
            eyeAdaptationMinExposure = 0.2f;
            eyeAdaptationMaxExposure = 5f;
            eyeAdaptationSpeedToLight = 0.4f;
            eyeAdaptationSpeedToDark = 0.2f;
            #endregion
            enablePurkinje = false;
            #region Purkinje effect
            purkinje = false;
            purkinjeAmount = 1f;
            purkinjeLuminanceThreshold = 0.15f;
            #endregion
            enableVignetting = false;
            #region Vignetting
            vignettingOuterRing = 0f;
            vignettingInnerRing = 0;
            vignettingFade = 0;
            vignettingCircularShape = false;
            vignettingAspectRatio = 1f;
            vignettingBlink = 0f;
            vignettingColor = new Color(0f, 0f, 0f, 1f);
            vignettingMask = null;
            vignettingMaskFile = "";
            #endregion
            enableDepthOfField = false;
            #region Depth of Field
            depthOfField = false;
            depthOfFieldDebug = false;
            depthOfFieldFocusMode = BeautifyDoFFocusMode.FixedDistance;
            depthOfFieldAutofocusMinDistance = 0;
            depthOfFieldAutofocusMaxDistance = 10000;
            depthofFieldAutofocusViewportPoint_X = 0.5f;
            depthofFieldAutofocusViewportPoint_Y = 0.5f;
            depthOfFieldAutofocusLayerMask = -1;
            depthOfFieldExclusionLayerMask = 0;
            depthOfFieldExclusionLayerMaskDownsampling = 1f;
            depthOfFieldTransparencySupport = false;
            depthOfFieldTransparencyLayerMask = -1;
            depthOfFieldTransparencySupportDownsampling = 1f;
            depthOfFieldExclusionBias = 0.99f;
            depthOfFieldDistance = 1f;
            depthOfFieldFocusSpeed = 1f;
            depthOfFieldDownsampling = 2;
            depthOfFieldMaxSamples = 4;
            depthOfFieldFocalLength = 0.050f;
            depthOfFieldAperture = 2.8f;
            depthOfFieldForegroundBlur = true;
            depthOfFieldForegroundBlurHQ = false;
            depthOfFieldForegroundDistance = 0.25f;
            depthOfFieldBokeh = true;
            depthOfFieldBokehThreshold = 1f;
            depthOfFieldBokehIntensity = 2f;
            depthOfFieldMaxBrightness = 1000f;
            depthOfFieldMaxDistance = 1f;
            depthOfFieldFilterMode = FilterMode.Bilinear;
            #endregion
            enableOutline = false;
            #region Outline
            outline = false;
            outlineColor = new Color(0, 0, 0, 0.8f);
            #endregion
        }

        public static void ClearEffect()
        {
            beautifyEffect = null;
            beautifyEffect = Util.GetComponentVar<Beautify, BeautifyDef>(beautifyEffect);
        }

        public static void InitMemberByInstance(Beautify lb)
        {
            antialiasing = lb.antialiasing;
            enableCompare = lb.enableCompare;
            #region Compare settings
            compareMode = lb.compareMode;
            compareLineAngle = lb.compareLineAngle;
            compareLineWidth = lb.compareLineWidth;
            #endregion
            enableSharpen = lb.enableSharpen;
            #region Sharpen settings
            sharpenIntensity = lb.sharpenIntensity;
            sharpenDepthThreshold = lb.sharpenDepthThreshold;
            sharpenMinDepth = lb.sharpenMinDepth;
            sharpenMaxDepth = lb.sharpenMaxDepth;
            sharpenRelaxation = lb.sharpenRelaxation;
            sharpenClamp = lb.sharpenClamp;
            sharpenMotionSensibility = lb.sharpenMotionSensibility;
            #endregion
            enableColorTweaks = lb.enableColorTweaks;
            #region Color tweaks
            daltonize = lb.daltonize;
            sepia = lb.sepia;
            saturate = lb.saturate;
            brightness = lb.brightness;
            contrast = lb.contrast;
            tintColor = lb.tintColor;
            tonemap = lb.tonemap;
            tonemapExposurePre = lb.tonemapExposurePre;
            tonemapBrightnessPost = lb.tonemapBrightnessPost;
            #endregion
            enableLut = lb.enableLut;
            #region Lut
            lut = lb.lut;
            lutIntensity = lb.lutIntensity;
            lutTexture = lb.lutTexture;
            #endregion
            enableBloomFlares = lb.enableBloomFlares;
            #region Bloom & Flares effects
            bloomIntensity = lb.bloomIntensity;
            bloomThreshold = lb.bloomThreshold;
            bloomMaxBrightness = lb.bloomMaxBrightness;
            bloomDepthAtten = lb.bloomDepthAtten;
            bloomAntiflicker = lb.bloomAntiflicker;
            bloomUltra = lb.bloomUltra;
            bloomDebug = lb.bloomDebug;
            bloomCustomize = lb.bloomCustomize;
            bloomWeight0 = lb.bloomWeight0;
            bloomWeight1 = lb.bloomWeight1;
            bloomWeight2 = lb.bloomWeight2;
            bloomWeight3 = lb.bloomWeight3;
            bloomWeight4 = lb.bloomWeight4;
            bloomWeight5 = lb.bloomWeight5;
            bloomBoost0 = lb.bloomBoost0;
            bloomBoost1 = lb.bloomBoost1;
            bloomBoost2 = lb.bloomBoost2;
            bloomBoost3 = lb.bloomBoost3;
            bloomBoost4 = lb.bloomBoost4;
            bloomBoost5 = lb.bloomBoost5;
            anamorphicFlaresIntensity = lb.anamorphicFlaresIntensity;
            anamorphicFlaresThreshold = lb.anamorphicFlaresThreshold;
            anamorphicFlaresVertical = lb.anamorphicFlaresVertical;
            anamorphicFlaresSpread = lb.anamorphicFlaresSpread;
            anamorphicFlaresDepthAtten = lb.anamorphicFlaresDepthAtten;
            anamorphicFlaresAntiflicker = lb.anamorphicFlaresAntiflicker;
            anamorphicFlaresUltra = lb.anamorphicFlaresUltra;
            anamorphicFlaresTint = lb.anamorphicFlaresTint;
            sunFlaresIntensity = lb.sunFlaresIntensity;
            sunFlaresTint = lb.sunFlaresTint;
            sunFlaresSolarWindSpeed = lb.sunFlaresSolarWindSpeed;
            sunFlaresRotationDeadZone = lb.sunFlaresRotationDeadZone;
            sunFlaresDownsampling = lb.sunFlaresDownsampling;
            sunFlaresLayerMask = lb.sunFlaresLayerMask;
            sunFlaresSunIntensity = lb.sunFlaresSunIntensity;
            sunFlaresSunDiskSize = lb.sunFlaresSunDiskSize;
            sunFlaresSunRayDiffractionIntensity = lb.sunFlaresSunRayDiffractionIntensity;
            sunFlaresSunRayDiffractionThreshold = lb.sunFlaresSunRayDiffractionThreshold;
            // Corona Rays Group 1
            sunFlaresCoronaRays1Length = lb.sunFlaresCoronaRays1Length;
            sunFlaresCoronaRays1Streaks = lb.sunFlaresCoronaRays1Streaks;
            sunFlaresCoronaRays1Spread = lb.sunFlaresCoronaRays1Spread;
            sunFlaresCoronaRays1AngleOffset = lb.sunFlaresCoronaRays1AngleOffset;
            // Corona Rays Group 2
            sunFlaresCoronaRays2Length = lb.sunFlaresCoronaRays2Length;
            sunFlaresCoronaRays2Streaks = lb.sunFlaresCoronaRays2Streaks;
            sunFlaresCoronaRays2Spread = lb.sunFlaresCoronaRays2Spread;
            sunFlaresCoronaRays2AngleOffset = lb.sunFlaresCoronaRays2AngleOffset;
            // Ghost 1
            sunFlaresGhosts1Size = lb.sunFlaresGhosts1Size;
            sunFlaresGhosts1Offset = lb.sunFlaresGhosts1Offset;
            sunFlaresGhosts1Brightness = lb.sunFlaresGhosts1Brightness;
            // Ghost 2
            sunFlaresGhosts2Size = lb.sunFlaresGhosts2Size;
            sunFlaresGhosts2Offset = lb.sunFlaresGhosts2Offset;
            sunFlaresGhosts2Brightness = lb.sunFlaresGhosts2Brightness;
            // Ghost 3
            sunFlaresGhosts3Size = lb.sunFlaresGhosts3Size;
            sunFlaresGhosts3Brightness = lb.sunFlaresGhosts3Brightness;
            sunFlaresGhosts3Offset = lb.sunFlaresGhosts3Offset;
            // Ghost 4
            sunFlaresGhosts4Size = lb.sunFlaresGhosts4Size;
            sunFlaresGhosts4Offset = lb.sunFlaresGhosts4Offset;
            sunFlaresGhosts4Brightness = lb.sunFlaresGhosts4Brightness;
            // Halo
            sunFlaresHaloOffset = lb.sunFlaresHaloOffset;
            sunFlaresHaloAmplitude = lb.sunFlaresHaloAmplitude;
            sunFlaresHaloIntensity = lb.sunFlaresHaloIntensity;
            #endregion
            enableLensDirt = lb.enableLensDirt;
            #region Lens Dirt
            lensDirtIntensity = lb.lensDirtIntensity;
            lensDirtThreshold = lb.lensDirtThreshold;
            lensDirtTexture = lb.lensDirtTexture;
            lensDirtSpread = lb.lensDirtSpread;
            #endregion
            enableEyeAdaptation = lb.enableEyeAdaptation;
            #region Eye Adaptation
            eyeAdaptation = lb.eyeAdaptation;
            eyeAdaptationMinExposure = lb.eyeAdaptationMinExposure;
            eyeAdaptationMaxExposure = lb.eyeAdaptationMaxExposure;
            eyeAdaptationSpeedToLight = lb.eyeAdaptationSpeedToLight;
            eyeAdaptationSpeedToDark = lb.eyeAdaptationSpeedToDark;
            #endregion
            enablePurkinje = lb.enablePurkinje;
            #region Purkinje effect
            purkinje = lb.purkinje;
            purkinjeAmount = lb.purkinjeAmount;
            purkinjeLuminanceThreshold = lb.purkinjeLuminanceThreshold;
            #endregion
            enableVignetting = lb.enableVignetting;
            #region Vignetting
            vignettingOuterRing = lb.vignettingOuterRing;
            vignettingInnerRing = lb.vignettingInnerRing;
            vignettingFade = lb.vignettingFade;
            vignettingCircularShape = lb.vignettingCircularShape;
            vignettingAspectRatio = lb.vignettingAspectRatio;
            vignettingBlink = lb.vignettingBlink;
            vignettingColor = lb.vignettingColor;
            vignettingMask = lb.vignettingMask;
            #endregion
            enableDepthOfField = lb.enableDepthOfField;
            #region Depth of Field
            depthOfField = lb.depthOfField;
            depthOfFieldDebug = lb.depthOfFieldDebug;
            depthOfFieldFocusMode = lb.depthOfFieldFocusMode;
            depthOfFieldAutofocusMinDistance = lb.depthOfFieldAutofocusMinDistance;
            depthOfFieldAutofocusMaxDistance = lb.depthOfFieldAutofocusMaxDistance;
            depthofFieldAutofocusViewportPoint_X = lb.depthofFieldAutofocusViewportPoint_X;
            depthofFieldAutofocusViewportPoint_Y = lb.depthofFieldAutofocusViewportPoint_Y;
            depthOfFieldAutofocusLayerMask = lb.depthOfFieldAutofocusLayerMask;
            depthOfFieldExclusionLayerMask = lb.depthOfFieldExclusionLayerMask;
            depthOfFieldExclusionLayerMaskDownsampling = lb.depthOfFieldExclusionLayerMaskDownsampling;
            depthOfFieldTransparencySupport = lb.depthOfFieldTransparencySupport;
            depthOfFieldTransparencyLayerMask = lb.depthOfFieldTransparencyLayerMask;
            depthOfFieldTransparencySupportDownsampling = lb.depthOfFieldTransparencySupportDownsampling;
            depthOfFieldExclusionBias = lb.depthOfFieldExclusionBias;
            depthOfFieldDistance = lb.depthOfFieldDistance;
            depthOfFieldFocusSpeed = lb.depthOfFieldFocusSpeed;
            depthOfFieldDownsampling = lb.depthOfFieldDownsampling;
            depthOfFieldMaxSamples = lb.depthOfFieldMaxSamples;
            depthOfFieldFocalLength = lb.depthOfFieldFocalLength;
            depthOfFieldAperture = lb.depthOfFieldAperture;
            depthOfFieldForegroundBlur = lb.depthOfFieldForegroundBlur;
            depthOfFieldForegroundBlurHQ = lb.depthOfFieldForegroundBlurHQ;
            depthOfFieldForegroundDistance = lb.depthOfFieldForegroundDistance;
            depthOfFieldBokeh = lb.depthOfFieldBokeh;
            depthOfFieldBokehThreshold = lb.depthOfFieldBokehThreshold;
            depthOfFieldBokehIntensity = lb.depthOfFieldBokehIntensity;
            depthOfFieldMaxBrightness = lb.depthOfFieldMaxBrightness;
            depthOfFieldMaxDistance = lb.depthOfFieldMaxDistance;
            depthOfFieldFilterMode = lb.depthOfFieldFilterMode;
            #endregion
            enableOutline = lb.enableOutline;
            #region Outline
            outline = lb.outline;
            outlineColor = lb.outlineColor;
            #endregion
        }

        public static void Update(BeautifyPane beautifyPane)
        {
            bool needEffectWindowReload = Instances.needEffectWindowReload;
            if (needEffectWindowReload)
            {
                beautifyPane.IsEnabled = beautifyEffect.enabled;
            }
            else
            {
                beautifyEffect.enabled = beautifyPane.IsEnabled;
            }
            beautifyEffect.antialiasing = beautifyPane.antialiasing;
            beautifyEffect.enableCompare = beautifyPane.enableCompare;
            #region Compare settings
            beautifyEffect.compareMode = beautifyPane.compareMode;
            beautifyEffect.compareLineAngle = beautifyPane.compareLineAngle;
            beautifyEffect.compareLineWidth = beautifyPane.compareLineWidth;
            #endregion
            beautifyEffect.enableSharpen = beautifyPane.enableSharpen;
            #region Sharpen settings
            beautifyEffect.sharpenIntensity = beautifyPane.sharpenIntensity;
            sharpenDepthThreshold = beautifyPane.sharpenDepthThreshold;
            beautifyEffect.sharpenMinDepth = beautifyPane.sharpenMinDepth;
            beautifyEffect.sharpenMaxDepth = beautifyPane.sharpenMaxDepth;
            beautifyEffect.sharpenRelaxation = beautifyPane.sharpenRelaxation;
            beautifyEffect.sharpenClamp = beautifyPane.sharpenClamp;
            beautifyEffect.sharpenMotionSensibility = beautifyPane.sharpenMotionSensibility;
            #endregion
            beautifyEffect.enableColorTweaks = beautifyPane.enableColorTweaks;
            #region Color tweaks
            beautifyEffect.daltonize = beautifyPane.daltonize;
            beautifyEffect.sepia = beautifyPane.sepia;
            beautifyEffect.saturate = beautifyPane.saturate;
            beautifyEffect.brightness = beautifyPane.brightness;
            beautifyEffect.contrast = beautifyPane.contrast;
            beautifyEffect.tintColor = beautifyPane.tintColor;
            beautifyEffect.tonemap = beautifyPane.tonemap;
            beautifyEffect.tonemapExposurePre = beautifyPane.tonemapExposurePre;
            beautifyEffect.tonemapBrightnessPost = beautifyPane.tonemapBrightnessPost;
            #endregion
            beautifyEffect.enableLut = beautifyPane.enableLut;
            #region Lut
            beautifyEffect.lut = beautifyPane.lut;
            beautifyEffect.lutIntensity = beautifyPane.lutIntensity;
            // beautifyEffect.lutTexture = beautifyPane.lutTexture;
            #endregion
            beautifyEffect.enableBloomFlares = beautifyPane.enableBloomFlares;
            #region Bloom & Flares effects
            beautifyEffect.bloomIntensity = beautifyPane.bloomIntensity;
            beautifyEffect.bloomThreshold = beautifyPane.bloomThreshold;
            beautifyEffect.bloomMaxBrightness = beautifyPane.bloomMaxBrightness;
            beautifyEffect.bloomDepthAtten = beautifyPane.bloomDepthAtten;
            beautifyEffect.bloomAntiflicker = beautifyPane.bloomAntiflicker;
            beautifyEffect.bloomUltra = beautifyPane.bloomUltra;
            beautifyEffect.bloomDebug = beautifyPane.bloomDebug;
            beautifyEffect.bloomCustomize = beautifyPane.bloomCustomize;
            beautifyEffect.bloomWeight0 = beautifyPane.bloomWeight0;
            beautifyEffect.bloomWeight1 = beautifyPane.bloomWeight1;
            beautifyEffect.bloomWeight2 = beautifyPane.bloomWeight2;
            beautifyEffect.bloomWeight3 = beautifyPane.bloomWeight3;
            beautifyEffect.bloomWeight4 = beautifyPane.bloomWeight4;
            beautifyEffect.bloomWeight5 = beautifyPane.bloomWeight5;
            beautifyEffect.bloomBoost0 = beautifyPane.bloomBoost0;
            beautifyEffect.bloomBoost1 = beautifyPane.bloomBoost1;
            beautifyEffect.bloomBoost2 = beautifyPane.bloomBoost2;
            beautifyEffect.bloomBoost3 = beautifyPane.bloomBoost3;
            beautifyEffect.bloomBoost4 = beautifyPane.bloomBoost4;
            beautifyEffect.bloomBoost5 = beautifyPane.bloomBoost5;
            beautifyEffect.anamorphicFlaresIntensity = beautifyPane.anamorphicFlaresIntensity;
            beautifyEffect.anamorphicFlaresThreshold = beautifyPane.anamorphicFlaresThreshold;
            beautifyEffect.anamorphicFlaresVertical = beautifyPane.anamorphicFlaresVertical;
            beautifyEffect.anamorphicFlaresSpread = beautifyPane.anamorphicFlaresSpread;
            beautifyEffect.anamorphicFlaresDepthAtten = beautifyPane.anamorphicFlaresDepthAtten;
            beautifyEffect.anamorphicFlaresAntiflicker = beautifyPane.anamorphicFlaresAntiflicker;
            beautifyEffect.anamorphicFlaresUltra = beautifyPane.anamorphicFlaresUltra;
            beautifyEffect.anamorphicFlaresTint = beautifyPane.anamorphicFlaresTint;
            beautifyEffect.sunFlaresIntensity = beautifyPane.sunFlaresIntensity;
            beautifyEffect.sunFlaresTint = beautifyPane.sunFlaresTint;
            beautifyEffect.sunFlaresSolarWindSpeed = beautifyPane.sunFlaresSolarWindSpeed;
            beautifyEffect.sunFlaresRotationDeadZone = beautifyPane.sunFlaresRotationDeadZone;
            beautifyEffect.sunFlaresDownsampling = beautifyPane.sunFlaresDownsampling;
            beautifyEffect.sunFlaresLayerMask = beautifyPane.sunFlaresLayerMask;
            beautifyEffect.sunFlaresSunIntensity = beautifyPane.sunFlaresSunIntensity;
            beautifyEffect.sunFlaresSunDiskSize = beautifyPane.sunFlaresSunDiskSize;
            beautifyEffect.sunFlaresSunRayDiffractionIntensity = beautifyPane.sunFlaresSunRayDiffractionIntensity;
            beautifyEffect.sunFlaresSunRayDiffractionThreshold = beautifyPane.sunFlaresSunRayDiffractionThreshold;
            // Corona Rays Group 1
            beautifyEffect.sunFlaresCoronaRays1Length = beautifyPane.sunFlaresCoronaRays1Length;
            beautifyEffect.sunFlaresCoronaRays1Streaks = beautifyPane.sunFlaresCoronaRays1Streaks;
            beautifyEffect.sunFlaresCoronaRays1Spread = beautifyPane.sunFlaresCoronaRays1Spread;
            beautifyEffect.sunFlaresCoronaRays1AngleOffset = beautifyPane.sunFlaresCoronaRays1AngleOffset;
            // Corona Rays Group 2
            beautifyEffect.sunFlaresCoronaRays2Length = beautifyPane.sunFlaresCoronaRays2Length;
            beautifyEffect.sunFlaresCoronaRays2Streaks = beautifyPane.sunFlaresCoronaRays2Streaks;
            beautifyEffect.sunFlaresCoronaRays2Spread = beautifyPane.sunFlaresCoronaRays2Spread;
            beautifyEffect.sunFlaresCoronaRays2AngleOffset = beautifyPane.sunFlaresCoronaRays2AngleOffset;
            // Ghost 1
            beautifyEffect.sunFlaresGhosts1Size = beautifyPane.sunFlaresGhosts1Size;
            beautifyEffect.sunFlaresGhosts1Offset = beautifyPane.sunFlaresGhosts1Offset;
            beautifyEffect.sunFlaresGhosts1Brightness = beautifyPane.sunFlaresGhosts1Brightness;
            // Ghost 2
            beautifyEffect.sunFlaresGhosts2Size = beautifyPane.sunFlaresGhosts2Size;
            beautifyEffect.sunFlaresGhosts2Offset = beautifyPane.sunFlaresGhosts2Offset;
            beautifyEffect.sunFlaresGhosts2Brightness = beautifyPane.sunFlaresGhosts2Brightness;
            // Ghost 3
            beautifyEffect.sunFlaresGhosts3Size = beautifyPane.sunFlaresGhosts3Size;
            beautifyEffect.sunFlaresGhosts3Brightness = beautifyPane.sunFlaresGhosts3Brightness;
            beautifyEffect.sunFlaresGhosts3Offset = beautifyPane.sunFlaresGhosts3Offset;
            // Ghost 4
            beautifyEffect.sunFlaresGhosts4Size = beautifyPane.sunFlaresGhosts4Size;
            beautifyEffect.sunFlaresGhosts4Offset = beautifyPane.sunFlaresGhosts4Offset;
            beautifyEffect.sunFlaresGhosts4Brightness = beautifyPane.sunFlaresGhosts4Brightness;
            // Halo
            beautifyEffect.sunFlaresHaloOffset = beautifyPane.sunFlaresHaloOffset;
            beautifyEffect.sunFlaresHaloAmplitude = beautifyPane.sunFlaresHaloAmplitude;
            beautifyEffect.sunFlaresHaloIntensity = beautifyPane.sunFlaresHaloIntensity;
            #endregion
            beautifyEffect.enableLensDirt = beautifyPane.enableLensDirt;
            #region Lens Dirt
            beautifyEffect.lensDirtIntensity = beautifyPane.lensDirtIntensity;
            beautifyEffect.lensDirtThreshold = beautifyPane.lensDirtThreshold;
            // beautifyEffect.lensDirtTexture = beautifyPane.lensDirtTexture;
            beautifyEffect.lensDirtSpread = beautifyPane.lensDirtSpread;
            #endregion
            beautifyEffect.enableEyeAdaptation = beautifyPane.enableEyeAdaptation;
            #region Eye Adaptation
            beautifyEffect.eyeAdaptation = beautifyPane.eyeAdaptation;
            beautifyEffect.eyeAdaptationMinExposure = beautifyPane.eyeAdaptationMinExposure;
            beautifyEffect.eyeAdaptationMaxExposure = beautifyPane.eyeAdaptationMaxExposure;
            beautifyEffect.eyeAdaptationSpeedToLight = beautifyPane.eyeAdaptationSpeedToLight;
            beautifyEffect.eyeAdaptationSpeedToDark = beautifyPane.eyeAdaptationSpeedToDark;
            #endregion
            beautifyEffect.enablePurkinje = beautifyPane.enablePurkinje;
            #region Purkinje effect
            beautifyEffect.purkinje = beautifyPane.purkinje;
            beautifyEffect.purkinjeAmount = beautifyPane.purkinjeAmount;
            beautifyEffect.purkinjeLuminanceThreshold = beautifyPane.purkinjeLuminanceThreshold;
            #endregion
            beautifyEffect.enableVignetting = beautifyPane.enableVignetting;
            #region Vignetting
            beautifyEffect.vignettingOuterRing = beautifyPane.vignettingOuterRing;
            beautifyEffect.vignettingInnerRing = beautifyPane.vignettingInnerRing;
            beautifyEffect.vignettingFade = beautifyPane.vignettingFade;
            beautifyEffect.vignettingCircularShape = beautifyPane.vignettingCircularShape;
            beautifyEffect.vignettingAspectRatio = beautifyPane.vignettingAspectRatio;
            beautifyEffect.vignettingBlink = beautifyPane.vignettingBlink;
            beautifyEffect.vignettingColor = beautifyPane.vignettingColor;
            // beautifyEffect.vignettingMask = beautifyPane.vignettingMask;
            #endregion
            beautifyEffect.enableDepthOfField = beautifyPane.enableDepthOfField;
            #region Depth of Field
            beautifyEffect.depthOfField = beautifyPane.depthOfField;
            beautifyEffect.depthOfFieldDebug = beautifyPane.depthOfFieldDebug;
            beautifyEffect.depthOfFieldFocusMode = beautifyPane.depthOfFieldFocusMode;
            beautifyEffect.depthOfFieldAutofocusMinDistance = beautifyPane.depthOfFieldAutofocusMinDistance;
            beautifyEffect.depthOfFieldAutofocusMaxDistance = beautifyPane.depthOfFieldAutofocusMaxDistance;
            beautifyEffect.depthofFieldAutofocusViewportPoint_X = beautifyPane.depthofFieldAutofocusViewportPoint_X;
            beautifyEffect.depthofFieldAutofocusViewportPoint_Y = beautifyPane.depthofFieldAutofocusViewportPoint_Y;
            beautifyEffect.depthOfFieldAutofocusLayerMask = beautifyPane.depthOfFieldAutofocusLayerMask;
            beautifyEffect.depthOfFieldExclusionLayerMask = beautifyPane.depthOfFieldExclusionLayerMask;
            beautifyEffect.depthOfFieldExclusionLayerMaskDownsampling = beautifyPane.depthOfFieldExclusionLayerMaskDownsampling;
            beautifyEffect.depthOfFieldTransparencySupport = beautifyPane.depthOfFieldTransparencySupport;
            beautifyEffect.depthOfFieldTransparencyLayerMask = beautifyPane.depthOfFieldTransparencyLayerMask;
            beautifyEffect.depthOfFieldTransparencySupportDownsampling = beautifyPane.depthOfFieldTransparencySupportDownsampling;
            beautifyEffect.depthOfFieldExclusionBias = beautifyPane.depthOfFieldExclusionBias;
            beautifyEffect.depthOfFieldDistance = beautifyPane.depthOfFieldDistance;
            beautifyEffect.depthOfFieldFocusSpeed = beautifyPane.depthOfFieldFocusSpeed;
            beautifyEffect.depthOfFieldDownsampling = beautifyPane.depthOfFieldDownsampling;
            beautifyEffect.depthOfFieldMaxSamples = beautifyPane.depthOfFieldMaxSamples;
            beautifyEffect.depthOfFieldFocalLength = beautifyPane.depthOfFieldFocalLength;
            beautifyEffect.depthOfFieldAperture = beautifyPane.depthOfFieldAperture;
            beautifyEffect.depthOfFieldForegroundBlur = beautifyPane.depthOfFieldForegroundBlur;
            beautifyEffect.depthOfFieldForegroundBlurHQ = beautifyPane.depthOfFieldForegroundBlurHQ;
            beautifyEffect.depthOfFieldForegroundDistance = beautifyPane.depthOfFieldForegroundDistance;
            beautifyEffect.depthOfFieldBokeh = beautifyPane.depthOfFieldBokeh;
            beautifyEffect.depthOfFieldBokehThreshold = beautifyPane.depthOfFieldBokehThreshold;
            beautifyEffect.depthOfFieldBokehIntensity = beautifyPane.depthOfFieldBokehIntensity;
            beautifyEffect.depthOfFieldMaxBrightness = beautifyPane.depthOfFieldMaxBrightness;
            beautifyEffect.depthOfFieldMaxDistance = beautifyPane.depthOfFieldMaxDistance;
            beautifyEffect.depthOfFieldFilterMode = beautifyPane.depthOfFieldFilterMode;
            #endregion
            beautifyEffect.enableOutline = beautifyPane.enableOutline;
            #region Outline
            beautifyEffect.outline = beautifyPane.outline;
            beautifyEffect.outlineColor = beautifyPane.outlineColor;
            #endregion

            bool loadPreset = BeautifyDef.loadPreset;
            if (loadPreset)
            {
                if (lutTexture != null)
                {
                    beautifyPane.lutTexture = lutTexture;
                    beautifyPane.lutTextureFile = lutTextureFile;
                }
                if (lensDirtTexture != null)
                {
                    beautifyPane.lensDirtTexture = lensDirtTexture;
                    beautifyPane.lensDirtTextureFile = lensDirtTextureFile;
                }
                if (vignettingMask != null)
                {
                    beautifyPane.vignettingMask = vignettingMask;
                    beautifyPane.vignettingMaskFile = vignettingMaskFile;
                }
                BeautifyDef.loadPreset = false;
            }
            else
            {
                beautifyEffect.lutTexture = beautifyPane.lutTexture;
                lutTextureFile = beautifyPane.lutTextureFile;
                beautifyEffect.lensDirtTexture = beautifyPane.lensDirtTexture;
                lensDirtTextureFile = beautifyPane.lensDirtTextureFile;
                beautifyEffect.vignettingMask = beautifyPane.vignettingMask;
                vignettingMaskFile = beautifyPane.vignettingMaskFile;
            }
        }

        public static void Reset()
        {
            if (beautifyEffect != null)
            {
                beautifyEffect.antialiasing = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
                beautifyEffect.enableCompare = enableCompare;
                #region Compare settings
                beautifyEffect.compareMode = compareMode;
                beautifyEffect.compareLineAngle = compareLineAngle;
                beautifyEffect.compareLineWidth = compareLineWidth;
                #endregion
                beautifyEffect.enableSharpen = enableSharpen;
                #region Sharpen settings
                beautifyEffect.sharpenIntensity = sharpenIntensity;
                beautifyEffect.sharpenDepthThreshold = sharpenDepthThreshold;
                beautifyEffect.sharpenMinDepth = sharpenMinDepth;
                beautifyEffect.sharpenMaxDepth = sharpenMaxDepth;
                beautifyEffect.sharpenRelaxation = sharpenRelaxation;
                beautifyEffect.sharpenClamp = sharpenClamp;
                beautifyEffect.sharpenMotionSensibility = sharpenMotionSensibility;
                #endregion
                beautifyEffect.enableColorTweaks = enableColorTweaks;
                #region Color tweaks
                beautifyEffect.daltonize = daltonize;
                beautifyEffect.sepia = sepia;
                beautifyEffect.saturate = saturate;
                beautifyEffect.brightness = brightness;
                beautifyEffect.contrast = contrast;
                beautifyEffect.tintColor = tintColor;
                beautifyEffect.tonemap = tonemap;
                beautifyEffect.tonemapExposurePre = tonemapExposurePre;
                beautifyEffect.tonemapBrightnessPost = tonemapBrightnessPost;
                #endregion
                beautifyEffect.enableLut = enableLut;
                #region Lut
                beautifyEffect.lut = lut;
                beautifyEffect.lutIntensity = lutIntensity;
                beautifyEffect.lutTexture = lutTexture;
                #endregion
                beautifyEffect.enableBloomFlares = enableBloomFlares;
                #region Bloom & Flares effects
                beautifyEffect.bloomIntensity = bloomIntensity;
                beautifyEffect.bloomThreshold = bloomThreshold;
                beautifyEffect.bloomMaxBrightness = bloomMaxBrightness;
                beautifyEffect.bloomDepthAtten = bloomDepthAtten;
                beautifyEffect.bloomAntiflicker = bloomAntiflicker;
                beautifyEffect.bloomUltra = bloomUltra;
                beautifyEffect.bloomDebug = bloomDebug;
                beautifyEffect.bloomCustomize = bloomCustomize;
                beautifyEffect.bloomWeight0 = bloomWeight0;
                beautifyEffect.bloomWeight1 = bloomWeight1;
                beautifyEffect.bloomWeight2 = bloomWeight2;
                beautifyEffect.bloomWeight3 = bloomWeight3;
                beautifyEffect.bloomWeight4 = bloomWeight4;
                beautifyEffect.bloomWeight5 = bloomWeight5;
                beautifyEffect.bloomBoost0 = bloomBoost0;
                beautifyEffect.bloomBoost1 = bloomBoost1;
                beautifyEffect.bloomBoost2 = bloomBoost2;
                beautifyEffect.bloomBoost3 = bloomBoost3;
                beautifyEffect.bloomBoost4 = bloomBoost4;
                beautifyEffect.bloomBoost5 = bloomBoost5;
                beautifyEffect.anamorphicFlaresIntensity = anamorphicFlaresIntensity;
                beautifyEffect.anamorphicFlaresThreshold = anamorphicFlaresThreshold;
                beautifyEffect.anamorphicFlaresVertical = anamorphicFlaresVertical;
                beautifyEffect.anamorphicFlaresSpread = anamorphicFlaresSpread;
                beautifyEffect.anamorphicFlaresDepthAtten = anamorphicFlaresDepthAtten;
                beautifyEffect.anamorphicFlaresAntiflicker = anamorphicFlaresAntiflicker;
                beautifyEffect.anamorphicFlaresUltra = anamorphicFlaresUltra;
                beautifyEffect.anamorphicFlaresTint = anamorphicFlaresTint;
                beautifyEffect.sunFlaresIntensity = sunFlaresIntensity;
                beautifyEffect.sunFlaresTint = sunFlaresTint;
                beautifyEffect.sunFlaresSolarWindSpeed = sunFlaresSolarWindSpeed;
                beautifyEffect.sunFlaresRotationDeadZone = sunFlaresRotationDeadZone;
                beautifyEffect.sunFlaresDownsampling = sunFlaresDownsampling;
                beautifyEffect.sunFlaresLayerMask = sunFlaresLayerMask;
                beautifyEffect.sunFlaresSunIntensity = sunFlaresSunIntensity;
                beautifyEffect.sunFlaresSunDiskSize = sunFlaresSunDiskSize;
                beautifyEffect.sunFlaresSunRayDiffractionIntensity = sunFlaresSunRayDiffractionIntensity;
                beautifyEffect.sunFlaresSunRayDiffractionThreshold = sunFlaresSunRayDiffractionThreshold;
                // Corona Rays Group 1
                beautifyEffect.sunFlaresCoronaRays1Length = sunFlaresCoronaRays1Length;
                beautifyEffect.sunFlaresCoronaRays1Streaks = sunFlaresCoronaRays1Streaks;
                beautifyEffect.sunFlaresCoronaRays1Spread = sunFlaresCoronaRays1Spread;
                beautifyEffect.sunFlaresCoronaRays1AngleOffset = sunFlaresCoronaRays1AngleOffset;
                // Corona Rays Group 2
                beautifyEffect.sunFlaresCoronaRays2Length = sunFlaresCoronaRays2Length;
                beautifyEffect.sunFlaresCoronaRays2Streaks = sunFlaresCoronaRays2Streaks;
                beautifyEffect.sunFlaresCoronaRays2Spread = sunFlaresCoronaRays2Spread;
                beautifyEffect.sunFlaresCoronaRays2AngleOffset = sunFlaresCoronaRays2AngleOffset;
                // Ghost 1
                beautifyEffect.sunFlaresGhosts1Size = sunFlaresGhosts1Size;
                beautifyEffect.sunFlaresGhosts1Offset = sunFlaresGhosts1Offset;
                beautifyEffect.sunFlaresGhosts1Brightness = sunFlaresGhosts1Brightness;
                // Ghost 2
                beautifyEffect.sunFlaresGhosts2Size = sunFlaresGhosts2Size;
                beautifyEffect.sunFlaresGhosts2Offset = sunFlaresGhosts2Offset;
                beautifyEffect.sunFlaresGhosts2Brightness = sunFlaresGhosts2Brightness;
                // Ghost 3
                beautifyEffect.sunFlaresGhosts3Size = sunFlaresGhosts3Size;
                beautifyEffect.sunFlaresGhosts3Brightness = sunFlaresGhosts3Brightness;
                beautifyEffect.sunFlaresGhosts3Offset = sunFlaresGhosts3Offset;
                // Ghost 4
                beautifyEffect.sunFlaresGhosts4Size = sunFlaresGhosts4Size;
                beautifyEffect.sunFlaresGhosts4Offset = sunFlaresGhosts4Offset;
                beautifyEffect.sunFlaresGhosts4Brightness = sunFlaresGhosts4Brightness;
                // Halo
                beautifyEffect.sunFlaresHaloOffset = sunFlaresHaloOffset;
                beautifyEffect.sunFlaresHaloAmplitude = sunFlaresHaloAmplitude;
                beautifyEffect.sunFlaresHaloIntensity = sunFlaresHaloIntensity;
                #endregion
                beautifyEffect.enableLensDirt = enableLensDirt;
                #region Lens Dirt
                beautifyEffect.lensDirtIntensity = lensDirtIntensity;
                beautifyEffect.lensDirtThreshold = lensDirtThreshold;
                beautifyEffect.lensDirtTexture = lensDirtTexture;
                beautifyEffect.lensDirtSpread = lensDirtSpread;
                #endregion
                beautifyEffect.enableEyeAdaptation = enableEyeAdaptation;
                #region Eye Adaptation
                beautifyEffect.eyeAdaptation = eyeAdaptation;
                beautifyEffect.eyeAdaptationMinExposure = eyeAdaptationMinExposure;
                beautifyEffect.eyeAdaptationMaxExposure = eyeAdaptationMaxExposure;
                beautifyEffect.eyeAdaptationSpeedToLight = eyeAdaptationSpeedToLight;
                beautifyEffect.eyeAdaptationSpeedToDark = eyeAdaptationSpeedToDark;
                #endregion
                beautifyEffect.enablePurkinje = enablePurkinje;
                #region Purkinje effect
                beautifyEffect.purkinje = purkinje;
                beautifyEffect.purkinjeAmount = purkinjeAmount;
                beautifyEffect.purkinjeLuminanceThreshold = purkinjeLuminanceThreshold;
                #endregion
                beautifyEffect.enableVignetting = enableVignetting;
                #region Vignetting
                beautifyEffect.vignettingOuterRing = vignettingOuterRing;
                beautifyEffect.vignettingInnerRing = vignettingInnerRing;
                beautifyEffect.vignettingFade = vignettingFade;
                beautifyEffect.vignettingCircularShape = vignettingCircularShape;
                beautifyEffect.vignettingAspectRatio = vignettingAspectRatio;
                beautifyEffect.vignettingBlink = vignettingBlink;
                beautifyEffect.vignettingColor = vignettingColor;
                beautifyEffect.vignettingMask = vignettingMask;
                #endregion
                beautifyEffect.enableDepthOfField = enableDepthOfField;
                #region Depth of Field
                beautifyEffect.depthOfField = depthOfField;
                beautifyEffect.depthOfFieldDebug = depthOfFieldDebug;
                beautifyEffect.depthOfFieldFocusMode = depthOfFieldFocusMode;
                beautifyEffect.depthOfFieldAutofocusMinDistance = depthOfFieldAutofocusMinDistance;
                beautifyEffect.depthOfFieldAutofocusMaxDistance = depthOfFieldAutofocusMaxDistance;
                beautifyEffect.depthofFieldAutofocusViewportPoint_X = depthofFieldAutofocusViewportPoint_X;
                beautifyEffect.depthofFieldAutofocusViewportPoint_Y = depthofFieldAutofocusViewportPoint_Y;
                beautifyEffect.depthOfFieldAutofocusLayerMask = depthOfFieldAutofocusLayerMask;
                beautifyEffect.depthOfFieldExclusionLayerMask = depthOfFieldExclusionLayerMask;
                beautifyEffect.depthOfFieldExclusionLayerMaskDownsampling = depthOfFieldExclusionLayerMaskDownsampling;
                beautifyEffect.depthOfFieldTransparencySupport = depthOfFieldTransparencySupport;
                beautifyEffect.depthOfFieldTransparencyLayerMask = depthOfFieldTransparencyLayerMask;
                beautifyEffect.depthOfFieldTransparencySupportDownsampling = depthOfFieldTransparencySupportDownsampling;
                beautifyEffect.depthOfFieldExclusionBias = depthOfFieldExclusionBias;
                beautifyEffect.depthOfFieldDistance = depthOfFieldDistance;
                beautifyEffect.depthOfFieldFocusSpeed = depthOfFieldFocusSpeed;
                beautifyEffect.depthOfFieldDownsampling = depthOfFieldDownsampling;
                beautifyEffect.depthOfFieldMaxSamples = depthOfFieldMaxSamples;
                beautifyEffect.depthOfFieldFocalLength = depthOfFieldFocalLength;
                beautifyEffect.depthOfFieldAperture = depthOfFieldAperture;
                beautifyEffect.depthOfFieldForegroundBlur = depthOfFieldForegroundBlur;
                beautifyEffect.depthOfFieldForegroundBlurHQ = depthOfFieldForegroundBlurHQ;
                beautifyEffect.depthOfFieldForegroundDistance = depthOfFieldForegroundDistance;
                beautifyEffect.depthOfFieldBokeh = depthOfFieldBokeh;
                beautifyEffect.depthOfFieldBokehThreshold = depthOfFieldBokehThreshold;
                beautifyEffect.depthOfFieldBokehIntensity = depthOfFieldBokehIntensity;
                beautifyEffect.depthOfFieldMaxBrightness = depthOfFieldMaxBrightness;
                beautifyEffect.depthOfFieldMaxDistance = depthOfFieldMaxDistance;
                beautifyEffect.depthOfFieldFilterMode = depthOfFieldFilterMode;
                #endregion
                beautifyEffect.enableOutline = enableOutline;
                #region Outline
                beautifyEffect.outline = outline;
                beautifyEffect.outlineColor = outlineColor;
                #endregion
            }
        }
    }
}
