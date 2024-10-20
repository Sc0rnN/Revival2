using UnityEngine;
using UnityEngine.Events;

public class DammageOnTriggerEnger : MonoBehaviour
{
    private GameObject _creator;

    public UnityEvent onPlayerHit; // Ajouter un UnityEvent

    public void DefineCreator(GameObject creator)
    {
        _creator = creator;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _creator) return;

        HealthPointsHandler hpHandler = other.GetComponent<HealthPointsHandler>();

        if (hpHandler == null)
        {
            hpHandler = other.GetComponentInParent<HealthPointsHandler>();
        }

        if (hpHandler != null)
        {
            hpHandler.TakeDamage(1);
        }

        if (!other.gameObject.CompareTag("EnnemyControlZone") || !other.gameObject.CompareTag("Island"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            onPlayerHit?.Invoke();
        }

        if (gameObject.CompareTag("Island"))
        {
            hpHandler.TakeDamage(100);
        }
    }
}
