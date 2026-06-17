using UnityEngine;

namespace Unity_Check_Demo
{
    public static class Config
    {
        // SA1311: Static readonly field should begin with upper-case letter
        public static readonly float defaultTimeout = 5.0f;

        public static readonly int MaxPlayers = 4;
        public static readonly string GameVersion = "1.0.0";

        public const float Gravity = -9.81f;
        public const int DefaultHealth = 100;

        public static string GetServerUrl()
        {
            return "https://api.example.com/v1";
        }
    }
}
