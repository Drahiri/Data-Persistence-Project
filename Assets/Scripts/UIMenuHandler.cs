#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIMenuHandler : MonoBehaviour
{
    public TMP_InputField nameField;
    public TextMeshProUGUI highscoreText;

    private void Awake()
    {
        highscoreText.text = "Score: " + PersistenceData.instance.highScorePlayerName + ": " + PersistenceData.instance.highScore;
        nameField.text = PersistenceData.instance.currentPlayerName;
    }

    public void StartGame()
    {
        PersistenceData.instance.currentPlayerName = nameField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PersistenceData.instance.SaveHighscore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
