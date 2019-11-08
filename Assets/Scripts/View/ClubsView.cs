using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClubsView : UIView<ClubsModel,ClubsController>
{
    public RectTransform ClubsScrollContent;
    public GameObject ClubPrefab;
    public List<ClubItem> ClubsList;
    public override void RegisterDependency()
    {
        base.RegisterDependency();
        Model.ListenOnPropertyChanged("ClubsList", ClubsListChanged);
    }
    private void ClubsListChanged()
    {
        for (int i = 0; i < Model.ClubsList.Count; i++)
        {
            ClubItem clubItem;
            if (ClubsList.Count <= i)
            {
                GameObject ClubObject = Instantiate(ClubPrefab, ClubsScrollContent);
                ClubObject.name = Model.ClubsList[i].ClubName + Model.ClubsList[i].ClubID;
                clubItem = ClubObject.GetComponent<ClubItem>();
                ClubsList.Add(clubItem);
            }
            else
            {
                clubItem = ClubsList[i];
            }
            HandleClubItemData(Model.ClubsList[i], clubItem);
        }
    }
    private void HandleClubItemData(ClubData clubData,ClubItem clubGameObject)
    {
        clubGameObject.clubButton.onClick.RemoveAllListeners();
        clubGameObject.clubButton.onClick.AddListener(()=> { OnClubClicked(clubData.ClubID); });
        clubGameObject.clubImage.sprite = clubData.ClubImage;
        clubGameObject.clubName.text = clubData.ClubName;
        clubGameObject.clubLeague.text = clubData.ClubLeague;
    }
    private void OnClubClicked(string clubID)
    {
        Controller.OnClubItemClicked(clubID);
    }
}
