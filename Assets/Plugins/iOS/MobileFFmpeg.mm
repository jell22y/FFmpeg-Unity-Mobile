//In unity, You'd place this file in your "Assets>plugins>ios" folder
//Objective-C Code
#import <mobileffmpeg/MobileFFmpeg.h>

extern "C"
{
    /**
    * Synchronously executes FFmpeg command provided. Space character is used to split command
    * into arguments.
    *
    * @param command FFmpeg command
    * @return zero on successful execution, 255 on user cancel and non-zero on error
    */
    int _execute(const char* command)
    {
        return [MobileFFmpeg execute: @(command)];
    }
    
    /**
    * Cancels an ongoing operation.
    *
    * This function does not wait for termination to complete and returns immediately.
    */
    void _cancel()
    {
        [MobileFFmpeg cancel];
    }
}
