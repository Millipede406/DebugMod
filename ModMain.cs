using UnityEngine;
using MelonLoader;

namespace DebugMod
{
    public class ModMain : MelonMod
    {
        public static ModMain Instance;

        bool improvedScreenshotMode;

        public override void OnInitializeMelon()
        {
            base.OnInitializeMelon();

            Instance = this;

            ModPreferences.LoadPreferences();
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg($"Loaded Scene: {sceneName} ({buildIndex})");
        }
        public override void OnUpdate()
        {
            base.OnUpdate();

            #region Controls

            if (Input.GetKeyDown(KeyCode.F6) && ModPreferences.preferences_ism_enableIsm)
            {
                improvedScreenshotMode = !improvedScreenshotMode;

                if (improvedScreenshotMode)
                {
                    ImprovedScreenshotMode.EnableIsm();
                }
                else
                {
                    ImprovedScreenshotMode.DisableIsm();
                }
            }
            
            #endregion

            #region Checks

            if (ModPreferences.preferences_main_disableFog)
            {
                DisableFog.Update();
            }

            #endregion

        }    
        public static void DebugLog(string msg)
        {
            Instance.LoggerInstance.Msg(msg);
        }
    }
}
