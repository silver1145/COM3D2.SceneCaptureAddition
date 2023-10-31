namespace UnityEngine.Rendering.PostProcessing
{
    public class RenderTextureDescriptor
    {
        public int width;
        public int height;
        public int mipCount;
        public int volumeDepth;
        public int msaaSamples;
        public int depthBufferBits;
        public bool sRGB;
        public bool useMipMap;
        public bool autoGenerateMips;
        public bool enableRandomWrite;
        public VRTextureUsage vrUsage;
        public TextureDimension dimension;
        public RenderTextureFormat colorFormat;
        public RenderTextureReadWrite readWrite;
        public ShadowSamplingMode shadowSamplingMode;

        public RenderTextureDescriptor(
            int width,
            int height,
            RenderTextureFormat colorFormat = RenderTextureFormat.Default,
            int depthBufferBits = 0,
            int mipCount = -1,
            RenderTextureReadWrite readWrite = RenderTextureReadWrite.Linear
        )
        {
            this.width = width;
            this.height = height;
            this.colorFormat = colorFormat;
            this.depthBufferBits = depthBufferBits;
            this.mipCount = mipCount;
            this.readWrite = readWrite;
            this.msaaSamples = 1;
        }
    }
}