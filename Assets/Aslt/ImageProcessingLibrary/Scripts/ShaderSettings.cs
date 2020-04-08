using UnityEngine;

namespace Aslt.IMLibary
{
    /// <summary>
    /// ComputeShaderおよびパラメータを格納する
    /// </summary>
    [RequireComponent(typeof(Glutton))]
    [DefaultExecutionOrder(-1000)]
    public class ShaderSettings : MonoBehaviour
    {
        private static ShaderSettings Instance;
        
        [Header("Filter Library")]
        public ComputeShader filterLibrary;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Initialize();
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
                Debug.LogWarning("[ShaderSetting] Deleted duplicate class.");
            }
        }

        private void Initialize()
        {
            FilterLibrary.Init(filterLibrary);
        }
    }
}
