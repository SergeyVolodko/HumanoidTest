using System;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class KeyboardController : MonoBehaviour
{
    public float ForceValue = 75f;
    public float Gravity = 0.85f;
    public Button jump;
    public Joystick joystick;
    private RectTransform t;
    private Rigidbody rb;

    void Start()
    {
        Physics.gravity = new Vector3(0, -Gravity, 0);
        rb = this.gameObject.GetComponent<Rigidbody>();

        if(jump != null)
            jump.onClick.AddListener(Jump);

#if !UNITY_EDITOR
        
        joystick.transform.parent.gameObject.SetActive(true);
#endif
    }

    private void Jump()
    {
        var direction = GetDirection();

        if (direction != Vector3.zero)
        {
            rb.AddForce(direction * ForceValue);
        }
    }

    void Update()
    {
        Jump();
    }

    private Vector3 GetDirection()
    {
        var direction = Vector3.zero;
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector3.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector3.right;
        }
        return direction;
#else
        if (t == null)
        {
            t = joystick.GetComponent<RectTransform>();
        }
        return new Vector3(t.anchoredPosition.x / 100f, t.anchoredPosition.y / 100f, 0);
#endif



    }
}
