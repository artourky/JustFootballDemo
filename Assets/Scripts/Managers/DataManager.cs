using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

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

    public Dictionary<string, Texture2D> clubsSprites;

}

public class DataManager : MonoBehaviourSingleton<DataManager>
{
    public Image tstUIImg;

    private float downloadTimeStart;
    public void DownloadSprites(ClubsData clubObject)
    {
        clubObject.clubsSprites = new Dictionary<string, Texture2D>();
        downloadTimeStart = Time.time;
        StartCoroutine(GetSprites(clubObject));

    }

    public void GetSpriteByUrl(string spriteUrl, Action<Sprite> callback)
    {
        StartCoroutine(GetSprite(spriteUrl, callback));
    }

    private IEnumerator GetSprite(string spriteUrl, Action<Sprite> callback)
    {
        UnityWebRequest req = UnityWebRequestTexture.GetTexture(spriteUrl);

        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            Debug.Log(req.error);
        }
        var texture2D = DownloadHandlerTexture.GetContent(req);
        var sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f));
        callback.Invoke(sprite);
    }

    private IEnumerator GetSprites(ClubsData clubObject)
    {
        for (int i = 0; i < clubObject.clubs.Length; i++)
        {
            UnityWebRequest req = UnityWebRequestTexture.GetTexture(clubObject.clubs[i].logoUrl);

            yield return req.SendWebRequest();

            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log(req.error);
            }
            clubObject.clubsSprites[clubObject.clubs[i].id]= DownloadHandlerTexture.GetContent(req);
          //  tstUIImg.sprite = Sprite.Create(clubObject.clubsSprites[clubObject.clubs[i].logoUrl], new Rect(0, 0, clubObject.clubsSprites[clubObject.clubs[i].logoUrl].width, clubObject.clubsSprites[clubObject.clubs[i].logoUrl].height), new Vector2(0.5f, 0.5f));
        }
        Debug.Log( "Finished in: "+ (Time.time-downloadTimeStart));
    }
}
