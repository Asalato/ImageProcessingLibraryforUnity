using UnityEngine;

namespace Aslt.IMLibary
{
    public static class FilterLibrary
    {
        private static ComputeShader _shader;

        private static int _gaussian3X3KernelIndex;
        private static int _gaussian5X5KernelIndex;
        private static int _laplacianKernelIndex;
        private static int _simpleMovingAverage3X3KernelIndex;
        private static int _simpleMovingAverage5X5KernelIndex;
        private static int _median3X3KernelIndex;
        private static int _median5X5KernelIndex;
        private static int _muskKernelIndex;
        private static int _appendKernelIndex;
        private static int _resolutionKernelIndex;
        private static int _threshold3X3KernelIndex;
        private static int _threshold5X5KernelIndex;
        private static int _transAlphaKernelIndex;
        private static int _createKernelIndex;
        private static int _addKernelIndex;
        private static int _moveChannelKernelIndex;
        private static int _exceptKernelIndex;
        private static int _overrideKernelIndex;
        private static int _edgeKernelIndex;

        public static void Init(ComputeShader shader)
        {
            _shader = shader;

            _gaussian3X3KernelIndex = _shader.FindKernel("Gaussian3x3");
            _gaussian5X5KernelIndex = _shader.FindKernel("Gaussian5x5");
            _laplacianKernelIndex = _shader.FindKernel("Laplacian");
            _simpleMovingAverage3X3KernelIndex = _shader.FindKernel("SMA3x3");
            _simpleMovingAverage5X5KernelIndex = _shader.FindKernel("SMA5x5");
            _median3X3KernelIndex = _shader.FindKernel("Median3x3");
            _median5X5KernelIndex = _shader.FindKernel("Median5x5");
            _muskKernelIndex = _shader.FindKernel("Musk");
            _appendKernelIndex = _shader.FindKernel("Append");
            _resolutionKernelIndex = _shader.FindKernel("FixResolution");
            _threshold3X3KernelIndex = _shader.FindKernel("ThresholdFilter3x3");
            _threshold5X5KernelIndex = _shader.FindKernel("ThresholdFilter5x5");
            _transAlphaKernelIndex = _shader.FindKernel("TransAlpha");
            _createKernelIndex = _shader.FindKernel("Create");
            _addKernelIndex = _shader.FindKernel("Add");
            _moveChannelKernelIndex = _shader.FindKernel("MoveChannel");
            _exceptKernelIndex = _shader.FindKernel("Except");
            _overrideKernelIndex = _shader.FindKernel("Override");
            _edgeKernelIndex = _shader.FindKernel("ExtractEdge");
        }

        /// <summary>
        /// 3x3 Gaussian Filter
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <returns></returns>
        public static RenderTexture GaussianFilter3X3(this RenderTexture source)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_gaussian3X3KernelIndex, "Source", source);
            _shader.SetTexture(_gaussian3X3KernelIndex, "Destination", destination);

            _shader.Dispatch(_gaussian3X3KernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// 5x5 Gaussian Filter
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <returns></returns>
        public static RenderTexture GaussianFilter5X5(this RenderTexture source)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_gaussian5X5KernelIndex, "Source", source);
            _shader.SetTexture(_gaussian5X5KernelIndex, "Destination", destination);

            _shader.Dispatch(_gaussian5X5KernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// 3x3 Laplacian Filter
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <returns></returns>
        public static RenderTexture LaplacianFilter(this RenderTexture source)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_laplacianKernelIndex, "Source", source);
            _shader.SetTexture(_laplacianKernelIndex, "Destination", destination);

            _shader.Dispatch(_laplacianKernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// 3x3 Smart Moving Average Filter
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <returns></returns>
        public static RenderTexture SimpleMovingAverageFilter3X3(this RenderTexture source)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_simpleMovingAverage3X3KernelIndex, "Source", source);
            _shader.SetTexture(_simpleMovingAverage3X3KernelIndex, "Destination", destination);

