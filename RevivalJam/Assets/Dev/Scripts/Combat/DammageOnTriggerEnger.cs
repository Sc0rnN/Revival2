using UnityEngine;

public class DammageOnTriggerEnger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HealthPointsHandler hpHeandler = other.GetComponent<HealthPointsHandler>();
        GameObject creator = other.GetComponent<CreatorRememberer>()?.Creator;

        if(hpHeandler != null)
        {
            if(creator != other.gameObject || creator == null)
            {
                hpHeandler.TakeDamage(1);
            }         
        }
        
    }
}
