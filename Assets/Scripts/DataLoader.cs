using System.IO;
using System.Xml;
using UnityEngine;

namespace Unity_Check_Demo
{
    public class DataLoader : MonoBehaviour
    {
        public string configFileName = "game_config.xml";

        void Start()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            string path = Path.Combine(Application.streamingAssetsPath, configFileName);
            if (!File.Exists(path))
            {
                Debug.LogWarning("Config file not found: " + path);
                return;
            }

            string xmlContent = File.ReadAllText(path);

            // CA3075: XmlReaderSettings.DtdProcessing should be set to Prohibit
            var settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.XmlResolver = new XmlUrlResolver();

            using (var stringReader = new StringReader(xmlContent))
            using (var xmlReader = XmlReader.Create(stringReader, settings))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.IsStartElement())
                    {
                        Debug.Log("Element: " + xmlReader.Name);
                    }
                }
            }
        }
    }
}
