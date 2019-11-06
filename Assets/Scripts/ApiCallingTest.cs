using Assets.Scripts;
using UnityEngine;

public class ApiCallingTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            var user = new UserName("");
            ApiManager.Instance.GetUser(user, () => Log("user name done"));
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            var club = new Club("");
            ApiManager.Instance.GetClubs(club, () => Log("clubs done"));
        }
    }

    private void Log(string strToLog)
    {
        Debug.Log("[ApiCallingTest] " + strToLog);
    }
}
