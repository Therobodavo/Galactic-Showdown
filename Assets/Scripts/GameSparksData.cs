using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSparksData : MonoBehaviour {
    
    public bool player1Online = false;
    public bool player2Online = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AuthPlayer()
    {
        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName("")
            .SetPassword("")
            .Send((response) => 
            {
                if(!response.HasErrors)
                {
                    
                }
            });
    }
}
