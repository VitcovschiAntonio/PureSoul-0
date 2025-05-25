using System;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    [Header("Dependencies")]
    [SerializeField] private PlayerInput _input;
    [Header("Menu References")]
    [SerializeField] private NavigationMenu _navMenu;
    [SerializeField] private GameObject _multipleMenusParent;
    [SerializeField] private EscapeMenu _escapeMenu;
    [SerializeField] private InventoryMenu _inventoryMenu;
    [SerializeField] private CharacterMenu _characterMenu;
    [SerializeField] private ObjectivesMenu _objectivesMenu;
    [SerializeField] private LogsMenu _logsMenu;
    [SerializeField] private PlayerSecondHUD _playerSecondHUD;

    private Stack<IUI> _uiStack = new Stack<IUI>();
    
    private void Awake()
    {
        if (Instance != null && Instance != this) 
            Destroy(gameObject);
        else 
            Instance = this;
    }

    void Start()
    {
        _navMenu.Initialize(); // Force early subscription
        SubscribeToEvents();
    } 

    private void SubscribeToEvents()
    {
        _input.On_I_Pressed += TryOpenInventory;
        _input.On_K_Pressed += TryOpenCharacter;
        _input.On_O_Pressed += TryOpenObjectives;
        _input.On_L_Pressed += TryOpenLogs;
        _input.On_TAB_Pressed += ToggleSecondHUD;
        _input.On_TAB_Released += CloseSecondHUD;
        _input.On_ESC_Pressed += HandleEscapeKey;
    }

    private void CloseSecondHUD()
    {
        if(_uiStack.Count == 1 &&_uiStack.Peek()._priority == UIPriority.SecondHUD)
        {
            CloseUI();
            return;
        }
        else
        {
            return;
        }
    }

    public void CloseUI()
    {
        if(_uiStack.Count > 0 && _uiStack.Peek()._priority != UIPriority.InfoLink)
        {
            if(_uiStack.Peek()._priority == UIPriority.MultipleMenu)
            {
            _multipleMenusParent.SetActive(false);

            }
            _uiStack.Peek().Close();
            _uiStack.Pop();
            return;
        }
    }
    
    public void CloseInfoLink()
    {

        _uiStack.Pop();
    }

    public void OpenUI(IUI UI)
    {
        // First handle EscapeMenu cases
        if (UI._isOpen)
        {
            return;
    }
    if (UI._priority == UIPriority.EscapeMenu)
            {
                UI.Open();
                _uiStack.Push(UI);
                return;
            }

    // Then handle EscapeMenuPanels only if there's an EscapeMenu open
    if (UI._priority == UIPriority.EscapeMenuPanels)
    {
        if (_uiStack.Count > 0 && _uiStack.Peek()._priority == UIPriority.EscapeMenu)
        {
            UI.Open();
            _uiStack.Push(UI);
            return;
        }
    }

    // Handle empty stack cases
    if (_uiStack.Count == 0)
    {
        if (UI._priority == UIPriority.SecondHUD)
        {
            UI.Open();
            _uiStack.Push(UI);
            return;
        }

        if (UI._priority == UIPriority.MultipleMenu)
        {
            _multipleMenusParent.SetActive(true);
            UI.Open();
            _uiStack.Push(UI);
            return;
        }

        if(UI._priority == UIPriority.ElectronicsUI)
        {
            UI.Open();
            _uiStack.Push(UI);
            return;
        }
        if(UI._priority == UIPriority.InfoLink)
        {
            UI.Open();
            _uiStack.Push(UI);
            return;
        }
    }

    // Handle MultipleMenu cases when stack isn't empty
    if (_uiStack.Count > 0)
    {
        if (UI._priority == UIPriority.MultipleMenu && 
            _uiStack.Peek()._priority == UIPriority.MultipleMenu)
        {
            CloseUI();
            _multipleMenusParent.SetActive(true);
            UI.Open();
            _uiStack.Push(UI);
            return;
        }
        
        if (_uiStack.Peek()._priority == UIPriority.SecondHUD)
        {
            CloseUI();
            UI.Open();
            _uiStack.Push(UI);
            return;
        }
        else
        {
            Debug.Log("Smth here");
        }
    }
}

    private void ToggleSecondHUD()
    {
        if(_uiStack.Count > 0 && _uiStack.Peek()._priority != UIPriority.SecondHUD) 
            return;
        
        OpenUI(_playerSecondHUD);
    }
    
    private void HandleEscapeKey()
    {
        if (_uiStack.Count == 0)
        {
            OpenUI(_escapeMenu);
            return;
        }
        else
        {
            CloseUI();
        }
    }

    private void TryOpenLogs()
    {
        OpenUI(_logsMenu);
    }

    private void TryOpenObjectives()
    {
       OpenUI(_objectivesMenu);
    }

    private void TryOpenCharacter()
    {
        OpenUI(_characterMenu);
    }

    private void TryOpenInventory()
    {
        OpenUI(_inventoryMenu);
    }

    private void OnDestroy()
    {
        // Clean up event subscriptions
        _input.On_I_Pressed -= TryOpenInventory;
        _input.On_K_Pressed -= TryOpenCharacter;
        _input.On_O_Pressed -= TryOpenObjectives;
        _input.On_L_Pressed -= TryOpenLogs;
        _input.On_TAB_Pressed -= ToggleSecondHUD;
        _input.On_ESC_Pressed -= HandleEscapeKey;
    }
}