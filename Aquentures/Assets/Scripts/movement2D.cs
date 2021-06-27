using UnityEngine;
using UnityEngine.Events;

public class movement2D : MonoBehaviour
{
    public GameObject player;

	public float movementSpeed;
    public float jumpHeight;
    public LayerMask groundMask;
    public Transform groundCheck;
    private bool isGrounded;
    private bool flipped;

    void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

	void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundMask);
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * movementSpeed;
        if (Input.GetKeyDown(KeyCode.A) && !flipped)
        {
            Flip();
        }
        else if (Input.GetKeyDown(KeyCode.D) && flipped)
        {
            Flip();
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        flipped = !flipped;

        Vector3 theScale = player.transform.localScale;
        theScale.x *= -1;
        player.transform.localScale = theScale;
    }
}