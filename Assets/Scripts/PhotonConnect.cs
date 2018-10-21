using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviourPunCallbacks {
    public bool isServer;
    public GameObject serverCam;

    public static bool serverMode;
    public static GameObject propeller;

    public void ConnectToPhoton()
    {
        PhotonConnect.serverMode = isServer;
        if (!serverMode)
        {
            serverCam.active = false;
        }
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Connecting...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master successfully!");
        RoomOptions rOpts = new RoomOptions();
        rOpts.IsVisible = true;
        rOpts.IsOpen = true;
        rOpts.MaxPlayers = 100;
        PhotonNetwork.JoinOrCreateRoom("testRoom", rOpts, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        if (propeller == null && !serverMode)
        {
            propeller = PhotonNetwork.Instantiate("Propeller", new Vector3() , new Quaternion());
        }
        Debug.Log("Room Joined!");
    }
}