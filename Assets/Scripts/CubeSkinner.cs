using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSkinner : MonoBehaviour {

    public Material elton;
    public Material radke;
    public Material raab;

    private string lastPlayer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (lastPlayer != Networker.CurrentPlayer)
        {
            lastPlayer = Networker.CurrentPlayer;
            switch (lastPlayer)
            {
                case "elton":
                    GetComponent<Renderer>().material = elton;
                    break;
                case "raab":
                    GetComponent<Renderer>().material = raab;
                    break;
                case "radke":
                    GetComponent<Renderer>().material = radke;
                    break;
            }
        }
	}
}
