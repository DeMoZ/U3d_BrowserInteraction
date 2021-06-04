using UnityEngine;

namespace BrowserInteraction
{
    public class DataTypesMessagesFromBrowser : MonoBehaviour
    {
        private static DataTypesMessagesFromBrowser _instance = null;

        // [SerializeField] private Text text;
        // [SerializeField] private Text osInfo;
        private void Start()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance == this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void ReceiveString(string value)
        {
            Debug.Log($"Unity: ReceiveString {value}");
        }

        public void ReceiveNumber(double value)
        {
            Debug.Log($"Unity: ReceiveNumber {value}");
        }

        public void ReceiveJson(string value)
        {
            Debug.Log($"Unity: ReceiveJson {value}");
            var rez = JsonUtility.FromJson<Box>(value);
            
            Debug.Log($"json converted: name= {rez.name}; size= {rez.size}; things amount= {rez.things.Count}");
                // Debug.Log($"things[0]: name= {rez.things[0].name}; size = {rez.things[0].size}");
        }
        
        
    }
}