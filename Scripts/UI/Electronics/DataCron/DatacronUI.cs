using TMPro;
using UnityEngine;

public class DatacronUI : MonoBehaviour, IUI ,IInputDisabler
{
    public UIPriority _priority => UIPriority.ElectronicsUI;

    public bool _isOpen => gameObject.activeSelf;

    public void Close()
    {
        EnableInput();
        gameObject.SetActive(false);
    }

    public void DisableInput()
    {
        GamePauseManager.Instance.PauseGame();
    }

    public void EnableInput()
    {
        GamePauseManager.Instance.ResumeGame();

    }

    public void Open()
    {
        DisableInput();
        gameObject.SetActive(true);

    }
}
