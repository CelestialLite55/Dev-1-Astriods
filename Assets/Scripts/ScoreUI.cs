using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text ScoreTextBox;
    public GameObject ScorePanel;
    private SpaceShip ship;

    void Start()
    {
        ship = FindFirstObjectByType<SpaceShip>();
    }

    void Update()
    {
        if (ship != null)
        {
            ScoreTextBox.text = ship.Score.ToString();
        }
    }
}
