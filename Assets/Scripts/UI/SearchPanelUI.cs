using UnityEngine;
using UnityEngine.UIElements;

public class SearchPanelUI : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDocument;

    private TextField _searchBarText;
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
        _searchBarText = root.Q<TextField>("SearchBar");
        _searchBarText.SetPlaceholderText("Search...");

        _modelListView = root.Q<ListView>("ModelList");
    }

    private void HookIntoEvents()
    {
        _searchBarText.RegisterValueChangedCallback(OnSearchBarTextInputChanged);

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
