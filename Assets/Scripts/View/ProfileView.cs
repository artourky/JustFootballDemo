using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView : UIView<ProfileModel, ProfileContoller>
{
    public Image ProfileImage;
    public Image ClubIcon;
    public Text ProfileName;
    public Text ClubeName;
    public Text ClubeLeague;
    public Button ChangeNameButton;
    public InputField UserNameInputField;
    private TouchScreenKeyboard touchScreenKeyboard;
    private bool _isMyProfile;
    public bool IsMyProfile
    {
        set
        {
            _isMyProfile = value;
            ChangeNameButton.interactable = _isMyProfile;
        }

        get => _isMyProfile;
    }

    private bool _isEditMode;
    public bool IsEditMode
    {
        set
        {
            _isEditMode = value;

            ToggleEditMode();
        }

        get => _isEditMode;
    }

    private void ToggleEditMode()
    {
        UserNameInputField.gameObject.SetActive(_isEditMode);
        ChangeNameButton.gameObject.SetActive(!_isEditMode);
        if( IsEditMode )
        {
            touchScreenKeyboard=TouchScreenKeyboard.Open( ProfileName.text );
        }
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Return) && IsEditMode) || (touchScreenKeyboard != null && touchScreenKeyboard.status == TouchScreenKeyboard.Status.Done))
        {
            UserNameSubmited();
        }

    }
    public override void RegisterDependency()
    {
        base.RegisterDependency();
        Model.ListenOnPropertyChanged("PlayerData", UpdateViewData);
    }
    private void UpdateViewData()
    {
        if (Model.PlayerData == null)
        {
            return;
        }

        IsMyProfile = Model.IsMyProfile;
        ProfileName.text = Model.PlayerData.username;
        ClubeName.text = Model.PlayerData.club;
        ClubeLeague.text = "";
        if (Model.PlayerData.pictureUrl == "" || Model.PlayerData.clubPictureUrl == "")
        { return; }
        DataManager.Instance.GetSpriteByUrl(Model.PlayerData.pictureUrl, (image) => { ProfileImage.sprite = image; });
        DataManager.Instance.GetSpriteByUrl(Model.PlayerData.clubPictureUrl, (image) => { ClubIcon.sprite = image; });
    }
    public void ChooseNameClicked()
    {
        IsEditMode = !IsEditMode;
        // Controller.OnChangeNameClicked(UserNameInputField.text);
    }

    public void UserNameSubmited()
    {
        IsEditMode = !IsEditMode;
        ProfileName.text = UserNameInputField.text;
        Controller.OnChangeNameClicked( UserNameInputField.text );
    }
}
