using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    Rigidbody playerRd;
    public ParticleSystem ForMoney;
    public ParticleSystem ForBomb;
    public float flyForce;
    public AudioClip AudioForMoney;
    public AudioClip AudioForBomb;
    public AudioClip AudioForJump;
    public int lives;
    public bool gameOver = false;

    private float UpConstrain =11.6800003f;
    //Vector3(-3,0.629999995,0)
    private float LowerConstrant =0.629999995f;

    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRd = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameOver !=true)
        {
            playerRd.AddForce(Vector3.up * flyForce,ForceMode.Force);
            playerAudio.PlayOneShot(AudioForJump, 0.7f);
        }
        else if (transform.position.y >= UpConstrain) {
            transform.position = new Vector3(transform.position.x, UpConstrain, transform.position.z);
            playerRd.AddForce(Vector3.down * 200.0f);
            
        }
        else if (transform.position.y <= LowerConstrant)
        {
            transform.position = new Vector3(transform.position.x, LowerConstrant, transform.position.z);
            playerRd.AddForce(Vector3.up * 200.0f);
        }
    }

    
      private void OnCollisionEnter(Collision collision)
     {
        if (collision.gameObject.CompareTag("Money"))
        {
            Destroy(collision.gameObject);
            ForMoney.Play();
            playerAudio.PlayOneShot(AudioForMoney, 0.7f);
            // ForBomb.Play();
            //playerAudio.PlayOneShot(AudioForBomb, 0.7f);
        }
        else if (collision.gameObject.CompareTag("Bomb") && lives < 3)
        {
            ForBomb.Play();
            playerAudio.PlayOneShot(AudioForBomb, 0.7f);
            Destroy(collision.gameObject);
            lives++;
            // Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("Bomb") && lives == 3) {
            
            Destroy(collision.gameObject);
            Physics.gravity = new Vector3(0f, 0f, 0f);

            gameOver = true;
            

        }
     }
    


}
