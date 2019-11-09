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
        for (int i = 0; i < Model.ClubsList.Length; i++)
        {
            ClubItem clubItem;
            if (ClubsList.Count <= i)
            {
                GameObject ClubObject = Instantiate(ClubPrefab, ClubsScrollContent);
                ClubObject.name = Model.ClubsList[i].name + Model.ClubsList[i].id;
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
    private void HandleClubItemData(ClubsData.ClubData clubData,ClubItem clubGameObject)
    {
        clubGameObject.clubButton.onClick.RemoveAllListeners();
        clubGameObject.clubButton.onClick.AddListener(()=> { OnClubClicked(clubData.id); });
        //StartCoroutine(Controller.GetTexture((sprite)=> { clubGameObject.clubImage.sprite = sprite; }, clubData.logoUrl));
        clubGameObject.clubName.text = clubData.name;
        clubGameObject.clubLeague.text = clubData.league;
    }
    private void OnClubClicked(string clubID)
    {
        Controller.OnClubItemClicked(clubID);
    }
}
