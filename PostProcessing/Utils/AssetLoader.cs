using BepInEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace COM3D2.PostProcessing.Plugin.Utils
{
    public static class AssetLoader
    {
        // UnityEngine.Rendering.PostProcessing
        public static PostProcessResources postProcessResources;
        /*
        public static Shader trackball;         // Hidden/PostProcessing/Editor/Trackball
        public static Shader curveGrid;         // Hidden/PostProcessing/Editor/CurveGrid
        public static Shader convertToLog;      // Hidden/PostProcessing/Editor/ConvertToLog
        */
        // MadGoat.SSAA
        public static Shader ssaaDef;           // Hidden/SSAA_Def
        public static Shader ssaaBilinear;      // Hidden/SSAA_Bilinear
        public static Shader ssaaBicubic;       // Hidden/SSAA_Bicubic
        public static Shader ssaaFSS;           // Hidden/SSAA/FSS
        public static Shader ssaaAlpha;         // Hidden/SSAA_Alpha
        public static Shader ssaaNearest;       // Hidden/SSAA_Nearest
        // BeautifyForPPS
        public static Shader beautifyPPSCore;   // Hidden/BeautifyPPSCore

        // Path
        internal static string AssetPath = Path.Combine(Paths.ConfigPath, "PostProcessing/postprocess_resources");
        
        public static readonly List<string> lutTextureDir = new List<string> { "SceneCapture/LUTs/BeautifyLUT/" };
        public static readonly List<string> lensDirtTextureDir = new List<string> { "SceneCapture/LensDirt/" };
        public static readonly List<string> vignettingMaskTextureDir = new List<string> { "SceneCapture/VignettingMask/" };
        public static void LoadAsset()
        {
            try
            {
                AssetBundle assetBundle = AssetBundle.LoadFromFile(AssetPath);
                postProcessResources = assetBundle.LoadAsset<PostProcessResources>("PostProcessResources");
                // https://issuetracker.unity3d.com/issues/assetbundle-is-not-loaded-correctly-when-they-reference-a-script-in-custom-dll-which-contains-system-dot-serializable-in-the-build
                postProcessResources.smaaLuts = new PostProcessResources.SMAALuts();
                postProcessResources.shaders = new PostProcessResources.Shaders();
                postProcessResources.computeShaders = new PostProcessResources.ComputeShaders();

                postProcessResources.smaaLuts.area = assetBundle.LoadAsset<Texture2D>("AreaTex");
                postProcessResources.smaaLuts.search = assetBundle.LoadAsset<Texture2D>("SearchTex");
                foreach (var s in assetBundle.LoadAllAssets())
                {
                    if (s is Shader)
                    {
                        string fieldName = Path.GetFileName(s.name);
                        fieldName = char.ToLower(fieldName[0]) + fieldName.Substring(1);
                        FieldInfo fieldInfo = typeof(PostProcessResources.Shaders).GetField(fieldName);
                        if (fieldInfo != null)
                        {
                            fieldInfo.SetValue(postProcessResources.shaders, s);
                        }
                    }
                    else if (s is ComputeShader)
                    {
                        string fieldName = Path.GetFileName(s.name);
                        fieldName = char.ToLower(fieldName[0]) + fieldName.Substring(1);
                        FieldInfo fieldInfo = typeof(PostProcessResources.ComputeShaders).GetField(fieldName);
                        if (fieldInfo != null)
                        {
                            fieldInfo.SetValue(postProcessResources.computeShaders, s);
                        }
                    }
                }

                ssaaDef = assetBundle.LoadAsset<Shader>("STD_SSAA_Def");
                ssaaBilinear = assetBundle.LoadAsset<Shader>("STD_SSAA_Bilinear");
                ssaaBicubic = assetBundle.LoadAsset<Shader>("STD_SSAA_Bicubic");
                ssaaFSS = assetBundle.LoadAsset<Shader>("STD_SSAA_FXAA");
                ssaaAlpha = assetBundle.LoadAsset<Shader>("STD_SSAA_Alpha");
                ssaaNearest = assetBundle.LoadAsset<Shader>("STD_SSAA_Nearest");
                beautifyPPSCore = assetBundle.LoadAsset<Shader>("BeautifyCore");
                assetBundle.Unload(false);
            }
            catch (Exception e)
            {
                PostProcessing.Logger.LogError($"PostProcessing LoadAsset Failed:\n{e}");
            }
        }
    }
}
