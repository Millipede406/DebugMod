using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using MelonLoader;
using HarmonyLib;
using PatchQuest;
using Il2CppMono;
using Il2CppMicrosoft;
using Il2CppSystem;
using UnhollowerRuntimeLib;
using UnhollowerBaseLib;
using UnityEngine.SceneManagement;

namespace DebugMod
{
    public static class ModPreferences
    {
        //Main
        public static bool preferences_main_disableFog;
        public static bool preferences_main_improvedScreenshotMode;
    }

    public class ModMain : MelonMod
    {
        #region Preferences

        MelonPreferences_Category preferences_main;
        MelonPreferences_Entry<bool> preferences_main_disableFog;
        MelonPreferences_Entry<bool> preferences_main_improvedScreenshotMode;

        #endregion
        public GameObject Player;
        public GameObject Crosshair;


        bool hideShots;

        bool improvedScreenshotMode;

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            preferences_main = MelonPreferences.CreateCategory("Main");
            preferences_main.SetFilePath("UserData/DebugMod.cfg");


            preferences_main_disableFog = preferences_main.CreateEntry<bool>("Disable Fog", false);
            preferences_main_improvedScreenshotMode = preferences_main.CreateEntry<bool>("Enable Hide Player controls", false);


            ModPreferences.preferences_main_disableFog = preferences_main_disableFog.Value;
            ModPreferences.preferences_main_improvedScreenshotMode = preferences_main_improvedScreenshotMode.Value;

            preferences_main.SaveToFile();

            LoggerInstance.Msg("Loading preferences:");
            LoggerInstance.Msg($"DebugMod.ModMain_preferences_main_disableFog: {preferences_main_disableFog.Value}");
            LoggerInstance.Msg($"DebugMod.ModMain_preferences_main_improvedScreenshotMode: {preferences_main_improvedScreenshotMode.Value}");
            LoggerInstance.Msg($"Preferences Loading finished");

        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Loaded Scene: {sceneName} ({buildIndex})");
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            #region Controls

            if (Input.GetKeyDown(KeyCode.F6))
            {
                improvedScreenshotMode = !improvedScreenshotMode;

                if (improvedScreenshotMode)
                {
                    if (GetPlayerReference())
                    {
                        Player.transform.localScale = Vector3.zero;
                    }

                    if (GetCursorReference())
                    {
                        Crosshair.GetComponent<Image>().enabled = false;
                    }
                    SetShots(true);

                }
                else
                {
                    if (GetPlayerReference())
                    {
                        Player.transform.localScale = Vector3.one;
                    }

                    if (GetCursorReference())
                    {
                        Crosshair.GetComponent<Image>().enabled = true;
                    }

                    SetShots(false);
                }
            }

            if (preferences_main_improvedScreenshotMode.Value)
            {
                
            }
            
            #endregion

            #region Checks

            if (ModPreferences.preferences_main_disableFog)
            {
                Darkness.Intensity = 0f;
            }

            #endregion

        }


        //scene.GetRootGameObjects - error message
        //  System.NotSupportedException: Method unstripping failed

        //GameObject.FindObjectsOfType and GameObject.FindGameObjectsOfTypeAll
        //  

        //removetrees


        public void SetShots(bool hidden)
        {
            Il2CppSystem.Type gameobjType = Il2CppType.Of<GameObject>();

            Scene scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();

            foreach (UnityEngine.Object obj in Resources.FindObjectsOfTypeAll(Il2CppType.Of<UnityEngine.GameObject>()))
            {
                LoggerInstance.Msg($"checking if {obj.name} is a Shot");
                if (obj.name == "Shot")
                {
                    LoggerInstance.Msg($"{obj.name} is a Shot, changing visibility");
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

        bool GetPlayerReference()
        {
            if (GameObject.Find("Patch/Positioner/Player1") == null)
                return false;

            Player = GameObject.Find("Patch/Positioner/Player1");
            return true;
        }
        bool GetCursorReference()
        {
            if (GameObject.Find("Letterbox Canvas/Crosshair") == null)
                return false;

            Crosshair = GameObject.Find("Letterbox Canvas/Crosshair");
            return true;
        }
        
    }

}
