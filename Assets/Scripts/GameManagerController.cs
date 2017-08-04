using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameManagerController : MonoBehaviour {    
    
    public List<ChoosedPlayer> players = new List<ChoosedPlayer>();
    public string modSelected;

    public bool selecaoPersonagem = true;

    private GameObject lastSelectedGameObject;
	// Use this for initialization
	void Start () {
                
        DontDestroyOnLoad(this);
        
	}
	
	// Update is called once per frame
	void Update () {
        
        if(EventSystem.current != null)
        {
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                lastSelectedGameObject = EventSystem.current.currentSelectedGameObject;
            }
            else
            {
                EventSystem.current.SetSelectedGameObject(lastSelectedGameObject);
            }
        }
        

        if (SceneManager.GetActiveScene().name.Equals("PlayerSelection") && selecaoPersonagem)
        {         
                OnPlayerSelectionScene();           
        }        
        
	}
    

    void OnPlayerSelectionScene()
    {
        players.Clear();
        foreach(ChoosedPlayer cs in FindObjectsOfType<ChoosedPlayer>()){
            players.Add(cs.GetComponent<ChoosedPlayer>());
            
        }
        players.Sort((IComparer<ChoosedPlayer>)new sort());
        selecaoPersonagem = false;
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
