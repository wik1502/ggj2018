using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStatusChange : MonoBehaviour {

    [SerializeField] private Color32[] colerPattern = new Color32[5];
    private GameObject myObject;
    private int state;

    [SerializeField] TextMesh myText;

    [SerializeField] private GameObject totalStatus;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void ChangeStatus(int val)
    {
        state++;
        if(state >= 5)
        {
            state = 0;
        }
        if(state == 0)
        {
            GetComponent<Renderer>().material.color = colerPattern[0];
            myText.text = ("");
        }
        if(state == 1)
        {
            GetComponent<Renderer>().material.color = colerPattern[1];
            myText.text = ("温度");
        }
        if(state == 2)
        {
            GetComponent<Renderer>().material.color = colerPattern[2];
            myText.text = ("空気");
        }
        if(state == 3)
        {
            GetComponent<Renderer>().material.color = colerPattern[3];
            myText.text = ("重力");
        }
        if(state == 4)
        {
            GetComponent<Renderer>().material.color = colerPattern[4];
            myText.text = ("質量");
        }
    }

    public int GetState()
    {
        return state;
    }
}
