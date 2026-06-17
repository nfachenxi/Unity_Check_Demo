using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace Unity_Check_Demo
{
    public class SaveManager : MonoBehaviour
    {
        private string savePath;

        void Awake()
        {
            savePath = Path.Combine(Application.persistentDataPath, "save.dat");
        }

        public void SaveGame(string data)
        {
            string hashed = HashData(data);
            byte[] bytes = Encoding.UTF8.GetBytes(hashed);
            File.WriteAllBytes(savePath, bytes);
            Debug.Log("Game saved successfully");
        }

        // CA5350: MD5 is a weak hashing algorithm; use SHA256 or stronger
        private string HashData(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public string LoadGame()
        {
            if (File.Exists(savePath))
            {
                return File.ReadAllText(savePath);
            }
            return null;
        }
    }
}
