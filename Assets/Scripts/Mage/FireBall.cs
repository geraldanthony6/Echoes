using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Fireball audio and behavior
public class FireBall : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioClip clip;

    void Start(){
        audioSource.PlayOneShot(clip, 1);
    }
    void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
        } else if(other.gameObject.CompareTag("BurnableBox")){
            Destroy(gameObject);
        } else if(other.gameObject.CompareTag("Shield")){
            Destroy(gameObject);
            Debug.Log("ShieldHit");
        } else if(other.gameObject.CompareTag("Player")){
            Destroy(gameObject);
            Debug.Log("Player is dead.");
        } else if(other.gameObject.CompareTag("Knight")){
            Debug.Log("KnightDead");
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Shield")){
            Debug.Log("Shield");
        } 
        if(other.CompareTag("Knight") || other.CompareTag("CharacterOutfit") || other.CompareTag("Mage") || other.CompareTag("Rogue")){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
