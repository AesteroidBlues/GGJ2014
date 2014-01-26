﻿using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class ScreenTransitioner : MonoBehaviour {


    public string levelName;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        for(int i = 1; i < 5; i++)
	        if (XInputManager.GetAButton(GetIndex(i)) || XInputManager.GetStart(GetIndex(i)))
            {
                Application.LoadLevel(levelName);
            }
	}

    private PlayerIndex GetIndex(int i)
    {
        switch (i)
        {
            case 1: return PlayerIndex.One;
            case 2: return PlayerIndex.Two;
            case 3: return PlayerIndex.Three;
            case 4: return PlayerIndex.Four;
            default: return PlayerIndex.One;
        }
    }
}
