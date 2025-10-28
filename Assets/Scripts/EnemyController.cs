using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    [Header("Enemy Settings")]
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed = 0.05f;
    
    void Update()
    {
        //OldMovement();

        var pos = (_player.transform.position - transform.position).normalized*( _speed * Time.deltaTime);
        transform.position += new Vector3(pos.x, pos.y, 0);
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