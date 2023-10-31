using COM3D2.SceneCaptureAddition.Plugin;
using UnityEngine;

namespace CM3D2.SceneCapture.Plugin
{
    public class HDR : MonoBehaviour
    {
        private Camera cachedCamera;

        private void OnEnable()
        {
            cachedCamera = GetComponent<Camera>();
            if (cachedCamera != null )
            {
                cachedCamera.allowHDR = true;
                SceneCaptureAddition.HDREnabled = true;
            }
        }

        private void OnDisable()
        {
            if ( cachedCamera != null )
            {
                cachedCamera.allowHDR = false;
                SceneCaptureAddition.HDREnabled = false;
            }
        }
    }
}
