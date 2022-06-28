using UnityEngine;

public class FFmpegWrapper
{
    private static int Execute(string command)
    {
#if UNITY_ANDROID
        using (AndroidJavaClass configClass = new AndroidJavaClass("com.arthenica.mobileffmpeg.Config"))
        {
            AndroidJavaObject paramVal = new AndroidJavaClass("com.arthenica.mobileffmpeg.Signal").GetStatic<AndroidJavaObject>("SIGXCPU");
            configClass.CallStatic("ignoreSignal", new object[] { paramVal });

            using (AndroidJavaClass ffmpeg = new AndroidJavaClass("com.arthenica.mobileffmpeg.FFmpeg"))
            {
                int code = ffmpeg.CallStatic<int>("execute", new object[] { command });
                return code;
            }
        }
#elif UNITY_IOS
        return MobileFFmpegIOS.Execute(command);
#else
        return 0;
#endif
    }

    private static int Cancel()
    {
#if UNITY_ANDROID
        using (AndroidJavaClass configClass = new AndroidJavaClass("com.arthenica.mobileffmpeg.Config"))
        {
            using (AndroidJavaClass ffmpeg = new AndroidJavaClass("com.arthenica.mobileffmpeg.FFmpeg"))
            {
                int code = ffmpeg.CallStatic<int>("cancel");
                return code;
            }
        }
#elif UNITY_IOS
        return MobileFFmpegIOS.Cancel();
#else
        return 0;
#endif
    }