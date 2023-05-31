using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TankSO tankSO;

    [Header("Movement")]
    private Vector3 initialPosition;

    [Header("Gun")]
    public Transform gunTransform;
    private Quaternion initialGunRotation;
    private float rotationLimiter = 90f;

    [Header("Shoot")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float shootDelay = 0f;
    [SerializeField] private float bulletLifespan = 5f; // Time in seconds
    private float shootCooldown = 0f;

    private void Awake()
    {
        initialPosition = transform.position;
        initialGunRotation = gunTransform.rotation;
    }

    private void Update()
    {
        //________________Turret Follow________________//
        Vector3 mousePosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = mouseWorldPosition - gunTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -rotationLimiter, rotationLimiter);
        gunTransform.rotation = initialGunRotation * Quaternion.AngleAxis(angle, Vector3.forward);

        //________________Shooting________________//
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
                shootCooldown = shootDelay;
            }
        }
    }

    private void OnBecameInvisible()
    {
        transform.position = initialPosition;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = bulletSpawn.right * bulletSpeed;
        Destroy(bullet, bulletLifespan);
    }
}