using UnityEngine;
using System.Collections;
using System.Linq;

public class CollideTest : MonoBehaviour
{
    public float force;

    public Collider[] ownColliders;
    private Rigidbody ownRig;
    private Vector3 forceVector;
    public Character controller;

    void OnCollisionEnter(Collision col)
    {
        if (ownColliders.Contains(col.collider))
        {
            return;
        }

        if (col.gameObject.tag == "ground")
        {
            return;
        }

        if (ownRig == null)
        {
            ownRig = gameObject.GetComponent<Rigidbody>();
        }
        var target = col.gameObject.GetComponent<Rigidbody>();
        forceVector = col.relativeVelocity.normalized * force;

        switch (gameObject.tag)
        {
            case "hit":
                switch (col.gameObject.tag)
                {
                    case "hit":
                        ownRig.AddForce(forceVector / 2f, ForceMode.Impulse);
                        StopCoroutine("TimeScale");
                        StartCoroutine("TimeScale", 0.5f);
                        break;
                    case "damage":
                        ownRig.AddForce(forceVector, ForceMode.Impulse);
                        break;

                }
                break;
            case "damage":
                switch (col.gameObject.tag)
                {
                    case "hit":
                        ownRig.AddForce(forceVector, ForceMode.Impulse);
                        StopCoroutine("TimeScale");
                        StartCoroutine("TimeScale", 1f);
                        controller.Hit();
                        var particle = Resources.Load("Particle");
                        Instantiate(particle, col.contacts[0].point, Quaternion.identity);
                        break;
                    case "damage":
                        ownRig.AddForce(forceVector, ForceMode.Impulse);
                        StopCoroutine("TimeScale");
                        StartCoroutine("TimeScale", 1f);
                        var particle1 = Resources.Load("Particle");
                        Instantiate(particle1, col.contacts[0].point, Quaternion.identity);
                        controller.Hit();
                        break;

                }
                break;

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + forceVector);
    }

    private IEnumerator TimeScale(float duration)
    {

        var startTime = Time.unscaledTime;

        Time.timeScale = 0.3f;
        yield return null;
        while (Time.unscaledTime - startTime < duration)
        {
            yield return null;
        }
        Time.timeScale = 1f;
    }
}
