using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;


    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float sprint = Input.GetAxis("Sprint");
        bool isJump = Input.GetAxis("Jump") > 0.1f;
        vertical = vertical + (sprint * vertical);

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        animator.SetFloat("Move Speed", vertical);
        animator.SetFloat("Direction", horizontal);
        
        transform.Translate(direction * Time.deltaTime * 5f, Space.World);

        if (isJump)
        {
            animator.SetTrigger("Jump");
        }
    }
}
