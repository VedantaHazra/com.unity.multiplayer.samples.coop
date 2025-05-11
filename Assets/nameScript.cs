using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Unity.Multiplayer.Samples.BossRoom
{

    public class nameScript : MonoBehaviour
    {
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI player_idText;
        public TextMeshProUGUI walletText;
        public TextMeshProUGUI tokenText;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            ProcessDeepLinkMngr urlScript = GameObject.Find("ProcessDeepLinkMngr").GetComponent<ProcessDeepLinkMngr>();
            nameText.text = "Your name : " + urlScript.GetName();
            player_idText.text = "Player ID : " + urlScript.GetPlayerID();
            walletText.text = "Wallet Address : " + urlScript.GetWallet();
            tokenText.text = "Tokens : " + urlScript.GetTokens();
        }
    }
}
