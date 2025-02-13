using ExitGames.Client.Photon;
using Microsoft.VisualBasic;
using Photon.Pun;
using Photon.Realtime;

namespace ModsNetworking;

public class ModNetworking
{
    private readonly byte _channel;
    public ModNetworking(byte Channel)
    {
        _channel = Channel;

        PhotonNetwork.NetworkingClient.EventReceived += OnEventReceived;
    }

    public void SendMessage(object messageContent)
    {
        object[] content = { _channel, messageContent };
        PhotonNetwork.RaiseEvent(48, messageContent, RaiseEventOptions.Default, SendOptions.SendReliable);
    }

    public event Action<object>? OnMessageReceived;

    private void OnEventReceived(EventData data)
    {
        if(data.Code != 48) return;

        object[] rawData = (object[]) data.CustomData;
        int channel = (int)rawData[0];
        object messagePayload = rawData[1];

        if (channel != _channel) return;

        OnMessageReceived?.Invoke(messagePayload);
    }
}