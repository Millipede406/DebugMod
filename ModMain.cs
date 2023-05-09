using UnityEngine;
using MelonLoader;
using UnityEngine;
using ModdingUtilities;

namespace DebugMod
{
    public class ModMain : PatchQuestMod
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
        public static bool infDamage = false;

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
        public override void MainUpdate()
        {


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
        public override void QuestUpdate()
        {
            base.QuestUpdate();
            PatchQuest.ShinyChance.BASE_SHINY_CHANCE = 1f;
        }
        public static void DebugLog(string msg)
        {
            Instance.LoggerInstance.Msg(msg);
        }
        public void DebugGUI()
        {
            if (!DebugGUI_isActive)
                return;
            GUI.Box(new Rect(0, 0, 300, 205), "Debug Menu");
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
            GUI.Label(new Rect(0, 180, 280, 20), "Press F6 to enable/disable this menu");

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



    }
}
