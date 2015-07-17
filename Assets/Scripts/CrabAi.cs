using UnityEngine;
using System.Collections;
using UnityEngine.Assertions.Must;

public class CrabAi : MonoBehaviour {

    public Transform Player;
    private Rigidbody rb;

    public float distanceLimit = 3.5f;
    public float period = 75f;
    private float forceValue = 100f;
    private float t = 0.0f;
    private System.Random random;

	void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
        random = new System.Random();
	}
	
	void Update ()
	{
        var vectorBetweenCrabAndPlayer = Player.position - gameObject.transform.position;

	    var directionToPlayer = vectorBetweenCrabAndPlayer.normalized;

	    var distance = vectorBetweenCrabAndPlayer.magnitude;

        if (distance < distanceLimit)
        {
            directionToPlayer = -1 * directionToPlayer;
        }

        if (t >= period)
	    {
            rb.AddForce(directionToPlayer * forceValue);
	        t = 0;
	    }
	    else
	    {
	        t++;
            SuddenJump(directionToPlayer);
	    }
	}

    private void SuddenJump(Vector3 directionToPlayer)
    {
        var bingo = random.Next(0, 1200);
        
        if (bingo == 1000)
            rb.AddForce(Vector3.up * 500f);
        else if (bingo == 1200)
            rb.AddForce(directionToPlayer * 500f);
    }
}
