using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
