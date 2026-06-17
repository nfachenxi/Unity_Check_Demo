using UnityEngine;

namespace Unity_Check_Demo
{
    public class EnemyAI : MonoBehaviour
    {
        public float detectionRange = 10f;
        public float attackCooldown = 1.5f;

        private float lastAttackTime;

        void Update()
        {
            // UNT0001: FindObjectOfType called in Update — cache in Awake or Start
            var player = FindObjectOfType<PlayerController>();
            if (player == null)
            {
                return;
            }

            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < detectionRange)
            {
                if (Time.time - lastAttackTime > attackCooldown)
                {
                    Attack(player);
                    lastAttackTime = Time.time;
                }
            }
        }

        void Attack(PlayerController target)
        {
            target.TakeDamage(5);
            Debug.Log("Enemy attacked the player!");
        }
    }
}
