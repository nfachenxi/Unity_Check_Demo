using UnityEngine;

namespace Unity_Check_Demo
{
    public class GameManager : MonoBehaviour
    {
        public int currentScore;
        public bool isGameOver;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        // CA1822: Method does not access instance data and can be marked as static
        void UpdateScore()
        {
            Debug.Log("Updating score...");
        }

        void Update()
        {
            if (isGameOver) return;  // RCS1001: Add braces to if statement

            // Simulate game logic
            currentScore += Mathf.FloorToInt(Time.deltaTime * 10);
            UpdateScore();
        }

        public void StartGame()
        {
            currentScore = 0;
            isGameOver = false;
        }

        public void EndGame()
        {
            isGameOver = true;
            Debug.LogFormat("Game Over! Final Score: {0}", currentScore);
        }
    }
}
