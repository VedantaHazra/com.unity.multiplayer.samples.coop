using UnityEngine;

namespace Unity.Multiplayer.Samples.BossRoom
{
    public class TokenUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject CharUI;
        [SerializeField] private GameObject TokenUI;

        private void Start()
        {
            CharUI.SetActive(true);
            TokenUI.SetActive(false);
        }
        public void ShowTokenUI()
        {
            CharUI.SetActive(false);
            TokenUI.SetActive(true);
        }
    }
}
