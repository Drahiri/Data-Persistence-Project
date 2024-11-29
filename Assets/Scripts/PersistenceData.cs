using UnityEngine;

public class PersistenceData : MonoBehaviour
{
    public static PersistenceData instance;

    public string playerName;
    public string highScorePlayerName;
    public int highScore;

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
