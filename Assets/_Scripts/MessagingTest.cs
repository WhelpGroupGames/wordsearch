using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagingTest : MonoBehaviour {

    UnityEngine.UI.Text copyText;
    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    private string topic = "TestTopic";


	// Use this for initialization
	//void Start () {
 //       Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
 //       Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
 //       copy = GetComponent<UnityEngine.UI.Text>();
 //       copy.text = "successful init .. a PN will appear here";
	//}

    protected virtual void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    // Setup message event handlers.
    void InitializeFirebase()
    {
        Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
        Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
        Firebase.Messaging.FirebaseMessaging.Subscribe(topic);
        UnityEngine.Debug.Log("XXX: Firebase Messaging Initialized");
    }


    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
    {
        UnityEngine.Debug.Log("XXX: Received Registration Token: " + token.Token);
    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        UnityEngine.Debug.Log("XXX: MESSAGE RECEIVED");
        UnityEngine.Debug.Log("XXX: Received a new message from: " + e.Message.From);
        var notification = e.Message.Notification;
        copyText = GetComponent<UnityEngine.UI.Text>();

        if (notification != null)
        {
            UnityEngine.Debug.Log("XXX: title: " + notification.Title);
            UnityEngine.Debug.Log("XXX: body: " + notification.Body);
            copyText.text = "title: " + notification.Title;
            copyText.text += "\nbody: " + notification.Body;
        }

        if (e.Message.From.Length > 0)
            UnityEngine.Debug.Log("XXX: from: " + e.Message.From);
        
        if (e.Message.Link != null)
        {
            UnityEngine.Debug.Log("XXX: link: " + e.Message.Link.ToString());
        }

        if (e.Message.Data.Count > 0)
        {
            UnityEngine.Debug.Log("XXX: data:");
            foreach (System.Collections.Generic.KeyValuePair<string, string> iter in
                     e.Message.Data)
            {
                UnityEngine.Debug.Log("  XXX: " + iter.Key + ": " + iter.Value);
                copyText.text += "\n  XXX: " + iter.Key + ": " + iter.Value;
            }
        }


    }
	// Update is called once per frame
	void Update () {
		
	}
}
