using System;
using UnityEngine;

public class LogsMenu : MonoBehaviour, IUI, IPausable
{
    public bool _isOpen => gameObject.activeSelf;
    public UIPriority _priority => UIPriority.MultipleMenu;

    public event Action OnLogsMenuOpened;
    public event Action OnLogsMenuClosed;


    public void Close()
    {
        OnLogsMenuClosed?.Invoke();
        gameObject.SetActive(false);
        GamePauseManager.Instance.ResumeGame();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        OnLogsMenuOpened?.Invoke();
        GamePauseManager.Instance.PauseGame();

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
