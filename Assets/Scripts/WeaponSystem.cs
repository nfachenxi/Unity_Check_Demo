using UnityEngine;
using System.Collections;  // SA1200: Using directive should appear within namespace

namespace Unity_Check_Demo
{
    public class WeaponSystem : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public Transform firePoint;
        public float bulletSpeed = 50f;

        // CA1062: Parameter 'target' is not validated for null
        public void Fire(GameObject target)
        {
            if (target.transform == null)
            {
                return;
            }

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                Vector3 direction = (target.transform.position - firePoint.position).normalized;
                bulletRb.velocity = direction * bulletSpeed;
            }

            string logMessage = "Fired at target: " + target.name;
            Debug.Log(logMessage);
        }
    }
}
