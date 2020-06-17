using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 800f;
    [SerializeField] private float junpForce;
    [SerializeField] private int jumpsAvaible = 1;

    private bool jumpAbility = false;
    private int jumpsLeft = 1;

    private Transform gun;
 
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gun = transform.GetChild(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpAbility)
        {
            jumpsLeft--;
            if (jumpsLeft == 0) { jumpAbility = false; }

            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, junpForce), ForceMode2D.Impulse);
        }

        GunLookAtCursor();
    }

    private void LateUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime , rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        jumpAbility = true;
        jumpsLeft = jumpsAvaible;
    }

    private void GunLookAtCursor()
    {
        /*
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
        gun.position = Quaternion.AngleAxis(angle, Vector3.forward);
        */
        /*
        Vector3 mouseInWorld = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gun.right = mouseInWorld - transform.position;
        
        Vector3 mouseInWorld = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseInWorld.Normalize();
        gun.position = mouseInWorld - transform.position;
        gun.right = mouseInWorld - transform.position;
        */
    }
}
