using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _body;
    
    public float accelerationSpeed = .1f;
    public float maxSpeed = 10f;
    
    public float ySpeed = 5f;
    public float rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float angle = transform.rotation.eulerAngles.z;
        
        if (!Input.GetKey(KeyCode.UpArrow))
        {
            if (angle >= 330F)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle + rotationSpeed / 2);
            }
            else if (angle <= 30)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle - rotationSpeed / 2);
            }
        }

        if (angle is < 330 and > 30)
        {
            if (angle > 180) {
                transform.rotation = Quaternion.Euler(0, 0, angle + rotationSpeed);
            }
            else {
                transform.rotation = Quaternion.Euler(0, 0, angle - rotationSpeed);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _body.velocity += new Vector2(0, ySpeed);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _body.velocity += new Vector2(0, -ySpeed);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && _body.velocity.x > -maxSpeed)
        {
            _body.velocity += new Vector2(-accelerationSpeed, 0);
            if (Input.GetKey(KeyCode.UpArrow) && angle is > 330 or < 30)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle - rotationSpeed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) && _body.velocity.x < maxSpeed)
        {
            _body.velocity += new Vector2(accelerationSpeed, 0);
            if (Input.GetKey(KeyCode.UpArrow) && angle is > 330 or < 30)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle + rotationSpeed);
            }
        }
    }
}
