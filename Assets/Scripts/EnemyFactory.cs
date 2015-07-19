using System;
using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour
{
    public Transform Player;

    private float y = 8f;
    private System.Random random;

	void Start () {
        random = new System.Random();
	}
	
	
	void Update () {
	    switch (random.Next(150))
	    {
            case 10:
	            CreateBox();
	            break;
	    }
	}

    private void CreateBox()
    {
        var cube  = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(random.Next(-4, 4), y, 0);
        cube.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        var rb = cube.gameObject.AddComponent<Rigidbody>();
        cube.gameObject.AddComponent<BoxCollider>();
        rb.mass = 0.5f;
        var direction = GetDirection(cube.transform.position);
        rb.AddForce(direction*75f);
        rb.AddTorque(UnityEngine.Random.insideUnitSphere);
        cube.gameObject.AddComponent<OnAsteroidCollide>();
    }


    private Vector3 GetDirection(Vector3 position)
    {
        return (Player.position - position).normalized;
    }
}
