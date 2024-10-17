using UnityEngine;
using UniRx;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private string _keyTrigger;
    [SerializeField] private float _cooldownDuration = 2f; 
    public ReactiveProperty<float> CooldownProgress { get; private set; } = new ReactiveProperty<float>(1f);

    private bool _canShoot = true;

    private void Start()
    {
        KeyCode triggerKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), _keyTrigger);

        Observable.EveryUpdate()
            .Where(_ => Input.GetKeyDown(triggerKey) && _canShoot)
            .Subscribe(_ => Fire())
            .AddTo(this);
    }

    private void Fire()
    {
        Debug.Log("Fire !");
        GameObject projectile = Instantiate(_projectile, transform.position, transform.rotation);
        MoveForward moveForward = projectile.GetComponent<MoveForward>();
        moveForward.SetDirection(transform.forward);

        _canShoot = false;
        CooldownProgress.Value = 0f;

        float elapsedTime = 0f;

        Observable.EveryUpdate()
            .TakeUntil(Observable.Timer(System.TimeSpan.FromSeconds(_cooldownDuration)))
            .Subscribe(_ =>
            {
                elapsedTime += Time.deltaTime;

                CooldownProgress.Value = Mathf.Clamp01(elapsedTime / _cooldownDuration);
            },
            () =>
            {
                _canShoot = true;
                CooldownProgress.Value = 1f; 
            })
            .AddTo(this);
    }

}
