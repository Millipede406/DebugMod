using MelonLoader;

namespace DebugMod
{
    /// <summary>
    /// This class manages the config file for the mod. It loads all of the config in the LoadPreferences() function and has a number
    /// of variables that store the config so that any other script can easily access.
    /// </summary>
    public static class ModPreferences
    {



        static MelonPreferences_Category _preferences_main;


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
        }

        static void SetupConfigPreferences()
        {
            SetupMainCategory();
        }

        static void SetupMainCategory()
        {

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
        }

        static void StoreMainPreferences()
        {

        }

        #endregion
        #region Console
        /// <summary>
        /// logs the value of every option in the console
        /// </summary>
        static void LogPreferences()
        {
            DebugConsole.Log("Loaded preferences:");
        }
        #endregion
    }
}
