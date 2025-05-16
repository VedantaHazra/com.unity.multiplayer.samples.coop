using UnityEngine;
using System.Collections.Generic;

namespace Unity.Multiplayer.Samples.BossRoom
{
    public class SkinManager : MonoBehaviour
    {
        // Assign these in the Inspector, should be ordered by skin ID
        public GameObject[] skinUIElements;

        void Start()
        {
            ProcessDeepLinkMngr urlScript = GameObject.Find("ProcessDeepLinkMngr").GetComponent<ProcessDeepLinkMngr>();
            List<int> skinIDs = urlScript.GetSkinIDs();

            foreach (int id in skinIDs)
            {
                if (id >= 0 && id < skinUIElements.Length)
                {
                    skinUIElements[id].SetActive(true);
                }
                else
                {
                    Debug.LogWarning($"Skin ID {id} is out of bounds.");
                }
            }
        }
    }
}
