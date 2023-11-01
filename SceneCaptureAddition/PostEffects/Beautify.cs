using BeautifyForPPS;
using COM3D2.PostProcessing.Plugin;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace CM3D2.SceneCapture.Plugin
{
    public class Beautify : MonoBehaviour
    {
        private Camera cachedCamera;
        private PostProcessLayer layer;
        private BeautifyForPPS.Beautify _beautify;
        private BeautifyForPPS.Beautify beautify
        {
            get
            {
                if (_beautify == null)
                {
                    _beautify = PostProcessing.PostVolume.profile.GetSetting<BeautifyForPPS.Beautify>();
                }
                return _beautify;
            }
        }
        public PostProcessLayer.Antialiasing antialiasing = PostProcessLayer.Antialiasing.FastApproximateAntialiasing;
        public bool enableCompare = false;
        #region Compare settings
        public bool compareMode = false;
        public float compareLineAngle = 1.4f;
        public float compareLineWidth = 0.002f;
        #endregion
        public bool enableSharpen = false;
        #region Sharpen settings
        public float sharpenIntensity = 4f;
        public float sharpenDepthThreshold = 0.035f;
        public float sharpenMinDepth = 0f;
        public float sharpenMaxDepth = 0.999f;
        public float sharpenRelaxation = 0.08f;
        public float sharpenClamp = 0.45f;
        public float sharpenMotionSensibility = 0.5f;
        #endregion
        public bool enableColorTweaks = false;
        #region Color tweaks
        public float daltonize = 0f;
        public float sepia = 0f;
        public float saturate = 0f;
        public float brightness = 1f;
        public float contrast = 1f;
        public Color tintColor = new Color(1, 1, 1, 0);
        public BeautifyTonemapOperator tonemap = BeautifyTonemapOperator.Linear;
        public float tonemapExposurePre = 1f;
        public float tonemapBrightnessPost = 1f;
        #endregion
        public bool enableLut = false;
        #region Lut
        public bool lut = false;
        public float lutIntensity = 1f;
        public Texture2D lutTexture;
        #endregion
        public bool enableBloomFlares = false;
        #region Bloom & Flares effects
        public float bloomIntensity = 0f;
        public float bloomThreshold = 0.75f;
        public float bloomMaxBrightness = 1000f;
        public float bloomDepthAtten = 0f;
        public bool bloomAntiflicker = false;
        public bool bloomUltra = false;
        public bool bloomDebug = false;
        public bool bloomCustomize = false;
        public float bloomWeight0 = 0.5f;
        public float bloomWeight1 = 0.5f;
        public float bloomWeight2 = 0.5f;
        public float bloomWeight3 = 0.5f;
        public float bloomWeight4 = 0.5f;
        public float bloomWeight5 = 0.5f;
        public float bloomBoost0 = 0f;
        public float bloomBoost1 = 0f;
        public float bloomBoost2 = 0f;
        public float bloomBoost3 = 0f;
        public float bloomBoost4 = 0f;
        public float bloomBoost5 = 0f;
        public float anamorphicFlaresIntensity = 0f;
        public float anamorphicFlaresThreshold = 0.75f;
        public bool anamorphicFlaresVertical = false;
        public float anamorphicFlaresSpread = 1f;
        public float anamorphicFlaresDepthAtten = 0f;
        public bool anamorphicFlaresAntiflicker = false;
        public bool anamorphicFlaresUltra = false;
        public Color anamorphicFlaresTint = new Color(0.5f, 0.5f, 1f, 0f);
        public float sunFlaresIntensity = 0.0f;
        public Color sunFlaresTint = new Color(1, 1, 1);
        public float sunFlaresSolarWindSpeed = 0.01f;
        public bool sunFlaresRotationDeadZone = false;
        public int sunFlaresDownsampling = 1;
        public int sunFlaresLayerMask = -1;
        public float sunFlaresSunIntensity = 0.1f;
        public float sunFlaresSunDiskSize = 0.05f;
        public float sunFlaresSunRayDiffractionIntensity = 3.5f;
        public float sunFlaresSunRayDiffractionThreshold = 0.13f;
        // Corona Rays Group 1
        public float sunFlaresCoronaRays1Length = 0.02f;
        public float sunFlaresCoronaRays1Streaks = 12;
        public float sunFlaresCoronaRays1Spread = 0.001f;
        public float sunFlaresCoronaRays1AngleOffset = 0f;
        // Corona Rays Group 2
        public float sunFlaresCoronaRays2Length = 0.05f;
        public float sunFlaresCoronaRays2Streaks = 12f;
        public float sunFlaresCoronaRays2Spread = 0.1f;
        public float sunFlaresCoronaRays2AngleOffset = 0f;
        // Ghost 1
        public float sunFlaresGhosts1Size = 0.03f;
        public float sunFlaresGhosts1Offset = 1.04f;
        public float sunFlaresGhosts1Brightness = 0.037f;
        // Ghost 2"
        public float sunFlaresGhosts2Size = 0.1f;
        public float sunFlaresGhosts2Offset = 0.71f;
        public float sunFlaresGhosts2Brightness = 0.03f;
        // Ghost 3
        public float sunFlaresGhosts3Size = 0.24f;
        public float sunFlaresGhosts3Brightness = 0.025f;
        public float sunFlaresGhosts3Offset = 0.31f;
        // Ghost 4
        public float sunFlaresGhosts4Size = 0.016f;
        public float sunFlaresGhosts4Offset = 0f;
        public float sunFlaresGhosts4Brightness = 0.017f;
        // Halo
        public float sunFlaresHaloOffset = 0.22f;
        public float sunFlaresHaloAmplitude = 15.1415f;
        public float sunFlaresHaloIntensity = 0.01f;
        #endregion
        public bool enableLensDirt = false;
        #region Lens Dirt
        public float lensDirtIntensity = 0f;
        public float lensDirtThreshold = 0.5f;
        public Texture2D lensDirtTexture;
        public int lensDirtSpread = 3;
        #endregion
        public bool enableEyeAdaptation = false;
        #region Eye Adaptation
        public bool eyeAdaptation = false;
        public float eyeAdaptationMinExposure = 0.2f;
        public float eyeAdaptationMaxExposure = 5f;
        public float eyeAdaptationSpeedToLight = 0.4f;
        public float eyeAdaptationSpeedToDark = 0.2f;
        #endregion
        public bool enablePurkinje = false;
        #region Purkinje effect
        public bool purkinje = false;
        public float purkinjeAmount = 1f;
        public float purkinjeLuminanceThreshold = 0.15f;
        #endregion
        public bool enableVignetting = false;
        #region Vignetting
        public float vignettingOuterRing = 0f;
        public float vignettingInnerRing = 0;
        public float vignettingFade = 0;
        public bool vignettingCircularShape = false;
        public float vignettingAspectRatio = 1f;
        public float vignettingBlink = 0f;
        public Color vignettingColor = new Color(0f, 0f, 0f, 1f);
        public Texture2D vignettingMask;
        #endregion
        public bool enableDepthOfField = false;
        #region Depth of Field
        public bool depthOfField = false;
        public bool depthOfFieldDebug = false;
        public BeautifyDoFFocusMode depthOfFieldFocusMode = BeautifyDoFFocusMode.FixedDistance;
        public float depthOfFieldAutofocusMinDistance = 0;
        public float depthOfFieldAutofocusMaxDistance = 10000;
        public float depthofFieldAutofocusViewportPoint_X = 0.5f;
        public float depthofFieldAutofocusViewportPoint_Y = 0.5f;
        public int depthOfFieldAutofocusLayerMask = -1;
        public int depthOfFieldExclusionLayerMask = 0;
        public float depthOfFieldExclusionLayerMaskDownsampling = 1f;
        public bool depthOfFieldTransparencySupport = false;
        public int depthOfFieldTransparencyLayerMask = -1;
        public float depthOfFieldTransparencySupportDownsampling = 1f;
        public float depthOfFieldExclusionBias = 0.99f;
        public float depthOfFieldDistance = 1f;
        public float depthOfFieldFocusSpeed = 1f;
        public int depthOfFieldDownsampling = 2;
        public int depthOfFieldMaxSamples = 4;
        public float depthOfFieldFocalLength = 0.050f;
        public float depthOfFieldAperture = 2.8f;
        public bool depthOfFieldForegroundBlur = true;
        public bool depthOfFieldForegroundBlurHQ = false;
        public float depthOfFieldForegroundDistance = 0.25f;
        public bool depthOfFieldBokeh = true;
        public float depthOfFieldBokehThreshold = 1f;
        public float depthOfFieldBokehIntensity = 2f;
        public float depthOfFieldMaxBrightness = 1000f;
        public float depthOfFieldMaxDistance = 1f;
        public FilterMode depthOfFieldFilterMode = FilterMode.Bilinear;
        #endregion
        public bool enableOutline = false;
        #region Outline
        public bool outline = false;
        public Color outlineColor = new Color(0, 0, 0, 0.8f);
        #endregion

        private void OnEnable()
        {
            cachedCamera = GetComponent<Camera>();
            if (cachedCamera != null)
            {
                layer = cachedCamera.gameObject.GetComponent<PostProcessLayer>();
                if (layer != null)
                {
                    Destroy(layer);
                    StartCoroutine(InitNextFrame());
                }
                else
                {
                    InitLayer();
                }
                
            }
        }

        private IEnumerator InitNextFrame()
        {
            yield return null;
            InitLayer();
        }

        private void InitLayer()
        {
            layer = cachedCamera.gameObject.GetOrAddComponent<PostProcessLayer>();
            layer.Init(COM3D2.PostProcessing.Plugin.Utils.AssetLoader.postProcessResources);
            layer.volumeLayer = -1;
            layer.fastApproximateAntialiasing.fastMode = false;
            layer.fastApproximateAntialiasing.keepAlpha = true;
            layer.subpixelMorphologicalAntialiasing.quality = SubpixelMorphologicalAntialiasing.Quality.High;
            layer.temporalAntialiasing.jitterSpread = 0.7f;
            layer.temporalAntialiasing.stationaryBlending = 0.8f;
            layer.temporalAntialiasing.motionBlending = 0.8f;
            layer.temporalAntialiasing.sharpness = 0.1f;
            layer.antialiasingMode = PostProcessLayer.Antialiasing.SubpixelMorphologicalAntialiasing;
        }

        private void OnDisable()
        {
            if (layer != null) {
                Destroy(layer);
            }
        }

        private void Update()
        {
            if (beautify == null)
            {
                return;
            }
            if (layer != null)
            {
                layer.antialiasingMode = antialiasing;
            }
            beautify.compareMode.overrideState
                = beautify.compareLineAngle.overrideState
                = beautify.compareLineWidth.overrideState
                = enableCompare;
            if (enableCompare)
            {
                beautify.compareMode.value = compareMode;
                beautify.compareLineAngle.value = compareLineAngle;
                beautify.compareLineWidth.value = compareLineWidth;
            }
            beautify.sharpenIntensity.overrideState
                = beautify.sharpenDepthThreshold.overrideState
                = beautify.sharpenMinDepth.overrideState
                = beautify.sharpenMaxDepth.overrideState
                = beautify.sharpenRelaxation.overrideState
                = beautify.sharpenClamp.overrideState
                = beautify.sharpenMotionSensibility.overrideState = enableSharpen;
            if (enableSharpen)
            {
                beautify.sharpenIntensity.value = sharpenIntensity;
                beautify.sharpenDepthThreshold.value = sharpenDepthThreshold;
                beautify.sharpenMinDepth.value = sharpenMinDepth;
                beautify.sharpenMaxDepth.value = sharpenMaxDepth;
                beautify.sharpenRelaxation.value = sharpenRelaxation;
                beautify.sharpenClamp.value = sharpenClamp;
                beautify.sharpenMotionSensibility.value = sharpenMotionSensibility;
            }
            beautify.daltonize.overrideState
                = beautify.sepia.overrideState
                = beautify.saturate.overrideState
                = beautify.brightness.overrideState
                = beautify.contrast.overrideState
                = beautify.tintColor.overrideState
                = beautify.tonemap.overrideState
                = beautify.tonemapExposurePre.overrideState
                = beautify.tonemapBrightnessPost.overrideState = enableColorTweaks;
            if (enableColorTweaks)
            {
                beautify.daltonize.value = daltonize;
                beautify.sepia.value = sepia;
                beautify.saturate.value = saturate;
                beautify.brightness.value = brightness;
                beautify.contrast.value = contrast;
                beautify.tintColor.value = tintColor;
                beautify.tonemap.value = tonemap;
                beautify.tonemapExposurePre.value = tonemapExposurePre;
                beautify.tonemapBrightnessPost.value = tonemapBrightnessPost;
            }
            beautify.lut.overrideState
                = beautify.lutIntensity.overrideState
                = beautify.lutTexture.overrideState = enableLut;
            if (enableLut)
            {
                beautify.lut.value = lut;
                beautify.lutIntensity.value = lutIntensity;
                beautify.lutTexture.value = lutTexture;
            }
            beautify.bloomIntensity.overrideState
                = beautify.bloomThreshold.overrideState
                = beautify.bloomMaxBrightness.overrideState
                = beautify.bloomDepthAtten.overrideState
                = beautify.bloomAntiflicker.overrideState
                = beautify.bloomUltra.overrideState
                = beautify.bloomDebug.overrideState
                = beautify.bloomCustomize.overrideState
                = beautify.bloomWeight0.overrideState
                = beautify.bloomWeight1.overrideState
                = beautify.bloomWeight2.overrideState
                = beautify.bloomWeight3.overrideState
                = beautify.bloomWeight4.overrideState
                = beautify.bloomWeight5.overrideState
                = beautify.bloomBoost0.overrideState
                = beautify.bloomBoost1.overrideState
                = beautify.bloomBoost2.overrideState
                = beautify.bloomBoost3.overrideState
                = beautify.bloomBoost4.overrideState
                = beautify.bloomBoost5.overrideState
                = beautify.anamorphicFlaresIntensity.overrideState
                = beautify.anamorphicFlaresThreshold.overrideState
                = beautify.anamorphicFlaresVertical.overrideState
                = beautify.anamorphicFlaresSpread.overrideState
                = beautify.anamorphicFlaresDepthAtten.overrideState
                = beautify.anamorphicFlaresAntiflicker.overrideState
                = beautify.anamorphicFlaresUltra.overrideState
                = beautify.anamorphicFlaresTint.overrideState
                = beautify.sunFlaresIntensity.overrideState
                = beautify.sunFlaresTint.overrideState
                = beautify.sunFlaresSolarWindSpeed.overrideState
                = beautify.sunFlaresRotationDeadZone.overrideState
                = beautify.sunFlaresDownsampling.overrideState
                = beautify.sunFlaresLayerMask.overrideState
                = beautify.sunFlaresSunIntensity.overrideState
                = beautify.sunFlaresSunDiskSize.overrideState
                = beautify.sunFlaresSunRayDiffractionIntensity.overrideState
                = beautify.sunFlaresSunRayDiffractionThreshold.overrideState
                = beautify.sunFlaresCoronaRays1Length.overrideState
                = beautify.sunFlaresCoronaRays1Streaks.overrideState
                = beautify.sunFlaresCoronaRays1Spread.overrideState
                = beautify.sunFlaresCoronaRays1AngleOffset.overrideState
                = beautify.sunFlaresCoronaRays2Length.overrideState
                = beautify.sunFlaresCoronaRays2Streaks.overrideState
                = beautify.sunFlaresCoronaRays2Spread.overrideState
                = beautify.sunFlaresCoronaRays2AngleOffset.overrideState
                = beautify.sunFlaresGhosts1Size.overrideState
                = beautify.sunFlaresGhosts1Offset.overrideState
                = beautify.sunFlaresGhosts1Brightness.overrideState
                = beautify.sunFlaresGhosts2Size.overrideState
                = beautify.sunFlaresGhosts2Offset.overrideState
                = beautify.sunFlaresGhosts2Brightness.overrideState
                = beautify.sunFlaresGhosts3Size.overrideState
                = beautify.sunFlaresGhosts3Brightness.overrideState
                = beautify.sunFlaresGhosts3Offset.overrideState
                = beautify.sunFlaresGhosts4Size.overrideState
                = beautify.sunFlaresGhosts4Offset.overrideState
                = beautify.sunFlaresGhosts4Brightness.overrideState
                = beautify.sunFlaresHaloOffset.overrideState
                = beautify.sunFlaresHaloAmplitude.overrideState
                = beautify.sunFlaresHaloIntensity.overrideState = enableBloomFlares;
            if (enableBloomFlares)
            {
                beautify.bloomIntensity.value = bloomIntensity;
                beautify.bloomThreshold.value = bloomThreshold;
                beautify.bloomMaxBrightness.value = bloomMaxBrightness;
                beautify.bloomDepthAtten.value = bloomDepthAtten;
                beautify.bloomAntiflicker.value = bloomAntiflicker;
                beautify.bloomUltra.value = bloomUltra;
                beautify.bloomDebug.value = bloomDebug;
                beautify.bloomCustomize.value = bloomCustomize;
                beautify.bloomWeight0.value = bloomWeight0;
                beautify.bloomWeight1.value = bloomWeight1;
                beautify.bloomWeight2.value = bloomWeight2;
                beautify.bloomWeight3.value = bloomWeight3;
                beautify.bloomWeight4.value = bloomWeight4;
                beautify.bloomWeight5.value = bloomWeight5;
                beautify.bloomBoost0.value = bloomBoost0;
                beautify.bloomBoost1.value = bloomBoost1;
                beautify.bloomBoost2.value = bloomBoost2;
                beautify.bloomBoost3.value = bloomBoost3;
                beautify.bloomBoost4.value = bloomBoost4;
                beautify.bloomBoost5.value = bloomBoost5;
                beautify.anamorphicFlaresIntensity.value = anamorphicFlaresIntensity;
                beautify.anamorphicFlaresThreshold.value = anamorphicFlaresThreshold;
                beautify.anamorphicFlaresVertical.value = anamorphicFlaresVertical;
                beautify.anamorphicFlaresSpread.value = anamorphicFlaresSpread;
                beautify.anamorphicFlaresDepthAtten.value = anamorphicFlaresDepthAtten;
                beautify.anamorphicFlaresAntiflicker.value = anamorphicFlaresAntiflicker;
                beautify.anamorphicFlaresUltra.value = anamorphicFlaresUltra;
                beautify.anamorphicFlaresTint.value = anamorphicFlaresTint;
                beautify.sunFlaresIntensity.value = sunFlaresIntensity;
                beautify.sunFlaresTint.value = sunFlaresTint;
                beautify.sunFlaresSolarWindSpeed.value = sunFlaresSolarWindSpeed;
                beautify.sunFlaresRotationDeadZone.value = sunFlaresRotationDeadZone;
                beautify.sunFlaresDownsampling.value = sunFlaresDownsampling;
                beautify.sunFlaresLayerMask.value = sunFlaresLayerMask;
                beautify.sunFlaresSunIntensity.value = sunFlaresSunIntensity;
                beautify.sunFlaresSunDiskSize.value = sunFlaresSunDiskSize;
                beautify.sunFlaresSunRayDiffractionIntensity.value = sunFlaresSunRayDiffractionIntensity;
                beautify.sunFlaresSunRayDiffractionThreshold.value = sunFlaresSunRayDiffractionThreshold;
                beautify.sunFlaresCoronaRays1Length.value = sunFlaresCoronaRays1Length;
                beautify.sunFlaresCoronaRays1Streaks.value = sunFlaresCoronaRays1Streaks;
                beautify.sunFlaresCoronaRays1Spread.value = sunFlaresCoronaRays1Spread;
                beautify.sunFlaresCoronaRays1AngleOffset.value = sunFlaresCoronaRays1AngleOffset;
                beautify.sunFlaresCoronaRays2Length.value = sunFlaresCoronaRays2Length;
                beautify.sunFlaresCoronaRays2Streaks.value = sunFlaresCoronaRays2Streaks;
                beautify.sunFlaresCoronaRays2Spread.value = sunFlaresCoronaRays2Spread;
                beautify.sunFlaresCoronaRays2AngleOffset.value = sunFlaresCoronaRays2AngleOffset;
                beautify.sunFlaresGhosts1Size.value = sunFlaresGhosts1Size;
                beautify.sunFlaresGhosts1Offset.value = sunFlaresGhosts1Offset;
                beautify.sunFlaresGhosts1Brightness.value = sunFlaresGhosts1Brightness;
                beautify.sunFlaresGhosts2Size.value = sunFlaresGhosts2Size;
                beautify.sunFlaresGhosts2Offset.value = sunFlaresGhosts2Offset;
                beautify.sunFlaresGhosts2Brightness.value = sunFlaresGhosts2Brightness;
                beautify.sunFlaresGhosts3Size.value = sunFlaresGhosts3Size;
                beautify.sunFlaresGhosts3Brightness.value = sunFlaresGhosts3Brightness;
                beautify.sunFlaresGhosts3Offset.value = sunFlaresGhosts3Offset;
                beautify.sunFlaresGhosts4Size.value = sunFlaresGhosts4Size;
                beautify.sunFlaresGhosts4Offset.value = sunFlaresGhosts4Offset;
                beautify.sunFlaresGhosts4Brightness.value = sunFlaresGhosts4Brightness;
                beautify.sunFlaresHaloOffset.value = sunFlaresHaloOffset;
                beautify.sunFlaresHaloAmplitude.value = sunFlaresHaloAmplitude;
                beautify.sunFlaresHaloIntensity.value = sunFlaresHaloIntensity;
            }
            beautify.lensDirtIntensity.overrideState
                = beautify.lensDirtThreshold.overrideState
                = beautify.lensDirtTexture.overrideState
                = beautify.lensDirtSpread.overrideState = enableLensDirt;
            if (enableLensDirt)
            {
                beautify.lensDirtIntensity.value = lensDirtIntensity;
                beautify.lensDirtThreshold.value = lensDirtThreshold;
                beautify.lensDirtTexture.value = lensDirtTexture;
                beautify.lensDirtSpread.value = lensDirtSpread;
            }
            beautify.eyeAdaptation.overrideState
                = beautify.eyeAdaptationMinExposure.overrideState
                = beautify.eyeAdaptationMaxExposure.overrideState
                = beautify.eyeAdaptationSpeedToLight.overrideState
                = beautify.eyeAdaptationSpeedToDark.overrideState = enableEyeAdaptation;
            if (enableEyeAdaptation)
            {
                beautify.eyeAdaptation.value = eyeAdaptation;
                beautify.eyeAdaptationMinExposure.value = eyeAdaptationMinExposure;
                beautify.eyeAdaptationMaxExposure.value = eyeAdaptationMaxExposure;
                beautify.eyeAdaptationSpeedToLight.value = eyeAdaptationSpeedToLight;
                beautify.eyeAdaptationSpeedToDark.value = eyeAdaptationSpeedToDark;
            }
            beautify.purkinje.overrideState
                = beautify.purkinjeAmount.overrideState
                = beautify.purkinjeLuminanceThreshold.overrideState = enablePurkinje;
            if (enablePurkinje)
            {
                beautify.purkinje.value = purkinje;
                beautify.purkinjeAmount.value = purkinjeAmount;
                beautify.purkinjeLuminanceThreshold.value = purkinjeLuminanceThreshold;
            }
            beautify.vignettingOuterRing.overrideState
                = beautify.vignettingInnerRing.overrideState
                = beautify.vignettingFade.overrideState
                = beautify.vignettingCircularShape.overrideState
                = beautify.vignettingAspectRatio.overrideState
                = beautify.vignettingBlink.overrideState
                = beautify.vignettingColor.overrideState
                = beautify.vignettingMask.overrideState = enableVignetting;
            if (enableVignetting)
            {
                beautify.vignettingOuterRing.value = vignettingOuterRing;
                beautify.vignettingInnerRing.value = vignettingInnerRing;
                beautify.vignettingFade.value = vignettingFade;
                beautify.vignettingCircularShape.value = vignettingCircularShape;
                beautify.vignettingAspectRatio.value = vignettingAspectRatio;
                beautify.vignettingBlink.value = vignettingBlink;
                beautify.vignettingColor.value = vignettingColor;
                beautify.vignettingMask.value = vignettingMask;
            }
            beautify.depthOfField.overrideState
                = beautify.depthOfFieldDebug.overrideState
                = beautify.depthOfFieldFocusMode.overrideState
                = beautify.depthOfFieldAutofocusMinDistance.overrideState
                = beautify.depthOfFieldAutofocusMaxDistance.overrideState
                = beautify.depthofFieldAutofocusViewportPoint.overrideState
                = beautify.depthOfFieldAutofocusLayerMask.overrideState
                = beautify.depthOfFieldExclusionLayerMask.overrideState
                = beautify.depthOfFieldExclusionLayerMaskDownsampling.overrideState
                = beautify.depthOfFieldTransparencySupport.overrideState
                = beautify.depthOfFieldTransparencyLayerMask.overrideState
                = beautify.depthOfFieldTransparencySupportDownsampling.overrideState
                = beautify.depthOfFieldExclusionBias.overrideState
                = beautify.depthOfFieldDistance.overrideState
                = beautify.depthOfFieldFocusSpeed.overrideState
                = beautify.depthOfFieldDownsampling.overrideState
                = beautify.depthOfFieldMaxSamples.overrideState
                = beautify.depthOfFieldFocalLength.overrideState
                = beautify.depthOfFieldAperture.overrideState
                = beautify.depthOfFieldForegroundBlur.overrideState
                = beautify.depthOfFieldForegroundBlurHQ.overrideState
                = beautify.depthOfFieldForegroundDistance.overrideState
                = beautify.depthOfFieldBokeh.overrideState
                = beautify.depthOfFieldBokehThreshold.overrideState
                = beautify.depthOfFieldBokehIntensity.overrideState
                = beautify.depthOfFieldMaxBrightness.overrideState
                = beautify.depthOfFieldMaxDistance.overrideState
                = beautify.depthOfFieldFilterMode.overrideState = enableDepthOfField;
            if (enableDepthOfField)
            {
                beautify.depthOfField.value = depthOfField;
                beautify.depthOfFieldDebug.value = depthOfFieldDebug;
                beautify.depthOfFieldFocusMode.value = depthOfFieldFocusMode;
                beautify.depthOfFieldAutofocusMinDistance.value = depthOfFieldAutofocusMinDistance;
                beautify.depthOfFieldAutofocusMaxDistance.value = depthOfFieldAutofocusMaxDistance;
                beautify.depthofFieldAutofocusViewportPoint.value.x = depthofFieldAutofocusViewportPoint_X;
                beautify.depthofFieldAutofocusViewportPoint.value.y = depthofFieldAutofocusViewportPoint_Y;
                beautify.depthOfFieldAutofocusLayerMask.value = depthOfFieldAutofocusLayerMask;
                beautify.depthOfFieldExclusionLayerMask.value = depthOfFieldExclusionLayerMask;
                beautify.depthOfFieldExclusionLayerMaskDownsampling.value = depthOfFieldExclusionLayerMaskDownsampling;
                beautify.depthOfFieldTransparencySupport.value = depthOfFieldTransparencySupport;
                beautify.depthOfFieldTransparencyLayerMask.value = depthOfFieldTransparencyLayerMask;
                beautify.depthOfFieldTransparencySupportDownsampling.value = depthOfFieldTransparencySupportDownsampling;
                beautify.depthOfFieldExclusionBias.value = depthOfFieldExclusionBias;
                beautify.depthOfFieldDistance.value = depthOfFieldDistance;
                beautify.depthOfFieldFocusSpeed.value = depthOfFieldFocusSpeed;
                beautify.depthOfFieldDownsampling.value = depthOfFieldDownsampling;
                beautify.depthOfFieldMaxSamples.value = depthOfFieldMaxSamples;
                beautify.depthOfFieldFocalLength.value = depthOfFieldFocalLength;
                beautify.depthOfFieldAperture.value = depthOfFieldAperture;
                beautify.depthOfFieldForegroundBlur.value = depthOfFieldForegroundBlur;
                beautify.depthOfFieldForegroundBlurHQ.value = depthOfFieldForegroundBlurHQ;
                beautify.depthOfFieldForegroundDistance.value = depthOfFieldForegroundDistance;
                beautify.depthOfFieldBokeh.value = depthOfFieldBokeh;
                beautify.depthOfFieldBokehThreshold.value = depthOfFieldBokehThreshold;
                beautify.depthOfFieldBokehIntensity.value = depthOfFieldBokehIntensity;
                beautify.depthOfFieldMaxBrightness.value = depthOfFieldMaxBrightness;
                beautify.depthOfFieldMaxDistance.value = depthOfFieldMaxDistance;
                beautify.depthOfFieldFilterMode.value = depthOfFieldFilterMode;
            }
            beautify.outline.overrideState
                = beautify.outlineColor.overrideState = enableOutline;
            if (enableOutline)
            {
                beautify.outline.value = outline;
                beautify.outlineColor.value = outlineColor;
            }
        }
    }
}
