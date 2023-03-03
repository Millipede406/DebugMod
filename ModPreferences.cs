using MelonLoader;

namespace DebugMod
{
    /// <summary>
    /// This class manages the config file for the mod. It loads all of the config in the LoadPreferences() function and has a number
    /// of variables that store the config so that any other script can easily access.
    /// </summary>
    public static class ModPreferences
    {
        //Main
        public static bool preferences_main_disableFog { get; private set; }
        //Improved Screenshot Mode
        public static bool preferences_ism_enableIsm { get; private set; }
        public static bool preferences_ism_HidePlayer { get; private set; }
        public static bool preferences_ism_HideCursor { get; private set; }
        public static bool preferences_ism_HideShots { get; private set; }


        static MelonPreferences_Category _preferences_main;
        static MelonPreferences_Entry<bool> _preferences_main_disableFog;


        static MelonPreferences_Category _preferences_ism;
        static MelonPreferences_Entry<bool> _preferences_ism_enableIsm;
        static MelonPreferences_Entry<bool> _preferences_ism_HidePlayer;
        static MelonPreferences_Entry<bool> _preferences_ism_HideCursor;
        static MelonPreferences_Entry<bool> _preferences_ism_HideShots;


        public static void LoadPreferences()
        {
            SetupConfigFile();
            StorePreferenceValues();
            LogPreferences();
        }

        #region Setup
        static void SetupConfigFile()
        {
            SetupConfigCategories();
            SetupConfigPreferences();
            _preferences_main.SaveToFile();
        }

        /// <summary>
        /// Sets up the categories that all the preferences will be sorted into
        /// </summary>
        static void SetupConfigCategories()
        {
            _preferences_main = MelonPreferences.CreateCategory("Main");
            _preferences_main.SetFilePath("UserData/DebugMod.cfg");

            _preferences_ism = MelonPreferences.CreateCategory("Improved Screenshot Mode");
            _preferences_ism.SetFilePath("UserData/DebugMod.cfg");
        }

        static void SetupConfigPreferences()
        {
            SetupMainCategory();
            SetupIsmCategory();
        }

        static void SetupMainCategory()
        {
            _preferences_main_disableFog = _preferences_main.CreateEntry<bool>("Disable Fog", false);
        }

        //improved screenshot mode
        static void SetupIsmCategory()
        {
            _preferences_ism_enableIsm = _preferences_ism.CreateEntry<bool>("Enable Improved Screenshot Mode", false);
            _preferences_ism_HidePlayer = _preferences_ism.CreateEntry<bool>("Hide Player", false);
            _preferences_ism_HideCursor = _preferences_ism.CreateEntry<bool>("Hide Cursor", false);
            _preferences_ism_HideShots = _preferences_ism.CreateEntry<bool>("Hide Shots", false);
        }

        #endregion
        #region Storage
        /// <summary>
        /// Gets the values for every item in the config file and stores them in public static variables
        /// These variables are marked as { get; private set; } which means that other classes can't change them, only this class.
        /// </summary>
        static void StorePreferenceValues()
        {
            StoreMainPreferences();
            StoreIsmPreferences();
        }

        static void StoreMainPreferences()
        {
            preferences_main_disableFog = _preferences_main_disableFog.Value;
        }

        static void StoreIsmPreferences()
        {
            preferences_ism_enableIsm = _preferences_ism_enableIsm.Value;
            preferences_ism_HidePlayer = _preferences_ism_HidePlayer.Value;
            preferences_ism_HideCursor = _preferences_ism_HideCursor.Value;
            preferences_ism_HideShots = _preferences_ism_HideShots.Value;
        }
        #endregion
        #region Console
        /// <summary>
        /// logs the value of every option in the console
        /// </summary>
        static void LogPreferences()
        {
            DebugConsole.Log("Loaded preferences:");
            DebugConsole.Log($"DebugMod.ModPreferences.preferences_main_disableFog: {preferences_main_disableFog}");
            DebugConsole.Log($"DebugMod.ModPreferences.preferences_Ism_enableIsm: {preferences_ism_enableIsm}");
            DebugConsole.Log($"DebugMod.ModPreferences.preferences_Ism_HidePlayer: {preferences_ism_HidePlayer}");
            DebugConsole.Log($"DebugMod.ModPreferences_preferences_Ism_HideCursor: {preferences_ism_HideCursor}");
            DebugConsole.Log($"DebugMod.ModPreferences_preferences_Ism_HideShots: {preferences_ism_HideShots}");

        }
        #endregion
    }
}
