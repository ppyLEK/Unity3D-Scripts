using UnityEngine;

public namespace ppyLEK.Util
{
    public class CommandLineArgs : MonoBehaviour
    {
        void Start()
        {
            string[] args = System.Environment.GetCommandLineArgs();

            foreach (string arg in args)
            {
                Debug.Log(arg);
            }

            // Parse command line arguments here
            // if (args.Contains("-offline"))
            // {
            //     Debug.Log("Offline mode enabled");
            // }
            // if (args.Contains("-fullscreen"))
            // {
            //     Screen.fullScreen = true;
            // }
        }
    }
}