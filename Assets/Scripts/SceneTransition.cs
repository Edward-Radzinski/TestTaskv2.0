using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void ScenesTransition(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