            _shader.Dispatch(_simpleMovingAverage3X3KernelIndex,
                Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32),
                1);
            return destination;
        }

        /// <summary>
        /// 5x5 Smart Moving Average Filter
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <returns></returns>
        public static RenderTexture SimpleMovingAverageFilter5X5(this RenderTexture source)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_simpleMovingAverage5X5KernelIndex, "Source", source);
            _shader.SetTexture(_simpleMovingAverage5X5KernelIndex, "Destination", destination);

            _shader.Dispatch(_simpleMovingAverage5X5KernelIndex,
                Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32),
                1);
            return destination;
        }

        /// <summary>
        /// 3x3 Median Filter
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <returns></returns>
        public static RenderTexture MedianFilter3X3(this RenderTexture source)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_median3X3KernelIndex, "Source", source);
            _shader.SetTexture(_median3X3KernelIndex, "Destination", destination);

            _shader.Dispatch(_median3X3KernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// 5x5 Median Filter
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <returns></returns>
        public static RenderTexture MedianFilter5X5(this RenderTexture source)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_median5X5KernelIndex, "Source", source);
            _shader.SetTexture(_median5X5KernelIndex, "Destination", destination);

            _shader.Dispatch(_median5X5KernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// Apply the mask image indicated by 0 or 1 to the source image
        /// </summary>
        /// <param name="source0">Source Image</param>
        /// <param name="source1">Mask Image(Indicated by 0 or 1)</param>
        /// <returns></returns>
        public static RenderTexture Mask(this RenderTexture source0, RenderTexture source1)
        {
            if (source1.width * source1.height == 0) return source0;

            var destination = new RenderTexture(source0.width, source0.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_muskKernelIndex, "Source", source0);
            _shader.SetTexture(_muskKernelIndex, "Source1", source1);
            _shader.SetTexture(_muskKernelIndex, "Destination", destination);

            _shader.Dispatch(_muskKernelIndex, Mathf.CeilToInt((float) source0.width / 32),
                Mathf.CeilToInt((float) source0.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// Two binary images store in R and G channels
        /// </summary>
        /// <param name="source0">1st Source Image</param>
        /// <param name="source1">2nd Source Image</param>
        /// <returns></returns>
        public static RenderTexture Append(this RenderTexture source0, RenderTexture source1)
        {
            if (source1.width * source1.height == 0) return source0;

            var destination = new RenderTexture(source0.width, source0.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_appendKernelIndex, "Source", source0);
            _shader.SetTexture(_appendKernelIndex, "Source1", source1);
            _shader.SetTexture(_appendKernelIndex, "Destination", destination);

            _shader.Dispatch(_appendKernelIndex, Mathf.CeilToInt((float) source0.width / 32),
                Mathf.CeilToInt((float) source0.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// Change the resolution
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <param name="newResolution">New Resolution(X stores width, Y stores height)</param>
        /// <returns></returns>
        public static RenderTexture FixResolution(this RenderTexture source, Vector2Int newResolution)
        {
            var destination = new RenderTexture(newResolution.x, newResolution.y, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_resolutionKernelIndex, "Source", source);
            _shader.SetTexture(_resolutionKernelIndex, "Destination", destination);
            _shader.SetInts("resolution", newResolution.x, newResolution.y);
            _shader.SetInts("dimensions", source.width, source.height);

            _shader.Dispatch(_resolutionKernelIndex, Mathf.CeilToInt((float) newResolution.x / 32),
                Mathf.CeilToInt((float) newResolution.y / 32), 1);
            return destination;
        }

        /// <summary>
        /// Change the resolution
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <param name="newResolution">New Resolution(X stores width, Y stores height)</param>
        /// <returns></returns>
        public static RenderTexture FixResolution(this RenderTexture source, Vector2 newResolution)
        {
            return FixResolution(source, new Vector2Int((int) newResolution.x, (int) newResolution.y));
        }

        /// <summary>
        /// 3x3 Threshold Filter
        /// </summary>
        /// <remarks>
        /// For a binary image, 1 is returned when the value of 1 in 3x3 pixels is greater than or equal to the threshold value.
        /// </remarks>
        /// <param name="source">Source Image</param>
        /// <param name="threshold">Threshold</param>
        /// <returns></returns>
        public static RenderTexture ThresholdFilter3X3(this RenderTexture source, int threshold)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.R8)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_threshold3X3KernelIndex, "Source", source);
            _shader.SetTexture(_threshold3X3KernelIndex, "Destination", destination);
            _shader.SetInts("Threshold", threshold);

            _shader.Dispatch(_threshold3X3KernelIndex,
                Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32),
                1);
            return destination;
        }

        /// <summary>
        /// 5x5 Threshold Filter
        /// </summary>
        /// <remarks>
        /// For a binary image, 1 is returned when the value of 1 in 5x5 pixels is greater than or equal to the threshold value.
        /// </remarks>
        /// <param name="source">Source Image</param>
        /// <param name="threshold">Threshold</param>
        /// <returns></returns>
        public static RenderTexture ThresholdFilter5X5(this RenderTexture source, int threshold)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.R8)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_threshold5X5KernelIndex, "Source", source);
            _shader.SetTexture(_threshold5X5KernelIndex, "Destination", destination);
            _shader.SetInts("Threshold", threshold);

            _shader.Dispatch(_threshold5X5KernelIndex,
                Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32),
                1);
            return destination;
        }

        /// <summary>
        /// Changing the value of Alpha
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <param name="value">Whether to make it transparent or not</param>
        /// <returns></returns>
        public static RenderTexture TransAlpha(this RenderTexture source, bool value)
        {
            var destination = new RenderTexture(source.width, source.height, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_transAlphaKernelIndex, "Source", source);
            _shader.SetTexture(_transAlphaKernelIndex, "Destination", destination);
            _shader.SetBool("fillAlpha", value);

            _shader.Dispatch(_transAlphaKernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// Create black(blank) image
        /// </summary>
        /// <param name="dimension">Resolution</param>
        /// <returns></returns>
        public static RenderTexture Create(Vector2Int dimension)
        {
            var destination = new RenderTexture(dimension.x, dimension.y, 0, RenderTextureFormat.ARGBFloat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_createKernelIndex, "Destination", destination);

            _shader.Dispatch(_createKernelIndex, Mathf.CeilToInt((float) dimension.x / 32),
                Mathf.CeilToInt((float) dimension.y / 32), 1);
            return destination;
        }

        /// <summary>
        /// Simply add the two images
        /// </summary>
        /// <param name="source">1st Source Image</param>
        /// <param name="source1">2nd Source Image</param>
        /// <returns></returns>
        public static RenderTexture Add(this RenderTexture source, RenderTexture source1)
        {
            var destination = new RenderTexture(source.width, source.height, 0, source.graphicsFormat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_addKernelIndex, "Source", source);
            _shader.SetTexture(_addKernelIndex, "Source1", source1);
            _shader.SetTexture(_addKernelIndex, "Destination", destination);

            _shader.Dispatch(_addKernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// Replaces the pixels of the 1st image when the alpha of the 2nd image is greater than or equal 0.5
        /// </summary>
        /// <param name="source">1st Source Image</param>
        /// <param name="source1">2nd Source Image</param>
        /// <returns></returns>
        public static RenderTexture Override(this RenderTexture source, RenderTexture source1)
        {
            var destination = new RenderTexture(source.width, source.height, 0, source.graphicsFormat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_overrideKernelIndex, "Source", source);
            _shader.SetTexture(_overrideKernelIndex, "Source1", source1);
            _shader.SetTexture(_overrideKernelIndex, "Destination", destination);

            _shader.Dispatch(_overrideKernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// When the r-channel of a pixel is 0.5 or greater, the pixel is filled with the specified color
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <param name="colorChannel">Destination Color</param>
        /// <returns></returns>
        public static RenderTexture MoveChannel(this RenderTexture source, Color colorChannel)
        {
            var destination = new RenderTexture(source.width, source.height, 0, source.graphicsFormat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_moveChannelKernelIndex, "Source", source);
            _shader.SetFloats("ColorChannel", colorChannel.r, colorChannel.g, colorChannel.b, colorChannel.a);
            _shader.SetTexture(_moveChannelKernelIndex, "Destination", destination);

            _shader.Dispatch(_moveChannelKernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }

        /// <summary>
        /// When a reference image has more than 0.5, the pixel is filled with 0
        /// </summary>
        /// <param name="source">Source Image</param>
        /// <param name="reference">Reference Image</param>
        /// <returns></returns>
        public static RenderTexture Except(this RenderTexture source, RenderTexture reference)
        {
            var destination = new RenderTexture(source.width, source.height, 0, source.graphicsFormat)
            {
                enableRandomWrite = true
            };
            destination.Create();
            _shader.SetTexture(_exceptKernelIndex, "Source", source);
            _shader.SetTexture(_exceptKernelIndex, "Source1", reference);
            _shader.SetTexture(_exceptKernelIndex, "Destination", destination);

            _shader.Dispatch(_exceptKernelIndex, Mathf.CeilToInt((float) source.width / 32),
                Mathf.CeilToInt((float) source.height / 32), 1);
            return destination;
        }
        
        
        /// <summary>
        /// Extracting edges by applying a Sobel filter
        /// </summary>
        /// <param name="texture">Source Image</param>
        /// <param name="threshold">Threshold</param>
        /// <returns></returns>
        public static RenderTexture ExtractEdge(this RenderTexture texture, float threshold = 0.15f)
        {
            var colorRenderTexture = new RenderTexture(texture.width, texture.height, 0, RenderTextureFormat.R16)
            {
                enableRandomWrite = true
            };
            colorRenderTexture.Create();
            
            _shader.SetTexture(_edgeKernelIndex, "Source", texture);
            _shader.SetTexture(_edgeKernelIndex, "Destination1Channel", colorRenderTexture);
            _shader.SetFloat("EdgeThreshold", threshold);

            _shader.Dispatch(_edgeKernelIndex,
                Mathf.CeilToInt((float) colorRenderTexture.width / 32),
                Mathf.CeilToInt((float) colorRenderTexture.height / 32), 1);

            return colorRenderTexture;
        }
    }
}