using UnityEngine;
using UniRx;

public class AfterDelayDestroyer : MonoBehaviour
{
    [SerializeField] private float _delayInSeconds = 0.6f;
    private void Start()
    {
        Observable.Timer(System.TimeSpan.FromSeconds(_delayInSeconds))
            .Subscribe(_ => Destroy(gameObject))
            .AddTo(this); 
    }

}
