using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Collections.Generic;

public class ProcessDeepLinkMngr : MonoBehaviour
{
    public static ProcessDeepLinkMngr Instance { get; private set; }
    public string deeplinkURL;
    public string new_name = "sample";
    public string wallet_address = "sample";
    public string player_id = "smple";
    public string tokens = "sample";
    public string roomCode = "sample";
    public List<int> skin_ids = new List<int>();
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
                string key = keyValue[0];
                string value = Uri.UnescapeDataString(keyValue[1]);
                Debug.Log($"Key: {key}, Value: {value}");

                switch (key)
                {
                    case "name": new_name = value; break;
                    case "player_id": player_id = value; break;
                    case "wallet_address": wallet_address = value; break;
                    case "tokens": tokens = value; break;
                    case "room_code": roomCode = value; break;
                    case "skin_ids":
                        skin_ids = value.Split(',').Select(s =>
                        {
                            int.TryParse(s, out int id);
                            return id;
                        }).ToList();
                        break;
                }
            }

        }
    }

    public string GetName() => new_name;
    public string GetPlayerID() => player_id;
    public string GetWallet() => wallet_address;
    public string GetTokens() => tokens;
    public string GetRoomCode() => roomCode;
    public List<int> GetSkinIDs() => skin_ids;
}
