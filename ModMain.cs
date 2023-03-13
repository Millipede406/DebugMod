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

        public static bool ism_hidePlayer = true;
        public static bool ism_hideCursor = true;
        public static bool ism_hideShots = false;

        public static bool hideFog = false;
        public static bool infStamina = false;

        public static bool DebugGUI_isActive = true;

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

            if (Input.GetKeyDown(KeyCode.F6))
                DebugGUI_isActive = !DebugGUI_isActive;

            if (invulnerability)
            {
                PatchQuest.Player.P1.GrantImmunity(1f);
                PatchQuest.Player.P2.GrantImmunity(1f);
            }
            if (hideFog)
            {
                DisableFog.Update();
            }
            if (infStamina)
            {
                PatchQuest.Player.P1.Stamina = int.MaxValue;
                PatchQuest.Player.P2.Stamina = int.MaxValue;
            }

        }    
        public static void DebugLog(string msg)
        {
            Instance.LoggerInstance.Msg(msg);
        }
        public void DebugGUI()
        {
            if (!DebugGUI_isActive)
                return;
            GUI.Box(new Rect(0, 0, 300, 180), "Debug Menu");
            InvulnerabilityButton(new Rect(10, 30, 280, 20));
            ISMButton(new Rect(10, 55, 280, 20));
            if (ISMSettingsButton(new Rect(10, 80, 280, 20)))
            {
                ISMSettingsGUI();
            }
            FogButton(new Rect(10, 105, 280, 20));
            InfStaminaButton(new Rect(10, 130, 280, 20));
            GUI.Label(new Rect(0, 150, 280, 20), "Press F6 to enable/disable this menu");

        }

        public void InvulnerabilityButton(Rect r)
        {
            string invText;
            if (invulnerability)
            {
                invText = "Disable Invulnerability";
            }
            else
            {
                invText = "Enable Invulnerability";
            }
            if (GUI.Button(r, invText))
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
        public void ISMButton(Rect r)
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
            if (GUI.Button(r, text))
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
        public bool ISMSettingsButton(Rect r)
        {
            if (GUI.Button(r, "Settings"))
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
        public void FogButton(Rect r)
        {
            string text;
            if (hideFog)
            {
                text = "Enable Fog";
            }
            else
            {
                text = "Disable Fog";
            }
            if (GUI.Button(r, text))
            {
                hideFog = !hideFog;
                if (hideFog)
                {
                    DebugConsole.Log("Fog Enabled");
                }
                else
                {
                    DebugConsole.Log("Fog Disabled");
                }
            }
        }
        public void InfStaminaButton(Rect r)
        {
            string text;
            if (infStamina)
            {
                text = "Deactivate Infinite Stamina";
            }
            else
            {
                text = "Activate Infinite Stamina";
            }
            if (GUI.Button(r, text))
            {
                infStamina = !infStamina;
                if (infStamina)
                {
                    DebugConsole.Log("Activating Infinite Stamina");
                }
                else
                {
                    DebugConsole.Log("Deactivating Infinite Stamina");
                }
            }
        }

    }
}
