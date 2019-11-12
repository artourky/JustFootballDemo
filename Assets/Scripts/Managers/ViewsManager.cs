using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewsManager : BaseManager<ViewsManager>
{
    private List<UIView> _viewsStack;
    public List<ViewData> ViewsObjectsList;
    Command TransitionViewsAnimationIn;
    Command TransitionViewsAnimationOut;

    public override void Initialize()
    {
        _viewsStack = new List<UIView>();
        TransitionViewsAnimationIn = new TransitionAnimationCommand(this, AnimationType.Transition, true);
        TransitionViewsAnimationOut = new TransitionAnimationCommand(this, AnimationType.Transition, false);
        IsReady = true;
    }
    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Escape ) )
        {
            CloseOnTopOfStack();
        }
    }
    public void OpenView( ViewType viewType, object dataObject = null,Action OnComplete = null)
    {
        StartCoroutine(LoadView(viewType, dataObject, OnComplete));
    }

    IEnumerator LoadView(ViewType viewType, object dataObject = null, Action OnComplete = null)
    {
        TransitionViewsAnimationIn.Execute(null);
        yield return new WaitUntil(() => TransitionViewsAnimationIn.IsFinished);
        DisableOnTopOfStack();
        var viewobject = Instantiate(ViewsObjectsList.FirstOrDefault(view => view.Type == viewType).ViewObject);
        var viewToOpen = viewobject.GetComponent<UIView>();
        viewToOpen.SetupView(dataObject);
        _viewsStack.Add(viewToOpen);
        yield return new WaitUntil(() => viewToOpen.isLoaded);
        if (OnComplete != null)
        {
            OnComplete.Invoke();
        }
        TransitionViewsAnimationOut.Execute(null);
        yield return new WaitUntil(() => TransitionViewsAnimationOut.IsFinished);
    }
    private void DisableOnTopOfStack()
    {
        if( _viewsStack.Count == 0 )
        {
            return;
        }

        _viewsStack[_viewsStack.Count-1].gameObject.SetActive( false );
    }
    public void CloseOnTopOfStack()
    {
        StartCoroutine(CloseViewOnTopOfStack());
    }
    private IEnumerator CloseViewOnTopOfStack( )
    {
        if( _viewsStack.Count == 1 )
        {
            yield break;
        }
        TransitionViewsAnimationIn.Execute(null);
        yield return new WaitUntil(() => TransitionViewsAnimationIn.IsFinished);

        var viewToClose = _viewsStack[_viewsStack.Count - 1];
        _viewsStack.Remove(viewToClose);
        Destroy(viewToClose.gameObject);

        EnableOnTopOfStack();

        TransitionViewsAnimationOut.Execute(null);
        yield return new WaitUntil(() => TransitionViewsAnimationOut.IsFinished);

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

public enum ScenesType
{
    SplashScene,
    MainScene,
}