using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] GameObject mainMenu;

    public void Play(int sceneId)

    {
        SceneManager.LoadScene(sceneId);
    }

    public void Tutorial()
    {

    }

}
