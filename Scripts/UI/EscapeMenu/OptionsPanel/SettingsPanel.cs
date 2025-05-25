using UnityEngine;

public class SettingsPanel : MonoBehaviour, IUI
{
      public UIPriority _priority => UIPriority.EscapeMenuPanels;

    public bool _isOpen => gameObject.activeSelf;

    public void Close() =>  gameObject.SetActive(false);
    public void Open()  
    {
        gameObject.SetActive(true);
    }
}
