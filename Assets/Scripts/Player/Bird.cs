using UnityEngine;
using UnityEngine.InputSystem;

public class Bird : MonoBehaviour
{
    [SerializeField] private float _velocity;
    [SerializeField] private float _rotationSpeed;

    private Rigidbody2D _rb;
    private Animator _animator;
    private bool _isDead;

    public Animator Animator => _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        if (BirdSkinManager.Instance != null) BirdSkinManager.Instance.ApplySkinTo(this);
    }

    void Update()
    {
        if (!GameManager.Instance.IsRunning)
        {
            _rb.gravityScale = 0f;
            _rb.linearVelocity = Vector2.zero;

            if (GameManager.Instance.IsPaused)
            {
                _animator.enabled = false;
            }

            return;
        }

        if (_isDead) return;

        _animator.enabled = true;
        _rb.gravityScale = 1f;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _rb.linearVelocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        if (!GameManager.Instance.IsRunning) return;
        if (_isDead) return;

        transform.rotation = Quaternion.Euler(0, 0, _rb.linearVelocity.y * _rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Ground"))
        {
            Die();
        }
    }

    private void Die()
    {
        _isDead = true;
        _rb.linearVelocity = Vector2.zero;
        _rb.gravityScale = 0f;
        _animator.enabled = false;

        GameManager.Instance.GameOver();
    }
}