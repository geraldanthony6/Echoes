using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Player Movement 
public class NewPlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject character;
    [SerializeField]private GameObject LoadScreen;
    private Animator animator;
    [SerializeField]private GameObject keyText;
    public float playerSpeed = 5f;
    public float turnTime = 0.1f;
    float turnVelocity;
    //Float variable for checking distance between player and objects
    private float distanceFromKey;
    private float distanceFromDoor;
    public Transform cam;
    //Location of character waist for item placement
    [SerializeField]private Transform characterWaist;
    //Locations of objects
    [SerializeField]private Transform key1Location;
    [SerializeField]private Transform doorLocation;
    //Gravity based variables
    private float gravity = 9.8f;
    private float constantGravity = -0.6f;
    private float currentGravity;
    private float maxGarvity = -15;
    public bool shielding = false;

    private Vector3 gravityMovement;

    private bool playerOnGround = false;
    private bool isWalking = false;
    private bool hasKey = false;
    private float xInput;
    private float zInput;

    void Start(){
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CalculatedGravity();

        PlayerMove();

        PickUpKey();

    }

    void PlayerMove()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        zInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(xInput, 0f, zInput).normalized;
        //this finds the angle the camera is facing and turns it into data we can use to control where the charachter moves and looks
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnTime);

        if(shielding)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        if (direction.magnitude > 0f || !controller.isGrounded)
        {
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * playerSpeed * Time.deltaTime + gravityMovement);
            isWalking = true;
            if(playerSpeed > 20)
            {
                animator.SetFloat("Blend", 0.5f, 0.05f, Time.deltaTime);
            }
            else
            {
                animator.SetFloat("Blend", 0.25f, 0.1f, Time.deltaTime);
            }
        } else {
            isWalking = false;
            animator.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
        }
    }
    
    void PickUpKey(){
        //Checks if key and door are still in scene. If they are do distance calculation, if they're not set both values to 0
        if(key1Location != null && doorLocation != null){
        distanceFromKey = Vector3.Distance(key1Location.position, transform.position);
        distanceFromDoor = Vector3.Distance(doorLocation.position, transform.position);
        } else {
            distanceFromDoor = 0;
            distanceFromKey = 0;
        }
        
        //Attaches key to player on use
        if(distanceFromKey <= 2 && Input.GetKeyDown(KeyCode.F)){
            hasKey = true;
            key1Location.gameObject.SetActive(false);
        } 
        if(hasKey == true){
            keyText.SetActive(true);
        } else if(hasKey == false){
            keyText.SetActive(false);
        }
        
        //Destroys door and key on use
        if(distanceFromDoor <= 5f && hasKey == true && Input.GetKeyDown(KeyCode.F)){
            hasKey = false;
            Destroy(doorLocation.gameObject);
            doorLocation = null;
            Destroy(key1Location.gameObject);
            key1Location = null;
        }

        
    }

    private void CalculatedGravity()
    {
        if(controller.isGrounded)
        {
            currentGravity = constantGravity;
        }
        else
        {
            if(gravity > maxGarvity)
            {
                currentGravity -= gravity * Time.deltaTime;
            }
        }

        gravityMovement = Vector3.down * -currentGravity * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Lava")){
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        } 
        if(other.CompareTag("Level1_Load")){
            LoadScreen.SetActive(true);
            SceneManager.LoadScene("Level_1");
        } 
        if(other.CompareTag("End")){
            LoadScreen.SetActive(true);
            SceneManager.LoadScene("End");
        }
    }
}
