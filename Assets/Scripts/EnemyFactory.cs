using System;
using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour
{
    public Transform Player;

    private float y = 11.0f;
    private System.Random random;

	void Start () {
        random = new System.Random();
        CreateAsteroid();
	}
	
	
	void Update () {
	    switch (random.Next(400))
	    {
            case 10:
	            CreateAsteroid();
	            break;
	    }
	}

    private void CreateAsteroid()
    {
        var asteroid  = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        asteroid.transform.position = new Vector3(UnityEngine.Random.Range(-5f, 5f), y, 0);
        var size = UnityEngine.Random.Range(0.4f, 0.75f);
        asteroid.transform.localScale = new Vector3(size, size, size);
        var rb = asteroid.gameObject.AddComponent<Rigidbody>();
        asteroid.gameObject.AddComponent<SphereCollider>();
        rb.mass = size;


        var velocity = UnityEngine.Random.Range(-1.1f, -2.5f);
        rb.velocity = new Vector3(0.0f, velocity, 0.0f);
        rb.useGravity = false;
        //var direction = GetDirection(asteroid.transform.position);
        //rb.AddForce(direction*75f);

        asteroid.gameObject.AddComponent<OnAsteroidCollide>();
        asteroid.gameObject.AddComponent<OnAsteroidEnteredAtmosphere>();
        
    }


    private Vector3 GetDirection(Vector3 position)
    {
        return (Player.position - position).normalized;
    }
}
