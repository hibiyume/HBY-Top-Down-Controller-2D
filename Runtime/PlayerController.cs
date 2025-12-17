using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 _moveVector;
    
    private Rigidbody2D _rb2d;
    private Animator _animator;

    private string _lastInputAxis = "x"; 

    void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 linearVelocity = _moveVector.normalized * moveSpeed;
        
        if (linearVelocity.magnitude > 0)
        {
            AnimateMovement(linearVelocity);
        }
        else 
        {
            _animator.SetInteger("x", 0);
            _animator.SetInteger("y", 0);
        }

        _rb2d.linearVelocity = linearVelocity;
    }

    private void AnimateMovement(Vector2 direction)
    {
        int xInt = direction.x > 0 ? 1 : (direction.x < 0 ? -1 : 0);
        int yInt = direction.y > 0 ? 1 : (direction.y < 0 ? -1 : 0);

        if (xInt != 0 && yInt != 0)
        {
            if (_lastInputAxis == "x")
            {
                _animator.SetInteger("x", xInt);
                _animator.SetInteger("y", 0);
            }
            else
            {
                _animator.SetInteger("x", 0);
                _animator.SetInteger("y", yInt);
            }
        }
        else
        {
            _animator.SetInteger("x", xInt);
            _animator.SetInteger("y", yInt);
        }
    }

    //Reads SendMessage from PlayerInput component
    private void OnMove(InputValue inputValue)
    {
        Vector2 newInput = inputValue.Get<Vector2>();

        if (newInput.x != 0 && _moveVector.x == 0) _lastInputAxis = "x";
        if (newInput.y != 0 && _moveVector.y == 0) _lastInputAxis = "y";

        _moveVector = newInput;
    }
}