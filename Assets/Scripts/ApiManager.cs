using Assets.Scripts;
using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ApiManager : MonoBehaviour
{
    private const string _apiUrl = "https://demo.dev.justfootball.io/api";
    private const string _authUrl = "/auth/token";
    private const string _getUsrUrl = "/user/get/"; // + user id
    private const string _setUsrNameUrl = "/user/set/username";
    private const string _setClubUrl = "/user/set/club";
    private const string _setUsrLocUrl = "/user/set/location";
    private const string _cardsUrl = "/cards";
    private const string _clubsUrl = "/clubs";
    private const string _getClubUrl = "/club/"; // + club id

    private static string _deviceID;
    private static string _authToken;

    private UnityWebRequest request;

    public static ApiManager Instance;
    public bool IsNewUser = true;

    public static bool IsReady;

    private void Awake()
    {
        Instance = this;
        _deviceID = SystemInfo.deviceUniqueIdentifier;

        StartCoroutine(GetAuthentication());
    }

    private IEnumerator GetAuthentication()
    {
        _deviceID = IsNewUser ? Guid.NewGuid().ToString() : _deviceID;
        var token = new Token(_deviceID);
        var rawBytes = Encoding.UTF8.GetBytes(token.ToJson());
        Log("Get Auth Token! " + _deviceID);

        var url = _apiUrl + _authUrl;

        request = new UnityWebRequest(url, "POST");
        request.uploadHandler = new UploadHandlerRaw(rawBytes);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        IsReady = request.responseCode == 200L;
        _authToken = request.downloadHandler.text;
        Log("ApiManager is ready? " + IsReady);
    }

    private void SetRequestInfo(string jsonBody = "")
    {
        request.SetRequestHeader("Authorization", $"Bearer {_authToken}");
        request.downloadHandler = new DownloadHandlerBuffer();

        if (!string.IsNullOrEmpty(jsonBody))
        {
            var rawBytes = Encoding.UTF8.GetBytes(jsonBody);
            request.uploadHandler = new UploadHandlerRaw(rawBytes);

            request.SetRequestHeader("Content-Type", "application/json");
        }
    }

    public void GetUser(UserName userName, Action onComplete = null)
    {
        StartCoroutine(GetUser(userName.username, onComplete));
    }

    public void SetUserName(UserName userName, Action onComplete = null)
    {
        StartCoroutine(SetUserName(userName.ToJson(), onComplete));
    }

    public void SetClub(Club club, Action onComplete = null)
    {
        StartCoroutine(SetClub(club.club, onComplete));
    }

    public void GetClubs(Club club, Action onComplete = null)
    {
        StartCoroutine(GetClubs(club.club, onComplete));
    }

    public void GetCardss(Action onComplete = null)
    {
        StartCoroutine(GetCards(onComplete));
    }

    private IEnumerator GetUser(string userId = "", Action onComplete = null)
    {
        StringBuilder url = new StringBuilder();
        if (!string.IsNullOrEmpty(userId))
            url.Append(_apiUrl + _getUsrUrl + userId);
        else
            url.Append(_apiUrl + "/user/me");

        request = new UnityWebRequest(url.ToString(), "GET");

        SetRequestInfo();

        yield return request.SendWebRequest();

        onComplete?.Invoke();
        Log(request.downloadHandler.text);
        var usr = JsonUtility.FromJson<UserData>(request.downloadHandler.text);
        Log(usr.ToString());
    }

    private IEnumerator SetUserName(string newUserName, Action onComplete = null)
    {
        StringBuilder url = new StringBuilder();
        url.Append(_apiUrl).Append(_setUsrNameUrl);

        request = new UnityWebRequest(url.ToString(), "POST");
        SetRequestInfo(newUserName);
        yield return request.SendWebRequest();
        Log(request.downloadHandler.text);

        onComplete?.Invoke();
    }

    private IEnumerator SetClub(string clubId, Action onComplete = null)
    {
        yield return null;
    }

    private IEnumerator UpdUserLocation(string newUserName, Action onComplete = null)
    {
        yield return null;
    }

    private IEnumerator GetCards(Action onComplete = null)
    {
        StringBuilder url = new StringBuilder();
        url.Append(_apiUrl).Append(_cardsUrl);
        request = new UnityWebRequest(url.ToString(), "GET");
        SetRequestInfo();

        yield return request.SendWebRequest();

        onComplete?.Invoke();

        url = new StringBuilder();
        url.Append(request.downloadHandler.text).Insert(0, "{\"cards\":").Append('}');
        var cards = JsonUtility.FromJson<CardsData>(url.ToString());
    }

    private IEnumerator GetClubs(string clubId = "", Action onComplete = null)
    {
        StringBuilder url = new StringBuilder();
        if (!string.IsNullOrEmpty(clubId))
            url.Append(_apiUrl + _getClubUrl + clubId);
        else
            url.Append(_apiUrl + _clubsUrl);

        request = new UnityWebRequest(url.ToString(), "GET");

        SetRequestInfo();

        yield return request.SendWebRequest();

        onComplete?.Invoke();
        Log(request.downloadHandler.text);
    }

    private void Log(string strToLog)
    {
        Debug.Log("[ApiManager] " + strToLog);
    }
}