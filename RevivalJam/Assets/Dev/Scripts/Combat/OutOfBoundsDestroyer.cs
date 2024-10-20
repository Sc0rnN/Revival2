using Unity.VisualScripting;
using UnityEngine;

public class OutOfBoundsDestroyer : MonoBehaviour
{
    public GameObject GameObject;
    public Rigidbody body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(body.transform.position.x) > 75 || Mathf.Abs(body.transform.position.z) > 75){
            Destroy(GameObject);
        }
    }
}
