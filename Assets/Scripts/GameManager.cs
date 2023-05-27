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
    }

    private void OnBecameInvisible()
    {
        transform.position = initialPosition;
    }
}