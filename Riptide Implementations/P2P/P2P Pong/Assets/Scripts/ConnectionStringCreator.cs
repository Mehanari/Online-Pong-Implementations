using System;
using System.Net;
using System.Net.Sockets;
using TMPro;
using UnityEngine;

public class ConnectionStringCreator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ipAddressText;
    [SerializeField] private TextMeshProUGUI portText;

    private void Start()
    {
        ipAddressText.text = GetIpAddress();
        portText.text = GetPort();  
    }
    
    private string GetIpAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            Debug.Log("Address family: " + ip.AddressFamily + " IP: " + ip);
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }

        return "Could not get local IP address.";
    }
    
    private string GetPort()
    {
        return "7777";
    }
}
