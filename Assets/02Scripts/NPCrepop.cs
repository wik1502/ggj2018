using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCrepop : MonoBehaviour {

    [SerializeField] private GameObject npc;　//ポップさせるNPC
    private Vector3 popPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Repop()
    {
        //ポップ時の音をここで流す
        popPos = new Vector3(Random.Range(-14, 14), Random.Range(-5, 5), 0);
        Instantiate(npc, popPos, transform.rotation);
    }
}
