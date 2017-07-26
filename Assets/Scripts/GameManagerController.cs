using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameManagerController : MonoBehaviour {    
    
    public List<ChoosedPlayer> players = new List<ChoosedPlayer>();

	// Use this for initialization
	void Start () {

        DontDestroyOnLoad(this);              
        
	}
	
	// Update is called once per frame
	void Update () {
       
        if (SceneManager.GetActiveScene().name.Equals("PlayerSelection") && players.Count < 1)
        {
            OnPlayerSelectionScene();
        }        
	}


    void OnPlayerSelectionScene()
    {
        foreach(ChoosedPlayer cs in FindObjectsOfType<ChoosedPlayer>()){
            players.Add(cs);
            
        }

        players.Sort((IComparer<ChoosedPlayer>)new sort());        
    }

    private class sort : IComparer<ChoosedPlayer>
    {
        int IComparer<ChoosedPlayer>.Compare(ChoosedPlayer x, ChoosedPlayer y)
        {
            int t1 = x.id;
            int t2 = y.id;
            return t1.CompareTo(t2);
        }
    }
}
