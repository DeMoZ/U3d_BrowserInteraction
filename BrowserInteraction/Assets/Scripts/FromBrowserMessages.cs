using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FromBrowserMessages : MonoBehaviour
{
    private static FromBrowserMessages instance = null;

    [SerializeField] private Text text;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance == this)
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
        Debug.LogWarning($"BrowserInfo {value}");
    }
}