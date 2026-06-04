using UnityEngine;
using UnityEngine.UI;

namespace Unity_Check_Demo
{
    public class UIManager : MonoBehaviour
    {
        public Text scoreLabel;
        public Text healthLabel;
        public GameObject gameOverPanel;

        public void UpdateUI(int score, int health)
        {
            // CA1303: Do not pass literals as localized parameters
            scoreLabel.text = "Score: " + score;
            healthLabel.text = "HP: " + health;

            if (health <= 0)
            {
                gameOverPanel.SetActive(true);
                scoreLabel.text = "Game Over";
            }
        }

        public void ShowMessage(string message)
        {
            scoreLabel.text = message;
        }
    }
}
