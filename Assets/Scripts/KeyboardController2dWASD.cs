using UnityEngine;

public class KeyboardController2dWASD : MonoBehaviour
{
    public float ForceValue = 300f;
    
    void Update ()
	{
	    var direction = GetDirection();

	    var rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * ForceValue);
    }

    private static Vector2 GetDirection()
    {
        var direction = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        return direction;
    }
}
