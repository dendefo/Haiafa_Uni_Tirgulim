using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;
    Vector3 direction = Vector3.zero;
    [SerializeField] private GameObject diamond;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //WASDControlls();

        var y = Input.GetAxis("Vertical");
        var x = Input.GetAxis("Horizontal");
        direction = new Vector3(x, y, 0);
        
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(diamond,  transform.position + new Vector3(0, 5.0f, 0), Quaternion.identity);
        
    }

    private void FixedUpdate()
    {
        if (rb == null)
        {
            Debug.LogWarning("Missing Rigidbody2D");
            return;
        }
        
        rb.MovePosition(rb.position + (Vector2)direction * (_speed * Time.fixedDeltaTime));
        
       // transform.position += direction * (_speed * Time.fixedDeltaTime);
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
        transform.position +=(Vector3)direction * (_speed * Time.deltaTime);
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
