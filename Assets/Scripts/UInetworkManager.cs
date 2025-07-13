using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UInetworkManager : MonoBehaviour
{
   [SerializeField] private Button HostStart;
   [SerializeField] private Button ClientStart;
    void Start()
    {
        HostStart.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartHost();
            Hide();
        });
        ClientStart.onClick.AddListener(() =>
        {
            NetworkManager.Singleton.StartClient();
            Hide();
         });
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
   
}
