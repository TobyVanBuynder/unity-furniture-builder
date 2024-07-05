using System;
using UnityEngine;
using UnityEngine.UIElements;

public class SearchPanelUI : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;

    private TextField _searchBarTextInput;
    private ListView _modelListView;

    void Awake()
    {
        if (_uiDocument == null)
        {
            enabled = false;
        }
    }

    void Start()
    {
        InitializeVariablesFromRoot(_uiDocument.rootVisualElement);
        HookIntoEvents();
    }

    private void InitializeVariablesFromRoot(VisualElement root)
    {
        _searchBarTextInput = root.Q<TextField>("SearchBar");
        _modelListView = root.Q<ListView>("ModelList");
    }

    private void HookIntoEvents()
    {
        _searchBarTextInput.RegisterValueChangedCallback(OnSearchBarTextInputChanged);

        // TODO: implement the listview
        // _modelListView.DoSomething()
    }

    private void OnSearchBarTextInputChanged(ChangeEvent<string> evt)
    {
        GlobalEvents.OnSearchBarTextChanged?.Invoke(evt.newValue);
    }

    void OnEnable()
    {
        GlobalEvents.OnAddressableModelLoaded += OnAddressableModelLoaded;
    }

    void OnDisable()
    {
        GlobalEvents.OnAddressableModelLoaded -= OnAddressableModelLoaded;
    }

    private void OnAddressableModelLoaded()
    {
    }
}
