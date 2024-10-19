using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;
using UniRx;

public class CameraShakerOnEvent : MonoBehaviour
{
    [SerializeField] private HealthPointsHandler hpPlayer;

    private const float DecreaseFactor = 1f;
    private const float OriginalShakeDuration = 0.3f;
    private const float ShakeFactor = 0.3f;

    private Vector3 _originalPosition;
    private Transform _transformCamera;

    private void Start()
    {
        _transformCamera = gameObject.transform;
        _originalPosition = _transformCamera.localPosition;
        Debug.Log(hpPlayer);

        if (hpPlayer != null)
        {
            hpPlayer.CurrentHealth
                .Subscribe(_ => ShakeCamera(OriginalShakeDuration))
                .AddTo(this);
        }
    }

    private void ShakeCamera(float duration)
    {
        Debug.Log("Shake");
        StartCoroutine(ShakeCoroutine(duration));
    }

    private System.Collections.IEnumerator ShakeCoroutine(float duration)
    {
        while (duration > 0)
        {
            _transformCamera.localPosition = _originalPosition + Random.insideUnitSphere * ShakeFactor;
            duration -= Time.deltaTime * DecreaseFactor;
            yield return null;
        }
        _transformCamera.localPosition = _originalPosition;
    }
}
