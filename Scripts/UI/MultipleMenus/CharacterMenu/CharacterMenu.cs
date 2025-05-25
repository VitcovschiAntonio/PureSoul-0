using System;
using UnityEngine;

public class CharacterMenu : MonoBehaviour, IUI, IPausable
{
    public bool _isOpen => gameObject.activeSelf;
    public UIPriority _priority => UIPriority.MultipleMenu;

    public event Action OnCharacterMenuOpened;
    public event Action OnCharacterMenuClosed;

    public void Close()
    {
        gameObject.SetActive(false);
        OnCharacterMenuClosed?.Invoke();

        GamePauseManager.Instance.ResumeGame();
        
    }

    public void Open()
    {
        gameObject.SetActive(true);
        OnCharacterMenuOpened?.Invoke();
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
