using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class CoolDownShower : MonoBehaviour
{
    [SerializeField] private Image _cooldownImage;

    private void Start()
    {
        Shoot shootScript = GetComponent<Shoot>();
        shootScript.CooldownProgress
            .Subscribe(progress =>
            {
                _cooldownImage.fillAmount = progress;
                _cooldownImage.enabled = progress < 1f;
            })
            .AddTo(this);
    }
}
