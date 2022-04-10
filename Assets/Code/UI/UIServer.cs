using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIServer : MonoBehaviour
{
    NetworkManager manager;
    private void Awake()
    {
        manager = GameObject.FindObjectOfType<NetworkManager>().GetComponent<NetworkManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BuildingServer()
    {
        if (!NetworkClient.active)
        {
            manager.StartHost();
        }
        gameObject.SetActive(false);
    }
    public void ConnectedToServer()
    {
        manager.networkAddress = GameObject.Find("Address").GetComponent<Text>().text;
        manager.StartClient();
        gameObject.SetActive(false);

    }
    public void stopClent()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            manager.StopHost();
        }
        // stop client if client-only
        else if (NetworkClient.isConnected)
        {
            manager.StopClient();
        }
        // stop server if server-only
        else if (NetworkServer.active)
        {
            manager.StopServer();
        }
        gameObject.SetActive(false);

    }
}
