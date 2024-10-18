using UnityEngine;
using UniRx;

[RequireComponent(typeof(HealthPointsHandler))]
public class NoHpDestroyer : MonoBehaviour
{
    void Start()
    {
        GetComponent<HealthPointsHandler>().CurrentHealth
            .Where(currentHp => currentHp <= 0)
            .Subscribe(_ => Destroy(gameObject))
            .AddTo(this);
    }
}
