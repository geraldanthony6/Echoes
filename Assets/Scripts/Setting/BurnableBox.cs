using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Destroys Boxes using Fire
public class BurnableBox : MonoBehaviour
{
    private bool isBurned = false;
    [SerializeField]private Material burned;
    // Update is called once per frame
    void Update()
    {
        if(isBurned == true){
            gameObject.GetComponent<MeshRenderer>().material = burned;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("FireBall")){
            Destroy(gameObject);
        } 
    }
}
