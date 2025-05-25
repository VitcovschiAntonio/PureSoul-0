using UnityEngine;

public class PC : MonoBehaviour, IInteractable
{
    [SerializeField] private PCUI _ui;
    public void Interact()
    {
        UIManager.Instance.OpenUI(_ui);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
