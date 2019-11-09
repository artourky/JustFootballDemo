using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView : UIView<ProfileModel,ProfileContoller>
{
    public Image profileImage;
    public Image clubIcon;
    public Text ProfileName;
    public Text ClubeName;
    public Text ClubeLeague;

    public override void RegisterDependency()
    {
        base.RegisterDependency();
        Model.ListenOnPropertyChanged("PlayerData", UpdateViewData);
    }
    private void UpdateViewData()
    {
        ProfileName.text = Model.playerData.username;
        ClubeName.text = Model.playerData.club;
        ClubeLeague.text = "";
    }
    public void ChooseNameClicked()
    {

    }
}
