using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {
	
    public string LocalIPAddress()
    {
        IPHostEntry host;
        string ipAddress = "";

        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList){
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                ipAddress = ip.ToString();
                break;
            }
        }
        return ipAddress;
    }

    public void MyStartHost()
    {
        StartHost();
        Debug.Log("Starting Host: " + LocalIPAddress() + " Time Started: \n" + System.DateTime.Now);
    }

    public override void OnStartHost()
    {
        Debug.Log("Host started: " + LocalIPAddress() + " Time Started: \n" + System.DateTime.Now);
    }

    public override void OnStartClient(NetworkClient client)
    {
        Debug.Log(System.DateTime.Now + " Client Start Requested");
        InvokeRepeating("ConnectingDots", 0f, 1f);
        base.OnStartClient(client);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log(System.DateTime.Now + " Client Connected. IP:" + conn.address);
        CancelInvoke();
        base.OnClientConnect(conn);
    }

    public void ConnectingDots()
    {
        print(".");
    }
}
