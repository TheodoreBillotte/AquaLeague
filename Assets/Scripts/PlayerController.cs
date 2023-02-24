using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _body;
    private Vector3 _startPosition;
    
    public float accelerationSpeed = 15f;
    public float maxSpeed = 20f;
    
    public float ySpeed = 5f;
    public float rotationSpeed = 200f;
    
    [SerializeField] private KeyCode _upKey = KeyCode.UpArrow;
    [SerializeField] private KeyCode _downKey = KeyCode.DownArrow;
    [SerializeField] private KeyCode _leftKey = KeyCode.LeftArrow;
    [SerializeField] private KeyCode _rightKey = KeyCode.RightArrow;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = transform.rotation.eulerAngles.z;
        
        if (!Input.GetKey(_upKey))
        {
            if (angle >= 330F)
            {
                transform.rotation = Quaternion.Euler(0, 0, (angle + rotationSpeed * Time.deltaTime / 2));
            }
            else if (angle <= 30)
            {
                transform.rotation = Quaternion.Euler(0, 0, (angle - rotationSpeed * Time.deltaTime / 2));
            }
        }

        if (angle is < 330 and > 30)
        {
            if (angle > 180) {
                transform.rotation = Quaternion.Euler(0, 0, (angle + rotationSpeed * Time.deltaTime));
            }
            else {
                transform.rotation = Quaternion.Euler(0, 0, (angle - rotationSpeed * Time.deltaTime));
            }
        }
        
        if (Input.GetKeyDown(_upKey))
        {
            _body.velocity += new Vector2(0, ySpeed);
        }

        if (Input.GetKeyDown(_downKey))
        {
            _body.velocity += new Vector2(0, -ySpeed);
        }

        if (Input.GetKey(_leftKey) && _body.velocity.x > -maxSpeed)
        {
            _body.velocity += new Vector2(-accelerationSpeed, 0) * Time.deltaTime;
            if (Input.GetKey(_upKey) && angle is > 330 or < 30)
            {
                transform.rotation = Quaternion.Euler(0, 0, (angle - rotationSpeed * Time.deltaTime));
            }
        }

        if (Input.GetKey(_rightKey) && _body.velocity.x < maxSpeed)
        {
            _body.velocity += new Vector2(accelerationSpeed, 0) * Time.deltaTime;
            if (Input.GetKey(_upKey) && angle is > 330 or < 30)
            {
                transform.rotation = Quaternion.Euler(0, 0, (angle + rotationSpeed * Time.deltaTime));
            }
        }
    }
    
    public void ResetPosition()
    {
        transform.position = _startPosition;
        _body.velocity = new Vector2(0, 0);
        _body.rotation = 0;
    }
}
