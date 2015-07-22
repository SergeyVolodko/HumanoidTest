using UnityEngine;
using System.Collections;

public class OnAsteroidEnteredAtmosphere : MonoBehaviour
{
    public float AtmosphereLevel = 3f;
    
    private Rigidbody rb;
    private Transform cachedTransform;
	
	void Start () {
        rb = this.gameObject.GetComponent<Rigidbody>();
        cachedTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
	    if (cachedTransform.position.y < AtmosphereLevel)
	    {
            var size = 1f;
            rb.transform.localScale = new Vector3(size, size, size);
	        rb.AddForce(new Vector3(0f, -2.5f, 0f), ForceMode.Acceleration);
	    }
	}
}
