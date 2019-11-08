using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIController<M> where M : UIModel
{
    protected M Model;
    public virtual void Setup(M model)
    {
        Model = model;
        Model.NotifyOnPropertyChanged();
    }
    protected virtual void Close()
    {

    }
}