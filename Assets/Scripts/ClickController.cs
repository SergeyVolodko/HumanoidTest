using UnityEngine;
using System.Collections;

public class ClickController : MonoBehaviour
{
    public float ForceValue = 200f;
    public float Gravity = 0.85f;

    private Rigidbody rb;
    private Transform cachedTransform;

    private void Start()
    {
        Physics.gravity = new Vector3(0, -Gravity, 0);
        rb = this.gameObject.GetComponent<Rigidbody>();
        cachedTransform = transform;
    }


    private void Jump()
    {
        var direction = GetDirection();

        if (direction != Vector3.zero)
        {
            rb.AddForce(direction * ForceValue, ForceMode.Force);
        }
    }

    private Vector3 GetDirection()
    {
        var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - cachedTransform.position;
        dir.z = 0f;
        return dir.normalized;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Jump();
        }

        if (Input.touchCount == 3)
        {
            Application.LoadLevel("Crab");
        }
    }
}
