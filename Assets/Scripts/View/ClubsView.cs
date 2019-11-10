using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ClubsView : UIView<ClubsModel,ClubsController>
{
    public RectTransform ClubsScrollContent;
    public GameObject ClubPrefab;
    public List<ClubItem> ClubsList;
    public ClubsScroll clubsScroll;
    public override void RegisterDependency()
    {
        base.RegisterDependency();
        Model.ListenOnPropertyChanged("ClubsList", ClubsListChanged);
    }
    private void ClubsListChanged()
    {

        if( Model.ClubsList.Length > 0 )
        {
            clubsScroll.Initialize(Model.ClubsList.ToList());

        }
        for (int i = 0; i < clubsScroll.ActiveElements.Count; i++)
        {
            HandleClubItemData( clubsScroll.ActiveElements[i]);
        }
    }
    private void HandleClubItemData(ClubItem clubGameObject)
    {
        clubGameObject.clubButton.onClick.RemoveAllListeners();
        clubGameObject.clubButton.onClick.AddListener(()=> { OnClubClicked(clubGameObject.Data.id); });
    }
    private void OnClubClicked(string clubID)
    {
        Controller.OnClubItemClicked(clubID);
    }
}
