using UnityEngine;
using System.Collections;
using UniRx;

public class FirerOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private GameObject _canon;
    [SerializeField] private float _xOffset = 1f;
    [SerializeField] private float _projectileDirection = 1f;
    private bool _hasShot = true;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
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
        if(_hasShot)
        {
            _hasShot = false;
            Vector3 spawnPosition = transform.position + (transform.forward * _xOffset);
            GameObject projectile = Instantiate(_projectile, spawnPosition, transform.rotation);

            MoveForward moveForward = projectile.GetComponent<MoveForward>();
            moveForward.SetDirection(transform.forward * _projectileDirection);

            projectile.GetComponent<DammageOnTriggerEnger>().DefineCreator(gameObject);
        }
       
    }

}
