using UnityEngine;
using UnityEngine.UI;
using DebugMod.GUI;
using Il2CppSystem;
using MelonLoader;
using HarmonyLib;
using UnhollowerBaseLib;
using UnhollowerRuntimeLib;

namespace DebugMod.Features.Visual.ISM
{
    public static class ImprovedScreenshotMode
    {
        public static GameObject Player;
        public static GameObject Crosshair;

        public static void EnableIsm()
        {
            if (ISMSettingsMenu.HidePlayer)
            {
                if (GetPlayerReference())
                {
                    Player.transform.localScale = Vector3.zero;
                }
            }

            if (ISMSettingsMenu.HideCursor)
            {
                if (GetCursorReference())
                {
                    Crosshair.GetComponent<Image>().enabled = false;
                }
            }

            if (ISMSettingsMenu.HideShots)
            {
                SetShots(true);
            }
        }

        public static void DisableIsm()
        {
            if (ISMSettingsMenu.HidePlayer)
            {
                if (GetPlayerReference())
                {
                    Player.transform.localScale = Vector3.one;
                }
            }

            if (ISMSettingsMenu.HideCursor)
            {
                if (GetCursorReference())
                {
                    Crosshair.GetComponent<Image>().enabled = true;
                }
            }

            if (ISMSettingsMenu.HideShots)
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
