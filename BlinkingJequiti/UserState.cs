using System.Runtime.InteropServices;

namespace BlinkingJequiti;

public partial class UserState
{
    public static bool IsConnected => UserInactiveTime() < 5;
    private static int UserInactiveTime()
    {
        uint idleTicks = 0;
        LASTINPUTINFO lastInputInfo = new();
        lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);
        lastInputInfo.dwTime = 0;

        if (GetLastInputInfo(ref lastInputInfo))
        {
            idleTicks = (uint)Environment.TickCount - lastInputInfo.dwTime;
        }

        uint idleSeconds = idleTicks / 1000;

        return (int)idleSeconds;
    }

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static partial bool GetLastInputInfo(ref LASTINPUTINFO plii);
    private struct LASTINPUTINFO
    {
        public uint cbSize;
        public uint dwTime;
    }
}
