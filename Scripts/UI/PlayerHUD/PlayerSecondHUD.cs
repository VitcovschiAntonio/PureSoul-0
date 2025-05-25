using UnityEngine;

public class PlayerSecondHUD : MonoBehaviour, IUI
{
    public UIPriority _priority => UIPriority.SecondHUD;

    public bool _isOpen => gameObject.activeSelf;

    public void Close()
    {
        gameObject.SetActive(false);
        
    }

    public void Open()
    {
        gameObject.SetActive(true);

    }
}
