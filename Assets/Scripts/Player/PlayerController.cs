using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Animator _animator;

    private Rigidbody _rb;
    RaycastHit _hit;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out _hit);
        Vector3 targetPosition = new Vector3(_hit.point.x, transform.position.y, _hit.point.z + 2.3f);
        transform.LookAt(targetPosition);

        _rb.MovePosition(transform.position + move.normalized * _moveSpeed * Time.deltaTime);
        _animator.SetFloat("Horizontal", x);
        _animator.SetFloat("Vertical", z);
    }
}
