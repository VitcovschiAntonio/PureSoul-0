using System;
using UnityEngine;

public class InventoryMenu : MonoBehaviour , IUI, IPausable
{
    public bool _isOpen => gameObject.activeSelf;
    public UIPriority _priority => UIPriority.MultipleMenu;

    public event Action OnInventoryMenuOpened;
    public event Action OnInventoryMenuClosed;

    public void Close()
    {
        OnInventoryMenuClosed?.Invoke();
        gameObject.SetActive(false);
        GamePauseManager.Instance.ResumeGame();
    }

    public void Open()
    {
        gameObject.SetActive(true);
        OnInventoryMenuOpened?.Invoke();
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
