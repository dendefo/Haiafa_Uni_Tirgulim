using UnityEngine;

public class CubeMover : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] Vector3 EndPos;
    bool direction = true;
    private void Awake()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        if (direction)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition + EndPos, 2 * Time.deltaTime);
            if (transform.position == startPosition + EndPos)
            {
                direction = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, 2 * Time.deltaTime);
            if (transform.position == startPosition)
            {
                direction = true;
            }
        }
    }
}
