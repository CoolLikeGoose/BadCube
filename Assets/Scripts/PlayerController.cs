using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 800f;
    [SerializeField] private float junpForce;

    private bool jumpAbility = false;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpAbility)
        {
            jumpAbility = false;
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, junpForce), ForceMode2D.Impulse);
        }
    }

    private void LateUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime , rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumpAbility = true;
    }
}
