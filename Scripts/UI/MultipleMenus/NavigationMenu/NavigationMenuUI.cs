using UnityEngine;
using UnityEngine.UI;
public enum ButtonState
{

}
public class NavigationMenuUI : MonoBehaviour
{
    [SerializeField] private Image _inventoryButton;
    [SerializeField] private Image _characterButton;
    [SerializeField] private Image _objectivesButton;
    [SerializeField] private Image _logsButton;
    void Start()
    {
        
    }

    public void SelectButton(Image button)
    {
        button.color = new Color(234, 0, 54, 1);
   }
    public void UnselectButton(Image button)
    {
           button.color = new Color(234, 0, 54, 0);

   }
    void Update()
    {
        
    }
}
