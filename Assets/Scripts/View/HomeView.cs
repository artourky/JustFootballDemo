using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeView : UIView<HomeModel, HomeController>
{
    public Text playerName;
    public Image playerImage;
    public override void RegisterDependency()
    {
        base.RegisterDependency();
        Model.ListenOnPropertyChanged("playerName", () => { playerName.text = Model.playerName; });
        Model.ListenOnPropertyChanged("playerImage", () => { playerImage.sprite = Model.playerImage; });
    }
}