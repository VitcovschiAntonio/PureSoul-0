using System;
using UnityEngine;

public class ObjectivesMenu : MonoBehaviour, IUI, IPausable
{
    public bool _isOpen => gameObject.activeSelf;
    public UIPriority _priority => UIPriority.MultipleMenu;

    public event Action OnObjectivesMenuOpened;
    public event Action OnObjectivesMenuClosed;

    public void Close()
    {
        OnObjectivesMenuClosed?.Invoke();
        gameObject.SetActive(false);
        GamePauseManager.Instance.ResumeGame();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        OnObjectivesMenuOpened?.Invoke();

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
