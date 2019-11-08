using System;
using UnityEngine;

[Serializable]
public class LocationData
{
    public double lat;
    public double lng;
}

[Serializable]
public class UserData
{
    public string username;
    public string club;
    public LocationData location;
    public string pictureUrl;
    public string clubPictureUrl;

    public override string ToString()
    {
        return username + " " + club + " " + location.lat + " " + location.lng + " " + pictureUrl + " " + clubPictureUrl;
    }
}

[Serializable]
public class CardsData
{
    [Serializable]
    public class CardData
    {
        public string id;
        public string username;
        public string pictureUrl;
        public string clubPictureUrl;
    }

    public CardData[] cards;
}

public class DataManager : MonoBehaviour
{
}
