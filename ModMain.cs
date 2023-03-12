using UnityEngine;
using MelonLoader;
using UnityEngine;

namespace DebugMod
{
    public class ModMain : MelonMod
    {
        public static ModMain Instance;

        bool improvedScreenshotMode;
        bool invulnerability;

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            Instance = this;

            ModPreferences.LoadPreferences();

            MelonEvents.OnGUI.Subscribe(DebugGUI, 100);
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Loaded Scene: {sceneName} ({buildIndex})");
        }
        public override void OnUpdate()
        {
            base.OnUpdate();

            //improved screenshot mode
            if (Input.GetKeyDown(KeyCode.F6) && ModPreferences.preferences_ism_enableIsm)
            {
                improvedScreenshotMode = !improvedScreenshotMode;

                if (improvedScreenshotMode)
                {
                    ImprovedScreenshotMode.EnableIsm();
                }
                else
                {
                    ImprovedScreenshotMode.DisableIsm();
                }
            } 
            //invulnerability
            if (ModPreferences.preferences_main_invulnerability)
            {
                if (Input.GetKeyDown(KeyCode.I))
                {
                    invulnerability = !invulnerability;
                    if (invulnerability)
                    {
                        DebugConsole.Log("Invulnerability Enabled");
                    }
                    else
                    {
                        DebugConsole.Log("Invulnerability Disabled");
                    }
                }

                if (invulnerability)
                {
                    PatchQuest.Player.P1.GrantImmunity(1f);
                    PatchQuest.Player.P2.GrantImmunity(1f);
                }
            }
            //disable fog
            if (ModPreferences.preferences_main_disableFog)
            {
                DisableFog.Update();
            }

        }    
        public static void DebugLog(string msg)
        {
            Instance.LoggerInstance.Msg(msg);
        }
        public void DebugGUI()
        {
            GUI.Box(new Rect(0, 0, 300, 500), "Debug Menu");
        }


    }
}
