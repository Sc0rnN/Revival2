using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateTowardsMouseAndMove : MonoBehaviour
{
    [SerializeField] private Plane plane = new Plane(Vector3.up, 0);
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private float velocity = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotateObjectTowardsMouse();

        MoveObjectForward();

        Debug.Log(rb.GetAccumulatedForce());
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
}
