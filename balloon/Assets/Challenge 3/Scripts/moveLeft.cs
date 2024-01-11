using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveLeft : MonoBehaviour
{
    private float leftConstrain  = 4.0f;
    public float MoveSpeed;
    private playerControl playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<playerControl>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) {
            transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);

            if (transform.position.x == -leftConstrain)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
