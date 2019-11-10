using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public abstract class UIView : MonoBehaviour
{
    public GameObject ViewGameObject;
    public virtual void Awake()
    {
    }
    public virtual void RegisterDependency()
    {

    }
    public virtual void SetupView(object dataObject = null)
    {
    }
    public virtual void ShowView()
    {
        ViewGameObject.SetActive(true);
    }
    public virtual void HideView()
    { 
        ViewGameObject.SetActive(false);
    }
    public virtual void CloseView()
    {
        ViewsManager.Instance.CloseViewOnTopOfStack();
    }
}
public abstract class UIView<M, C> : UIView
    where M : UIModel,new ()
    where C : UIController<M>, new()
{
    public M Model;
    protected C Controller;
    public override void SetupView(object dataObject=null)
    {
        base.Awake();
        Controller = new C();
        Model = Model ?? new M(); 
        RegisterDependency();
        Controller.Setup(Model,dataObject);
        ShowView();
    }
}
