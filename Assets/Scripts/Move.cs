using UnityEngine;

public class Move : MonoBehaviour
{
    public double SpringEffectTime = 0.5;
    private double elapsedTime = 0;
	void Update ()
	{
        var spring = GetComponent<SpringJoint2D>();

	    if (Input.anyKeyDown)
        {
            var target = GameObject.Find("MovementTarget");
            var nextPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.transform.position = nextPosition;

            spring.enabled = true;
            elapsedTime = 0;
        }
        
	    if (elapsedTime > SpringEffectTime)
	    {
	      spring.enabled = false;
	    }

	    elapsedTime += Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, 0);
	}
}
