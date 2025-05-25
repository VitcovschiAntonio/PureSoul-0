using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour, IUI, IPausable
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _saveButton;
    [SerializeField] private Button _loadButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitToMainButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private LoadGamePanel _loadGamePanel;
    [SerializeField] private SettingsPanel _settingsPanel;


    public UIPriority _priority => UIPriority.EscapeMenu;

    public bool _isOpen => gameObject.activeSelf;



    void Start()
    {
        _resumeButton.onClick.AddListener(Resume);
        _saveButton.onClick.AddListener(SaveGame);
        _loadButton.onClick.AddListener(OpenLoadPanel);
        _settingsButton.onClick.AddListener(OpenSettingsPanel);
        _exitToMainButton.onClick.AddListener(ExitToMenu);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void Resume()
    {
        UIManager.Instance.CloseUI();
    }
    private void SaveGame()
    {
        Debug.Log("Game is Saved");
    }
    private void OpenLoadPanel()
    {
        Debug.Log("Opens Load Game Panel");
        UIManager.Instance.OpenUI(_loadGamePanel);
    }
    private void OpenSettingsPanel()
    {
        UIManager.Instance.OpenUI(_settingsPanel);
    }
    private void ExitToMenu()
    {
        SaveGame();
        Debug.Log("Exiting to Main Menu");
    }
    private void ExitGame()
    {
        SaveGame();
        Debug.Log("Exit to Windows");
    }
    public void Close()
    {
        ResumeGame();
        gameObject.SetActive(false);
    }  

    public void Open()  
    {
        PauseGame();
        gameObject.SetActive(true);
    }

    public void PauseGame()
    {
        GamePauseManager.Instance.PauseGame();
    }

    public void ResumeGame()
    {
        GamePauseManager.Instance.ResumeGame();
    }
}
