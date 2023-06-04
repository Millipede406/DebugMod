using DebugMod.Features.Tools;
using DebugMod.GUI;
using MelonLoader;
using ModdingUtilities;
using UnityEngine;

namespace DebugMod
{
    public class ModMain : PatchQuestMod
    {
        public static ModMain Instance;

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            Instance = this;

            ModPreferences.LoadPreferences();

            InitializeDebugGUI();

        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Loaded Scene: {sceneName} ({buildIndex})");
        }
        public override void MainUpdate()
        {
            // Toggles active state of DebugMenu when F6 is pressed
            if (Input.GetKeyDown(KeyCode.F6))
            {
                DebugMenu.IsActive = !DebugMenu.IsActive;
            }

            // Random features that haven't been moved to different classes yet:

            // Invulnerability
            if (CheatsMenu.Invulnerability)
            {
                // Making both players invulnerable
                PatchQuest.Player.P1.GrantImmunity(1f);
                PatchQuest.Player.P2.GrantImmunity(1f);
            }

            // Infinite Damage
            if (CheatsMenu.InfiniteDamage)
            {
                // Setting stamina for both players to maximum possible value
                PatchQuest.Player.P1.Stamina = int.MaxValue;
                PatchQuest.Player.P2.Stamina = int.MaxValue;
            }

            // Disable Fog
            if (VisualMenu.DisableFog)
            {
                // Disabling fog
                DisableFog.Update();
            }
        }
        public static void DebugLog(string msg)
        {
            Instance.LoggerInstance.Msg(msg);
        }
        private void InitializeDebugGUI()
        {
            // Making the DebugGUI method recieve GUI updates
            MelonEvents.OnGUI.Subscribe(GUI, 100);

            // Initializing individual menus
            DebugMenu.InitializeMenu();

            CheatsMenu.InitializeMenu();

            VisualMenu.InitializeMenu();

            ISMSettingsMenu.InitializeMenu();
        }
        public void GUI()
        {
            if (!DebugMenu.IsActive)
                return;

            DebugMenu.DrawMenu();

            if (CheatsMenu.IsActive)
            {
                CheatsMenu.DrawMenu();
            }

            if (VisualMenu.IsActive)
            {
                VisualMenu.DrawMenu();
            }

            if (ISMSettingsMenu.IsActive)
            {
                ISMSettingsMenu.DrawMenu();
            }

            // Debug Menu
            // Enable and disable the separate category windows

            

            

            
        }
        void DebugWindow(int windowID)
        {


            /*
            InvulnerabilityButton(new Rect(10, 30, 280, 20));
            ISMButton(new Rect(10, 55, 185, 20));
            if (ISMSettingsButton(new Rect(200, 55, 90, 20)))
            {
                ISMSettingsGUI();
            }
            FogButton(new Rect(10, 80, 280, 20));
            InfStaminaButton(new Rect(10, 105, 280, 20));
            InfDamageButton(new Rect(10, 130, 280, 20));
            FastTravelButton(new Rect(10, 155, 280, 20));
            AllShinyButton(new Rect(10, 180, 280, 20));
            GUI.Label(new Rect(0, 205, 280, 20), "Press F6 to enable/disable this menu");
            UnityEngine.GUI.DragWindow();
            */

        }
        /*
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
                text = "Disable ISM";
            }
            else
            {
                text = "Enable ISM";
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
        public void InfDamageButton(Rect r)
        {
            string text;
            if (infDamage)
            {
                text = "Deactivate Infinite Damage";
            }
            else
            {
                text = "Activate Infinite Damage";
            }
            if (GUI.Button(r, text))
            {
                infDamage = !infDamage;
                if (infStamina)
                {
                    DebugConsole.Log("Activating Infinite Damage");
                }
                else
                {
                    DebugConsole.Log("Deactivating Infinite Damage");
                }
            }
        }
        public void FastTravelButton(Rect r)
        {
            if (GUI.Button(r, "Fast Travel"))
            {
                if(GameState == PatchQuest.GameState.QUESTING)
                {
                    PatchQuest.Player.P1.SetBallooning(true);
                    DebugConsole.Log($"Activated Fast Travel");
                }
                else
                {
                    LoggerInstance.Error($"Can't set fast travel: Player isn't on a quest.");
                }
            }
        }
        public void AllShinyButton(Rect r)
        {
            string text;
            if (!ShinyMode)
            {
                text = "Enable Shiny Mode";
            }
            else
            {
                text = "Disable Shiny Mode";
            }
            if(GUI.Button(r, text))
            {
                ShinyMode = !ShinyMode;
            }
        }
        */
    }
}
