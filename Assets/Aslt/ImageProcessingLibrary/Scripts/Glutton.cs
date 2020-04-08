using UnityEngine;

namespace Aslt.IMLibary
{
    /// <summary>
    /// Releases unnecessary memory at regular intervals
    /// </summary>
    [DefaultExecutionOrder(100)]
    public class Glutton : MonoBehaviour
    {
        private static int _count;

        [SerializeField] private int refreshRatio;
        
        private void Update()
        {
            ++_count;
            if (_count > refreshRatio)
            {
                _count = 0;
                Resources.UnloadUnusedAssets();
            }
        }
    }
}