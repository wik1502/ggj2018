using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetStatusChange : MonoBehaviour {

    private enum MAIN_PARA_ID
    {
        normal = 0,
        tempe,
        air,
        grav,
        mass,
        MAXID
    };

    private enum SAB_PARA_ID
    {
        water = 0,
        elec,
        pois,
        metal,
        MAXID
    };


    [SerializeField] private Color32[] colerPattern = new Color32[5];
    private GameObject myObject;
    private MAIN_PARA_ID state;

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
        string[] paramStr = {"", "温度", "空気", "重力", "質量"};
        state = (MAIN_PARA_ID)((int)(state + 1) % (int)MAIN_PARA_ID.MAXID);

        GetComponent<Renderer>().material.color = colerPattern[(int)state];
        myText.text = paramStr[(int)state];

 
    }

    public int GetState()
    {
        return (int)state;
    }
}
