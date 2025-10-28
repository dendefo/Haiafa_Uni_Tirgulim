using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //WASDControlls();

        var y = Input.GetAxis("Vertical");
        var x = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(x, y, 0);
        transform.position += direction * (_speed * Time.deltaTime);
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
}
