using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour {

    public GameObject playerPrefab;
    public ArrayList players;
    public int NumberOfPlayers = 4;
    private System.Random random = new System.Random(System.DateTime.Now.Millisecond);
	// Use this for initialization
	void Start () {
        GameObject[] spawntags = GameObject.FindGameObjectsWithTag("Respawn");
        shuffle(spawntags, NumberOfPlayers);
        players = new ArrayList();
        for (int id = 0; id < NumberOfPlayers; ++id)
        {
            Instantiate(playerPrefab, spawntags[id].transform.position, Quaternion.identity);
            players[id] = playerPrefab;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Shuffles randomly NumShuffles times. The front NumShuffles in the array
    // are the shuffled elements. All objects in the array stay in the array, but
    // their order will be different. The advantage is no new memory is required, so if
    // persisting order doesn't matter, this is optimal.
    private void shuffle(GameObject[] arr, int NumShuffles)
    {
        for (int i = 0; i < NumShuffles; i++)
        {
            int r = random.Next(0, arr.Length);
            // swap
            var temp = arr[i];
            arr[i] = arr[r];
            arr[r] = temp;
        }
    }
}
