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
    public virtual void SetupView()
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
        Destroy(gameObject);
    }
}
public abstract class UIView<M, C> : UIView
    where M : UIModel,new ()
    where C : UIController<M>, new()
{
    public M Model;
    protected C Controller;
    public override void Awake()
    {
        base.Awake();
        Controller = new C();
        Model = Model ?? new M(); 
        RegisterDependency();
        Controller.Setup(Model);
        SetupView();
        ShowView();
    }
}
