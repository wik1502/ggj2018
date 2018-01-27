using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCrepop : MonoBehaviour {


    [SerializeField] private GameObject npc;　//ポップさせるNPC
    private Vector3 popPos;
    int debugkey = -1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            debugkey = 1;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            debugkey = 2;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            debugkey = 3;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            debugkey = 4;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            debugkey = 5;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            debugkey = 6;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            debugkey = 7;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha8))
        {
            debugkey = 8;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha9))
        {
            debugkey = 9;
        }
        else if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            debugkey = 0;
        }
    }

    void Repop()
    {
        //ポップ時の音をここで流す
        popPos = new Vector3((Random.Range(0, 10) + 5) * (Random.Range(0, 2) * 2 - 1), (Random.Range(0, 3) + 3) * (Random.Range(0, 2) * 2 - 1), 0);
        if (popPos.x >= 9 && popPos.y >= 4.5)
        {
            popPos.y = 3;
        }
        GameObject generatedNPC = Instantiate(npc, popPos, transform.rotation);
        int mParam = 0;
        int sParam = 0;
        switch (debugkey)
        {
            case 0:
                mParam = 0;
                sParam = 4;
                break;
            case 1:
                mParam = 1;
                sParam = 4;
                break;
            case 2:
                mParam = 2;
                sParam = 4;
                break;
            case 3:
                mParam = 3;
                sParam = 4;
                break;
            case 4:
                mParam = 4;
                sParam = 4;
                break;
            case 5:
                mParam = 0;
                sParam = 0;
                break;
            case 6:
                mParam = 0;
                sParam = 1;
                break;
            case 7:
                mParam = 0;
                sParam = 2;
                break;
            case 8:
                mParam = 0;
                sParam = 3;
                break;
            case 9:
                mParam = 0;
                sParam = 0;
                break;
            default:
                mParam = Random.Range(0, 5);
                sParam = Random.Range(0, 5);
                break;
        }

        debugkey = -1;
        generatedNPC.GetComponent<NpcParameter>().SetParam(mParam, sParam);
        SoundManager.Instance.PlaySE(1);                        //1=決定音
    }
}
