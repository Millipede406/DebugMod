using DebugMod.Features.Visual;
using DebugMod.GUI;
using MelonLoader;
using UnityEngine;

namespace DebugMod
{
    public class ModMain : MelonMod
    {
        public static ModMain Instance;

        #region Initialization
        public override void OnInitializeMelon()
        {
            Console.LogType l = Console.LogType.Init_Main;
            Console.Log(l, "Initializing...");

            // Initializing singleton
            Instance = this;

            Console.Log(l, "Loading preferences...");
            // Loading preferences
            ModPreferences.LoadPreferences();

            Console.Log(l, "Initializing GUI...");
            // Initializing GUI
            InitializeDebugGUI();

            Console.Log(l, "Initializing Features...");
            // Initializing features
            Features.FeatureManager.Initialize();

            Console.Log(l, "Initialization Complete!");
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
        #endregion

        #region Update
        public void Update()
        {
            if(PatchQuest.Game.State != PatchQuest.GameState.NONE)
            {
                // We don't want to run any of the features while not ingame, because it can cause problems
                // So instead we just return out if we are not ingame
                return;
            }

            // Toggles active state of DebugMenu when F6 is pressed
            if (Input.GetKeyDown(KeyCode.F6))
            {
                DebugMenu.IsActive = !DebugMenu.IsActive;
            }

            // Updating all of the features
            Features.FeatureManager.Update();
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
        #endregion
    }
}