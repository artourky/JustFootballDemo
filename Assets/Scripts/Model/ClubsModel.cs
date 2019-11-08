using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubData
{
    public string ClubID;
    public Sprite ClubImage;
    public string ClubName;
    public string ClubLeague;
}
public class ClubsModel : UIModel
{
    public List<ClubData> ClubsList = new List<ClubData>();

    public void RequestClubs()
    {
        AddClub(new ClubData { ClubID = "1", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name1" ,ClubLeague = "league1"});
        AddClub(new ClubData { ClubID = "2", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name2" ,ClubLeague = "league2"});
        AddClub(new ClubData { ClubID = "3", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name3" ,ClubLeague = "league3"});
        AddClub(new ClubData { ClubID = "4", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name4" ,ClubLeague = "league4"});
        AddClub(new ClubData { ClubID = "5", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name5" ,ClubLeague = "league5"});
        AddClub(new ClubData { ClubID = "6", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name6" ,ClubLeague = "league6"});
        AddClub(new ClubData { ClubID = "7", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name7" ,ClubLeague = "league7"});
        AddClub(new ClubData { ClubID = "8", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name8" ,ClubLeague = "league8"});
        AddClub(new ClubData { ClubID = "9", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name9" ,ClubLeague = "league9"});
        AddClub(new ClubData { ClubID = "10", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name10" ,ClubLeague = "league10"});
        AddClub(new ClubData { ClubID = "11", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name11" ,ClubLeague = "league11"});
        AddClub(new ClubData { ClubID = "12", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name12" ,ClubLeague = "league12"});
        AddClub(new ClubData { ClubID = "13", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name13" ,ClubLeague = "league13"});
        AddClub(new ClubData { ClubID = "14", ClubImage = Resources.Load<Sprite>("Art/Woman"),ClubName="name14" ,ClubLeague = "league14"});
        NotifyOnPropertyChanged("ClubsList");
    }
    private void AddClub(ClubData clubData)
    {
        ClubsList.Add(clubData);
    }
}