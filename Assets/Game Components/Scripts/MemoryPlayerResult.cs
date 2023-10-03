using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryPlayerResult : MonoBehaviour
{
    [SerializeField] private GameObject _loseWindow;
    [Header("Name")]
    [SerializeField] private TMP_Text _namesTextField;
    [Header("Level")]
    [SerializeField] private TMP_Text _levelsTextField;
    [Header("Stones")]
    [SerializeField] private TMP_Text _stonesTextField;

    private void Start()
    {
        _loseWindow.SetActive(false);
    }

    public void AddNameToField(string name)
    {
        _namesTextField.text += $"\n{name}";
    }

    public void AddLevelToField(float level)
    {
        int lvl = (int)level;
        _levelsTextField.text += $"\n{ lvl}";
    }

    public void AddStonesToField(int stonesEated)
    {
        _stonesTextField.text += $"\n{stonesEated}";
    }

    public void ShowResultsWindow()
    {
        Time.timeScale = 0f;
        _loseWindow.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}