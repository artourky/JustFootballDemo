using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ClubsController : UIController<ClubsModel>
{
    public override void Setup(ClubsModel model)
    {
        base.Setup(model);
        Model.RequestClubs();
    }
    public void OnClubItemClicked(string ClubID)
    {
        Debug.Log("ClubClicked " + ClubID);
    }
}
