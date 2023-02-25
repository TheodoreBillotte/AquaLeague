using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _body;
    private Vector3 _startPosition;
    
    public int jump = 1;
    private float _fallTime;
    private bool _canFall = true;
    
    public float accelerationSpeed = 15f;
    public float maxXSpeed = 20f;
    public float maxYSpeed = 10f;
    
    public float ySpeed = 5f;
    public float rotationSpeed = 200f;
    public int jumpAmount = 1;
    
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

        if (!_canFall)
        {
            _fallTime += Time.deltaTime;
            if (_fallTime > .5f)
            {
                _canFall = true;
                _fallTime = 0;
            }
        }

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
            if (jump > 0)
            {
                float yMovement = Mathf.Clamp(_body.velocity.y + ySpeed, -maxYSpeed, maxYSpeed);
                _body.velocity = new Vector2(_body.velocity.x, yMovement);
                jump -= 1;
            }
        }

        if (Input.GetKeyDown(_downKey) && _canFall)
        {
            float yMovement = Mathf.Clamp(_body.velocity.y - ySpeed, -maxYSpeed, maxYSpeed);
            _body.velocity = new Vector2(_body.velocity.x, yMovement);
            _canFall = false;
        }

        if (Input.GetKey(_leftKey))
        {
            float xMovement = Mathf.Clamp(_body.velocity.x - accelerationSpeed, -maxXSpeed, maxXSpeed);
            _body.velocity += new Vector2(xMovement, 0) * Time.deltaTime;
            if (Input.GetKey(_upKey) && angle is > 330 or < 30)
            {
                transform.rotation = Quaternion.Euler(0, 0, (angle - rotationSpeed * Time.deltaTime));
            }
        }

        if (Input.GetKey(_rightKey))
        {
            float xMovement = Mathf.Clamp(_body.velocity.x + accelerationSpeed, -maxXSpeed, maxXSpeed);
            _body.velocity += new Vector2(xMovement, 0) * Time.deltaTime;
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
        
        transform.rotation = Quaternion.Euler(0, 0, 0);
        jump = jumpAmount;
        _canFall = true;
        _fallTime = 0;
    }
}
