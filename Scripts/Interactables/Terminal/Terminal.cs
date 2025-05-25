using UnityEngine;

public class Terminal : MonoBehaviour, IInteractable
{
 
    [SerializeField] private TerminalUI _ui;
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
