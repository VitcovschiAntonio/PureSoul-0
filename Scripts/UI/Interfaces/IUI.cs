using UnityEngine;
public enum UIPriority{
    EscapeMenu = 0,    // e.g., PlayerHUD
    EscapeMenuPanels = 1,       // e.g., SecondUI (TAB)
    MultipleMenu = 2,    // e.g., Inventory, Objectives
    MultipleMenuPanels = 3,
    ElectronicsUI = 4,
    ElectronicsUIPanels = 5,      // e.g., Terminal, PC, Keypad
    SecondHUD = 6,
    InfoLink = 7
}

public interface IUI 
{
    public bool _isOpen { get; }
    public UIPriority _priority { get; }
    public void Open();
    public void Close();

}
