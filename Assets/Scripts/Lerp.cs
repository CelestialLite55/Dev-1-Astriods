using System.Collections;
using UnityEngine;

public class Lerp : MonoBehaviour
{
    float currentValue = 0f;
    float endValue = 1f;
    float moveSpeed = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DemoRoutine());
    }

    private IEnumerator DemoRoutine()
    {
        while (true)
        {
            Debug.Log("I run forever!");
            yield return new WaitForEndOfFrame();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue < endValue)
        {
            currentValue += moveSpeed * Time.deltaTime;
        }
    }
}
