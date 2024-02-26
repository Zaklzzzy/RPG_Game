using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 500f;

    private Rigidbody rb;
    RaycastHit hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //Vector3 mousePosition = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.z);

        Physics.Raycast(ray, out hit);
        Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        transform.LookAt(targetPosition);

        //Quaternion toRotation = Quaternion.LookRotation(mousePosition1.normalized, Vector3.up);
        //transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, turnSpeed * Time.deltaTime);
/*        if (mousePosition.magnitude > 0.1f)
        {
            
        }*/

        rb.MovePosition(transform.position + move.normalized * moveSpeed * Time.deltaTime);
    }
}
