using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Rock : MonoBehaviour
{
    [SerializeField] private Vector2Int _rockAmount; 
    [SerializeField] private Transform[] _smallerRocks;
    [SerializeField] private float _smallRockSpeed = 5f;
    [SerializeField] private float _speed;

    [SerializeField] private IntChannel _addScoreChannel;

    public int ScoreValue = 10;

   
    public void Explode()
    {
        SpaceShip ship = FindFirstObjectByType<SpaceShip>();
        if (ship != null)
        {
            {
                ship.Score += ScoreValue;
            }
            if (ship.Score >= 10)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            return;
        }

        _addScoreChannel.RasieEvent(4);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        int rng = UnityEngine.Random.Range(_rockAmount.x, _rockAmount.y + 1);

        for (int i = 0; i < rng; i++)
        {
            float randomXPos = UnityEngine.Random.Range(-1f, 1f);
            float randomYPos = UnityEngine.Random.Range(-1f, 1f);

            Vector2 randomOffset = new Vector2(randomXPos, randomYPos);

            Rigidbody2D rb = Instantiate(_smallerRocks[UnityEngine.Random.Range(0, _smallerRocks.Length)],
               transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();

            float randomX = UnityEngine.Random.Range(-1f, 1f);
            float randomY = UnityEngine.Random.Range(-1f, 1f);

            Vector2 randomVector = new Vector2(randomX, randomY);

            randomVector.Normalize();

            rb.AddForce(randomVector * _smallRockSpeed, ForceMode2D.Impulse);
        }

        Explode();
    }


    // private void OnEnable()
    // {
    //     StartCoroutine(DestroyAfterTime());
    // }
    // private IEnumerator DestroyAfterTime()
    // {
    //     yield return new WaitForSeconds(5f);
    //     Destroy(gameObject);
    // }
}
