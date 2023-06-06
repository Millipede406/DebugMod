

namespace DebugMod
{
    public static class Console
    {
        public enum LogType
        {
            // Initialization
            Init_Main,
            Init_GUI,
            Init_Features,

            // Main
            Main,
            Feature,
        }

        /// <summary>
        /// Sends a formatted message to the console.
        /// Format is consistent, so it looks nice and makes me happy
        /// </summary>
        /// <param name="l">Log type</param>
        /// <param name="m">Message</param>
        public static void Log(LogType l, string m)
        {
            string prefix = PrefixManager.GetPrefix(l);

            string message = prefix + " " + m;

            MelonLoader.MelonLogger.Msg(message);
        }

        public class PrefixManager
        {
            public static string GetPrefix(LogType l)
            {
                switch (l)
                {
                    default:
                        return "[???] ";

                    case LogType.Init_Main:
                        return InitMain();

                    case LogType.Init_GUI:
                        return InitGUI();

                    case LogType.Init_Features:
                        return InitFeatures();

                    case LogType.Main:
                        return Main();

                    case LogType.Feature:
                        return Feature();
                }
            }
            private static string InitMain()
            {
                return "[Init]";
            }

            private static string InitGUI()
            {
                return "[Init] [GUI]";
            }

            private static string InitFeatures()
            {
                return "[Init] [Features]";
            }

            private static string Main()
            {
                return "[Main]";
            }

            private static string Feature()
            {
                return "[Features]";
            }
        }
    }
}
