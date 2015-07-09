using UnityEngine;

public class KeyboardController2d : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        return direction;
    }
}
