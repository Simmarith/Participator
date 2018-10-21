using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Net;
using System.Threading;

public class Networker : MonoBehaviour
{

    public static string CurrentPlayer;

	private HttpListener listener;
	private Thread listenerThread;

	void Start ()
	{
		listener = new HttpListener ();
		listener.Prefixes.Add ("http://*:4444/");
		listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
		listener.Start ();

		listenerThread = new Thread (startListener);
		listenerThread.Start ();
		Debug.Log ("Server Started");
	}

	void Update ()
	{		
	}

	private void startListener ()
	{
		while (true) {               
			var result = listener.BeginGetContext (ListenerCallback, listener);
			result.AsyncWaitHandle.WaitOne ();
		}
	}

	private void ListenerCallback (IAsyncResult result)
	{				
		var context = listener.EndGetContext (result);		

		Debug.Log ("Method: " + context.Request.HttpMethod);
        Debug.Log("LocalUrl: " + context.Request.Url.LocalPath);
        Debug.Log("LocalUrl: " + context.Request.Url);

        if (context.Request.Url.ToString().Contains("radke"))
        {
            CurrentPlayer = "radke";
            Debug.Log("We did radke stuff!");
        }

        if (context.Request.Url.ToString().Contains("elton"))
        {
            CurrentPlayer = "elton";
            Debug.Log("We did Elton stuff!");
        }

        if (context.Request.Url.ToString().Contains("raab"))
        {
            CurrentPlayer = "raab";
            Debug.Log("We did Raab stuff!");
        }

        context.Response.Close ();
	}

}