using System;
using UnityEngine;

[HelpURL("https://example.com/docs/MyComponent")]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    [SerializeField] HealthData healthData;
    [SerializeField] IntEventBuffer HelathChangedEvent;
    Vector3 direction = Vector3.zero;
    [SerializeField] private GameObject diamond;

    [ContextMenuItem("ChangeHP", "ChangeHP")]
    public int score = 0;

    private Vector3 orginalScale;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        orginalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //WASDControlls();

        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("Attack");

        if (!IsAnimationFinised(animator, "PlayerPunch"))
        {
            Debug.Log("is attacking");
            return;
        }


        var y = Input.GetAxis("Vertical");
        var x = Input.GetAxis("Horizontal");
        direction = new Vector3(x, y, 0);


        bool isWalking = x != 0 || y != 0;
        animator.SetBool("IsWalking", isWalking);


        if (isWalking)
        {
            transform.localScale = new Vector3(x < 0 ? -orginalScale.x : orginalScale.x, orginalScale.y, 1);
        }

        if (rb == null)
        {
            Debug.LogWarning("Missing Rigidbody2D");
            return;
        }

        rb.MovePosition(rb.position + (Vector2)direction * (_speed * Time.fixedDeltaTime));

        // transform.position += direction * (_speed * Time.fixedDeltaTime);

    }

    public static bool IsAnimationFinised(Animator animator, string AnimationName)
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

        if (!info.IsName(AnimationName)) return true;

        if (info.normalizedTime >= 1)
            return true;

        return false;
    }

    [ContextMenu("Change HP")]
    public void ChangeHP()
    {
        var hp = healthData.GetCurrentHealth() - 1;
        healthData.SetCurrentHealth(hp);
        HelathChangedEvent.Notify((int)hp);

    }

    public void AddScore(int amount)
    {
        score += amount;

        GameManager.Instance.HUD.GetComponent<HUD>().UpdateScore(score);
    }

    private void WASDControlls()
    {
        Vector2 direction = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
        transform.position += (Vector3)direction * (_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"$On trigger enter = {other.name}");
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"$On trigger exit = {other.name}");
    }
}
