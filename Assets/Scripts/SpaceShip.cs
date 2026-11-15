using System.Collections;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    [SerializeField] private Transform _bullet;

    [SerializeField] private int _health = 3;

    [SerializeField] private float moveForce;
    [SerializeField] private float turnPower;

    private Rigidbody2D myR82d;

    public ScreenFlash Flash;
    public Screenshake Shake;
    public int Score = 0;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myR82d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horis = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        ApplyThrust(vert);
        ApplyTurn(horis);

        if(Input .GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    private void ApplyThrust(float amount)
    {
        Vector2 thrust = transform.up * moveForce * Time.deltaTime * amount;
        myR82d.AddForce(thrust);
    }

    private void ApplyTurn(float amount)
    {
        transform.Rotate(transform.forward, turnPower * -amount * Time.deltaTime);
    }

    private void Shoot()
    {
        Instantiate(_bullet, transform.position + transform.up * 0.35f, transform.rotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage();
    }

    private void TakeDamage()
    {
        _health--;
        StartCoroutine(Flash.FlashRoutine());
        Shake.ShakeScreen();
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Hiscore", 0);
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt("Hisscore", score);
    }

    public void GameOver()
    {
        if (Score > GetHighScore())
        {
            SetHighScore(Score);
        }
    }

}
