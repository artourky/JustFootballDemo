using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeView : UIView<HomeModel, HomeController>
{
    public Text playerName;
    public Image PlayerIcon;

    public override void SetupView()
    {
        base.SetupView();
        playerName.text = Model.playerName;
        PlayerIcon.sprite = Controller.getPlayerSprite();
    }

}
