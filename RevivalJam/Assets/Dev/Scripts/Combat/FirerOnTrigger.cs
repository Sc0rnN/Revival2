using UnityEngine;
using System.Collections;
using UniRx;

public class FirerOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _canon;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player detected");
            StartCoroutine(FireAfterDelay(0.5f));
        }
    }

    private IEnumerator FireAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Fire();
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(_projectile, _canon.transform.position, Quaternion.identity);
        MoveForward moveForward = projectile.GetComponent<MoveForward>();
        moveForward.SetDirection(transform.forward);
        projectile.GetComponent<CreatorRememberer>().DefineCreator(transform.parent.parent.gameObject);
        Debug.Log(transform.parent.parent.gameObject);
    }
}
