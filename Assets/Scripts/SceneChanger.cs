using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Restart scene
public class SceneChanger : MonoBehaviour
{

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("CharacterOutfit")){
            Debug.Log("Hit");
            SceneManager.LoadScene("Level_1");
        }
    }
}
