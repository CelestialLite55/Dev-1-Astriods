using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void OnEnable()
    {
        StartCoroutine(DestroyAfterTime());
    }

    private void Upadte()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime; 
    }

    private IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
