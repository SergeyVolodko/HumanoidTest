using UnityEngine;
using System.Collections;

public class OnAsteroidCollide : MonoBehaviour {


    void OnCollisionEnter()
    {
        Destroy(gameObject);
    }
}
