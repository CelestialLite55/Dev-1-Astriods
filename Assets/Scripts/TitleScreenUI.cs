using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{

    public void ClickPlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ClickQuit()
    {
        Application.Quit();
    }

}
