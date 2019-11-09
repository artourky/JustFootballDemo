using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewsManager : MonoBehaviour
{
    private List<UIView> _viewsStack;
    public List<ViewData> ViewsObjectsList;

    public static ViewsManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        _viewsStack = new List<UIView>();
        OpenView( ViewType.HomeView );
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Escape ) )
        {
            CloseViewOnTopOfStack();
        }
    }

    public void OpenView( ViewType viewType )
    {
        DisableOnTopOfStack();

        var viewobject = Instantiate(ViewsObjectsList.FirstOrDefault(view => view.Type == viewType).ViewObject);
        _viewsStack.Add( viewobject.GetComponent<UIView>());
    }

    private void DisableOnTopOfStack()
    {
        if( _viewsStack.Count == 0 )
        {
            return;
        }

        _viewsStack[_viewsStack.Count-1].gameObject.SetActive( false );
    }

    public void CloseViewOnTopOfStack( )
    {
        if( _viewsStack.Count == 1 )
        {
            return;
        }
        
        var viewToClose = _viewsStack[_viewsStack.Count - 1];
        _viewsStack.Remove(viewToClose);
        Destroy(viewToClose.gameObject);

        EnableOnTopOfStack();
    }

    private void EnableOnTopOfStack()
    {
        _viewsStack[_viewsStack.Count - 1].gameObject.SetActive(true);
    }
}

[System.Serializable]
public class ViewData
{
    public ViewType Type;
    public GameObject ViewObject;
}

public enum ViewType
{
    HomeView,
    CardsView,
    ClubsView,
    ProfileView
}