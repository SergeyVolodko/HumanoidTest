using UnityEngine;
using System.Collections;

public class CollideTest : MonoBehaviour
{
    public float force;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "damage")
        {
            var forceVector = (-transform.position + col.transform.position).normalized * force;

            col.gameObject.GetComponent<Rigidbody>().AddForce(forceVector, ForceMode.Impulse);
            gameObject.GetComponent<Rigidbody>().AddForce(-forceVector / 2f, ForceMode.Impulse);

            StopCoroutine("TimeScale");
            StartCoroutine("TimeScale");
        }
        else if (col.gameObject.tag == "ground")
        {

        }
        else if (col.gameObject.tag == "hit")
        {
            var forceVector = (-transform.position + col.transform.position).normalized * force;

            col.gameObject.GetComponent<Rigidbody>().AddForce(forceVector / 2f, ForceMode.Impulse);

            StopCoroutine("TimeScale");
            StartCoroutine("TimeScale");
        }

    }

    private IEnumerator TimeScale()
    {
        var duration = 0.5f;

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
