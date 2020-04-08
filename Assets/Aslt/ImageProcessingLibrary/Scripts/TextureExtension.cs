using UnityEngine;

namespace Aslt.IMLibary
{
    /// <summary>
    /// Converting Texture
    /// </summary>
    public static class TextureExtension
    {
        /// <summary>
        /// Converting Texture to RenderTexture
        /// </summary>
        /// <param name="texture">Source Texture</param>
        /// <returns></returns>
        public static RenderTexture ToRenderTexture(this Texture texture)
        {
            var renderTexture = new RenderTexture(texture.width, texture.height, 0) {enableRandomWrite = true};
            renderTexture.Create();
            Graphics.Blit(texture, renderTexture);
            return renderTexture;
        }
        
        /// <summary>
        /// Converting RenderTexture to Texture2D
        /// </summary>
        /// <param name="texture">Source RenderTexture</param>
        /// <returns></returns>
        public static Texture2D ToTexture2D(this RenderTexture texture)
        {
            Texture2D texture2D = new Texture2D(texture.width, texture.height, TextureFormat.ARGB32, false, false);

            RenderTexture.active = texture;
            texture2D.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
            texture2D.Apply();
            RenderTexture.active = null;
            return texture2D;
        }

        /// <summary>
        /// Get dimension of the texture
        /// </summary>
        /// <param name="texture">Source Image</param>
        /// <returns></returns>
        public static Vector2Int GetSize(this RenderTexture texture) => new Vector2Int(texture.width, texture.height);

        /// <summary>
        /// Get dimension of the texture
        /// </summary>
        /// <param name="texture">Source Image</param>
        /// <returns></returns>
        public static Vector2Int GetSize(this Texture texture) => new Vector2Int(texture.width, texture.height);
    }
}