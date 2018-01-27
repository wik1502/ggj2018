using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalPlanetStatus : MonoBehaviour {

    [SerializeField] private GameObject[] planet;
    private float[] planetTemp;

    private float totalTemp;
    private float totalAir;
    private float totalGravity;
    private float totalMass;

    private int[] planetStatus = new int[5];

	// Use this for initialization
	void Start () {
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update () {

    }

    void StatusCheck()
    {
        for (int i = 0; i < 8; i++)
        {
            int id = planet[i].GetComponent<PlanetStatusChange>().GetState();
            planetStatus[id]++;
        }
        Debug.Log("defalt+" + planetStatus[0]);
        Debug.Log("temp+" + planetStatus[1]);
        Debug.Log("air+" + planetStatus[2]);
        Debug.Log("gra+" + planetStatus[3]);
        Debug.Log("mass+" + planetStatus[4]);
    }
}
