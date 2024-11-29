using UnityEngine;

public class DataPersistance : MonoBehaviour
{
    public static DataPersistance instance;

    public string playerName;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
