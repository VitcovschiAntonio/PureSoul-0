
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//TODO : Save shareable anytime

public class NavigationMenu : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private NavigationMenuUI _ui;
    [SerializeField] private InventoryMenu _inventoryMenu;
    [SerializeField] private CharacterMenu _characterMenu;
    [SerializeField] private ObjectivesMenu _objectivesMenu;
    [SerializeField] private LogsMenu _logsMenu;

    [SerializeField] private Button _inventoryButton;
    [SerializeField] private Button _characterButton;
    [SerializeField] private Button _objectivesButton;
    [SerializeField] private Button _logsButton;

    private Button _lastButtonActive;
    private IUI _currentActiveMenu;
    private int _currentMenuIndex =-1;
    private List<IUI> _menusList = new List<IUI>();

    void Awake()
    {
        //Initialize();
        InitialiseNavigationMenu();
    }
    public void Initialize()
    {
        SubscribeToEvents();
    }

    private void InitialiseNavigationMenu()
    {
        _menusList.Add(_inventoryMenu);
        _menusList.Add(_characterMenu);
        _menusList.Add(_objectivesMenu);
        _menusList.Add(_logsMenu);
    }

    private void NavigateRight()
    {
        if (_currentMenuIndex + 1 > _menusList.Count - 1)
        {
            _currentMenuIndex = 0;
            UIManager.Instance.OpenUI(_menusList[_currentMenuIndex]);
        }
        else
        {
            _currentMenuIndex++;
            UIManager.Instance.OpenUI(_menusList[_currentMenuIndex]);
        }
    }

    private void NavigateLft()
    {
        if (_currentMenuIndex - 1 < 0)
        {
            _currentMenuIndex = _menusList.Count -1;
            UIManager.Instance.OpenUI(_menusList[_currentMenuIndex]);
        }
        else
        {
            _currentMenuIndex--;
            UIManager.Instance.OpenUI(_menusList[_currentMenuIndex]);
        }
    }
    
    private void HandleButtonSelection(Button button)
    {
        Image image = button.GetComponent<Image>();
        if (_lastButtonActive == null)
        {
            _lastButtonActive = button;
            _ui.SelectButton(image);
        }
        else if (_lastButtonActive != button)
        {
            _ui.UnselectButton(_lastButtonActive.GetComponent<Image>());
            _lastButtonActive = button;
            _ui.SelectButton(image);
        }
        else
        {
            return;
        }
    }

    private void InventoryMenuOpened()
    {
        _currentActiveMenu = _inventoryMenu;
        _currentMenuIndex = _menusList.IndexOf(_inventoryMenu);
        HandleButtonSelection(_inventoryButton);
    }

    private void CharacacterMenuOpened()
    {
        _currentActiveMenu = _characterMenu;
        _currentMenuIndex = _menusList.IndexOf(_characterMenu);
        HandleButtonSelection(_characterButton);

    }
    
    private void ObjectivesMenuOpened()
    {
        _currentActiveMenu = _objectivesMenu;
        _currentMenuIndex = _menusList.IndexOf(_objectivesMenu);
        HandleButtonSelection(_objectivesButton);

    }
    private void LogsMenuOpened()
    {
        _currentActiveMenu = _logsMenu;
        _currentMenuIndex = _menusList.IndexOf(_logsMenu);
        HandleButtonSelection(_logsButton);

    }

    private void HandleInventoryButtonClicked()
    {
        if (_inventoryMenu._isOpen)
        {
            return;
        }
        _currentActiveMenu = _inventoryMenu;
        UIManager.Instance.OpenUI(_currentActiveMenu);
    }

    private void HandleCharacterButtonClicked()
    {
        if (_characterMenu._isOpen)
        {
            return;
        }
        _currentActiveMenu = _characterMenu;
        UIManager.Instance.OpenUI(_currentActiveMenu);
    }

    private void HandleLogsButtonCLicked()
    {
        if (_logsMenu._isOpen)
        {
            return;
        }
        _currentActiveMenu = _logsMenu;
        UIManager.Instance.OpenUI(_currentActiveMenu);
    }

    private void HandleObjectivesButtonClicked()
    {
        if (_objectivesMenu._isOpen)
        {
            return;
        }
        _currentActiveMenu = _objectivesMenu;
        UIManager.Instance.OpenUI(_objectivesMenu);
    }

    private void SubscribeToEvents()
    {
        _input.On_Q_Pressed_UI += NavigateLft;
        _input.On_E_Pressed_UI += NavigateRight;

        _inventoryMenu.OnInventoryMenuOpened += InventoryMenuOpened;
        _characterMenu.OnCharacterMenuOpened += CharacacterMenuOpened;
        _objectivesMenu.OnObjectivesMenuOpened += ObjectivesMenuOpened;
        _logsMenu.OnLogsMenuOpened += LogsMenuOpened;

        _inventoryButton.onClick.AddListener(HandleInventoryButtonClicked);
        _characterButton.onClick.AddListener(HandleCharacterButtonClicked);
        _objectivesButton.onClick.AddListener(HandleObjectivesButtonClicked);
        _logsButton.onClick.AddListener(HandleLogsButtonCLicked);
    }

    private void Unsubscribe()
    {
        _input.On_Q_Pressed_UI -= NavigateLft;
        _input.On_E_Pressed_UI -= NavigateRight;

        _inventoryMenu.OnInventoryMenuOpened -= InventoryMenuOpened;
        _characterMenu.OnCharacterMenuOpened -= CharacacterMenuOpened;
        _objectivesMenu.OnObjectivesMenuOpened -= ObjectivesMenuOpened;
        _logsMenu.OnLogsMenuOpened -= LogsMenuOpened;

        _inventoryButton.onClick.RemoveListener(HandleInventoryButtonClicked);
        _characterButton.onClick.RemoveListener(HandleCharacterButtonClicked);
        _objectivesButton.onClick.RemoveListener(HandleObjectivesButtonClicked);
        _logsButton.onClick.RemoveListener(HandleLogsButtonCLicked);
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
}
