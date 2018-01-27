using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGeneration : MonoBehaviour {

    private bool moveStart;
    [SerializeField] GameObject lookPoint;
    private float deltaTimeWait = 1;

    [SerializeField] Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        
    }

    void MoveStart()
    {
        moveStart = true;
        //anim.SetBool("GenerationStart", true);
    }

    void Move()
    {
        if (moveStart == true)
        {
            deltaTimeWait -= Time.deltaTime;
            if(deltaTimeWait <= 0)
            {
                //transform.Translate(1 * Time.deltaTime, 0, 2 * Time.deltaTime);
            }            
        }
    }
}
