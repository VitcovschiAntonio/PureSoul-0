using UnityEngine;

public class Keypad : MonoBehaviour, IInteractable
{
    [SerializeField] private KeypadUI _ui;

    public void Interact()
    {
        UIManager.Instance.OpenUI(_ui);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
