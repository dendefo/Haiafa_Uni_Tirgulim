using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    [Header("Enemy Settings")]
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 0.05f;
    [SerializeField] private Rigidbody2D rb;
    
    string tagPlayer = "Player";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        _player = GameObject.FindGameObjectWithTag(tagPlayer);
    }

    void FixedUpdate()
    {
        //OldMovement();

        
        if (rb == null)
        {
            Debug.LogWarning("Missing Rigidbody2D");
            return;
        }
        var direction = (_player.transform.position - transform.position).normalized*( _speed * Time.deltaTime);

        rb.MovePosition(rb.position + (Vector2)direction * (_speed * Time.fixedDeltaTime));

        //transform.position += new Vector3(pos.x, pos.y, 0);
    }

    private void OldMovement()
    {
        Transform playerTransform = _player.transform;
        var playerPos = playerTransform.position;
        var selfPos = transform.position;
        var direction = playerPos - selfPos;
        var normalized = direction.normalized;
        var movement = normalized*_speed;
        transform.position += new Vector3(movement.x, movement.y, 0) * Time.deltaTime;

    }
}