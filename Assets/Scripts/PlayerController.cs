using UnityEngine;

namespace Unity_Check_Demo
{
    public class PlayerController : MonoBehaviour
    {
        // CA1805: Field initialized to its default value
        private float maxSpeed = 0;

        private Rigidbody rb;
        private Animator animator;

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveX, 0, moveZ) * maxSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }

        void OnCollisionEnter(Collision other)
        {
            // UNT0002: Use CompareTag instead of tag string comparison
            if (other.gameObject.tag == "Enemy")
            {
                TakeDamage(10);
            }
        }

        void Attack()
        {
            // RCS1015: Use 'nameof' instead of string literal
            Debug.Log("maxSpeed");
            animator.SetTrigger("Attack");
        }

        public void TakeDamage(int amount)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                Debug.Log("Player died");
            }
        }

        private int currentHealth = 100;
    }
}
