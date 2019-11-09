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

[Serializable]
public class ClubsData
{
    [System.Serializable]
    public class ClubData
    {
        public string id;
        public string logoUrl;
        public string name;
        public string league;
    }
    public ClubData[] clubs;
}

public class DataManager : MonoBehaviour
{
}
