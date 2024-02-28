using UnityEngine;

public class Distance : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Bullet bullet;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, point.position, point.rotation);
    }
}
