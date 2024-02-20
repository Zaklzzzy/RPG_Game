using UnityEngine;

public class Weapon : MonoBehaviour
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
