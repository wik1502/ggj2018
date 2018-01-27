using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCrepop : MonoBehaviour {

    [SerializeField] private GameObject npc;　//ポップさせるNPC

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
        Instantiate(npc, transform.position, transform.rotation);
    }
}
