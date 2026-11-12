using UnityEngine;

public class SinWaveMove : MonoBehaviour
{
    [SerializeField] private float _amp;
    
    private Vector3 _startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0f,Mathf.Sin(Time.time), 0f) * _amp;
        transform.position = _startPosition + offset;
    }
}
