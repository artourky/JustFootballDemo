using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ViewsManager : BaseManager<ViewsManager>
{
    private List<UIView> _viewsStack;
    public List<ViewData> ViewsObjectsList;
    TransitionAnimationCommand TransitionViewsAnimation;
    public override void Initialize()
    {
        _viewsStack = new List<UIView>();
        TransitionViewsAnimation = new TransitionAnimationCommand(this, AnimationType.Transition, true);
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
        TransitionViewsAnimation.UpdateCommand(AnimationType.Transition,true);
        TransitionViewsAnimation.Execute(null);
        yield return new WaitUntil(() => TransitionViewsAnimation.IsFinished);
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
        TransitionViewsAnimation.UpdateCommand(AnimationType.Transition, false);
        TransitionViewsAnimation.Execute(null);
        yield return new WaitUntil(() => TransitionViewsAnimation.IsFinished);
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
        TransitionViewsAnimation.UpdateCommand(AnimationType.Transition, true);
        TransitionViewsAnimation.Execute(null);
        yield return new WaitUntil(() => TransitionViewsAnimation.IsFinished);

        var viewToClose = _viewsStack[_viewsStack.Count - 1];
        _viewsStack.Remove(viewToClose);
        Destroy(viewToClose.gameObject);

        EnableOnTopOfStack();

        TransitionViewsAnimation.UpdateCommand(AnimationType.Transition, false);
        TransitionViewsAnimation.Execute(null);
        yield return new WaitUntil(() => TransitionViewsAnimation.IsFinished);

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