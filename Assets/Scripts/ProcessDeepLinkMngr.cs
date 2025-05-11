using UnityEngine;
using UnityEngine.SceneManagement;

public class ProcessDeepLinkMngr : MonoBehaviour
{
    public static ProcessDeepLinkMngr Instance { get; private set; }
    public string deeplinkURL;
    public string new_name = "sample";
    public string wallet_address = "sample";
    public string player_id = "smple";
    public string tokens = "sample";
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Application.deepLinkActivated += onDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                // Cold start and Application.absoluteURL not null so process Deep Link.
                onDeepLinkActivated(Application.absoluteURL);
            }
            // Initialize DeepLink Manager global variable.
            else deeplinkURL = "[none]";
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void onDeepLinkActivated(string url)
    {
        // Update DeepLink Manager global variable, so URL can be accessed from anywhere.
        deeplinkURL = url;

        // Decode the URL to determine action.
        // In this example, the app expects a link formatted like this:
        // unitydl://mylink?scene1
        string parameters = url.Split("?"[0])[1];
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
