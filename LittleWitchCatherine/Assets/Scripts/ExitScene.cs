using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    [SerializeField] private string SceneName;

    public void Exit()
    {
        SceneManager.LoadScene(SceneName);
    }
}
