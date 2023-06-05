using DebugMod.Features.Visual;
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

            // Fast Travel
            if (CheatsMenu.FastTravel)
            {
                // Making both players enter the ballooning state, allowing them to fast travel.
                PatchQuest.Player.P1.SetBallooning(true);
                PatchQuest.Player.P2.SetBallooning(true);
            }

            // Disable Fog
            if (VisualMenu.DisableFog)
            {
                // Disabling fog
                DisableFog.Update();
            }
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
        }
    }
}