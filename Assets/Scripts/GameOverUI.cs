using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TMP_Text ScoreTextBox, HiScoreTextBox;
    public GameObject ScorePanel, Celebrate;
    private SpaceShip ship;

    public void ClickPlayAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ClickMainMenu()
    {
        SceneManager.LoadScene("Title");
    }

    void Start()
    {
        ship = FindFirstObjectByType<SpaceShip>();
        //HideFlags();
    }

    public void Show(bool celebrateHIScore)
    {
        ScorePanel.SetActive(true);
    }

    public void Hide()
    {
        ScorePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
