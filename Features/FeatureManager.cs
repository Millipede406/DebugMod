using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebugMod.Features.Cheats;
using DebugMod.Features.Visual;

namespace DebugMod.Features
{
    /// <summary>
    /// This class handles instances of all features which need to be updated / initialized. So not including patches
    /// This looks kinda complicated, but basically what it does is it gets a list of every feature
    ///     (which is hardcoded so if you create a feature you will need to implement it here)
    /// And then it will initialize and update every feature in the list
    /// 
    /// 
    /// In order to add to this, find the related method that your new feature is a part of, and then simply write (list).Add(new Feature());
    /// Replacing (list) with the name of the list in that method
    /// And obviously replacing Feature with the name of your feature
    /// Assuming your feature derives from IFeature, which it should. And if it doesn't then you might want to go do that otherwise this won't work.
    /// Anyway yeah that's how this works have fun
    /// </summary>
    public static class FeatureManager
    {
        public static List<IFeature> features;

        public static void Initialize()
        {
            // Initializing FeatureManager
            features = GetAllFeatures();

            // Initializing features
            InitializeFeatures();
        }

        public static void Update()
        {
            // Updating features
            UpdateFeatures();
        }

        private static List<IFeature> GetAllFeatures()
        {
            // Initializing list
            List<IFeature> f = new List<IFeature>();

            // Getting features from each category
            f.AddRange(GetAllCheats());

            f.AddRange(GetAllVisual());

            // Returning result
            return f;
        }

        private static List<IFeature> GetAllCheats()
        {
            // Initializing list
            List<IFeature> cheats = new List<IFeature>();

            // Creating instance of features
            cheats.Add(new Invulnerability());
            cheats.Add(new InfiniteStamina());

            // Returning list of features
            return cheats;
        }

        private static List<IFeature> GetAllVisual()
        {
            // Initializing list
            List<IFeature> visual = new List<IFeature>();

            // Creating instance of features
            // (there is nothing here yet)

            // Returning the list of features
            return visual;
        }

        private static void InitializeFeatures()
        {
            foreach (IFeature feature in features)
            {
                feature.Initialize();
            }
        }

        private static void UpdateFeatures()
        {
            foreach (IFeature feature in features)
            {
                feature.Update();
            }
        }
    }
}