using UnityEngine;
using UniRx;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private string _keyTrigger;
    [SerializeField] private float gravityMultiplier = 10f;

    private void Start()
    {
        KeyCode triggerKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), _keyTrigger);

        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(triggerKey))
            .Subscribe(_ => Fire())
            .AddTo(this);
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
        MoveForward moveForward = projectile.GetComponent<MoveForward>();

        moveForward.SetDirection(transform.forward);
    }
}
