using System.Text;
using UnityEngine;

public enum OsTypes
{
    Other,
    Windows,
    Mac,
    Android,
    Ios
}

public enum SystemTypes
{
    Desktop,
    Tablet,
    Phone
}

public static class ScreenInfo
{
    public static string ToString(float inch, string os, string systemType)
    {
        var strBuild = new StringBuilder();
        strBuild.AppendLine(os);
        strBuild.AppendLine(inch.ToString());
        strBuild.AppendLine(Screen.dpi.ToString());
        strBuild.AppendLine(Screen.width + "x" + Screen.height);
        strBuild.AppendLine(systemType);
            
        strBuild.AppendLine(SystemInfo.operatingSystem);
        strBuild.AppendLine("UNITY_WEBGL");
        return strBuild.ToString();
    }

    public static float ViewSize() =>
        ViewSize(out var os);

    public static float ViewSize(out OsTypes os)
    {
        float inch = Screen.width * Screen.width + Screen.height * Screen.height;
        inch = Mathf.Sqrt(inch);
        os = GetOs();

        if (os == OsTypes.Android)
            inch /= (2 * Screen.dpi);
        if (os == OsTypes.Ios)
            inch /= (3 * Screen.dpi);
        else
            inch /= Screen.dpi;

        return inch;
    }

    public static OsTypes GetOs()
    {
        var result = OsTypes.Other;
        var systemName = SystemInfo.operatingSystem.Split(' ')[0];
        // Windows ...  / Mac ... / iOS ... / Android ... / Other
        switch (systemName)
        {
            case "Windows":
                result = OsTypes.Windows;
                break;
            case "Mac":
                result = OsTypes.Mac;
                break;
            case "iOS":
                result = OsTypes.Ios;
                break;
            case "Android":
                result = OsTypes.Android;
                break;
        }

        return result;
    }

    public static SystemTypes GetSystem(float inch, OsTypes os)
    {
        var result = SystemTypes.Desktop;
        switch (os)
        {
            case OsTypes.Mac:
            case OsTypes.Windows:
            case OsTypes.Other:
                result = (inch < 13) ? SystemTypes.Tablet : SystemTypes.Desktop;
                break;
            case OsTypes.Ios:
            case OsTypes.Android:
                result = (inch < 8) ? SystemTypes.Phone : SystemTypes.Tablet;
                break;
        }

        return result;
    }
}