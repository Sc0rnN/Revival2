using UnityEngine;

public class CreatorRememberer : MonoBehaviour
{
    [SerializeField] private GameObject _creator;
    public GameObject Creator => _creator;

    public void DefineCreator(GameObject creator)
    {
        _creator = creator;
    }

}
