using UnityEngine;

public class UnityActivityIndicator
{
    public UnityActivityIndicator()
    {
    }

    public static void ShowActivityIndicator()
    {
    #if UNITY_IPHONE
        Handheld.SetActivityIndicatorStyle(iOS.ActivityIndicatorStyle.Gray);
    #elif UNITY_ANDROID
        Handheld.SetActivityIndicatorStyle(AndroidActivityIndicatorStyle.Large);
    #endif

        Handheld.StartActivityIndicator();

    #if UNITY_ANDROID
        // This must be called after Handheld.StartActivityIndicator() because that 
        // method instantiates the ProgressBar widget whose layout params we are modifying.
        UnityActivityIndicator.MoveToCenterOfScreen(); 
    #endif
    }

    public static void HideActivityIndicator()
    {
        Handheld.StopActivityIndicator();
    }

    public static void MoveToCenterOfScreen()
    {
    #if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android)
        {
            using (var javaUnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                using (var currentActivity = javaUnityPlayer.GetStatic<AndroidJavaObject>("currentActivity"))
                {
                    using (var androidActivityIndicator = new AndroidJavaObject("com.nickschipano.unityandroidactivityindicator.UnityActivityIndicator", currentActivity))
                    {
                        androidActivityIndicator.Call("MoveToCenterOfScreen");
                    }
                }
            }
        }
    #endif
    }
}