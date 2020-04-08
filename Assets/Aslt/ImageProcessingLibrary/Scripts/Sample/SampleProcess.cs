using UnityEngine;
using UnityEngine.UI;

namespace Aslt.IMLibary
{
    public class SampleProcess : MonoBehaviour
    {
        public RawImage source;
        public RawImage destination;

        private void Start()
        {
            // UnityのTextureフォーマット（Texture，Texture2D）をRenderTextureに変換する
            var renderTexture = source.texture.ToRenderTexture();
        
            // ノイズ除去し，エッジを抽出
            var edgeTexture = renderTexture.GaussianFilter5X5().ExtractEdge();

            // 色を変更して画面に表示
            // RenderTextureはRawImageにしか貼り付けられないので注意
            destination.texture = edgeTexture.TransAlpha(true).MoveChannel(Color.white);
            
            // 必要に応じてTexture2Dに変更する（画像を保存するとき等）
            //var tex2d = renderTexture.ToTexture2D();
        }
    }
}
