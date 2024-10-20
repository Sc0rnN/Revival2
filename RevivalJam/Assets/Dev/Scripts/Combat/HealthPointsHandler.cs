using UnityEngine;
using UniRx;

public class HealthPointsHandler : MonoBehaviour
{
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject HealthBar;
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
        if (CompareTag("Player")) { UiHealthHandler(_currentHealth.Value); }
        if (_currentHealth.Value <= 0)
        {
            GameOver();

        }
    }

    public void GameOver()
    {
        if (CompareTag("Player"))
        {
            Destroy(gameObject);
            GameOverMenu.SetActive(true);
        }
       

    }

    public void UiHealthHandler(int health)
    {
        for (int i = 0; i <= _maxHealth; i++)
        {
            if ( i> health)
            {
                HealthBar.transform.GetChild(2*i - 1).gameObject.SetActive(false);
            }
        }
    }


}
