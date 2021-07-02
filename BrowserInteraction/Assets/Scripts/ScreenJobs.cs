using UnityEngine;
using UnityEngine.UI;

public class ScreenJobs : MonoBehaviour
{
    [SerializeField] private CanvasScaler canvasScaler = default;
    [SerializeField] private Vector2 desktopResolution = default;
    [SerializeField] private Vector2 tabletResolution = default;
    [SerializeField] private Vector2 phoneResolution = default;

    [SerializeField] private bool showOnScreen = false;
    [SerializeField] private Text infoField = default;

    void Start()
    {
#if UNITY_WEBGL
        var inch = ScreenInfo.ViewSize(out var os);
        var systemType = ScreenInfo.GetSystem(inch, os);

        switch (systemType)
        {
            case SystemTypes.Desktop:
                SetUiResolution(desktopResolution);
                break;
            case SystemTypes.Tablet:
                SetUiResolution(tabletResolution);
                break;
            default:
                SetUiResolution(phoneResolution);
                break;
        }

        var log = ScreenInfo.ToString(inch, os.ToString(), systemType.ToString());
        Debug.Log(log);

        if (showOnScreen)
            infoField.text = log;

        canvasScaler.gameObject.SetActive(enabled);
#endif
    }

    private void SetUiResolution(Vector2 resolution) =>
        canvasScaler.referenceResolution = resolution;
}