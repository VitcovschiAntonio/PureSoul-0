using UnityEngine;
using UnityEngine.UI;

public class Infolink : MonoBehaviour
{
    [SerializeField] private InfolinkUI _ui;
    [SerializeField] Texture2D _portret;
    [SerializeField] string _name;
    [SerializeField] string _dialogue;
    


    private void OnTriggerEnter(Collider other) // Changed to OnTriggerEnter
    {
        if (other.CompareTag("Player")) // Using CompareTag is more efficient
        {
            if(_ui._isOpen)
            {
                return;
            }
            _ui.InitialiseInfoLink(_portret, _name, _dialogue);
            UIManager.Instance.OpenUI(_ui);
        }
    }
    
    
}
