using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    [SerializeField] private SceneNames SceneName;
    public void Exit()
    {
        SceneManager.LoadScene(SceneName.ToString());
    }
}
