using UnityEngine;

public class KeypadUI : MonoBehaviour, IUI ,IInputDisabler
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
        GamePauseManager.Instance.DisableGameplayInput(true);
    }

    public void EnableInput()
    {
        GamePauseManager.Instance.DisableGameplayInput(false);

    }

    public void Open()
    {
        DisableInput();
        gameObject.SetActive(true);

    }
}
