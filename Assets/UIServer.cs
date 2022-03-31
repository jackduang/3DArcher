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
    }
    public void ConnectedToServer()
    {
        manager.networkAddress = GameObject.Find("Address").GetComponent<Text>().text;
        manager.StartClient();
    }
    public void stopClent()
    {
        if (NetworkServer.active && NetworkClient.isConnected)
        {
            if (GUILayout.Button("Stop Host"))
            {
                manager.StopHost();
            }
        }
        // stop client if client-only
        else if (NetworkClient.isConnected)
        {
            if (GUILayout.Button("Stop Client"))
            {
                manager.StopClient();
            }
        }
        // stop server if server-only
        else if (NetworkServer.active)
        {
            if (GUILayout.Button("Stop Server"))
            {
                manager.StopServer();
            }
        }
    }
}
