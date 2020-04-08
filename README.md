# ImageProcessingLibraryforUnity
Unityで画像処理を行うためのライブラリ<br>
A library for image processing in Unity<br>
<br>
簡単な画像処理をComputeShaderを利用することで高速に行うことができます．<br>
You can simple image processing rapidly by using ComputeShader.<br>
<br>
メソッドチェーンのように記述することができ，直感的に書けるのが特徴です．<br>
You can write like a method chain, so you can write intuitively.<br>

## 導入 / Installation
[Release](https://github.com/Asalato/ImageProcessingLibraryforUnity/releases)のページから最新版をダウンロードし，利用するUnityプロジェクト内で展開してください<br>
Please download the latest version from the Release page, and deploy it in your Unity project.<br>

## 利用方法 / How to Use
### 事前準備 / Prepare before Scripting
利用したいシーン内に `ShaderSettings` のPrefabを置きます．<br>
Put a Prefab called `ShaderSettings` in the scene you want to use.

### コードの書き方 / How to write codes
* 画像処理したいテクスチャをTexture2D等のフォーマットからRenderTexture（ComputeShaderで扱えるフォーマット）に変換します．<br>
Converts a texture to RenderTexture (a format that can be handled by ComputeShader).

```cs
var renderTexture = tex2D.ToRenderTexture();
```

* `FilterLibrary.cs` を参考に，好きなフィルタ関数を選びRenderTextureに適用します．<br>
Refer to `FilterLibrary.cs` and choose your favorite filter function and apply it to RenderTexture.

```cs
// このようにメソッドチェーンのように連続して処理を行うことができます
// you can write a sequence of operations like a method chain
var editedTexture = renderTexture.GaussianFilter3x3().MedianFilter3x3();
```

* RenderTextureのままRawImageに貼りつけることで，画像を表示できます<br>
You can view the image by pasting it to RawImage, even if it is still a RenderTexture.

```cs
this.GetComponent<RawImage>().texture = renderTexture;
```

* 画像をRenderTextureからTexture2Dに変更することもできます<br>
You can also change the image from RenderTexture to Texture2D.

```cs
var texture2D = renderTexture().ToTexture2D();
```
