using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : UIController<HomeModel>
{
    protected override void Close()
    {
        base.Close();
    }

    public void OpenClubView()
    {
        ViewsManager.Instance.OpenView(ViewType.ClubsView);
    }
    public void OpenCardsView()
    {
        ViewsManager.Instance.OpenView(ViewType.CardsView);
    }

    
}
