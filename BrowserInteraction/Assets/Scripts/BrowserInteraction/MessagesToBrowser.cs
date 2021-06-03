using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BrowserInteraction
{
    public class MessagesToBrowser : MonoBehaviour
    {
        private static MessagesToBrowser _instance = null;

        public TMP_InputField inputString;
        public TMP_InputField inputNumber;
        public TMP_InputField inputJson;

        public Button sendString;
        public Button sendNumber;

        public Button sendJson;

// #if (!UNITY_EDITOR && UNITY_WEBGL)
//  #pragma warning disable CA2101
        [DllImport("__Internal")]
        private static extern void OnModelLoaded();

        [DllImport("__Internal")]
        private static extern void SendString(string value);

        [DllImport("__Internal")]
        private static extern void SendNumber(double value);

        [DllImport("__Internal")]
        private static extern void SendJson(string value);
//  #pragma warning restore CA2101
// #endif

        private void Awake()
        {
            sendString.onClick.AddListener(SendString);
            sendNumber.onClick.AddListener(SendNumber);
            sendJson.onClick.AddListener(SendJson);
        }

        private void Start()
        {
            if (_instance == null)
                _instance = this;
            else if (_instance == this)
                Destroy(gameObject);

// #if (!UNITY_EDITOR && UNITY_WEBGL)
//  #pragma warning disable CA2101
            Debug.LogWarning("C# communicate to browser");
            OnModelLoaded();

            SendString();
            SendNumber();
            SendJson();

//  #pragma warning restore CA2101
// #endif
        }

        private void SendString()
        {
            SendString(inputString.text);
        }

        private void SendNumber()
        {
            var isParsed = double.TryParse(inputNumber.text, out var value);
            SendNumber(value);
        }

        private void SendJson()
        {
            SendJson(inputJson.text);
        }
//  #pragma warning restore CA2101
// #endif
    }
}