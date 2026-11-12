using UnityEngine;

public class Singelton : MonoBehaviour
{
    public static Singelton instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
}
