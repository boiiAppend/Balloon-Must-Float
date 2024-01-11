using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spwanmanage : MonoBehaviour
{
    private float UpConstrain = 11.6800003f;
    private float LowerConstrant = 0.629999995f;
    public GameObject[] hehe;
    private playerControl playerControlScript;
    private Vector3 SpwanPos;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spwanAnimal", 1.0f,2.0f);
        playerControlScript = GameObject.Find("Player").GetComponent <playerControl> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spwanAnimal() {
        if(playerControlScript.gameOver == false) {
            int Animal = Random.Range(0, hehe.Length);
            SpwanPos = new Vector3(37, Random.Range(LowerConstrant, UpConstrain), 0);
            Instantiate(hehe[Animal], SpwanPos, hehe[Animal].transform.rotation);

            
        }
        
        
    }
}
