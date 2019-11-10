using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.PooledScrollList;
using UnityEngine;
using UnityEngine.UI;

public class ClubItem : PooledElement<ClubsData.ClubData>
{
    public Image clubImage;
    public Text clubName;
    public Text clubLeague;
    public Button clubButton;
    public GameObject CheckMarkImage;
    [SerializeField]
    private ClubsData.ClubData _data;
    public override ClubsData.ClubData Data
    {
        get => _data;
        set
        {
            _data = value;
            SetupView(value);
        }
    }
    public void SetupView(ClubsData.ClubData data)
    {
        clubName.text = data.name;
        clubLeague.text = data.league;
        DataManager.Instance.GetSpriteByUrl(data.logoUrl, (image) => { clubImage.sprite = image; });
    }

}
