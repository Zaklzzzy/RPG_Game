using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Animator _animator;

    [Header("Health")]
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private int HP = 100;
    [SerializeField] private GameObject healthUI;
    [SerializeField] private TextMeshProUGUI counter;

    //New Input System
    //private IControllable _controllable;
    private GameInput _gameInput;

    //Rotate And Movement
    private Rigidbody _rb;
    RaycastHit _hit;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();

        _gameInput = new GameInput();
        _gameInput.Enable();

        //_controllable = GetComponent<IControllable>();
    }

    private void FixedUpdate()
    {
        var inputDirection = _gameInput.Gameplay.Movement.ReadValue<Vector2>();

        float x = inputDirection.x;
        float z = inputDirection.y;
        Vector3 move = new Vector3(x, 0, z);


        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out _hit);
        Vector3 targetPosition = new Vector3(_hit.point.x, transform.position.y, _hit.point.z + 2.3f);
        transform.LookAt(targetPosition);

        _rb.MovePosition(transform.position + move.normalized * _moveSpeed * Time.deltaTime);
        _animator.SetFloat("Horizontal", x);
        _animator.SetFloat("Vertical", z);
    }
    public void TakeDamage(short damage)
    {
        HP -= damage;
        healthUI.GetComponent<Image>().fillAmount = (float)HP/100;
        counter.text = HP.ToString() + "/" + _maxHP.ToString();
        if(HP <= _maxHP / 2)
        {
            counter.color = Color.black;
        }
        if (HP <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
