using UnityEngine;

public class Datacron : MonoBehaviour, IInteractable
{

    [SerializeField] private DatacronUI _ui;
    public void Interact()
    {
        UIManager.Instance.OpenUI(_ui);
    }

 
}
