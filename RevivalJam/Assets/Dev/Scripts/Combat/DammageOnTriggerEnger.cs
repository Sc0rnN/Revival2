using UnityEngine;

public class DammageOnTriggerEnger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        HealthPointsHandler hpHeandler = other.GetComponent<HealthPointsHandler>();
        GameObject creator = other.GetComponent<CreatorRememberer>()?.Creator;

        if(hpHeandler != null)
        {
            Debug.Log("components ok");
            if(creator != other.gameObject || creator == null)
            {
                Debug.Log("dammaged !");
                hpHeandler.TakeDamage(1);
            }         
        }
        
    }
}
