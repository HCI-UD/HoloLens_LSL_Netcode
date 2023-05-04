// only run this script if it's on the PC. Does not compile right for UWP Hololens 
#if UNITY_EDITOR || UNITY_STANDALONE_WIN

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

namespace HCIUD.HoloLSL
{
    public class ConfigLoader : MonoBehaviour
    {
        public static ConfigLoader Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            LoadDemoSceneSetup();
        }

        // Name of scene config file.
        private const string gameDataFileName = "config.json";

        public Configs Configs { get; private set; } = new Configs();

        private void LoadDemoSceneSetup()
        {
            // Path.Combine combines strings into a file path.
            // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build.
            string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
            if (File.Exists(filePath))
            {
                // Read the json from the file into a string.
                string dataAsJson = File.ReadAllText(filePath);

                // Pass the json to JsonUtility, and tell it to create a Configs object from it.
                Configs = JsonUtility.FromJson<Configs>(dataAsJson);

                UnityEngine.Debug.Log("Successfully loaded config file.");
            }
            else
            {
                Debug.LogError("Cannot load game data!");
            }
        }
    }

}
#endif