using System;
using System.Runtime.InteropServices;

class Program
{
    // Import the SetThreadExecutionState function from the Windows API
    [DllImport("kernel32.dll")]
    static extern uint SetThreadExecutionState(uint esFlags);

    const uint ES_CONTINUOUS = 0x80000000;
    const uint ES_SYSTEM_REQUIRED = 0x00000001;

    static bool isPreventingIdleState = true;

    static void Main(string[] args)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine(" --] Loading                                                                                                           ");
        Thread.Sleep(100);
        Console.WriteLine(" --] Idle Started                                                                                                      ");
        Console.WriteLine("                                                                                                                       ");
        Thread.Sleep(800);
        Console.ResetColor();
        Console.WriteLine(""); // DNE
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" --] Press any key to pause/resume preventing idle state");

        while (true)
        {
            Console.ReadKey();

            if (isPreventingIdleState)
            {
                // Allow the system to enter an idle state
                SetThreadExecutionState(ES_CONTINUOUS);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --] Idle state prevention paused");
            }
            else
            {
                // Prevent the system from entering an idle state
                SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(" --] Idle state prevention resumed");
            }

            isPreventingIdleState = !isPreventingIdleState;
        }
    }
}
