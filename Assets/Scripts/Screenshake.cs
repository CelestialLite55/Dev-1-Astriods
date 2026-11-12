using System;
using System.Collections;
using UnityEngine;

public class Screenshake : MonoBehaviour
{
    private float _ShakeAmount = 1.0f;
    [SerializeField] private float _ShakeDelay = 0.001f;

    private int Iterations = 5;

    private Coroutine _Coroutine;

    public void ShakeScreen()
    {
        if(_Coroutine != null)
        {
            return;
        }

        _Coroutine = StartCoroutine(ShakeRoutine());
    }

    public IEnumerator ShakeRoutine()
    {
        Vector3 originalPos = transform.position;
        for (int n = 0; n < Iterations; n++)
        {
            Vector3 pos = UnityEngine.Random.insideUnitCircle * _ShakeAmount;
            transform.position = transform.position + pos;
            yield return new WaitForSeconds(_ShakeDelay);
        }
        transform.position = originalPos;
        yield return null;

        _Coroutine = null;
    }
}
