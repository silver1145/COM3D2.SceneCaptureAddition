using HarmonyLib;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using static HarmonyLib.AccessTools;

namespace COM3D2.SceneCaptureAddition.Plugin
{
    internal class ScreenshotPatch
    {
        static FieldRef<CameraMain, bool> custom_screenshot_ = FieldRefAccess<CameraMain, bool>("custom_screenshot_");
        static FieldRef<CameraMain, string> custom_screenshot_save_file_path_ = FieldRefAccess<CameraMain, string>("custom_screenshot_save_file_path_");
        static FieldRef<CameraMain, int> custom_screenshot_super_size_ = FieldRefAccess<CameraMain, int>("custom_screenshot_super_size_");
        static FieldRef<CameraMain, int[]> ss_super_size_ = FieldRefAccess<CameraMain, int[]>("ss_super_size_");
        static FieldRef<CameraMain, bool> screen_shot_normal_ = FieldRefAccess<CameraMain, bool>("screen_shot_normal_");
        static FieldRef<CameraMain, bool> screen_shot_noui_ = FieldRefAccess<CameraMain, bool>("screen_shot_noui_");
        static Func<CameraMain, string> cameraMainGetTimeFileName = AccessTools.MethodDelegate<Func<CameraMain, string>>(AccessTools.Method(typeof(CameraMain), "GetTimeFileName"));


        [HarmonyPatch(typeof(CameraMain), nameof(CameraMain.ScreenShot), new[] { typeof(bool)})]
        [HarmonyPrefix]
        private static bool ScreenShotPrefix1(CameraMain __instance, bool f_bNoUI)
        {
            custom_screenshot_(__instance) = false;
            if (f_bNoUI)
            {
                __instance.StartCoroutine(SaveScreenShotNoUI(__instance));
            }
            else
            {
                __instance.StartCoroutine(SaveScreenShotNormal(__instance));
            }
            return false;
        }

        [HarmonyPatch(typeof(CameraMain), nameof(CameraMain.ScreenShot), new[] { typeof(string), typeof(int), typeof(bool) })]
        [HarmonyPrefix]
        private static bool ScreenShotPrefix2(CameraMain __instance, string file_path, int super_size, bool no_ui_mode)
        {
            custom_screenshot_(__instance) = true;
            custom_screenshot_save_file_path_(__instance) = file_path;
            custom_screenshot_super_size_(__instance) = super_size;
            if (no_ui_mode)
            {
                __instance.StartCoroutine(SaveScreenShotNoUI(__instance));
            }
            else
            {
                __instance.StartCoroutine(SaveScreenShotNormal(__instance));
            }
            return false;
        }

        private static IEnumerator SaveScreenShotNormal(CameraMain cameraMain)
        {
            yield return new WaitForEndOfFrame();
            int super_size = ss_super_size_(cameraMain)[(int)GameMain.Instance.CMSystem.ScreenShotSuperSize];
            string file_path = cameraMainGetTimeFileName.Invoke(cameraMain);
            if (custom_screenshot_(cameraMain))
            {
                file_path = custom_screenshot_save_file_path_(cameraMain);
                super_size = custom_screenshot_super_size_(cameraMain);
            }
            #region ScreenShot With UI
            int width = Screen.width;
            int height = Screen.height;
            if (super_size > 1)
            {
                width *= super_size;
                height *= super_size;
            }

            RenderTexture rt = new RenderTexture(width, height, 24, RenderTextureFormat.ARGB32);
            rt.antiAliasing = 1;
            rt.useMipMap = false;
            rt.autoGenerateMips = false;

            var cam = GameMain.Instance.MainCamera.camera;
            RenderTexture oldRT = cam.targetTexture;
            RenderTexture oldActive = RenderTexture.active;

            cam.targetTexture = rt;
            RenderTexture.active = rt;
            cam.Render();

            foreach (UICamera uiCam in NGUITools.FindActive<UICamera>()) {
                if (uiCam.cachedCamera != null)
                {
                    uiCam.cachedCamera.targetTexture = rt;
                    uiCam.cachedCamera.Render();
                    uiCam.cachedCamera.targetTexture = null;
                }
            }

            RenderTexture.active = rt;
            Texture2D image = new Texture2D(width, height, TextureFormat.RGB24, false);
            image.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            image.Apply();

            byte[] bytes = image.EncodeToPNG();
            File.WriteAllBytes(file_path, bytes);

            cam.targetTexture = oldRT;
            RenderTexture.active = oldActive;
            UnityEngine.Object.Destroy(rt);
            UnityEngine.Object.Destroy(image);
            #endregion
            yield return new WaitForEndOfFrame();
            screen_shot_normal_(cameraMain) = false;
            yield break;
        }

        private static IEnumerator SaveScreenShotNoUI(CameraMain cameraMain)
        {
            yield return new WaitForEndOfFrame();
            int super_size = ss_super_size_(cameraMain)[(int)GameMain.Instance.CMSystem.ScreenShotSuperSize];
            string file_path = cameraMainGetTimeFileName.Invoke(cameraMain);
            if (custom_screenshot_(cameraMain))
            {
                file_path = custom_screenshot_save_file_path_(cameraMain);
                super_size = custom_screenshot_super_size_(cameraMain);
            }
            #region ScreenShot Without UI
            int width = Screen.width;
            int height = Screen.height;
            if (super_size > 1)
            {
                width *= super_size;
                height *= super_size;
            }
            RenderTexture rt = new RenderTexture(width, height, 24);
            rt.antiAliasing = 1;
            rt.useMipMap = false;
            rt.autoGenerateMips = false;

            RenderTexture oldRT = GameMain.Instance.MainCamera.camera.targetTexture;
            RenderTexture oldActive = RenderTexture.active;

            GameMain.Instance.MainCamera.camera.targetTexture = rt;
            RenderTexture.active = rt;

            GameMain.Instance.MainCamera.camera.Render();

            Texture2D image = new Texture2D(width, height, TextureFormat.RGB24, false);
            image.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            image.Apply();

            byte[] bytes = image.EncodeToPNG();
            File.WriteAllBytes(file_path, bytes);

            GameMain.Instance.MainCamera.camera.targetTexture = oldRT;
            RenderTexture.active = oldActive;
            UnityEngine.Object.Destroy(rt);
            UnityEngine.Object.Destroy(image);
            #endregion
            yield return new WaitForEndOfFrame();
            screen_shot_noui_(cameraMain) = false;
            yield break;
        }
    }
}
