using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private bool enableDebugLogs = true;
    [SerializeField] private bool enableForceGroundKey = true;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private float debugTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        CheckGround();

        if (enableForceGroundKey && Input.GetKeyDown(KeyCode.G))
        {
            isGrounded = true;
            if (enableDebugLogs) Debug.Log("Forced grounded for test");
        }

        HandleJump();
    }

    private void CheckGround()
    {
        if (groundCheck == null)
        {
            if (enableDebugLogs) Debug.LogWarning("Player: groundCheck not assigned.");
            isGrounded = false;
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        debugTimer -= Time.deltaTime;
        if (enableDebugLogs && debugTimer <= 0f)
        {
            Debug.Log($"GroundCheck pos: {groundCheck.position} | Grounded: {isGrounded}");
            debugTimer = 1f;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            if (enableDebugLogs) Debug.Log("Jump triggered");
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Coinchange.AddPoint();
            Destroy(collision.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
