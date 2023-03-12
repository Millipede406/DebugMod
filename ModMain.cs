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
        bool ismSettings;

        public static bool ism_hidePlayer;
        public static bool ism_hideCursor;
        public static bool ism_hideShots;

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
                    
                }

                
            }

            if (invulnerability)
            {
                PatchQuest.Player.P1.GrantImmunity(1f);
                PatchQuest.Player.P2.GrantImmunity(1f);
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
            InvulnerabilityButton();
            ISMButton();
            if (ISMSettingsButton())
            {
                ISMSettingsGUI();
            }

        }

        public void InvulnerabilityButton()
        {
            string invText = "";
            if (invulnerability)
            {
                invText = "Disable Invulnerability";
            }
            else
            {
                invText = "Enable Invulnerability";
            }
            if (GUI.Button(new Rect(10, 30, 280, 20), invText))
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
        }
        public void ISMButton()
        {
            string text;
            if (improvedScreenshotMode)
            {
                text = "Disable Improved Screenshot Mode";
            }
            else
            {
                text = "Enable Improved Screenshot Mode";
            }
            if (GUI.Button(new Rect(10, 60, 280, 20), text))
            {
                improvedScreenshotMode = !improvedScreenshotMode;
                if (improvedScreenshotMode)
                {
                    DebugConsole.Log("Improved Screenshot Mode Enabled");
                    ImprovedScreenshotMode.EnableIsm();
                }
                else
                {
                    DebugConsole.Log("Improved Screenshot Mode Disabled");
                    ImprovedScreenshotMode.DisableIsm();
                }
            }
        }
        public bool ISMSettingsButton()
        {
            string text;
            if (ismSettings)
            {
                text = "Hide ISM Settings";
            }
            else
            {
                text = "Show ISM Settings";
            }
            if (GUI.Button(new Rect(10, 90, 280, 20), text))
            {
                ismSettings = !ismSettings;
                if (ismSettings)
                {
                    DebugConsole.Log("Showing ISM Settings");
                }
                else
                {
                    DebugConsole.Log("Hiding ISM Settings");
                }
            }
            return ismSettings;
        }
        public void ISMSettingsGUI()
        {
            GUI.Box(new Rect(310, 0, 300, 150), "ISM Settings");
            ism_hidePlayer = GUI.Toggle(new Rect(320, 30, 280, 20), ism_hidePlayer, "Hide Player");
            ism_hideCursor = GUI.Toggle(new Rect(320, 60, 280, 20), ism_hideCursor, "Hide Cursor");
            ism_hideShots = GUI.Toggle(new Rect(320, 90, 280, 20), ism_hideShots, "Hide Shots* (Shots can still damage you)");
            GUI.Label(new Rect(320, 120, 280, 20), "*This option can cause lag");
        }

    }
}
