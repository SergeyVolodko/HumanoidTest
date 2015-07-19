using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    public Collider[] ownColliders;
    public int winHitCount = 10;
    public int hit;



    public void Hit()
    {
        hit++;

        if (hit == winHitCount)
        {
            var rigs = gameObject.GetComponentsInChildren<Joint>();

            foreach (var joint in rigs)
            {
                joint.breakForce = 2;
            }
        }
        


    }

    private void Start()
    {
        ownColliders = gameObject.GetComponentsInChildren<Collider>();

        var collideTests = gameObject.GetComponentsInChildren<CollideTest>();

        foreach (var collideTest in collideTests)
        {
            collideTest.ownColliders = ownColliders;
            collideTest.controller = this;
            collideTest.force = 2.5f;
        }

        //var rigs = gameObject.GetComponentsInChildren<Rigidbody>();

        //foreach (var rig in rigs)
        //{
        //    rig.drag = rig.mass;
        //}
    }
}
