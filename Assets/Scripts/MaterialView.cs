using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialView : MonoBehaviour, IPunObservable
{
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            string cp = Networker.CurrentPlayer;
            stream.Serialize(ref cp);
        } else
        {
            string cp = "";
            stream.Serialize(ref cp);
            Networker.CurrentPlayer = cp;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
