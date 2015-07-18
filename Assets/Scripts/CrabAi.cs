using UnityEngine;

public class CrabAi : MonoBehaviour {

    public Transform Player;
    private Rigidbody rb;

    public float distanceLimit = 3.5f;
    public float period = 75f;
    public float forceValue = 100f;
    private float t = 0.0f;
    private System.Random random;
    private Transform cachedTransform;

	void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
        random = new System.Random();
	    cachedTransform = gameObject.transform;
	}
	
	void Update ()
	{
        var vectorBetweenCrabAndPlayer = Player.position - cachedTransform.position;

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
            RandomJump(directionToPlayer);
            t++;
	    }
	}

    private void RandomJump(Vector3 directionToPlayer)
    {
        var bingo = random.Next(0, 1500);
        
        if (bingo == 1000)
            rb.AddForce(Vector3.up * 300f);
        else if (bingo == 1200)
            rb.AddForce(directionToPlayer * 300f);
    }
}
