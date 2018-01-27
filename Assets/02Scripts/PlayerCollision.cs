using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    public static bool triggerEnter;    //接触した瞬間ONになる
    public static Collider collider;    //プレイヤーに衝突した対象

	// Use this for initialization
	void Start () {
        triggerEnter = false;
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider t)
    {
        t.GetComponent<NpcInputTouch>().deadTrigger = true;     //接触した時点でNPCは死ぬ(無慈悲)
        triggerEnter = true;
        collider = t;
    }

    void OnTriggerExit(Collider t)
    {
        triggerEnter = false;   //スクリプトPlayerSystemでfalseにしているけど、一応ここでもfalseにする
        collider = t;
    }
}
