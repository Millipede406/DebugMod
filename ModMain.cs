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

            // Loading preferences
            Console.Log(l, "Loading preferences...");
            ModPreferences.LoadPreferences();

            // Initializing GUI
            Console.Log(l, "Initializing GUI...");
            InitializeDebugGUI();

            // Initializing features
            Console.Log(l, "Initializing Features...");
            Features.FeatureManager.Initialize();

            Console.Log(l, "Initialization Complete!");
        }

        private void InitializeDebugGUI()
        {
            Console.LogType l = Console.LogType.Init_GUI;

            // Making the DebugGUI method recieve GUI updates
            Console.Log(l, "Subscribing GUI");
            MelonEvents.OnGUI.Subscribe(GUI, 100);

            Console.Log(l, "Initializing Menus");
            // Initializing individual menus
            Console.Log(l, "Initializing DebugMenu");
            DebugMenu.InitializeMenu();

            Console.Log(l, "Initializing CheatsMenu");
            CheatsMenu.InitializeMenu();

            Console.Log(l, "Initializing VisualMenu");
            VisualMenu.InitializeMenu();

            Console.Log(l, "Initializing ISMSettingsMenu");
            ISMSettingsMenu.InitializeMenu();

            Console.Log(l, "GUI Initialization Complete!");
        }
        #endregion

        #region Update
        public override void OnUpdate()
        {

            if(PatchQuest.Game.State != PatchQuest.GameState.NONE)
            {
                // We don't want to run any of the features while not ingame, because it can cause problems
                // So instead we just return out if we are not ingame
                return;
            }

            // Toggles active state of DebugMenu when F6 is pressed
            if (Input.GetKeyDown(ModPreferences.preferences_main_guiHotkey))
            {
                Console.LogType l = Console.LogType.Main;

                DebugMenu.IsActive = !DebugMenu.IsActive;

                Console.Log(l, DebugMenu.IsActive ? "Showing Debug Menu" : "Hid Debug Menu");
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