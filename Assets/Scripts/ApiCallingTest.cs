using Assets.Scripts;
using UnityEngine;

public class ApiCallingTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Log("Press 'U' to GetUser with UserName, Press 'C' to Get a club or Clubs, Press 'Q' to Get Cards");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && ApiManager.IsReady)
        {
            var user = new UserName("");
            ApiManager.Instance.GetUser(user, (userdata) => Log("user name done"));
        }

        if (Input.GetKeyDown(KeyCode.S) && ApiManager.IsReady)
        {
            var user = new UserName("Esm gdeed");
            ApiManager.Instance.SetUserName(user, () => Log("set user name done"));
        }

        if (Input.GetKeyDown(KeyCode.C) && ApiManager.IsReady)
        {
            var club = new Club("");
            ApiManager.Instance.GetClubs(club, (cards) => Log("cardss done"));
        }

        if (Input.GetKeyDown(KeyCode.Q) && ApiManager.IsReady)
        {
            var club = new Club("barcelona");
            ApiManager.Instance.SetClub(club, () => Log("set a club done"));
        }

        if (Input.GetKeyDown(KeyCode.G) && ApiManager.IsReady)
        {
            var usrLoc = new LocationData();
            usrLoc.lat = 12.4586;
            usrLoc.lng = 57.443636;
            ApiManager.Instance.UpdUsrLocation(usrLoc, () => Log("upd usr location done"));
        }
    }

    private void Log(string strToLog)
    {
        Debug.Log("[ApiCallingTest] " + strToLog);
    }
}
