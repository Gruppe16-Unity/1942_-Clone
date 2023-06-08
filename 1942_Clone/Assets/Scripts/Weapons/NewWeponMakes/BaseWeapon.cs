    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BaseWeapon : MonoBehaviour
    {
        public GameObject bulletPrefab;
        public GameObject bombPrefab;
        public Transform firePoint;

        private float bulletSpeed = 5f;
        private float bombSpeed = 1.0f;
        private int extraBulletCount = 0;


        /*
        private float fireRate = 0.2f;
        private float reloadSpeed = 2f;
        private int currentAmmo;
        private bool isReloading = false;
        private float nextFireTime = 0f;
        */
        public Player Spiller;
        private void Start()
        {
            Spiller = GetComponent<Player>();
        }

        private void Update()
        {
        
        }

        public void Shoot()
        {
            // Calculate the position in front of the player based on the fire point
            Vector3 spawnPosition = firePoint.position + firePoint.right * 0.5f;

            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, firePoint.rotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.velocity = bulletSpeed * firePoint.right;

            if (extraBulletCount > 0)
            {
                // Calculate the position for the extra bullet
                Vector3 extraBulletSpawnPosition = firePoint.position + (Quaternion.Euler(0, 0, 10f) * firePoint.right) * 0.5f;

                GameObject extraBullet = Instantiate(bulletPrefab, extraBulletSpawnPosition, firePoint.rotation);
                Rigidbody2D extraBulletRigidbody = extraBullet.GetComponent<Rigidbody2D>();
                extraBulletRigidbody.velocity = bulletSpeed * (Quaternion.Euler(0, 0, 10f) * firePoint.right);
                extraBulletCount--;
            }
        }

        public void EnemyShoot(Transform enemyTransform, Transform playerTransform, int enemyType)
        {
            float lineOfSightAngle = 70f;

            // Customize shooting behavior based on the enemy type
            switch (enemyType)
            {
                case 1:
                    // Calculate the direction from the enemy to the player
                    Vector3 directionToPlayer = playerTransform.position - enemyTransform.position;

                    // Calculate the angle between the enemy's forward direction and the direction to the player
                    float angleToPlayer = Vector3.Angle(enemyTransform.up, directionToPlayer);

                    // Check if the player is within the line of sight
                    if (angleToPlayer <= lineOfSightAngle)
                    {
                        // Spawn a bullet away from the enemy's center
                        Vector3 spawnPosition = enemyTransform.position + enemyTransform.up * 1.2f;

                        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, enemyTransform.rotation);
                        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
                        bulletRigidbody.velocity = bulletSpeed * enemyTransform.up;
                    }
                    break;

                case 2:
                    // Spawn a bomb in front of the boss enemy
                    Vector3 bombSpawnPosition = enemyTransform.position + enemyTransform.up;
                    GameObject bomb = Instantiate(bombPrefab, bombSpawnPosition, enemyTransform.rotation);
                    Rigidbody2D bombRigidbody = bomb.GetComponent<Rigidbody2D>();
                    bombRigidbody.velocity = bombSpeed * enemyTransform.up;
                    break;

                case 3:
                    // Customize special enemy shooting behavior
                    // ...
                    break;
            }
        }

    


    public void AddExtraBullet()
        {
            extraBulletCount++;
        }

        public void IncreaseFireRate(float amount)
        {
            Spiller.shootCooldown -= amount;
        }

        public void DecreaseReloadSpeed(float amount)
        {
            Spiller.reloadTimer -= amount;
        }


}
