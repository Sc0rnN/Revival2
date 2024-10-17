using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class GameObjectOnScreenFollower : MonoBehaviour
{
    [SerializeField] private Image cooldownImage; 
    [SerializeField] private Camera mainCamera;  

    private RectTransform cooldownImageRectTransform;

    private void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main; 
        }

        cooldownImageRectTransform = cooldownImage.GetComponent<RectTransform>();

        Observable.EveryLateUpdate()
            .Subscribe(_ => UpdateCooldownPosition())
            .AddTo(this);
    }

    private void UpdateCooldownPosition()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);

        if (screenPos.z > 0)
        {
            cooldownImageRectTransform.position = screenPos;
            cooldownImage.gameObject.SetActive(true);
        }
        else
        {
            cooldownImage.gameObject.SetActive(false);
        }
    }
}
