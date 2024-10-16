using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _velocity = 5f;
    [SerializeField] private Vector3 _originalDirection = new Vector3(1, 0, 0);

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        _rb.linearVelocity = _originalDirection * _velocity;
    }

    public void SetDirection(Vector3 direction)
    {
        _originalDirection = direction;
    }

}