using UnityEngine;

public class KeyboardController : MonoBehaviour
{
    public float ForceValue = 65f;
    public float Gravity = 0.75f;

    void Start()
    {
        Physics.gravity = new Vector3(0, -Gravity, 0);
    }

    void Update ()
	{
	    var direction = GetDirection();

	    var rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(direction * ForceValue);
    }

    private static Vector3 GetDirection()
    {
        var direction = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }
        return direction;
    }
}
