using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : UIController<HomeModel>
{
    public Sprite getPlayerSprite()
    {
        return Resources.Load<Sprite>("Art/"+ Model.playerImage);
    }
    protected override void Close()
    {
        base.Close();

    }
}
