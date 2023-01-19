using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Fireball spell cast for mage
public class MageCharacter : MonoBehaviour
{
    //Fire Spell Variables
    public Transform castPoint;
    [SerializeField]private GameObject fireBall;
    public float fireBallForce = 1f;
    public float fireSpellCooldown = 0;

    // Update is called once per frame
    void Update()
    {
        if(fireSpellCooldown > 0){
            fireSpellCooldown -= Time.deltaTime;
        }

        fireSpell();
    }

    void fireSpell(){
         if(Input.GetKeyDown(KeyCode.Q) && fireSpellCooldown <= 0){
            GameObject tmpFireBall = Instantiate(fireBall, castPoint.transform.position, Quaternion.identity);;

            Rigidbody tmpRb = tmpFireBall.GetComponent<Rigidbody>();;

            tmpRb.velocity = castPoint.forward * 10;
            fireSpellCooldown = 2f;
        }
    }

}
