using UnityEngine;
using UnityEngine.UI;
using UnhollowerRuntimeLib;
using UnityEngine.SceneManagement;

namespace DebugMod
{
    public static class ImprovedScreenshotMode
    {
        public static GameObject Player;
        public static GameObject Crosshair;

        public static void EnableIsm()
        {
            if (ModMain.ism_hidePlayer)
            {
                if (GetPlayerReference())
                {
                    Player.transform.localScale = Vector3.zero;
                }
            }

            if (ModMain.ism_hideCursor)
            {
                if (GetCursorReference())
                {
                    Crosshair.GetComponent<Image>().enabled = false;
                }
            }

            if (ModMain.ism_hideShots)
            {
                SetShots(true);
            }
        }

        public static void DisableIsm()
        {
            if (ModMain.ism_hidePlayer)
            {
                if (GetPlayerReference())
                {
                    Player.transform.localScale = Vector3.one;
                }
            }

            if (ModMain.ism_hideCursor)
            {
                if (GetCursorReference())
                {
                    Crosshair.GetComponent<Image>().enabled = true;
                }
            }

            if (ModMain.ism_hideShots)
            {
                SetShots(false);
            }
        }

        static void SetShots(bool hidden)
        {
            Il2CppSystem.Type gameobjType = Il2CppType.Of<GameObject>();

            foreach (UnityEngine.Object obj in Resources.FindObjectsOfTypeAll(Il2CppType.Of<UnityEngine.GameObject>()))
            {
                DebugConsole.Log($"checking if {obj.name} is a Shot");
                if (obj.name == "Shot")
                {
                    DebugConsole.Log($"{obj.name} is a Shot, changing visibility");
                    if (hidden)
                    {
                        obj.Cast<GameObject>().GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                    }
                    else
                    {
                        obj.Cast<GameObject>().GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                    }
                }
            }
        }
        static bool GetPlayerReference()
        {
            if (GameObject.Find("Patch/Positioner/Player1") == null)
                return false;

            Player = GameObject.Find("Patch/Positioner/Player1");
            return true;
        }
        static bool GetCursorReference()
        {
            if (GameObject.Find("Letterbox Canvas/Crosshair") == null)
                return false;

            Crosshair = GameObject.Find("Letterbox Canvas/Crosshair");
            return true;
        }
    }
}
