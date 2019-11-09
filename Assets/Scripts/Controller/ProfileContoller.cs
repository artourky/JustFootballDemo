using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileContoller : UIController<ProfileModel>
{
    public override void Setup(ProfileModel model)
    {
        base.Setup(model);
        Model.RequestProfileData();
    }

}
