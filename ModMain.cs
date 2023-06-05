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
            // Initializing singleton
            Instance = this;

            // Loading preferences
            ModPreferences.LoadPreferences();

            // Initializing GUI
            InitializeDebugGUI();

            // Initializing features
            Features.FeatureManager.Initialize();
        }

        public override void MainUpdate()
        {
            // Toggles active state of DebugMenu when F6 is pressed
            if (Input.GetKeyDown(KeyCode.F6))
            {
                DebugMenu.IsActive = !DebugMenu.IsActive;
            }

            // Updating all of the features
            Features.FeatureManager.Update();
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
            // Drawing each menu

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