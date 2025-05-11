using UnityEngine;


public class URLParameterReceiver : MonoBehaviour
{
    public string new_name = "sample";
    public string wallet_address = "sample";
    public string player_id = "smple";
    public string tokens = "sample";
    void Start()
    {
        string url = Application.absoluteURL;
        string parameters = url.Split('?')[1];
        string[] pairs = parameters.Split('&');
        foreach (string pair in pairs)
        {
            string[] keyValue = pair.Split('=');
            if (keyValue.Length == 2)
            {
                Debug.Log("Key: " + keyValue[0] + ", Value: " + keyValue[1]);
                if (keyValue[0] == "name") new_name = keyValue[1];
                else if (keyValue[0] == "player_id") player_id = keyValue[1];
                else if (keyValue[0] == "wallet_address") wallet_address = keyValue[1];
                else if (keyValue[0] == "tokens") tokens = keyValue[1];
            }

        }
    }
    // public void ReceiveURLParameters(string parameters)
    // {
    //     Debug.Log("Received URL Parameters: " + parameters);

    //     // You can parse them here
    //     // Example: if your parameters are like "name=John&score=42"
    //     string[] pairs = parameters.Split('&');
    //     foreach (string pair in pairs)
    //     {
    //         string[] keyValue = pair.Split('=');
    //         if (keyValue.Length == 2)
    //         {
    //             Debug.Log("Key: " + keyValue[0] + ", Value: " + keyValue[1]);
    //             name = keyValue[1];
    //         }

    //     }
    // }
    public string GetName()
    {
        return new_name;
    }
    public string GetPlayerID()
    {
        return player_id;
    }
    public string GetWallet()
    {
        return wallet_address;
    }
    public string GetTokens()
    {
        return tokens;
    }

}
