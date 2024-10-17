using UnityEngine;

public class DestroyerOnTriggerEnter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
