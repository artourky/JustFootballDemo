using Assets.Scripts;
using UnityEngine;

public class ApiCallingTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Log("Press 'U' to GetUser with UserName.\nPress 'C' to Get a club or Clubs");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && ApiManager.IsReady)
        {
            var user = new UserName("");
            ApiManager.Instance.GetUser(user, () => Log("user name done"));
        }

        if (Input.GetKeyDown(KeyCode.S) && ApiManager.IsReady)
        {
            var user = new UserName("Esm gdeed");
            ApiManager.Instance.SetUserName(user, () => Log("user name done"));
        }

        if (Input.GetKeyDown(KeyCode.C) && ApiManager.IsReady)
        {
            //var club = new Club("");
            ApiManager.Instance.GetCardss(() => Log("cardss done"));
        }
    }

    private void Log(string strToLog)
    {
        Debug.Log("[ApiCallingTest] " + strToLog);
    }
}
