using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public static event Action OnPointScored;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator _animator;
    [SerializeField] float JumpForce = 300f;
    [SerializeField] AudioResource jumpSFX;
    [SerializeField] AudioResource deathSFX;
    [SerializeField] AudioResource pointSFX;
    [SerializeField] AudioResource hitSFX;
    private bool isDead = false;
    public PlayerColors PlayerColor;
    [SerializeField] Slider HealthSlider;
    [SerializeField] int StartHelath = 2;
    [SerializeField] int CurrentHealth = 2;

    private void Start()
    {
        CurrentHealth = StartHelath;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        _animator.SetFloat("Vertical Speed", rb.linearVelocityY);
        rb.linearVelocityY = Mathf.Min(rb.linearVelocityY, 10);
        HealthSlider.transform.rotation = Quaternion.identity;
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0, JumpForce));
        _animator.SetTrigger("Jump");
        AudioManager.GetInstance().PlaySFX(jumpSFX);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            GetHit();
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
            GetHit();
        }
    }

    private void GetHit()
    {
        CurrentHealth--;
        HealthSlider.value = (CurrentHealth / (float)StartHelath);
        if (CurrentHealth <= 0)
        {
            Death();
        }
        else
        {
            AudioManager.GetInstance().PlaySFX(hitSFX);
        }
    }

    private void Death()
    {
        if (isDead) return;
        isDead = true;
        enabled = false;
        OnPlayerDeath?.Invoke();
        AudioManager.GetInstance().PlaySFX(deathSFX);
    }
    private void ScorePoint()
    {
        if (isDead) return;
        OnPointScored?.Invoke();
        AudioManager.GetInstance().PlaySFX(pointSFX);
    }
}
public enum PlayerColors
{
    Blue, Red, Yellow
}
