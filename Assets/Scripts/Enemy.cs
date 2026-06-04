using UnityEngine;

namespace Unity_Check_Demo
{
    public class Enemy : MonoBehaviour
    {
        // SA1300: Field must begin with an upper-case letter
        private int health;

        // IDE1006: Naming rule violation — should use camelCase
        private float _Speed;

        void Start()
        {
            health = 100;
            _Speed = 3.0f;
        }

        void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
                return;
            }

            transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
