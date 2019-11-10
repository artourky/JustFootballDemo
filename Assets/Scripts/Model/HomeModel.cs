using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HomeModel : UIModel
{
    public UserData playerData;
    public void RequestProfileData()
    {
        ApiManager.Instance.GetUser(null, OnGetUserData);
    }
    private void OnGetUserData(UserData userData)
    {
        playerData = userData;
        NotifyOnPropertyChanged("PlayerData");
    }

}
