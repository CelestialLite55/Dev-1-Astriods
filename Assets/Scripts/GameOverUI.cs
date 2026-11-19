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
        gameObject.SetActive(false);
        //Hide();
    }

    public void Show(bool celebrateHIScore)
    {
        ScorePanel.SetActive(true);
        Celebrate.SetActive(celebrateHIScore);
        HiScoreTextBox.enabled = true; 
    }

    public void Hide()
    {
        ScorePanel.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (ship != null)
        {
            ScoreTextBox.text = ship.Score.ToString();
            HiScoreTextBox.text = ship.GetHighScore().ToString();
        }
    }
}
