using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateTowardsMouseAndMove : MonoBehaviour
{
    [SerializeField] private Plane plane = new Plane(Vector3.up, 0);
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private float velocity = 5f;

    private Rigidbody rb;
    public int PlayerMovementSpeed = 5;
    public int PlayerMovementSpeedWindy = 10;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //RotateObjectTowardsMouse();
        //MoveObjectForward();
        MovePlayer();
    }

    void RotateObjectTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);
            Vector3 direction = (targetPoint - transform.position).normalized;

            direction.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void MoveObjectForward()
    {
        rb.linearVelocity = transform.forward * velocity;
    }

    public void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal") ;
        float verticalInput = 1f;
        float movementSpeed;
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 player_Direction = transform.right * horizontalInput + transform.forward * verticalInput;
        Quaternion targetRotation = Quaternion.LookRotation(player_Direction);
        if (Input.GetKey(KeyCode.Space))
        {
            movementSpeed = PlayerMovementSpeedWindy;
        }
        else
        {
            movementSpeed = PlayerMovementSpeed;
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


    }
}
