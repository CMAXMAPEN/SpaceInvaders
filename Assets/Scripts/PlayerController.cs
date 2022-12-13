using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject laserBeam, laserBeamSpawn;
    public float fireRate = 0.25f;
    private float timer = 0;

    public Rigidbody2D rBody;
    public Vector3 startPosition;
    public AudioClip shoot;
    

    private float movement;


    void Start()
    {
        startPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        rBody.velocity = new Vector2(movement * speed, 0);

        if(Input.GetAxis("Fire1") > 0 && timer > fireRate) //if right click is pressed and there has been enough time between shots
        {
            //GameObject.Instantiate();
            AudioSource.PlayClipAtPoint(shoot, rBody.transform.position);
            GameObject goObj;
            goObj = Instantiate(laserBeam, laserBeamSpawn.transform.position, laserBeamSpawn.transform.rotation);
            //spawning our laser beams, setting their position and rotation relative to ship
            timer = 0;
        }
        timer += Time.deltaTime;

    }

}
