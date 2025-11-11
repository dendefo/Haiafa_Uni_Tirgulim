using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public static event Action OnPointScored;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float JumpForce = 300f;
    private bool isDead = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, JumpForce));
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Death();
        }
        else if (other.CompareTag("Collectable"))
        {
            ScorePoint();
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Death();
        }
    }
    private void Death()
    {
        if (isDead) return;
        isDead = true;
        enabled = false;
        OnPlayerDeath?.Invoke();
    }
    private void ScorePoint()
    {
        if (isDead) return;
        OnPointScored?.Invoke();
    }
}
