using BeautifyForPPS;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace CM3D2.SceneCapture.Plugin
{
    internal class BeautifyPane : BasePane
    {
        private CustomButton ResetButton;
        private CustomComboBox antialiasingBox;
        private CustomToggleButton enableCompareToggle;
        #region Compare settings
        private CustomToggleButton compareModeToggle;
        private CustomSlider compareLineAngleSlider;
        private CustomSlider compareLineWidthSlider;
        #endregion
        private CustomToggleButton enableSharpenToggle;
        #region Sharpen settings
        private CustomSlider sharpenIntensitySlider;
        private CustomSlider sharpenDepthThresholdSlider;
        private CustomSlider sharpenMinDepthSlider;
        private CustomSlider sharpenMaxDepthSlider;
        private CustomSlider sharpenRelaxationSlider;
        private CustomSlider sharpenClampSlider;
        private CustomSlider sharpenMotionSensibilitySlider;
        #endregion
        private CustomToggleButton enableColorTweaksToggle;
        #region Color tweaks
        private CustomSlider daltonizeSlider;
        private CustomSlider sepiaSlider;
        private CustomSlider saturateSlider;
        private CustomSlider brightnessSlider;
        private CustomSlider contrastSlider;
        private CustomColorPicker tintColorPicker;
        private CustomComboBox tonemapBox;
        private CustomSlider tonemapExposurePreSlider;
        private CustomSlider tonemapBrightnessPostSlider;
        #endregion
        private CustomToggleButton enableLutToggle;
        #region Lut
        private CustomToggleButton lutToggle;
        private CustomSlider lutIntensitySlider;
        private CustomLinearImagePicker lutTexturePicker;
        #endregion
        private CustomToggleButton enableBloomFlaresToggle;
        #region Bloom & Flares effects
        private CustomSlider bloomIntensitySlider;
        private CustomSlider bloomThresholdSlider;
        private CustomSlider bloomMaxBrightnessSlider;
        private CustomSlider bloomDepthAttenSlider;
        private CustomToggleButton bloomAntiflickerToggle;
        private CustomToggleButton bloomUltraToggle;
        private CustomToggleButton bloomDebugToggle;
        private CustomToggleButton bloomCustomizeToggle;
        private CustomSlider bloomWeight0Slider;
        private CustomSlider bloomWeight1Slider;
        private CustomSlider bloomWeight2Slider;
        private CustomSlider bloomWeight3Slider;
        private CustomSlider bloomWeight4Slider;
        private CustomSlider bloomWeight5Slider;
        private CustomSlider bloomBoost0Slider;
        private CustomSlider bloomBoost1Slider;
        private CustomSlider bloomBoost2Slider;
        private CustomSlider bloomBoost3Slider;
        private CustomSlider bloomBoost4Slider;
        private CustomSlider bloomBoost5Slider;
        private CustomSlider anamorphicFlaresIntensitySlider;
        private CustomSlider anamorphicFlaresThresholdSlider;
        private CustomToggleButton anamorphicFlaresVerticalToggle;
        private CustomSlider anamorphicFlaresSpreadSlider;
        private CustomSlider anamorphicFlaresDepthAttenSlider;
        private CustomToggleButton anamorphicFlaresAntiflickerToggle;
        private CustomToggleButton anamorphicFlaresUltraToggle;
        private CustomColorPicker anamorphicFlaresTintPicker;
        private CustomSlider sunFlaresIntensitySlider;
        private CustomColorPicker sunFlaresTintPicker;
        private CustomSlider sunFlaresSolarWindSpeedSlider;
        private CustomToggleButton sunFlaresRotationDeadZoneToggle;
        private CustomSlider sunFlaresDownsamplingSlider;
        private CustomSlider sunFlaresLayerMaskSlider;
        private CustomSlider sunFlaresSunIntensitySlider;
        private CustomSlider sunFlaresSunDiskSizeSlider;
        private CustomSlider sunFlaresSunRayDiffractionIntensitySlider;
        private CustomSlider sunFlaresSunRayDiffractionThresholdSlider;
        // Corona Rays Group 1
        private CustomSlider sunFlaresCoronaRays1LengthSlider;
        private CustomSlider sunFlaresCoronaRays1StreaksSlider;
        private CustomSlider sunFlaresCoronaRays1SpreadSlider;
        private CustomSlider sunFlaresCoronaRays1AngleOffsetSlider;
        // Corona Rays Group 2
        private CustomSlider sunFlaresCoronaRays2LengthSlider;
        private CustomSlider sunFlaresCoronaRays2StreaksSlider;
        private CustomSlider sunFlaresCoronaRays2SpreadSlider;
        private CustomSlider sunFlaresCoronaRays2AngleOffsetSlider;
        // Ghost 1
        private CustomSlider sunFlaresGhosts1SizeSlider;
        private CustomSlider sunFlaresGhosts1OffsetSlider;
        private CustomSlider sunFlaresGhosts1BrightnessSlider;
        // Ghost 2"
        private CustomSlider sunFlaresGhosts2SizeSlider;
        private CustomSlider sunFlaresGhosts2OffsetSlider;
        private CustomSlider sunFlaresGhosts2BrightnessSlider;
        // Ghost 3
        private CustomSlider sunFlaresGhosts3SizeSlider;
        private CustomSlider sunFlaresGhosts3BrightnessSlider;
        private CustomSlider sunFlaresGhosts3OffsetSlider;
        // Ghost 4
        private CustomSlider sunFlaresGhosts4SizeSlider;
        private CustomSlider sunFlaresGhosts4OffsetSlider;
        private CustomSlider sunFlaresGhosts4BrightnessSlider;
        // Halo
        private CustomSlider sunFlaresHaloOffsetSlider;
        private CustomSlider sunFlaresHaloAmplitudeSlider;
        private CustomSlider sunFlaresHaloIntensitySlider;
        #endregion
        private CustomToggleButton enableLensDirtToggle;
        #region Lens Dirt
        private CustomSlider lensDirtIntensitySlider;
        private CustomSlider lensDirtThresholdSlider;
        private CustomImagePicker lensDirtTexturePicker;
        private CustomSlider lensDirtSpreadSlider;
        #endregion
        private CustomToggleButton enableEyeAdaptationToggle;
        #region Eye Adaptation
        private CustomToggleButton eyeAdaptationToggle;
        private CustomSlider eyeAdaptationMinExposureSlider;
        private CustomSlider eyeAdaptationMaxExposureSlider;
        private CustomSlider eyeAdaptationSpeedToLightSlider;
        private CustomSlider eyeAdaptationSpeedToDarkSlider;
        #endregion
        private CustomToggleButton enablePurkinjeToggle;
        #region Purkinje effect
        private CustomToggleButton purkinjeToggle;
        private CustomSlider purkinjeAmountSlider;
        private CustomSlider purkinjeLuminanceThresholdSlider;
        #endregion
        private CustomToggleButton enableVignettingToggle;
        #region Vignetting
        private CustomSlider vignettingOuterRingSlider;
        private CustomSlider vignettingInnerRingSlider;
        private CustomSlider vignettingFadeSlider;
        private CustomToggleButton vignettingCircularShapeToggle;
        private CustomSlider vignettingAspectRatioSlider;
        private CustomSlider vignettingBlinkSlider;
        private CustomColorPicker vignettingColorPicker;
        private CustomImagePicker vignettingMaskPicker;
        #endregion
        private CustomToggleButton enableDepthOfFieldToggle;
        #region Depth of Field
        private CustomToggleButton depthOfFieldToggle;
        private CustomToggleButton depthOfFieldDebugToggle;
        private CustomComboBox depthOfFieldFocusModeBox;
        private CustomSlider depthOfFieldAutofocusMinDistanceSlider;
        private CustomSlider depthOfFieldAutofocusMaxDistanceSlider;
        private CustomSlider depthofFieldAutofocusViewportPoint_XSlider;
        private CustomSlider depthofFieldAutofocusViewportPoint_YSlider;
        private CustomSlider depthOfFieldAutofocusLayerMaskSlider;
        private CustomSlider depthOfFieldExclusionLayerMaskSlider;
        private CustomSlider depthOfFieldExclusionLayerMaskDownsamplingSlider;
        private CustomToggleButton depthOfFieldTransparencySupportToggle;
        private CustomSlider depthOfFieldTransparencyLayerMaskSlider;
        private CustomSlider depthOfFieldTransparencySupportDownsamplingSlider;
        private CustomSlider depthOfFieldExclusionBiasSlider;
        private CustomSlider depthOfFieldDistanceSlider;
        private CustomSlider depthOfFieldFocusSpeedSlider;
        private CustomSlider depthOfFieldDownsamplingSlider;
        private CustomSlider depthOfFieldMaxSamplesSlider;
        private CustomSlider depthOfFieldFocalLengthSlider;
        private CustomSlider depthOfFieldApertureSlider;
        private CustomToggleButton depthOfFieldForegroundBlurToggle;
        private CustomToggleButton depthOfFieldForegroundBlurHQToggle;
        private CustomSlider depthOfFieldForegroundDistanceSlider;
        private CustomToggleButton depthOfFieldBokehToggle;
        private CustomSlider depthOfFieldBokehThresholdSlider;
        private CustomSlider depthOfFieldBokehIntensitySlider;
        private CustomSlider depthOfFieldMaxBrightnessSlider;
        private CustomSlider depthOfFieldMaxDistanceSlider;
        private CustomComboBox depthOfFieldFilterModeBox;
        #endregion
        private CustomToggleButton enableOutlineToggle;
        #region Outline
        private CustomToggleButton outlineToggle;
        private CustomColorPicker outlineColorPicker;
        #endregion

        public PostProcessLayer.Antialiasing antialiasing => (PostProcessLayer.Antialiasing)Enum.Parse(typeof(PostProcessLayer.Antialiasing), antialiasingBox.SelectedItem);
        public bool enableCompare => enableCompareToggle.Value;
        #region Compare settings
        public bool compareMode => compareModeToggle.Value;
        public float compareLineAngle => compareLineAngleSlider.Value;
        public float compareLineWidth => compareLineWidthSlider.Value;
        #endregion
        public bool enableSharpen => enableSharpenToggle.Value;
        #region Sharpen settings
        public float sharpenIntensity => sharpenIntensitySlider.Value;
        public float sharpenDepthThreshold => sharpenDepthThresholdSlider.Value;
        public float sharpenMinDepth => sharpenMinDepthSlider.Value;
        public float sharpenMaxDepth => sharpenMaxDepthSlider.Value;
        public float sharpenRelaxation => sharpenRelaxationSlider.Value;
        public float sharpenClamp => sharpenClampSlider.Value;
        public float sharpenMotionSensibility => sharpenMotionSensibilitySlider.Value;
        #endregion
        public bool enableColorTweaks => enableColorTweaksToggle.Value;
        #region Color tweaks
        public float daltonize => daltonizeSlider.Value;
        public float sepia => sepiaSlider.Value;
        public float saturate => saturateSlider.Value;
        public float brightness => brightnessSlider.Value;
        public float contrast => contrastSlider.Value;
        public Color tintColor => tintColorPicker.Value;
        public BeautifyTonemapOperator tonemap => (BeautifyTonemapOperator)Enum.Parse(typeof(BeautifyTonemapOperator), tonemapBox.SelectedItem);
        public float tonemapExposurePre => tonemapExposurePreSlider.Value;
        public float tonemapBrightnessPost => tonemapBrightnessPostSlider.Value;
        #endregion
        public bool enableLut => enableLutToggle.Value;
        #region Lut
        public bool lut => lutToggle.Value;
        public float lutIntensity => lutIntensitySlider.Value;
        public Texture2D lutTexture { get => lutTexturePicker.Value; set => lutTexturePicker.Value = value; }
        public string lutTextureFile { get => lutTexturePicker.Filename; set => lutTexturePicker.Filename = value; }
        #endregion
        public bool enableBloomFlares => enableBloomFlaresToggle.Value;
        #region Bloom & Flares effects
        public float bloomIntensity => bloomIntensitySlider.Value;
        public float bloomThreshold => bloomThresholdSlider.Value;
        public float bloomMaxBrightness => bloomMaxBrightnessSlider.Value;
        public float bloomDepthAtten => bloomDepthAttenSlider.Value;
        public bool bloomAntiflicker => bloomAntiflickerToggle.Value;
        public bool bloomUltra => bloomUltraToggle.Value;
        public bool bloomDebug => bloomDebugToggle.Value;
        public bool bloomCustomize => bloomCustomizeToggle.Value;
        public float bloomWeight0 => bloomWeight0Slider.Value;
        public float bloomWeight1 => bloomWeight1Slider.Value;
        public float bloomWeight2 => bloomWeight2Slider.Value;
        public float bloomWeight3 => bloomWeight3Slider.Value;
        public float bloomWeight4 => bloomWeight4Slider.Value;
        public float bloomWeight5 => bloomWeight5Slider.Value;
        public float bloomBoost0 => bloomBoost0Slider.Value;
        public float bloomBoost1 => bloomBoost1Slider.Value;
        public float bloomBoost2 => bloomBoost2Slider.Value;
        public float bloomBoost3 => bloomBoost3Slider.Value;
        public float bloomBoost4 => bloomBoost4Slider.Value;
        public float bloomBoost5 => bloomBoost5Slider.Value;
        public float anamorphicFlaresIntensity => anamorphicFlaresIntensitySlider.Value;
        public float anamorphicFlaresThreshold => anamorphicFlaresThresholdSlider.Value;
        public bool anamorphicFlaresVertical => anamorphicFlaresVerticalToggle.Value;
        public float anamorphicFlaresSpread => anamorphicFlaresSpreadSlider.Value;
        public float anamorphicFlaresDepthAtten => anamorphicFlaresDepthAttenSlider.Value;
        public bool anamorphicFlaresAntiflicker => anamorphicFlaresAntiflickerToggle.Value;
        public bool anamorphicFlaresUltra => anamorphicFlaresUltraToggle.Value;
        public Color anamorphicFlaresTint => anamorphicFlaresTintPicker.Value;
        public float sunFlaresIntensity => sunFlaresIntensitySlider.Value;
        public Color sunFlaresTint => sunFlaresTintPicker.Value;
        public float sunFlaresSolarWindSpeed => sunFlaresSolarWindSpeedSlider.Value;
        public bool sunFlaresRotationDeadZone => sunFlaresRotationDeadZoneToggle.Value;
        public int sunFlaresDownsampling => (int)sunFlaresDownsamplingSlider.Value;
        public int sunFlaresLayerMask => (int)sunFlaresLayerMaskSlider.Value;
        public float sunFlaresSunIntensity => sunFlaresSunIntensitySlider.Value;
        public float sunFlaresSunDiskSize => sunFlaresSunDiskSizeSlider.Value;
        public float sunFlaresSunRayDiffractionIntensity => sunFlaresSunRayDiffractionIntensitySlider.Value;
        public float sunFlaresSunRayDiffractionThreshold => sunFlaresSunRayDiffractionThresholdSlider.Value;
        // Corona Rays Group 1
        public float sunFlaresCoronaRays1Length => sunFlaresCoronaRays1LengthSlider.Value;
        public float sunFlaresCoronaRays1Streaks => sunFlaresCoronaRays1StreaksSlider.Value;
        public float sunFlaresCoronaRays1Spread => sunFlaresCoronaRays1SpreadSlider.Value;
        public float sunFlaresCoronaRays1AngleOffset => sunFlaresCoronaRays1AngleOffsetSlider.Value;
        // Corona Rays Group 2
        public float sunFlaresCoronaRays2Length => sunFlaresCoronaRays2LengthSlider.Value;
        public float sunFlaresCoronaRays2Streaks => sunFlaresCoronaRays2StreaksSlider.Value;
        public float sunFlaresCoronaRays2Spread => sunFlaresCoronaRays2SpreadSlider.Value;
        public float sunFlaresCoronaRays2AngleOffset => sunFlaresCoronaRays2AngleOffsetSlider.Value;
        // Ghost 1
        public float sunFlaresGhosts1Size => sunFlaresGhosts1SizeSlider.Value;
        public float sunFlaresGhosts1Offset => sunFlaresGhosts1OffsetSlider.Value;
        public float sunFlaresGhosts1Brightness => sunFlaresGhosts1BrightnessSlider.Value;
        // Ghost 2"
        public float sunFlaresGhosts2Size => sunFlaresGhosts2SizeSlider.Value;
        public float sunFlaresGhosts2Offset => sunFlaresGhosts2OffsetSlider.Value;
        public float sunFlaresGhosts2Brightness => sunFlaresGhosts2BrightnessSlider.Value;
        // Ghost 3
        public float sunFlaresGhosts3Size => sunFlaresGhosts3SizeSlider.Value;
        public float sunFlaresGhosts3Brightness => sunFlaresGhosts3BrightnessSlider.Value;
        public float sunFlaresGhosts3Offset => sunFlaresGhosts3OffsetSlider.Value;
        // Ghost 4
        public float sunFlaresGhosts4Size => sunFlaresGhosts4SizeSlider.Value;
        public float sunFlaresGhosts4Offset => sunFlaresGhosts4OffsetSlider.Value;
        public float sunFlaresGhosts4Brightness => sunFlaresGhosts4BrightnessSlider.Value;
        // Halo
        public float sunFlaresHaloOffset => sunFlaresHaloOffsetSlider.Value;
        public float sunFlaresHaloAmplitude => sunFlaresHaloAmplitudeSlider.Value;
        public float sunFlaresHaloIntensity => sunFlaresHaloIntensitySlider.Value;
        #endregion
        public bool enableLensDirt => enableLensDirtToggle.Value;
        #region Lens Dirt
        public float lensDirtIntensity => lensDirtIntensitySlider.Value;
        public float lensDirtThreshold => lensDirtThresholdSlider.Value;
        public Texture2D lensDirtTexture { get => lensDirtTexturePicker.Value; set => lensDirtTexturePicker.Value = value; }
        public string lensDirtTextureFile { get => lensDirtTexturePicker.Filename; set => lensDirtTexturePicker.Filename = value; }
        public int lensDirtSpread => (int)lensDirtSpreadSlider.Value;
        #endregion
        public bool enableEyeAdaptation => enableEyeAdaptationToggle.Value;
        #region Eye Adaptation
        public bool eyeAdaptation => eyeAdaptationToggle.Value;
        public float eyeAdaptationMinExposure => eyeAdaptationMinExposureSlider.Value;
        public float eyeAdaptationMaxExposure => eyeAdaptationMaxExposureSlider.Value;
        public float eyeAdaptationSpeedToLight => eyeAdaptationSpeedToLightSlider.Value;
        public float eyeAdaptationSpeedToDark => eyeAdaptationSpeedToDarkSlider.Value;
        #endregion
        public bool enablePurkinje => enablePurkinjeToggle.Value;
        #region Purkinje effect
        public bool purkinje => purkinjeToggle.Value;
        public float purkinjeAmount => purkinjeAmountSlider.Value;
        public float purkinjeLuminanceThreshold => purkinjeLuminanceThresholdSlider.Value;
        #endregion
        public bool enableVignetting => enableVignettingToggle.Value;
        #region Vignetting
        public float vignettingOuterRing => vignettingOuterRingSlider.Value;
        public float vignettingInnerRing => vignettingInnerRingSlider.Value;
        public float vignettingFade => vignettingFadeSlider.Value;
        public bool vignettingCircularShape => vignettingCircularShapeToggle.Value;
        public float vignettingAspectRatio => vignettingAspectRatioSlider.Value;
        public float vignettingBlink => vignettingBlinkSlider.Value;
        public Color vignettingColor => vignettingColorPicker.Value;
        public Texture2D vignettingMask { get => vignettingMaskPicker.Value; set => vignettingMaskPicker.Value = value; }
        public string vignettingMaskFile { get => vignettingMaskPicker.Filename; set => vignettingMaskPicker.Filename = value; }
        #endregion
        public bool enableDepthOfField => enableDepthOfFieldToggle.Value;
        #region Depth of Field
        public bool depthOfField => depthOfFieldToggle.Value;
        public bool depthOfFieldDebug => depthOfFieldDebugToggle.Value;
        public BeautifyDoFFocusMode depthOfFieldFocusMode => (BeautifyDoFFocusMode)Enum.Parse(typeof(BeautifyDoFFocusMode), depthOfFieldFocusModeBox.SelectedItem);
        public float depthOfFieldAutofocusMinDistance => depthOfFieldAutofocusMinDistanceSlider.Value;
        public float depthOfFieldAutofocusMaxDistance => depthOfFieldAutofocusMaxDistanceSlider.Value;
        public float depthofFieldAutofocusViewportPoint_X => depthofFieldAutofocusViewportPoint_XSlider.Value;
        public float depthofFieldAutofocusViewportPoint_Y => depthofFieldAutofocusViewportPoint_YSlider.Value;
        public int depthOfFieldAutofocusLayerMask => (int)depthOfFieldAutofocusLayerMaskSlider.Value;
        public int depthOfFieldExclusionLayerMask => (int)depthOfFieldExclusionLayerMaskSlider.Value;
        public float depthOfFieldExclusionLayerMaskDownsampling => depthOfFieldExclusionLayerMaskDownsamplingSlider.Value;
        public bool depthOfFieldTransparencySupport => depthOfFieldTransparencySupportToggle.Value;
        public int depthOfFieldTransparencyLayerMask => (int)depthOfFieldTransparencyLayerMaskSlider.Value;
        public float depthOfFieldTransparencySupportDownsampling => depthOfFieldTransparencySupportDownsamplingSlider.Value;
        public float depthOfFieldExclusionBias => depthOfFieldExclusionBiasSlider.Value;
        public float depthOfFieldDistance => depthOfFieldDistanceSlider.Value;
        public float depthOfFieldFocusSpeed => depthOfFieldFocusSpeedSlider.Value;
        public int depthOfFieldDownsampling => (int)depthOfFieldDownsamplingSlider.Value;
        public int depthOfFieldMaxSamples => (int)depthOfFieldMaxSamplesSlider.Value;
        public float depthOfFieldFocalLength => depthOfFieldFocalLengthSlider.Value;
        public float depthOfFieldAperture => depthOfFieldApertureSlider.Value;
        public bool depthOfFieldForegroundBlur => depthOfFieldForegroundBlurToggle.Value;
        public bool depthOfFieldForegroundBlurHQ => depthOfFieldForegroundBlurHQToggle.Value;
        public float depthOfFieldForegroundDistance => depthOfFieldForegroundDistanceSlider.Value;
        public bool depthOfFieldBokeh => depthOfFieldBokehToggle.Value;
        public float depthOfFieldBokehThreshold => depthOfFieldBokehThresholdSlider.Value;
        public float depthOfFieldBokehIntensity => depthOfFieldBokehIntensitySlider.Value;
        public float depthOfFieldMaxBrightness => depthOfFieldMaxBrightnessSlider.Value;
        public float depthOfFieldMaxDistance => depthOfFieldMaxDistanceSlider.Value;
        public FilterMode depthOfFieldFilterMode => (FilterMode)Enum.Parse(typeof(FilterMode), depthOfFieldFilterModeBox.SelectedItem);
        #endregion
        public bool enableOutline => enableOutlineToggle.Value;
        #region Outline
        public bool outline => outlineToggle.Value;
        public Color outlineColor => outlineColorPicker.Value;
        #endregion

        public BeautifyPane(int fontSize) : base(fontSize, Translation.GetText("Panes", "Beautify"))
        {
        }

        public override void SetupPane()
        {
            ResetButton = new CustomButton();
            ResetButton.Text = "×";
            ResetButton.Click += (sender, e) =>
            {
                Reset();
            };
            ChildControls.Add(ResetButton);
            antialiasingBox = new CustomComboBox(Enum.GetNames(typeof(PostProcessLayer.Antialiasing)));
            antialiasingBox.Text = Translation.GetText("Beautify", "antialiasing");
            antialiasingBox.SelectedIndex = (int)BeautifyDef.beautifyEffect.antialiasing;
            ChildControls.Add(antialiasingBox);
            enableCompareToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableCompare, "toggle");
            enableCompareToggle.Text = Translation.GetText("Beautify", "enableCompare");
            ChildControls.Add(enableCompareToggle);
            #region Compare settings
            compareModeToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.compareMode, "toggle");
            compareModeToggle.Text = Translation.GetText("Beautify", "compareMode");
            ChildControls.Add(compareModeToggle);
            compareLineAngleSlider = new CustomSlider(BeautifyDef.beautifyEffect.compareLineAngle, -Mathf.PI, Mathf.PI, 4);
            compareLineAngleSlider.Text = Translation.GetText("Beautify", "compareLineAngle");
            ChildControls.Add(compareLineAngleSlider);
            compareLineWidthSlider = new CustomSlider(BeautifyDef.beautifyEffect.compareLineWidth, 0.0001f, 0.05f, 4);
            compareLineWidthSlider.Text = Translation.GetText("Beautify", "compareLineWidth");
            ChildControls.Add(compareLineWidthSlider);
            #endregion
            enableSharpenToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableSharpen, "toggle");
            enableSharpenToggle.Text = Translation.GetText("Beautify", "enableSharpen");
            ChildControls.Add(enableSharpenToggle);
            #region Sharpen settings
            sharpenIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.sharpenIntensity, 0f, 25f, 4);
            sharpenIntensitySlider.Text = Translation.GetText("Beautify", "sharpenIntensity");
            ChildControls.Add(sharpenIntensitySlider);
            sharpenDepthThresholdSlider = new CustomSlider(BeautifyDef.beautifyEffect.sharpenDepthThreshold, 0f, 0.05f, 4);
            sharpenDepthThresholdSlider.Text = Translation.GetText("Beautify", "sharpenDepthThreshold");
            ChildControls.Add(sharpenDepthThresholdSlider);
            sharpenMinDepthSlider = new CustomSlider(BeautifyDef.beautifyEffect.sharpenMinDepth, 0f, 1f, 4);
            sharpenMinDepthSlider.Text = Translation.GetText("Beautify", "sharpenMinDepth");
            ChildControls.Add(sharpenMinDepthSlider);
            sharpenMaxDepthSlider = new CustomSlider(BeautifyDef.beautifyEffect.sharpenMaxDepth, 0f, 1.1f, 4);
            sharpenMaxDepthSlider.Text = Translation.GetText("Beautify", "sharpenMaxDepth");
            ChildControls.Add(sharpenMaxDepthSlider);
            sharpenRelaxationSlider = new CustomSlider(BeautifyDef.beautifyEffect.sharpenRelaxation, 0f, 0.2f, 4);
            sharpenRelaxationSlider.Text = Translation.GetText("Beautify", "sharpenRelaxation");
            ChildControls.Add(sharpenRelaxationSlider);
            sharpenClampSlider = new CustomSlider(BeautifyDef.beautifyEffect.sharpenClamp, 0f, 1f, 4);
            sharpenClampSlider.Text = Translation.GetText("Beautify", "sharpenClamp");
            ChildControls.Add(sharpenClampSlider);
            sharpenMotionSensibilitySlider = new CustomSlider(BeautifyDef.beautifyEffect.sharpenMotionSensibility, 0f, 1f, 4);
            sharpenMotionSensibilitySlider.Text = Translation.GetText("Beautify", "sharpenMotionSensibility");
            ChildControls.Add(sharpenMotionSensibilitySlider);
            #endregion
            enableColorTweaksToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableColorTweaks, "toggle");
            enableColorTweaksToggle.Text = Translation.GetText("Beautify", "enableColorTweaks");
            ChildControls.Add(enableColorTweaksToggle);
            #region Color tweaks
            daltonizeSlider = new CustomSlider(BeautifyDef.beautifyEffect.daltonize, 0f, 2f, 4);
            daltonizeSlider.Text = Translation.GetText("Beautify", "daltonize");
            ChildControls.Add(daltonizeSlider);
            sepiaSlider = new CustomSlider(BeautifyDef.beautifyEffect.sepia, 0f, 1f, 4);
            sepiaSlider.Text = Translation.GetText("Beautify", "sepia");
            ChildControls.Add(sepiaSlider);
            saturateSlider = new CustomSlider(BeautifyDef.beautifyEffect.saturate, -2f, 3f, 4);
            saturateSlider.Text = Translation.GetText("Beautify", "saturate");
            ChildControls.Add(saturateSlider);
            brightnessSlider = new CustomSlider(BeautifyDef.beautifyEffect.brightness, 0f, 2f, 4);
            brightnessSlider.Text = Translation.GetText("Beautify", "brightness");
            ChildControls.Add(brightnessSlider);
            contrastSlider = new CustomSlider(BeautifyDef.beautifyEffect.contrast, 0.5f, 1.5f, 4);
            contrastSlider.Text = Translation.GetText("Beautify", "contrast");
            ChildControls.Add(contrastSlider);
            tintColorPicker = new CustomColorPicker(BeautifyDef.beautifyEffect.tintColor);
            tintColorPicker.Text = Translation.GetText("Beautify", "tintColor");
            ChildControls.Add(tintColorPicker);
            tonemapBox = new CustomComboBox(Enum.GetNames(typeof(BeautifyTonemapOperator)));
            tonemapBox.Text = Translation.GetText("Beautify", "tonemap");
            tonemapBox.SelectedIndex = (int)BeautifyDef.beautifyEffect.tonemap;
            ChildControls.Add(tonemapBox);
            tonemapExposurePreSlider = new CustomSlider(BeautifyDef.beautifyEffect.tonemapExposurePre, 0f, 10f, 4);
            tonemapExposurePreSlider.Text = Translation.GetText("Beautify", "tonemapExposurePre");
            ChildControls.Add(tonemapExposurePreSlider);
            tonemapBrightnessPostSlider = new CustomSlider(BeautifyDef.beautifyEffect.tonemapBrightnessPost, 0f, 10f, 4);
            tonemapBrightnessPostSlider.Text = Translation.GetText("Beautify", "tonemapBrightnessPost");
            ChildControls.Add(tonemapBrightnessPostSlider);
            #endregion
            enableLutToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableLut, "toggle");
            enableLutToggle.Text = Translation.GetText("Beautify", "enableLut");
            ChildControls.Add(enableLutToggle);
            #region Lut
            lutToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.lut, "toggle");
            lutToggle.Text = Translation.GetText("Beautify", "lut");
            ChildControls.Add(lutToggle);
            lutIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.lutIntensity, 0f, 1f, 4);
            lutIntensitySlider.Text = Translation.GetText("Beautify", "lutIntensity");
            ChildControls.Add(lutIntensitySlider);
            lutTexturePicker = new CustomLinearImagePicker(BeautifyDef.lutTexture, BeautifyDef.lutTextureFile, COM3D2.PostProcessing.Plugin.Utils.AssetLoader.lutTextureDir);
            lutTexturePicker.Text = lutTexturePicker.Value.name;
            lutTexturePicker.TextureChanged += (sender, e) =>
            {
                lutTexturePicker.Text = lutTexturePicker.Value.name;
            };
            ChildControls.Add(lutTexturePicker);
            #endregion
            enableBloomFlaresToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableBloomFlares, "toggle");
            enableBloomFlaresToggle.Text = Translation.GetText("Beautify", "enableBloomFlares");
            ChildControls.Add(enableBloomFlaresToggle);
            #region Bloom & Flares effects
            bloomIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.bloomIntensity, 0, 10f, 4);
            bloomIntensitySlider.Text = Translation.GetText("Beautify", "bloomIntensity");
            ChildControls.Add(bloomIntensitySlider);
            bloomThresholdSlider = new CustomSlider(BeautifyDef.beautifyEffect.bloomThreshold, 0f, 5f, 4);
            bloomThresholdSlider.Text = Translation.GetText("Beautify", "bloomThreshold");
            ChildControls.Add(bloomThresholdSlider);
            bloomMaxBrightnessSlider = new CustomSlider(BeautifyDef.beautifyEffect.bloomMaxBrightness, 0f, 1000f, 4);
            bloomMaxBrightnessSlider.Text = Translation.GetText("Beautify", "bloomMaxBrightness");
            ChildControls.Add(bloomMaxBrightnessSlider);
            bloomDepthAttenSlider = new CustomSlider(BeautifyDef.beautifyEffect.bloomDepthAtten, 0, 1f, 4);
            bloomDepthAttenSlider.Text = Translation.GetText("Beautify", "bloomDepthAtten");
            ChildControls.Add(bloomDepthAttenSlider);
            bloomAntiflickerToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.bloomAntiflicker, "toggle");
            bloomAntiflickerToggle.Text = Translation.GetText("Beautify", "bloomAntiflicker");
            ChildControls.Add(bloomAntiflickerToggle);
            bloomUltraToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.bloomUltra, "toggle");
            bloomUltraToggle.Text = Translation.GetText("Beautify", "bloomUltra");
            ChildControls.Add(bloomUltraToggle);
            bloomDebugToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.bloomDebug, "toggle");
            bloomDebugToggle.Text = Translation.GetText("Beautify", "bloomDebug");
            ChildControls.Add(bloomDebugToggle);
            bloomCustomizeToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.bloomCustomize, "toggle");
            bloomCustomizeToggle.Text = Translation.GetText("Beautify", "bloomCustomize");
            ChildControls.Add(bloomCustomizeToggle);
            bloomWeight0Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomWeight0, 0, 1f, 4);
            bloomWeight0Slider.Text = Translation.GetText("Beautify", "bloomWeight0");
            ChildControls.Add(bloomWeight0Slider);
            bloomWeight1Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomWeight1, 0, 1f, 4);
            bloomWeight1Slider.Text = Translation.GetText("Beautify", "bloomWeight1");
            ChildControls.Add(bloomWeight1Slider);
            bloomWeight2Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomWeight2, 0, 1f, 4);
            bloomWeight2Slider.Text = Translation.GetText("Beautify", "bloomWeight2");
            ChildControls.Add(bloomWeight2Slider);
            bloomWeight3Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomWeight3, 0, 1f, 4);
            bloomWeight3Slider.Text = Translation.GetText("Beautify", "bloomWeight3");
            ChildControls.Add(bloomWeight3Slider);
            bloomWeight4Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomWeight4, 0, 1f, 4);
            bloomWeight4Slider.Text = Translation.GetText("Beautify", "bloomWeight4");
            ChildControls.Add(bloomWeight4Slider);
            bloomWeight5Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomWeight5, 0, 1f, 4);
            bloomWeight5Slider.Text = Translation.GetText("Beautify", "bloomWeight5");
            ChildControls.Add(bloomWeight5Slider);
            bloomBoost0Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomBoost0, 0, 3f, 4);
            bloomBoost0Slider.Text = Translation.GetText("Beautify", "bloomBoost0");
            ChildControls.Add(bloomBoost0Slider);
            bloomBoost1Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomBoost1, 0, 3f, 4);
            bloomBoost1Slider.Text = Translation.GetText("Beautify", "bloomBoost1");
            ChildControls.Add(bloomBoost1Slider);
            bloomBoost2Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomBoost2, 0, 3f, 4);
            bloomBoost2Slider.Text = Translation.GetText("Beautify", "bloomBoost2");
            ChildControls.Add(bloomBoost2Slider);
            bloomBoost3Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomBoost3, 0, 3f, 4);
            bloomBoost3Slider.Text = Translation.GetText("Beautify", "bloomBoost3");
            ChildControls.Add(bloomBoost3Slider);
            bloomBoost4Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomBoost4, 0, 3f, 4);
            bloomBoost4Slider.Text = Translation.GetText("Beautify", "bloomBoost4");
            ChildControls.Add(bloomBoost4Slider);
            bloomBoost5Slider = new CustomSlider(BeautifyDef.beautifyEffect.bloomBoost5, 0, 3f, 4);
            bloomBoost5Slider.Text = Translation.GetText("Beautify", "bloomBoost5");
            ChildControls.Add(bloomBoost5Slider);
            anamorphicFlaresIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.anamorphicFlaresIntensity, 0f, 10f, 4);
            anamorphicFlaresIntensitySlider.Text = Translation.GetText("Beautify", "anamorphicFlaresIntensity");
            ChildControls.Add(anamorphicFlaresIntensitySlider);
            anamorphicFlaresThresholdSlider = new CustomSlider(BeautifyDef.beautifyEffect.anamorphicFlaresThreshold, 0f, 5f, 4);
            anamorphicFlaresThresholdSlider.Text = Translation.GetText("Beautify", "anamorphicFlaresThreshold");
            ChildControls.Add(anamorphicFlaresThresholdSlider);
            anamorphicFlaresVerticalToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.anamorphicFlaresVertical, "toggle");
            anamorphicFlaresVerticalToggle.Text = Translation.GetText("Beautify", "anamorphicFlaresVertical");
            ChildControls.Add(anamorphicFlaresVerticalToggle);
            anamorphicFlaresSpreadSlider = new CustomSlider(BeautifyDef.beautifyEffect.anamorphicFlaresSpread, 0.1f, 2f, 4);
            anamorphicFlaresSpreadSlider.Text = Translation.GetText("Beautify", "anamorphicFlaresSpread");
            ChildControls.Add(anamorphicFlaresSpreadSlider);
            anamorphicFlaresDepthAttenSlider = new CustomSlider(BeautifyDef.beautifyEffect.anamorphicFlaresDepthAtten, 0f, 1f, 4);
            anamorphicFlaresDepthAttenSlider.Text = Translation.GetText("Beautify", "anamorphicFlaresDepthAtten");
            ChildControls.Add(anamorphicFlaresDepthAttenSlider);
            anamorphicFlaresAntiflickerToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.anamorphicFlaresAntiflicker, "toggle");
            anamorphicFlaresAntiflickerToggle.Text = Translation.GetText("Beautify", "anamorphicFlaresAntiflicker");
            ChildControls.Add(anamorphicFlaresAntiflickerToggle);
            anamorphicFlaresUltraToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.anamorphicFlaresUltra, "toggle");
            anamorphicFlaresUltraToggle.Text = Translation.GetText("Beautify", "anamorphicFlaresUltra");
            ChildControls.Add(anamorphicFlaresUltraToggle);
            anamorphicFlaresTintPicker = new CustomColorPicker(BeautifyDef.beautifyEffect.anamorphicFlaresTint);
            anamorphicFlaresTintPicker.Text = Translation.GetText("Beautify", "anamorphicFlaresTint");
            ChildControls.Add(anamorphicFlaresTintPicker);
            sunFlaresIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresIntensity, 0f, 1f, 4);
            sunFlaresIntensitySlider.Text = Translation.GetText("Beautify", "sunFlaresIntensity");
            ChildControls.Add(sunFlaresIntensitySlider);
            sunFlaresTintPicker = new CustomColorPicker(BeautifyDef.beautifyEffect.sunFlaresTint);
            sunFlaresTintPicker.Text = Translation.GetText("Beautify", "sunFlaresTint");
            ChildControls.Add(sunFlaresTintPicker);
            sunFlaresSolarWindSpeedSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresSolarWindSpeed, 0f, 1f, 4);
            sunFlaresSolarWindSpeedSlider.Text = Translation.GetText("Beautify", "sunFlaresSolarWindSpeed");
            ChildControls.Add(sunFlaresSolarWindSpeedSlider);
            sunFlaresRotationDeadZoneToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.sunFlaresRotationDeadZone, "toggle");
            sunFlaresRotationDeadZoneToggle.Text = Translation.GetText("Beautify", "sunFlaresRotationDeadZone");
            ChildControls.Add(sunFlaresRotationDeadZoneToggle);
            sunFlaresDownsamplingSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresDownsampling, 1, 5, 1);
            sunFlaresDownsamplingSlider.Text = Translation.GetText("Beautify", "sunFlaresDownsampling");
            ChildControls.Add(sunFlaresDownsamplingSlider);
            sunFlaresLayerMaskSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresLayerMask, -10, 10, 1);
            sunFlaresLayerMaskSlider.Text = Translation.GetText("Beautify", "sunFlaresLayerMask");
            ChildControls.Add(sunFlaresLayerMaskSlider);
            sunFlaresSunIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresSunIntensity, 0f, 1f, 4);
            sunFlaresSunIntensitySlider.Text = Translation.GetText("Beautify", "sunFlaresSunIntensity");
            ChildControls.Add(sunFlaresSunIntensitySlider);
            sunFlaresSunDiskSizeSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresSunDiskSize, 0f, 1f, 4);
            sunFlaresSunDiskSizeSlider.Text = Translation.GetText("Beautify", "sunFlaresSunDiskSize");
            ChildControls.Add(sunFlaresSunDiskSizeSlider);
            sunFlaresSunRayDiffractionIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresSunRayDiffractionIntensity, 0f, 10f, 4);
            sunFlaresSunRayDiffractionIntensitySlider.Text = Translation.GetText("Beautify", "sunFlaresSunRayDiffractionIntensity");
            ChildControls.Add(sunFlaresSunRayDiffractionIntensitySlider);
            sunFlaresSunRayDiffractionThresholdSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresSunRayDiffractionThreshold, 0f, 1f, 4);
            sunFlaresSunRayDiffractionThresholdSlider.Text = Translation.GetText("Beautify", "sunFlaresSunRayDiffractionThreshold");
            ChildControls.Add(sunFlaresSunRayDiffractionThresholdSlider);
            // Corona Rays Group 1
            sunFlaresCoronaRays1LengthSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresCoronaRays1Length, 0f, 0.2f, 4);
            sunFlaresCoronaRays1LengthSlider.Text = Translation.GetText("Beautify", "sunFlaresCoronaRays1Length");
            ChildControls.Add(sunFlaresCoronaRays1LengthSlider);
            sunFlaresCoronaRays1StreaksSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresCoronaRays1Streaks, 2f, 30f, 4);
            sunFlaresCoronaRays1StreaksSlider.Text = Translation.GetText("Beautify", "sunFlaresCoronaRays1Streaks");
            ChildControls.Add(sunFlaresCoronaRays1StreaksSlider);
            sunFlaresCoronaRays1SpreadSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresCoronaRays1Spread, 0f, 0.1f, 4);
            sunFlaresCoronaRays1SpreadSlider.Text = Translation.GetText("Beautify", "sunFlaresCoronaRays1Spread");
            ChildControls.Add(sunFlaresCoronaRays1SpreadSlider);
            sunFlaresCoronaRays1AngleOffsetSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresCoronaRays1AngleOffset, 0f, 2f * Mathf.PI, 4);
            sunFlaresCoronaRays1AngleOffsetSlider.Text = Translation.GetText("Beautify", "sunFlaresCoronaRays1AngleOffset");
            ChildControls.Add(sunFlaresCoronaRays1AngleOffsetSlider);
            // Corona Rays Group 2
            sunFlaresCoronaRays2LengthSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresCoronaRays2Length, 0f, 0.2f, 4);
            sunFlaresCoronaRays2LengthSlider.Text = Translation.GetText("Beautify", "sunFlaresCoronaRays2Length");
            ChildControls.Add(sunFlaresCoronaRays2LengthSlider);
            sunFlaresCoronaRays2StreaksSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresCoronaRays2Streaks, 2f, 30f, 4);
            sunFlaresCoronaRays2StreaksSlider.Text = Translation.GetText("Beautify", "sunFlaresCoronaRays2Streaks");
            ChildControls.Add(sunFlaresCoronaRays2StreaksSlider);
            sunFlaresCoronaRays2SpreadSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresCoronaRays2Spread, 0f, 0.1f, 4);
            sunFlaresCoronaRays2SpreadSlider.Text = Translation.GetText("Beautify", "sunFlaresCoronaRays2Spread");
            ChildControls.Add(sunFlaresCoronaRays2SpreadSlider);
            sunFlaresCoronaRays2AngleOffsetSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresCoronaRays2AngleOffset, 0f, 2f * Mathf.PI, 4);
            sunFlaresCoronaRays2AngleOffsetSlider.Text = Translation.GetText("Beautify", "sunFlaresCoronaRays2AngleOffset");
            ChildControls.Add(sunFlaresCoronaRays2AngleOffsetSlider);
            // Ghost 1
            sunFlaresGhosts1SizeSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts1Size, 0f, 1f, 4);
            sunFlaresGhosts1SizeSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts1Size");
            ChildControls.Add(sunFlaresGhosts1SizeSlider);
            sunFlaresGhosts1OffsetSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts1Offset, -3f, 3f, 4);
            sunFlaresGhosts1OffsetSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts1Offset");
            ChildControls.Add(sunFlaresGhosts1OffsetSlider);
            sunFlaresGhosts1BrightnessSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts1Brightness, 0f, 1f, 4);
            sunFlaresGhosts1BrightnessSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts1Brightness");
            ChildControls.Add(sunFlaresGhosts1BrightnessSlider);
            // Ghost 2
            sunFlaresGhosts2SizeSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts2Size, 0f, 1f, 4);
            sunFlaresGhosts2SizeSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts2Size");
            ChildControls.Add(sunFlaresGhosts2SizeSlider);
            sunFlaresGhosts2OffsetSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts2Offset, -3f, 3f, 4);
            sunFlaresGhosts2OffsetSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts2Offset");
            ChildControls.Add(sunFlaresGhosts2OffsetSlider);
            sunFlaresGhosts2BrightnessSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts2Brightness, 0f, 1f, 4);
            sunFlaresGhosts2BrightnessSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts2Brightness");
            ChildControls.Add(sunFlaresGhosts2BrightnessSlider);
            // Ghost 3
            sunFlaresGhosts3SizeSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts3Size, 0f, 1f, 4);
            sunFlaresGhosts3SizeSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts3Size");
            ChildControls.Add(sunFlaresGhosts3SizeSlider);
            sunFlaresGhosts3OffsetSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts3Offset, -3f, 3f, 4);
            sunFlaresGhosts3OffsetSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts3Offset");
            ChildControls.Add(sunFlaresGhosts3OffsetSlider);
            sunFlaresGhosts3BrightnessSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts3Brightness, 0f, 1f, 4);
            sunFlaresGhosts3BrightnessSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts3Brightness");
            ChildControls.Add(sunFlaresGhosts3BrightnessSlider);
            // Ghost 4
            sunFlaresGhosts4SizeSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts4Size, 0f, 1f, 4);
            sunFlaresGhosts4SizeSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts4Size");
            ChildControls.Add(sunFlaresGhosts4SizeSlider);
            sunFlaresGhosts4OffsetSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts4Offset, -3f, 3f, 4);
            sunFlaresGhosts4OffsetSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts4Offset");
            ChildControls.Add(sunFlaresGhosts4OffsetSlider);
            sunFlaresGhosts4BrightnessSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresGhosts4Brightness, 0f, 1f, 4);
            sunFlaresGhosts4BrightnessSlider.Text = Translation.GetText("Beautify", "sunFlaresGhosts4Brightness");
            ChildControls.Add(sunFlaresGhosts4BrightnessSlider);
            // Halo
            sunFlaresHaloOffsetSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresHaloOffset, 0f, 1f, 4);
            sunFlaresHaloOffsetSlider.Text = Translation.GetText("Beautify", "sunFlaresHaloOffset");
            ChildControls.Add(sunFlaresHaloOffsetSlider);
            sunFlaresHaloAmplitudeSlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresHaloAmplitude, 0f, 50f, 4);
            sunFlaresHaloAmplitudeSlider.Text = Translation.GetText("Beautify", "sunFlaresHaloAmplitude");
            ChildControls.Add(sunFlaresHaloAmplitudeSlider);
            sunFlaresHaloIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.sunFlaresHaloIntensity, 0f, 1f, 4);
            sunFlaresHaloIntensitySlider.Text = Translation.GetText("Beautify", "sunFlaresHaloIntensity");
            ChildControls.Add(sunFlaresHaloIntensitySlider);
            #endregion
            enableLensDirtToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableLensDirt, "toggle");
            enableLensDirtToggle.Text = Translation.GetText("Beautify", "enableLensDirt");
            ChildControls.Add(enableLensDirtToggle);
            #region Lens Dirt
            lensDirtIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.lensDirtIntensity, 0f, 1f, 4);
            lensDirtIntensitySlider.Text = Translation.GetText("Beautify", "lensDirtIntensity");
            ChildControls.Add(lensDirtIntensitySlider);
            lensDirtThresholdSlider = new CustomSlider(BeautifyDef.beautifyEffect.lensDirtThreshold, 0f, 1f, 4);
            lensDirtThresholdSlider.Text = Translation.GetText("Beautify", "lensDirtThreshold");
            ChildControls.Add(lensDirtThresholdSlider);
            lensDirtTexturePicker = new CustomImagePicker(BeautifyDef.lensDirtTexture, BeautifyDef.lensDirtTextureFile, COM3D2.PostProcessing.Plugin.Utils.AssetLoader.lensDirtTextureDir);
            lensDirtTexturePicker.Text = lensDirtTexturePicker.Value.name;
            lensDirtTexturePicker.TextureChanged += (sender, e) =>
            {
                lensDirtTexturePicker.Text = lensDirtTexturePicker.Value.name;
            };
            ChildControls.Add(lensDirtTexturePicker);
            lensDirtSpreadSlider = new CustomSlider(BeautifyDef.beautifyEffect.lensDirtSpread, 3, 5, 1);
            lensDirtSpreadSlider.Text = Translation.GetText("Beautify", "lensDirtSpread");
            ChildControls.Add(lensDirtSpreadSlider);
            #endregion
            enableEyeAdaptationToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableEyeAdaptation, "toggle");
            enableEyeAdaptationToggle.Text = Translation.GetText("Beautify", "enableEyeAdaptation");
            ChildControls.Add(enableEyeAdaptationToggle);
            #region Eye Adaptation
            eyeAdaptationToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.eyeAdaptation, "toggle");
            eyeAdaptationToggle.Text = Translation.GetText("Beautify", "eyeAdaptation");
            ChildControls.Add(eyeAdaptationToggle);
            eyeAdaptationMinExposureSlider = new CustomSlider(BeautifyDef.beautifyEffect.eyeAdaptationMinExposure, 0f, 1f, 4);
            eyeAdaptationMinExposureSlider.Text = Translation.GetText("Beautify", "eyeAdaptationMinExposure");
            ChildControls.Add(eyeAdaptationMinExposureSlider);
            eyeAdaptationMaxExposureSlider = new CustomSlider(BeautifyDef.beautifyEffect.eyeAdaptationMaxExposure, 1f, 100f, 4);
            eyeAdaptationMaxExposureSlider.Text = Translation.GetText("Beautify", "eyeAdaptationMaxExposure");
            ChildControls.Add(eyeAdaptationMaxExposureSlider);
            eyeAdaptationSpeedToLightSlider = new CustomSlider(BeautifyDef.beautifyEffect.eyeAdaptationSpeedToLight, 0f, 1f, 4);
            eyeAdaptationSpeedToLightSlider.Text = Translation.GetText("Beautify", "eyeAdaptationSpeedToLight");
            ChildControls.Add(eyeAdaptationSpeedToLightSlider);
            eyeAdaptationSpeedToDarkSlider = new CustomSlider(BeautifyDef.beautifyEffect.eyeAdaptationSpeedToDark, 0f, 1f, 4);
            eyeAdaptationSpeedToDarkSlider.Text = Translation.GetText("Beautify", "eyeAdaptationSpeedToDark");
            ChildControls.Add(eyeAdaptationSpeedToDarkSlider);
            #endregion
            enablePurkinjeToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enablePurkinje, "toggle");
            enablePurkinjeToggle.Text = Translation.GetText("Beautify", "enablePurkinje");
            ChildControls.Add(enablePurkinjeToggle);
            #region Purkinje effect
            purkinjeToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.purkinje, "toggle");
            purkinjeToggle.Text = Translation.GetText("Beautify", "purkinje");
            ChildControls.Add(purkinjeToggle);
            purkinjeAmountSlider = new CustomSlider(BeautifyDef.beautifyEffect.purkinjeAmount, 0f, 5f, 4);
            purkinjeAmountSlider.Text = Translation.GetText("Beautify", "purkinjeAmount");
            ChildControls.Add(purkinjeAmountSlider);
            purkinjeLuminanceThresholdSlider = new CustomSlider(BeautifyDef.beautifyEffect.purkinjeLuminanceThreshold, 0f, 1f, 4);
            purkinjeLuminanceThresholdSlider.Text = Translation.GetText("Beautify", "purkinjeLuminanceThreshold");
            ChildControls.Add(purkinjeLuminanceThresholdSlider);
            #endregion
            enableVignettingToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableVignetting, "toggle");
            enableVignettingToggle.Text = Translation.GetText("Beautify", "enableVignetting");
            ChildControls.Add(enableVignettingToggle);
            #region Vignetting
            vignettingOuterRingSlider = new CustomSlider(BeautifyDef.beautifyEffect.vignettingOuterRing, 0f, 1f, 4);
            vignettingOuterRingSlider.Text = Translation.GetText("Beautify", "vignettingOuterRing");
            ChildControls.Add(vignettingOuterRingSlider);
            vignettingInnerRingSlider = new CustomSlider(BeautifyDef.beautifyEffect.vignettingInnerRing, 0f, 1f, 4);
            vignettingInnerRingSlider.Text = Translation.GetText("Beautify", "vignettingInnerRing");
            ChildControls.Add(vignettingInnerRingSlider);
            vignettingFadeSlider = new CustomSlider(BeautifyDef.beautifyEffect.vignettingFade, 0f, 1f, 4);
            vignettingFadeSlider.Text = Translation.GetText("Beautify", "vignettingFade");
            ChildControls.Add(vignettingFadeSlider);
            vignettingCircularShapeToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.vignettingCircularShape, "toggle");
            vignettingCircularShapeToggle.Text = Translation.GetText("Beautify", "vignettingCircularShape");
            ChildControls.Add(vignettingCircularShapeToggle);
            vignettingAspectRatioSlider = new CustomSlider(BeautifyDef.beautifyEffect.vignettingAspectRatio, 0f, 1f, 4);
            vignettingAspectRatioSlider.Text = Translation.GetText("Beautify", "vignettingAspectRatio");
            ChildControls.Add(vignettingAspectRatioSlider);
            vignettingBlinkSlider = new CustomSlider(BeautifyDef.beautifyEffect.vignettingBlink, 0f, 1f, 4);
            vignettingBlinkSlider.Text = Translation.GetText("Beautify", "vignettingBlink");
            ChildControls.Add(vignettingBlinkSlider);
            vignettingColorPicker = new CustomColorPicker(BeautifyDef.beautifyEffect.vignettingColor);
            vignettingColorPicker.Text = Translation.GetText("Beautify", "vignettingColor");
            ChildControls.Add(vignettingColorPicker);
            vignettingMaskPicker = new CustomImagePicker(BeautifyDef.vignettingMask, BeautifyDef.vignettingMaskFile, COM3D2.PostProcessing.Plugin.Utils.AssetLoader.vignettingMaskTextureDir);
            vignettingMaskPicker.Text = vignettingMaskPicker.Value.name;
            vignettingMaskPicker.TextureChanged += (sender, e) =>
            {
                vignettingMaskPicker.Text = vignettingMaskPicker.Value.name;
            };
            ChildControls.Add(vignettingMaskPicker);
            #endregion
            enableDepthOfFieldToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableDepthOfField, "toggle");
            enableDepthOfFieldToggle.Text = Translation.GetText("Beautify", "enableDepthOfField");
            ChildControls.Add(enableDepthOfFieldToggle);
            #region Depth of Field
            depthOfFieldToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.depthOfField, "toggle");
            depthOfFieldToggle.Text = Translation.GetText("Beautify", "depthOfField");
            ChildControls.Add(depthOfFieldToggle);
            depthOfFieldDebugToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.depthOfFieldDebug, "toggle");
            depthOfFieldDebugToggle.Text = Translation.GetText("Beautify", "depthOfFieldDebug");
            ChildControls.Add(depthOfFieldDebugToggle);
            depthOfFieldFocusModeBox = new CustomComboBox(Enum.GetNames(typeof(BeautifyDoFFocusMode)));
            depthOfFieldFocusModeBox.Text = Translation.GetText("Beautify", "depthOfFieldFocusMode");
            depthOfFieldFocusModeBox.SelectedIndex = (int)BeautifyDef.beautifyEffect.depthOfFieldFocusMode;
            ChildControls.Add(depthOfFieldFocusModeBox);
            depthOfFieldAutofocusMinDistanceSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldAutofocusMinDistance, 0f, 100f, 4);
            depthOfFieldAutofocusMinDistanceSlider.Text = Translation.GetText("Beautify", "depthOfFieldAutofocusMinDistance");
            ChildControls.Add(depthOfFieldAutofocusMinDistanceSlider);
            depthOfFieldAutofocusMaxDistanceSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldAutofocusMaxDistance, 0f, 10000f, 4);
            depthOfFieldAutofocusMaxDistanceSlider.Text = Translation.GetText("Beautify", "depthOfFieldAutofocusMaxDistance");
            ChildControls.Add(depthOfFieldAutofocusMaxDistanceSlider);
            depthofFieldAutofocusViewportPoint_XSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthofFieldAutofocusViewportPoint_X, 0f, 1f, 4);
            depthofFieldAutofocusViewportPoint_XSlider.Text = Translation.GetText("Beautify", "depthofFieldAutofocusViewportPoint_X");
            ChildControls.Add(depthofFieldAutofocusViewportPoint_XSlider);
            depthofFieldAutofocusViewportPoint_YSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthofFieldAutofocusViewportPoint_Y, 0f, 1f, 4);
            depthofFieldAutofocusViewportPoint_YSlider.Text = Translation.GetText("Beautify", "depthofFieldAutofocusViewportPoint_Y");
            ChildControls.Add(depthofFieldAutofocusViewportPoint_YSlider);
            depthOfFieldAutofocusLayerMaskSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldAutofocusLayerMask, -1, 100, 4);
            depthOfFieldAutofocusLayerMaskSlider.Text = Translation.GetText("Beautify", "depthOfFieldAutofocusLayerMask");
            ChildControls.Add(depthOfFieldAutofocusLayerMaskSlider);
            depthOfFieldExclusionLayerMaskSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldExclusionLayerMask, 0, 100, 4);
            depthOfFieldExclusionLayerMaskSlider.Text = Translation.GetText("Beautify", "depthOfFieldExclusionLayerMask");
            ChildControls.Add(depthOfFieldExclusionLayerMaskSlider);
            depthOfFieldExclusionLayerMaskDownsamplingSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldExclusionLayerMaskDownsampling, 1, 4, 4);
            depthOfFieldExclusionLayerMaskDownsamplingSlider.Text = Translation.GetText("Beautify", "depthOfFieldExclusionLayerMaskDownsampling");
            ChildControls.Add(depthOfFieldExclusionLayerMaskDownsamplingSlider);
            depthOfFieldTransparencySupportToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.depthOfFieldTransparencySupport, "toggle");
            depthOfFieldTransparencySupportToggle.Text = Translation.GetText("Beautify", "depthOfFieldTransparencySupport");
            ChildControls.Add(depthOfFieldTransparencySupportToggle);
            depthOfFieldTransparencyLayerMaskSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldTransparencyLayerMask, -1, 100, 4);
            depthOfFieldTransparencyLayerMaskSlider.Text = Translation.GetText("Beautify", "depthOfFieldTransparencyLayerMask");
            ChildControls.Add(depthOfFieldTransparencyLayerMaskSlider);
            depthOfFieldTransparencySupportDownsamplingSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldTransparencySupportDownsampling, 1, 4, 4);
            depthOfFieldTransparencySupportDownsamplingSlider.Text = Translation.GetText("Beautify", "depthOfFieldTransparencySupportDownsampling");
            ChildControls.Add(depthOfFieldTransparencySupportDownsamplingSlider);
            depthOfFieldExclusionBiasSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldExclusionBias, 0.9f, 1f, 4);
            depthOfFieldExclusionBiasSlider.Text = Translation.GetText("Beautify", "depthOfFieldExclusionBias");
            ChildControls.Add(depthOfFieldExclusionBiasSlider);
            depthOfFieldDistanceSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldDistance, 1f, 100f, 4);
            depthOfFieldDistanceSlider.Text = Translation.GetText("Beautify", "depthOfFieldDistance");
            ChildControls.Add(depthOfFieldDistanceSlider);
            depthOfFieldFocusSpeedSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldFocusSpeed, 0.001f, 5f, 4);
            depthOfFieldFocusSpeedSlider.Text = Translation.GetText("Beautify", "depthOfFieldFocusSpeed");
            ChildControls.Add(depthOfFieldFocusSpeedSlider);
            depthOfFieldDownsamplingSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldDownsampling, 1, 5, 4);
            depthOfFieldDownsamplingSlider.Text = Translation.GetText("Beautify", "depthOfFieldDownsampling");
            ChildControls.Add(depthOfFieldDownsamplingSlider);
            depthOfFieldMaxSamplesSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldMaxSamples, 2, 16, 4);
            depthOfFieldMaxSamplesSlider.Text = Translation.GetText("Beautify", "depthOfFieldMaxSamples");
            ChildControls.Add(depthOfFieldMaxSamplesSlider);
            depthOfFieldFocalLengthSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldFocalLength, 0.005f, 0.5f, 4);
            depthOfFieldFocalLengthSlider.Text = Translation.GetText("Beautify", "depthOfFieldFocalLength");
            ChildControls.Add(depthOfFieldFocalLengthSlider);
            depthOfFieldApertureSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldAperture, 0f, 5f, 4);
            depthOfFieldApertureSlider.Text = Translation.GetText("Beautify", "depthOfFieldAperture");
            ChildControls.Add(depthOfFieldApertureSlider);
            depthOfFieldForegroundBlurToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.depthOfFieldForegroundBlur, "toggle");
            depthOfFieldForegroundBlurToggle.Text = Translation.GetText("Beautify", "depthOfFieldForegroundBlur");
            ChildControls.Add(depthOfFieldForegroundBlurToggle);
            depthOfFieldForegroundBlurHQToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.depthOfFieldForegroundBlurHQ, "toggle");
            depthOfFieldForegroundBlurHQToggle.Text = Translation.GetText("Beautify", "depthOfFieldForegroundBlurHQ");
            ChildControls.Add(depthOfFieldForegroundBlurHQToggle);
            depthOfFieldForegroundDistanceSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldForegroundDistance, 0f, 1f, 4);
            depthOfFieldForegroundDistanceSlider.Text = Translation.GetText("Beautify", "depthOfFieldForegroundDistance");
            ChildControls.Add(depthOfFieldForegroundDistanceSlider);
            depthOfFieldBokehToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.depthOfFieldBokeh, "toggle");
            depthOfFieldBokehToggle.Text = Translation.GetText("Beautify", "depthOfFieldBokeh");
            ChildControls.Add(depthOfFieldBokehToggle);
            depthOfFieldBokehThresholdSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldBokehThreshold, 0.5f, 3f, 4);
            depthOfFieldBokehThresholdSlider.Text = Translation.GetText("Beautify", "depthOfFieldBokehThreshold");
            ChildControls.Add(depthOfFieldBokehThresholdSlider);
            depthOfFieldBokehIntensitySlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldBokehIntensity, 0f, 8f, 4);
            depthOfFieldBokehIntensitySlider.Text = Translation.GetText("Beautify", "depthOfFieldBokehIntensity");
            ChildControls.Add(depthOfFieldBokehIntensitySlider);
            depthOfFieldMaxBrightnessSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldMaxBrightness, 0f, 2000f, 4);
            depthOfFieldMaxBrightnessSlider.Text = Translation.GetText("Beautify", "depthOfFieldMaxBrightness");
            ChildControls.Add(depthOfFieldMaxBrightnessSlider);
            depthOfFieldMaxDistanceSlider = new CustomSlider(BeautifyDef.beautifyEffect.depthOfFieldMaxDistance, 0f, 10f, 4);
            depthOfFieldMaxDistanceSlider.Text = Translation.GetText("Beautify", "depthOfFieldMaxDistance");
            ChildControls.Add(depthOfFieldMaxDistanceSlider);
            depthOfFieldFilterModeBox = new CustomComboBox(Enum.GetNames(typeof(FilterMode)));
            depthOfFieldFilterModeBox.Text = Translation.GetText("Beautify", "depthOfFieldFilterMode");
            depthOfFieldFilterModeBox.SelectedIndex = (int)BeautifyDef.beautifyEffect.depthOfFieldFilterMode;
            ChildControls.Add(depthOfFieldFilterModeBox);
            #endregion
            enableOutlineToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.enableOutline, "toggle");
            enableOutlineToggle.Text = Translation.GetText("Beautify", "enableOutline");
            ChildControls.Add(enableOutlineToggle);
            #region Outline
            outlineToggle = new CustomToggleButton(BeautifyDef.beautifyEffect.outline, "toggle");
            outlineToggle.Text = Translation.GetText("Beautify", "outline");
            ChildControls.Add(outlineToggle);
            outlineColorPicker = new CustomColorPicker(BeautifyDef.beautifyEffect.outlineColor);
            outlineColorPicker.Text = Translation.GetText("Beautify", "outlineColor");
            ChildControls.Add(outlineColorPicker);
            #endregion
        }

        public override void ShowPane()
        {
            GUIUtil.AddResetButton(this, ResetButton);
            GUIUtil.AddGUICheckbox(this, antialiasingBox);
            GUIUtil.AddGUICheckbox(this, enableCompareToggle);
            if (enableCompare)
            {
                GUIUtil.AddGUICheckbox(this, compareModeToggle);
                GUIUtil.AddGUISlider(this, compareLineAngleSlider);
                GUIUtil.AddGUISlider(this, compareLineWidthSlider);
            }
            GUIUtil.AddGUICheckbox(this, enableSharpenToggle);
            if (enableSharpen)
            {
                GUIUtil.AddGUISlider(this, sharpenIntensitySlider);
                GUIUtil.AddGUISlider(this, sharpenDepthThresholdSlider);
                GUIUtil.AddGUISlider(this, sharpenMinDepthSlider);
                GUIUtil.AddGUISlider(this, sharpenMaxDepthSlider);
                GUIUtil.AddGUISlider(this, sharpenRelaxationSlider);
                GUIUtil.AddGUISlider(this, sharpenClampSlider);
                GUIUtil.AddGUISlider(this, sharpenMotionSensibilitySlider);
            }
            GUIUtil.AddGUICheckbox(this, enableColorTweaksToggle);
            if (enableColorTweaks)
            {
                GUIUtil.AddGUISlider(this, daltonizeSlider);
                GUIUtil.AddGUISlider(this, sepiaSlider);
                GUIUtil.AddGUISlider(this, saturateSlider);
                GUIUtil.AddGUISlider(this, brightnessSlider);
                GUIUtil.AddGUISlider(this, contrastSlider);
                GUIUtil.AddGUICheckbox(this, tintColorPicker);
                GUIUtil.AddGUICheckbox(this, tonemapBox);
                GUIUtil.AddGUISlider(this, tonemapExposurePreSlider);
                GUIUtil.AddGUISlider(this, tonemapBrightnessPostSlider);
            }
            GUIUtil.AddGUICheckbox(this, enableLutToggle);
            if (enableLut)
            {
                GUIUtil.AddGUICheckbox(this, lutToggle);
                GUIUtil.AddGUISlider(this, lutIntensitySlider);
                GUIUtil.AddGUICheckbox(this, lutTexturePicker);
            }
            GUIUtil.AddGUICheckbox(this, enableBloomFlaresToggle);
            if (enableBloomFlares)
            {
                GUIUtil.AddGUISlider(this, bloomIntensitySlider);
                GUIUtil.AddGUISlider(this, bloomThresholdSlider);
                GUIUtil.AddGUISlider(this, bloomMaxBrightnessSlider);
                GUIUtil.AddGUISlider(this, bloomDepthAttenSlider);
                GUIUtil.AddGUICheckbox(this, bloomAntiflickerToggle);
                GUIUtil.AddGUICheckbox(this, bloomUltraToggle);
                GUIUtil.AddGUICheckbox(this, bloomDebugToggle);
                GUIUtil.AddGUICheckbox(this, bloomCustomizeToggle);
                if (bloomCustomize)
                {
                    GUIUtil.AddGUISlider(this, bloomWeight0Slider);
                    GUIUtil.AddGUISlider(this, bloomBoost0Slider);
                    GUIUtil.AddGUISlider(this, bloomWeight1Slider);
                    GUIUtil.AddGUISlider(this, bloomBoost1Slider);
                    GUIUtil.AddGUISlider(this, bloomWeight2Slider);
                    GUIUtil.AddGUISlider(this, bloomBoost2Slider);
                    GUIUtil.AddGUISlider(this, bloomWeight3Slider);
                    GUIUtil.AddGUISlider(this, bloomBoost3Slider);
                    GUIUtil.AddGUISlider(this, bloomWeight4Slider);
                    GUIUtil.AddGUISlider(this, bloomBoost4Slider);
                    GUIUtil.AddGUISlider(this, bloomWeight5Slider);
                    GUIUtil.AddGUISlider(this, bloomBoost5Slider);
                }
                GUIUtil.AddGUISlider(this, anamorphicFlaresIntensitySlider);
                GUIUtil.AddGUISlider(this, anamorphicFlaresThresholdSlider);
                GUIUtil.AddGUICheckbox(this, anamorphicFlaresVerticalToggle);
                GUIUtil.AddGUISlider(this, anamorphicFlaresSpreadSlider);
                GUIUtil.AddGUISlider(this, anamorphicFlaresDepthAttenSlider);
                GUIUtil.AddGUICheckbox(this, anamorphicFlaresAntiflickerToggle);
                GUIUtil.AddGUICheckbox(this, anamorphicFlaresUltraToggle);
                GUIUtil.AddGUICheckbox(this, anamorphicFlaresTintPicker);
                GUIUtil.AddGUISlider(this, sunFlaresIntensitySlider);
                GUIUtil.AddGUICheckbox(this, sunFlaresTintPicker);
                GUIUtil.AddGUISlider(this, sunFlaresSolarWindSpeedSlider);
                GUIUtil.AddGUICheckbox(this, sunFlaresRotationDeadZoneToggle);
                GUIUtil.AddGUISlider(this, sunFlaresDownsamplingSlider);
                GUIUtil.AddGUISlider(this, sunFlaresLayerMaskSlider);
                GUIUtil.AddGUISlider(this, sunFlaresSunIntensitySlider);
                GUIUtil.AddGUISlider(this, sunFlaresSunDiskSizeSlider);
                GUIUtil.AddGUISlider(this, sunFlaresSunRayDiffractionIntensitySlider);
                GUIUtil.AddGUISlider(this, sunFlaresSunRayDiffractionThresholdSlider);
                // Corona Rays Group 1
                GUIUtil.AddGUISlider(this, sunFlaresCoronaRays1LengthSlider);
                GUIUtil.AddGUISlider(this, sunFlaresCoronaRays1StreaksSlider);
                GUIUtil.AddGUISlider(this, sunFlaresCoronaRays1SpreadSlider);
                GUIUtil.AddGUISlider(this, sunFlaresCoronaRays1AngleOffsetSlider);
                // Corona Rays Group 2
                GUIUtil.AddGUISlider(this, sunFlaresCoronaRays2LengthSlider);
                GUIUtil.AddGUISlider(this, sunFlaresCoronaRays2StreaksSlider);
                GUIUtil.AddGUISlider(this, sunFlaresCoronaRays2SpreadSlider);
                GUIUtil.AddGUISlider(this, sunFlaresCoronaRays2AngleOffsetSlider);
                // Ghost 1
                GUIUtil.AddGUISlider(this, sunFlaresGhosts1SizeSlider);
                GUIUtil.AddGUISlider(this, sunFlaresGhosts1OffsetSlider);
                GUIUtil.AddGUISlider(this, sunFlaresGhosts1BrightnessSlider);
                // Ghost 2"
                GUIUtil.AddGUISlider(this, sunFlaresGhosts2SizeSlider);
                GUIUtil.AddGUISlider(this, sunFlaresGhosts2OffsetSlider);
                GUIUtil.AddGUISlider(this, sunFlaresGhosts2BrightnessSlider);
                // Ghost 3
                GUIUtil.AddGUISlider(this, sunFlaresGhosts3SizeSlider);
                GUIUtil.AddGUISlider(this, sunFlaresGhosts3BrightnessSlider);
                GUIUtil.AddGUISlider(this, sunFlaresGhosts3OffsetSlider);
                // Ghost 4
                GUIUtil.AddGUISlider(this, sunFlaresGhosts4SizeSlider);
                GUIUtil.AddGUISlider(this, sunFlaresGhosts4OffsetSlider);
                GUIUtil.AddGUISlider(this, sunFlaresGhosts4BrightnessSlider);
                // Halo
                GUIUtil.AddGUISlider(this, sunFlaresHaloOffsetSlider);
                GUIUtil.AddGUISlider(this, sunFlaresHaloAmplitudeSlider);
                GUIUtil.AddGUISlider(this, sunFlaresHaloIntensitySlider);
            }
            GUIUtil.AddGUICheckbox(this, enableLensDirtToggle);
            if (enableLensDirt)
            {
                GUIUtil.AddGUISlider(this, lensDirtIntensitySlider);
                GUIUtil.AddGUISlider(this, lensDirtThresholdSlider);
                GUIUtil.AddGUICheckbox(this, lensDirtTexturePicker);
                GUIUtil.AddGUISlider(this, lensDirtSpreadSlider);
            }
            GUIUtil.AddGUICheckbox(this, enableEyeAdaptationToggle);
            if (enableEyeAdaptation)
            {
                GUIUtil.AddGUICheckbox(this, eyeAdaptationToggle);
                GUIUtil.AddGUISlider(this, eyeAdaptationMinExposureSlider);
                GUIUtil.AddGUISlider(this, eyeAdaptationMaxExposureSlider);
                GUIUtil.AddGUISlider(this, eyeAdaptationSpeedToLightSlider);
                GUIUtil.AddGUISlider(this, eyeAdaptationSpeedToDarkSlider);
            }
            GUIUtil.AddGUICheckbox(this, enablePurkinjeToggle);
            if (enablePurkinje)
            {
                GUIUtil.AddGUICheckbox(this, purkinjeToggle);
                GUIUtil.AddGUISlider(this, purkinjeAmountSlider);
                GUIUtil.AddGUISlider(this, purkinjeLuminanceThresholdSlider);
            }
            GUIUtil.AddGUICheckbox(this, enableVignettingToggle);
            if (enableVignetting)
            {
                GUIUtil.AddGUISlider(this, vignettingOuterRingSlider);
                GUIUtil.AddGUISlider(this, vignettingInnerRingSlider);
                GUIUtil.AddGUISlider(this, vignettingFadeSlider);
                GUIUtil.AddGUICheckbox(this, vignettingCircularShapeToggle);
                GUIUtil.AddGUISlider(this, vignettingAspectRatioSlider);
                GUIUtil.AddGUISlider(this, vignettingBlinkSlider);
                GUIUtil.AddGUICheckbox(this, vignettingColorPicker);
                GUIUtil.AddGUICheckbox(this, vignettingMaskPicker);
            }
            GUIUtil.AddGUICheckbox(this, enableDepthOfFieldToggle);
            if (enableDepthOfField)
            {
                GUIUtil.AddGUICheckbox(this, depthOfFieldToggle);
                GUIUtil.AddGUICheckbox(this, depthOfFieldDebugToggle);
                GUIUtil.AddGUICheckbox(this, depthOfFieldFocusModeBox);
                GUIUtil.AddGUISlider(this, depthOfFieldAutofocusMinDistanceSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldAutofocusMaxDistanceSlider);
                GUIUtil.AddGUISlider(this, depthofFieldAutofocusViewportPoint_XSlider);
                GUIUtil.AddGUISlider(this, depthofFieldAutofocusViewportPoint_YSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldAutofocusLayerMaskSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldExclusionLayerMaskSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldExclusionLayerMaskDownsamplingSlider);
                GUIUtil.AddGUICheckbox(this, depthOfFieldTransparencySupportToggle);
                GUIUtil.AddGUISlider(this, depthOfFieldTransparencyLayerMaskSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldTransparencySupportDownsamplingSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldExclusionBiasSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldDistanceSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldFocusSpeedSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldDownsamplingSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldMaxSamplesSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldFocalLengthSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldApertureSlider);
                GUIUtil.AddGUICheckbox(this, depthOfFieldForegroundBlurToggle);
                GUIUtil.AddGUICheckbox(this, depthOfFieldForegroundBlurHQToggle);
                GUIUtil.AddGUISlider(this, depthOfFieldForegroundDistanceSlider);
                GUIUtil.AddGUICheckbox(this, depthOfFieldBokehToggle);
                GUIUtil.AddGUISlider(this, depthOfFieldBokehThresholdSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldBokehIntensitySlider);
                GUIUtil.AddGUISlider(this, depthOfFieldMaxBrightnessSlider);
                GUIUtil.AddGUISlider(this, depthOfFieldMaxDistanceSlider);
                GUIUtil.AddGUICheckbox(this, depthOfFieldFilterModeBox);
            }
            GUIUtil.AddGUICheckbox(this, enableOutlineToggle);
            if (enableOutline)
            {
                GUIUtil.AddGUICheckbox(this, outlineToggle);
                GUIUtil.AddGUICheckbox(this, outlineColorPicker);
            }
        }

        public override void Reset()
        {
            antialiasingBox.SelectedIndex = 1;
            enableCompareToggle.Value = BeautifyDef.enableCompare;
            #region Compare settings
            compareModeToggle.Value = BeautifyDef.compareMode;
            compareLineAngleSlider.Value = BeautifyDef.compareLineAngle;
            compareLineWidthSlider.Value = BeautifyDef.compareLineWidth;
            #endregion
            enableSharpenToggle.Value = BeautifyDef.enableSharpen;
            #region Sharpen settings
            sharpenIntensitySlider.Value = BeautifyDef.sharpenIntensity;
            sharpenDepthThresholdSlider.Value = BeautifyDef.sharpenDepthThreshold;
            sharpenMinDepthSlider.Value = BeautifyDef.sharpenMinDepth;
            sharpenMaxDepthSlider.Value = BeautifyDef.sharpenMaxDepth;
            sharpenRelaxationSlider.Value = BeautifyDef.sharpenRelaxation;
            sharpenClampSlider.Value = BeautifyDef.sharpenClamp;
            sharpenMotionSensibilitySlider.Value = BeautifyDef.sharpenMotionSensibility;
            #endregion
            enableColorTweaksToggle.Value = BeautifyDef.enableColorTweaks;
            #region Color tweaks
            daltonizeSlider.Value = BeautifyDef.daltonize;
            sepiaSlider.Value = BeautifyDef.sepia;
            saturateSlider.Value = BeautifyDef.saturate;
            brightnessSlider.Value = BeautifyDef.brightness;
            contrastSlider.Value = BeautifyDef.contrast;
            tintColorPicker.Value = BeautifyDef.tintColor;
            tonemapBox.SelectedIndex = (int)BeautifyDef.tonemap;
            tonemapExposurePreSlider.Value = BeautifyDef.tonemapExposurePre;
            tonemapBrightnessPostSlider.Value = BeautifyDef.tonemapBrightnessPost;
            #endregion
            enableLutToggle.Value = BeautifyDef.enableLut;
            #region Lut
            lutToggle.Value = BeautifyDef.lut;
            lutIntensitySlider.Value = BeautifyDef.lutIntensity;
            lutTexturePicker.Value = new Texture2D(2, 2);
            #endregion
            enableBloomFlaresToggle.Value = BeautifyDef.enableBloomFlares;
            #region Bloom & Flares effects
            bloomIntensitySlider.Value = BeautifyDef.bloomIntensity;
            bloomThresholdSlider.Value = BeautifyDef.bloomThreshold;
            bloomMaxBrightnessSlider.Value = BeautifyDef.bloomMaxBrightness;
            bloomDepthAttenSlider.Value = BeautifyDef.bloomDepthAtten;
            bloomAntiflickerToggle.Value = BeautifyDef.bloomAntiflicker;
            bloomUltraToggle.Value = BeautifyDef.bloomUltra;
            bloomDebugToggle.Value = BeautifyDef.bloomDebug;
            bloomCustomizeToggle.Value = BeautifyDef.bloomCustomize;
            bloomWeight0Slider.Value = BeautifyDef.bloomWeight0;
            bloomWeight1Slider.Value = BeautifyDef.bloomWeight1;
            bloomWeight2Slider.Value = BeautifyDef.bloomWeight2;
            bloomWeight3Slider.Value = BeautifyDef.bloomWeight3;
            bloomWeight4Slider.Value = BeautifyDef.bloomWeight4;
            bloomWeight5Slider.Value = BeautifyDef.bloomWeight5;
            bloomBoost0Slider.Value = BeautifyDef.bloomBoost0;
            bloomBoost1Slider.Value = BeautifyDef.bloomBoost1;
            bloomBoost2Slider.Value = BeautifyDef.bloomBoost2;
            bloomBoost3Slider.Value = BeautifyDef.bloomBoost3;
            bloomBoost4Slider.Value = BeautifyDef.bloomBoost4;
            bloomBoost5Slider.Value = BeautifyDef.bloomBoost5;
            anamorphicFlaresIntensitySlider.Value = BeautifyDef.anamorphicFlaresIntensity;
            anamorphicFlaresThresholdSlider.Value = BeautifyDef.anamorphicFlaresThreshold;
            anamorphicFlaresVerticalToggle.Value = BeautifyDef.anamorphicFlaresVertical;
            anamorphicFlaresSpreadSlider.Value = BeautifyDef.anamorphicFlaresSpread;
            anamorphicFlaresDepthAttenSlider.Value = BeautifyDef.anamorphicFlaresDepthAtten;
            anamorphicFlaresAntiflickerToggle.Value = BeautifyDef.anamorphicFlaresAntiflicker;
            anamorphicFlaresUltraToggle.Value = BeautifyDef.anamorphicFlaresUltra;
            anamorphicFlaresTintPicker.Value = BeautifyDef.anamorphicFlaresTint;
            sunFlaresIntensitySlider.Value = BeautifyDef.sunFlaresIntensity;
            sunFlaresTintPicker.Value = BeautifyDef.sunFlaresTint;
            sunFlaresSolarWindSpeedSlider.Value = BeautifyDef.sunFlaresSolarWindSpeed;
            sunFlaresRotationDeadZoneToggle.Value = BeautifyDef.sunFlaresRotationDeadZone;
            sunFlaresDownsamplingSlider.Value = BeautifyDef.sunFlaresDownsampling;
            sunFlaresLayerMaskSlider.Value = BeautifyDef.sunFlaresLayerMask;
            sunFlaresSunIntensitySlider.Value = BeautifyDef.sunFlaresSunIntensity;
            sunFlaresSunDiskSizeSlider.Value = BeautifyDef.sunFlaresSunDiskSize;
            sunFlaresSunRayDiffractionIntensitySlider.Value = BeautifyDef.sunFlaresSunRayDiffractionIntensity;
            sunFlaresSunRayDiffractionThresholdSlider.Value = BeautifyDef.sunFlaresSunRayDiffractionThreshold;
            // Corona Rays Group 1
            sunFlaresCoronaRays1LengthSlider.Value = BeautifyDef.sunFlaresCoronaRays1Length;
            sunFlaresCoronaRays1StreaksSlider.Value = BeautifyDef.sunFlaresCoronaRays1Streaks;
            sunFlaresCoronaRays1SpreadSlider.Value = BeautifyDef.sunFlaresCoronaRays1Spread;
            sunFlaresCoronaRays1AngleOffsetSlider.Value = BeautifyDef.sunFlaresCoronaRays1AngleOffset;
            // Corona Rays Group 2
            sunFlaresCoronaRays2LengthSlider.Value = BeautifyDef.sunFlaresCoronaRays2Length;
            sunFlaresCoronaRays2StreaksSlider.Value = BeautifyDef.sunFlaresCoronaRays2Streaks;
            sunFlaresCoronaRays2SpreadSlider.Value = BeautifyDef.sunFlaresCoronaRays2Spread;
            sunFlaresCoronaRays2AngleOffsetSlider.Value = BeautifyDef.sunFlaresCoronaRays2AngleOffset;
            // Ghost 1
            sunFlaresGhosts1SizeSlider.Value = BeautifyDef.sunFlaresGhosts1Size;
            sunFlaresGhosts1OffsetSlider.Value = BeautifyDef.sunFlaresGhosts1Offset;
            sunFlaresGhosts1BrightnessSlider.Value = BeautifyDef.sunFlaresGhosts1Brightness;
            // Ghost 2
            sunFlaresGhosts2SizeSlider.Value = BeautifyDef.sunFlaresGhosts2Size;
            sunFlaresGhosts2OffsetSlider.Value = BeautifyDef.sunFlaresGhosts2Offset;
            sunFlaresGhosts2BrightnessSlider.Value = BeautifyDef.sunFlaresGhosts2Brightness;
            // Ghost 3
            sunFlaresGhosts3SizeSlider.Value = BeautifyDef.sunFlaresGhosts3Size;
            sunFlaresGhosts3BrightnessSlider.Value = BeautifyDef.sunFlaresGhosts3Brightness;
            sunFlaresGhosts3OffsetSlider.Value = BeautifyDef.sunFlaresGhosts3Offset;
            // Ghost 4
            sunFlaresGhosts4SizeSlider.Value = BeautifyDef.sunFlaresGhosts4Size;
            sunFlaresGhosts4OffsetSlider.Value = BeautifyDef.sunFlaresGhosts4Offset;
            sunFlaresGhosts4BrightnessSlider.Value = BeautifyDef.sunFlaresGhosts4Brightness;
            // Halo
            sunFlaresHaloOffsetSlider.Value = BeautifyDef.sunFlaresHaloOffset;
            sunFlaresHaloAmplitudeSlider.Value = BeautifyDef.sunFlaresHaloAmplitude;
            sunFlaresHaloIntensitySlider.Value = BeautifyDef.sunFlaresHaloIntensity;
            #endregion
            enableLensDirtToggle.Value = BeautifyDef.enableLensDirt;
            #region Lens Dirt
            lensDirtIntensitySlider.Value = BeautifyDef.lensDirtIntensity;
            lensDirtThresholdSlider.Value = BeautifyDef.lensDirtThreshold;
            lensDirtTexturePicker.Value = new Texture2D(2, 2);
            lensDirtSpreadSlider.Value = BeautifyDef.lensDirtSpread;
            #endregion
            enableEyeAdaptationToggle.Value = BeautifyDef.enableEyeAdaptation;
            #region Eye Adaptation
            eyeAdaptationToggle.Value = BeautifyDef.eyeAdaptation;
            eyeAdaptationMinExposureSlider.Value = BeautifyDef.eyeAdaptationMinExposure;
            eyeAdaptationMaxExposureSlider.Value = BeautifyDef.eyeAdaptationMaxExposure;
            eyeAdaptationSpeedToLightSlider.Value = BeautifyDef.eyeAdaptationSpeedToLight;
            eyeAdaptationSpeedToDarkSlider.Value = BeautifyDef.eyeAdaptationSpeedToDark;
            #endregion
            enablePurkinjeToggle.Value = BeautifyDef.enablePurkinje;
            #region Purkinje effect
            purkinjeToggle.Value = BeautifyDef.purkinje;
            purkinjeAmountSlider.Value = BeautifyDef.purkinjeAmount;
            purkinjeLuminanceThresholdSlider.Value = BeautifyDef.purkinjeLuminanceThreshold;
            #endregion
            enableVignettingToggle.Value = BeautifyDef.enableVignetting;
            #region Vignetting
            vignettingOuterRingSlider.Value = BeautifyDef.vignettingOuterRing;
            vignettingInnerRingSlider.Value = BeautifyDef.vignettingInnerRing;
            vignettingFadeSlider.Value = BeautifyDef.vignettingFade;
            vignettingCircularShapeToggle.Value = BeautifyDef.vignettingCircularShape;
            vignettingAspectRatioSlider.Value = BeautifyDef.vignettingAspectRatio;
            vignettingBlinkSlider.Value = BeautifyDef.vignettingBlink;
            vignettingColorPicker.Value = BeautifyDef.vignettingColor;
            vignettingMaskPicker.Value = new Texture2D(2, 2);
            #endregion
            enableDepthOfFieldToggle.Value = BeautifyDef.enableDepthOfField;
            #region Depth of Field
            depthOfFieldToggle.Value = BeautifyDef.depthOfField;
            depthOfFieldDebugToggle.Value = BeautifyDef.depthOfFieldDebug;
            depthOfFieldFocusModeBox.SelectedIndex = (int)BeautifyDef.depthOfFieldFocusMode;
            depthOfFieldAutofocusMinDistanceSlider.Value = BeautifyDef.depthOfFieldAutofocusMinDistance;
            depthOfFieldAutofocusMaxDistanceSlider.Value = BeautifyDef.depthOfFieldAutofocusMaxDistance;
            depthofFieldAutofocusViewportPoint_XSlider.Value = BeautifyDef.depthofFieldAutofocusViewportPoint_X;
            depthofFieldAutofocusViewportPoint_YSlider.Value = BeautifyDef.depthofFieldAutofocusViewportPoint_Y;
            depthOfFieldAutofocusLayerMaskSlider.Value = BeautifyDef.depthOfFieldAutofocusLayerMask;
            depthOfFieldExclusionLayerMaskSlider.Value = BeautifyDef.depthOfFieldExclusionLayerMask;
            depthOfFieldExclusionLayerMaskDownsamplingSlider.Value = BeautifyDef.depthOfFieldExclusionLayerMaskDownsampling;
            depthOfFieldTransparencySupportToggle.Value = BeautifyDef.depthOfFieldTransparencySupport;
            depthOfFieldTransparencyLayerMaskSlider.Value = BeautifyDef.depthOfFieldTransparencyLayerMask;
            depthOfFieldTransparencySupportDownsamplingSlider.Value = BeautifyDef.depthOfFieldTransparencySupportDownsampling;
            depthOfFieldExclusionBiasSlider.Value = BeautifyDef.depthOfFieldExclusionBias;
            depthOfFieldDistanceSlider.Value = BeautifyDef.depthOfFieldDistance;
            depthOfFieldFocusSpeedSlider.Value = BeautifyDef.depthOfFieldFocusSpeed;
            depthOfFieldDownsamplingSlider.Value = BeautifyDef.depthOfFieldDownsampling;
            depthOfFieldMaxSamplesSlider.Value = BeautifyDef.depthOfFieldMaxSamples;
            depthOfFieldFocalLengthSlider.Value = BeautifyDef.depthOfFieldFocalLength;
            depthOfFieldApertureSlider.Value = BeautifyDef.depthOfFieldAperture;
            depthOfFieldForegroundBlurToggle.Value = BeautifyDef.depthOfFieldForegroundBlur;
            depthOfFieldForegroundBlurHQToggle.Value = BeautifyDef.depthOfFieldForegroundBlurHQ;
            depthOfFieldForegroundDistanceSlider.Value = BeautifyDef.depthOfFieldForegroundDistance;
            depthOfFieldBokehToggle.Value = BeautifyDef.depthOfFieldBokeh;
            depthOfFieldBokehThresholdSlider.Value = BeautifyDef.depthOfFieldBokehThreshold;
            depthOfFieldBokehIntensitySlider.Value = BeautifyDef.depthOfFieldBokehIntensity;
            depthOfFieldMaxBrightnessSlider.Value = BeautifyDef.depthOfFieldMaxBrightness;
            depthOfFieldMaxDistanceSlider.Value = BeautifyDef.depthOfFieldMaxDistance;
            depthOfFieldFilterModeBox.SelectedIndex = (int)BeautifyDef.depthOfFieldFilterMode;
            #endregion
            enableOutlineToggle.Value = BeautifyDef.enableOutline;
            #region Outline
            outlineToggle.Value = BeautifyDef.outline;
            outlineColorPicker.Value = BeautifyDef.outlineColor;
            #endregion
        }
    }

    internal class CustomLinearImagePicker : ControlBase
    {
        private Texture2D _value;

        private string _filename;

        private List<string> imageDirectories;

        public EventHandler TextureChanged = delegate
        {
        };

        public virtual Texture2D Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                Text = " " + value.name;
            }
        }

        public virtual string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
            }
        }

        public CustomLinearImagePicker(Texture texture, string filename, List<string> imageDirectories)
        {
            try
            {
                this.imageDirectories = imageDirectories;
                _value = (Texture2D)texture;
                if (_value == null)
                {
                    _value = new Texture2D(1, 1);
                    _value.SetPixel(0, 0, new Color(255f, 255f, 255f, 127f));
                    _value.name = " Texture";
                    _value.Apply();
                }

                _filename = filename;
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }

        public override void OnGUI()
        {
            try
            {
                Rect position = new Rect(Left, Top, Height, Height);
                Rect position2 = new Rect(Left + Height, Top, Width - Height, Height);
                GUIStyle gUIStyle = new GUIStyle("label");
                gUIStyle.alignment = TextAnchor.MiddleLeft;
                gUIStyle.normal.textColor = TextColor;
                gUIStyle.fontSize = FixedFontSize;
                GUI.DrawTexture(position, _value);
                GUI.Label(position2, Text, gUIStyle);
                if (GUI.Button(position, string.Empty, gUIStyle))
                {
                    GlobalTexturePicker.Set(new Vector2(Left + base.ScreenPos.x, Top + base.ScreenPos.y), FontSize * 40, FontSize, imageDirectories, delegate (Texture2D x, string y)
                    {
                        string fullPath = Path.Combine(ConstantValues.BaseConfigDir, y);
                        byte[] data = File.ReadAllBytes(fullPath);
                        _value = new Texture2D(1, 1, TextureFormat.RGBA32, false, true);
                        _value.wrapMode = TextureWrapMode.Clamp;
                        _value.filterMode = FilterMode.Bilinear;
                        _value.anisoLevel = 0;
                        _value.LoadImage(data);
                        _filename = y;
                        TextureChanged(this, new EventArgs());
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
    }
}
