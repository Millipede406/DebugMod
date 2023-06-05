using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DebugMod.Features.Cheats;
using DebugMod.Features.Visual;

namespace DebugMod.Features
{
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