using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Runtime
{
    public class JsonSaveSystem : ISaveSystem
    {
        private readonly string _filePath;

        public JsonSaveSystem()
        {
            _filePath = Application.persistentDataPath + "/Save.json";
        }

        public void Save(SaveData data)
        {
            string json = JsonUtility.ToJson(data);
            using (StreamWriter writer = new StreamWriter(_filePath))
            {
                writer.WriteLine(json);
            }
        }

        public SaveData Load()
        {
            string json = string.Empty;
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    json += line;
                }
            }
            if (string.IsNullOrEmpty(json))
            {
                return new SaveData();
            }
            return JsonUtility.FromJson<SaveData>(json);
        }
    }

}