using UnityEngine;
using UniRx;

public class HealthPointsHandler : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 3;
    private ReactiveProperty<int> _currentHealth = new();
    public ReactiveProperty<int> CurrentHealth => _currentHealth;

    void Awake()
    {
        _currentHealth.Value = _maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth.Value -= damageAmount;
        Debug.Log("current hp : " + _currentHealth.Value);

    }

}
