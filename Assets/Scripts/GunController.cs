using UnityEngine;

public class GunController : MonoBehaviour
{

    private void Update()
    {
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        lookPos = lookPos - transform.position;
        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        if (angle > 90 || angle < -90) { transform.localScale = new Vector3(1, -1, 1); }
        else if (angle < 90 && angle > 0 || angle > -90 && angle < 0) { transform.localScale = new Vector3(1, 1, 1); }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
