using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsController : UIController<CardsModel>
{
    public override void Setup(CardsModel model)
    {
        base.Setup(model);
        Model.RequestCards();
    }
    public void OnCardItemClicked(string CardID)
    {
        Debug.Log("CardClicked " + CardID);
    }

}
