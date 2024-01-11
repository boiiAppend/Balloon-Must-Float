using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private float Startpos;
    private float RepeatWidth;
    public float BackGroundMoveSpeed;
    private playerControl PlayerControllerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        RepeatWidth = GetComponent<BoxCollider>().size.x / 2;
        Startpos = transform.position.x;
        PlayerControllerScript = GameObject.Find("Player").GetComponent <playerControl> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerScript.gameOver == false) {
            transform.Translate(Vector3.left * BackGroundMoveSpeed * Time.deltaTime);
            if (transform.position.x <= Startpos - RepeatWidth)
            {
                transform.position = new Vector3(Startpos, transform.position.y, transform.position.z);
            }
        }
       
    }


}
