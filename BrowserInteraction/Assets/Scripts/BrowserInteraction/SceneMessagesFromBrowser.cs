using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BrowserInteraction
{
    public class SceneMessagesFromBrowser : MonoBehaviour
    {
        private static SceneMessagesFromBrowser _instance = null;

        [SerializeField] private Text text;
        [SerializeField] private Text osInfo;
        private void Start()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance == this)
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void SendString(string value)
        {
            text.text = value;
            Debug.LogWarning($"SendString {value}");
        }

        public void LoadSceneByNumber(string value)
        {
            text.text = value;
            Debug.LogWarning($"LoadSceneByNumber {value}");

            if (int.TryParse(value, out var parsed))
                SceneManager.LoadScene(parsed);
        }

        public void LoadSceneByName(string value)
        {
            text.text = value;
            Debug.LogWarning($"LoadSceneByName {value}");

            SceneManager.LoadScene(value);
        }

        public void FromBrowserInfo(string value)
        {
            osInfo.text = value;
            Debug.LogWarning($"BrowserInfo {value}");
        }
    }
}