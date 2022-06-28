using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;


public class MobileFFmpegIOS : MonoBehaviour
{
#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern int _execute(string command);

    [DllImport("__Internal")]
    private static extern void _cancel();
#endif

    /**
     * Synchronously executes FFmpeg command provided. Space character is used to split command
     * into arguments.
     *
     * @param command FFmpeg command
     * @return zero on successful execution, 255 on user cancel and non-zero on error
     */
    public static int Execute(string command)
    {
        int result = -1;
#if UNITY_IOS
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            result = _execute(command);
        }
#endif

        return result;
    }

    /**
     * Cancels an ongoing operation.
     *
     * This function does not wait for termination to complete and returns immediately.
     */
    public static void Cancel()
    {
#if UNITY_IOS
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _cancel();
        }
#endif
    }
}
