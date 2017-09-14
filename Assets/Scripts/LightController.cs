using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    List<LightsTest> players = new List<LightsTest>();
    List<MovePlayer> inGame = new List<MovePlayer>();
    public float light_timer = 0f;
    public int atual_player_lighted = 0;
    public bool player_was_dead = false;

    // Use this for initialization

    void recalibrateLights() {
        players.Clear();
        inGame.Clear();

        foreach (MovePlayer playerInGame in FindObjectsOfType<MovePlayer>())
        {
            inGame.Add(playerInGame);
        }

        foreach (LightsTest player in FindObjectsOfType<LightsTest>())
        {
            players.Add(player);
            player.illumination.enabled = false;
        }

        players.Sort(delegate (LightsTest a, LightsTest b) {
            return (a.id).CompareTo(b.id);
        });

        atual_player_lighted = 0;
    }

    void Start () {

        recalibrateLights();
        players[0].illumination.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (player_was_dead == true)
        {            
            recalibrateLights();
            player_was_dead = false;
        }

        //recalibrateLights();
        light_timer += Time.deltaTime;

        if (light_timer >= 3f) {
            light_timer = 0;

            if (players[atual_player_lighted] != null)
            {
                players[atual_player_lighted].illumination.enabled = false;

                atual_player_lighted++;
                if (atual_player_lighted + 1 > inGame.Count)
                {
                    atual_player_lighted = 0;
                }

                players[atual_player_lighted].illumination.enabled = true;
            }
            else {
                atual_player_lighted++;
                if (atual_player_lighted + 1 > inGame.Count)
                {
                    atual_player_lighted = 0;
                }

                players[atual_player_lighted].illumination.enabled = true;
                recalibrateLights();

            }

        }

	}

}
