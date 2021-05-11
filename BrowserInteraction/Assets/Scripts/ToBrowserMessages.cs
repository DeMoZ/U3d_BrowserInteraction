using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using UnityEngine;

public class ToBrowserMessages : MonoBehaviour
{
    private static ToBrowserMessages instance = null;
    
    [SerializeField] private string helloValue = string.Empty;
#if (!UNITY_EDITOR && UNITY_WEBGL)
 #pragma warning disable CA2101
         [DllImport("__Internal")]
         private static extern string OnModelLoaded(string value);
         
         [DllImport("__Internal")]
         private static extern string ToBrowserInfo();
 #pragma warning restore CA2101
#endif

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this) 
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        
#if (!UNITY_EDITOR && UNITY_WEBGL)
 #pragma warning disable CA2101
         Debug.LogWarning("C# communicate to browser");
         OnModelLoaded(helloValue);
        
         ToBrowserInfo();
 #pragma warning restore CA2101
#endif
    }
}

// using UnityEngine;
// 
// public class ToBrowserMessages : MonoBehaviour
// {
//     [SerializeField] private string helloValue = string.Empty;
// 
//     private void Start()
//     {
//         var s = Application.dataPath.Split("/"[0]);
//         helloValue = s[s.Length - 2];
//         Application.ExternalCall("OnModelLoaded", helloValue);
//     }
// }