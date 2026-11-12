using System.Collections;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _rockPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(gameObject.name);
        StartCoroutine(Spawn());
    }

  

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(_rockPrefab.gameObject, _spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _spawnPoint.position);
    }
}
