using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawner used for knight puzzles
public class FireballSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    [SerializeField]private GameObject fireBall;
    public float fireBallForce = 10f;
    public float fireBallCooldown = 0;

    // Update is called once per frame
    void Update()
    {
        if(fireBallCooldown > 0){
            fireBallCooldown -= Time.deltaTime;
        }
        ShootFireball();
    }

    void ShootFireball(){
            if(fireBallCooldown <= 0){
            GameObject tmpFireBall = Instantiate(fireBall, spawnPoint.transform.position, Quaternion.identity);;

            Rigidbody tmpRb = tmpFireBall.GetComponent<Rigidbody>();;

            tmpRb.velocity = spawnPoint.forward * fireBallForce;
            fireBallCooldown = 2f;
        }
    }
}
