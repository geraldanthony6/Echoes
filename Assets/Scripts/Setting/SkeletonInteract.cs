using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls UI for skeleton interaction
public class SkeletonInteract : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private float distanceFromPlayer;
    [SerializeField]private GameObject interactUI;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector3.Distance(player.transform.position, transform.position);

        if(distanceFromPlayer <= 2){
            interactUI.SetActive(true);
        } else {
            interactUI.SetActive(false);
        }
    }
}
