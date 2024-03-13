using Unity.VisualScripting;
using UnityEngine;
public class Melee : MonoBehaviour
{
    [SerializeField] private MeleeItem _meleeItem;

    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _boxCollider.enabled = true;
            Invoke("OffTrigger", 2f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().TakeDamage(_meleeItem.damage);
            _boxCollider.enabled = false;
        }
    }

    private void OffTrigger()
    { 
        _boxCollider.enabled = false;
    }
}