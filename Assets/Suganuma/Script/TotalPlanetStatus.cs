using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalPlanetStatus : MonoBehaviour {

    private const int planet_num = 8;   // 初期設定できる惑星の数
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

    [SerializeField] private GameObject[] planet;

    private int[] planetStatus = new int[(int)MAIN_PARA_ID.MAXID];

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
        for (int i = 0; i < planet_num; i++)
        {
            MAIN_PARA_ID id = (MAIN_PARA_ID)planet[i].GetComponent<PlanetStatusChange>().GetState();
            planetStatus[(int)id]++;
        }

        string[] paramStr = { "norm", "temp", "air", "grav", "mess" };

        for (int i = 1; i < (int)MAIN_PARA_ID.MAXID; i++)
        {
			PlayerPrefs.SetInt("prottype"+paramStr[i],planetStatus[i]);
        }
    }
}
