using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//Character Switch Mechanic
public class SwitchCharacter : MonoBehaviour
{
    [SerializeField] private Camera mainCharCam;
    [SerializeField] private CinemachineFreeLook vcam;
    [SerializeField] private Camera animalCam;
    [SerializeField] private GameObject mainChar;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject mage;
    [SerializeField] private GameObject rogue;
    [SerializeField] private GameObject animal;

    [SerializeField] private GameObject knightSkeleton;

    [SerializeField] private GameObject mageSkeleton;

    [SerializeField] private GameObject rogueSkeleton;
    private GameObject currKnightSkeleton;
    private GameObject currMageSkeleton;
    private GameObject currRogueSkeleton;

    public GameObject WizUI;
    public GameObject KnightUI;
    public GameObject RogueUI;
    public GameObject MCUI;
    public GameObject knightPopUp;
    public GameObject roguePopUp;
    public GameObject magePopUp;

    public ParticleSystem transform = null;

    [SerializeField] private Vector3 mainCharCurPos;
    [SerializeField] private Vector3 kinghtSkeletonCurPos;
    [SerializeField] private Vector3 mageSkeletonCurPos;
    [SerializeField] private Vector3 rogueSkeletonCurPos;
    [SerializeField] private Vector3 animalCurPos;
    [SerializeField] private Vector3 mageCurPos;

    [SerializeField] private float distanceFromKnight;
    [SerializeField] private float distanceFromMage;
    [SerializeField] private float distanceFromRogue;

    private bool switchAvailable1 = true;
    private bool switchAvailable2 = true;
    private bool switchAvailable3 = true;
    private bool animalSwitch = true;
    void Start()
    {
        currKnightSkeleton = GameObject.FindGameObjectWithTag("KnightSkeleton");
        currMageSkeleton = GameObject.FindGameObjectWithTag("MageSkeleton");
        currRogueSkeleton = GameObject.FindGameObjectWithTag("RogueSkeleton");
    }
    // Update is called once per frame
    void Update()
    {
        mainCharCurPos = mainChar.transform.position;
        kinghtSkeletonCurPos = knight.transform.position;
        mageSkeletonCurPos = mage.transform.position;
        rogueSkeletonCurPos = rogue.transform.position;
        animalCurPos = animal.transform.position;
        mageCurPos = mage.transform.position;
        distanceFromKnight = Vector3.Distance(mainCharCurPos, kinghtSkeletonCurPos);
        distanceFromMage = Vector3.Distance(mainCharCurPos, mageSkeletonCurPos);
        distanceFromRogue = Vector3.Distance(mainCharCurPos, rogueSkeletonCurPos);
        KnightSwitch();
        MageSwitch();
        RogueSwitch();
        AnimalSwitch();
    }

    void KnightSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && switchAvailable1 == true && distanceFromKnight <= 2)
        {
            vcam.LookAt = knight.transform;
            vcam.Follow = knight.transform;
            mainChar.gameObject.SetActive(false);
            currMageSkeleton.gameObject.SetActive(false);
            currRogueSkeleton.gameObject.SetActive(false);
            knight.gameObject.SetActive(true);
            switchAvailable1 = false;
            Trans();
            OpenKnightUI();
            Destroy(currKnightSkeleton);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && switchAvailable1 == false)
        {
            vcam.LookAt = mainChar.transform;
            vcam.Follow = mainChar.transform;
            mainChar.gameObject.SetActive(true);
            currMageSkeleton.gameObject.SetActive(true);
            currRogueSkeleton.gameObject.SetActive(true);
            knight.gameObject.SetActive(false);
            switchAvailable1 = true;
            OpenMCUI();
            currKnightSkeleton = Instantiate(knightSkeleton, knight.transform.position, Quaternion.identity);
        }
    }

    void MageSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && switchAvailable2 == true && distanceFromMage <= 2)
        {
            vcam.LookAt = mage.transform;
            vcam.Follow = mage.transform;
            mainChar.gameObject.SetActive(false);
            currKnightSkeleton.gameObject.SetActive(false);
            currRogueSkeleton.gameObject.SetActive(false);
            mage.gameObject.SetActive(true);
            switchAvailable2 = false;
            Trans();
            OpenWizUI();
            Destroy(currMageSkeleton);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && switchAvailable2 == false && animalSwitch == true)
        {
            vcam.LookAt = mainChar.transform;
            vcam.Follow = mainChar.transform;
            mainChar.gameObject.SetActive(true);
            currKnightSkeleton.gameObject.SetActive(true);
            currRogueSkeleton.gameObject.SetActive(true);
            mage.gameObject.SetActive(false);
            switchAvailable2 = true;
            OpenMCUI();
            currMageSkeleton = Instantiate(mageSkeleton, mage.transform.position, Quaternion.identity);
        }
    }

    //animal switching ties the mages position to the mouse and vice versa
    void AnimalSwitch()
    {
        if (Input.GetKeyDown(KeyCode.E) && switchAvailable2 == false && animalSwitch == true)
        {
            animal.transform.position = mageCurPos -= new Vector3(0, .33f, 0);
            mage.gameObject.SetActive(false);
            vcam.LookAt = animal.transform;
            vcam.Follow = animal.transform;
            animal.gameObject.SetActive(true);
            animalSwitch = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && switchAvailable2 == false && animalSwitch == false)
        {
            mage.transform.position = animalCurPos += new Vector3(0, .33f, 0);
            mage.gameObject.SetActive(true);
            vcam.Follow = mage.transform;
            vcam.LookAt = mage.transform;
            animal.gameObject.SetActive(false);
            animalSwitch = true;
        }
    }

    void RogueSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && switchAvailable3 == true && distanceFromRogue <= 2)
        {
            vcam.LookAt = rogue.transform;
            vcam.Follow = rogue.transform;
            mainChar.gameObject.SetActive(false);
            currKnightSkeleton.gameObject.SetActive(false);
            currMageSkeleton.gameObject.SetActive(false);
            rogue.gameObject.SetActive(true);
            switchAvailable3 = false;
            Trans();
            OpenRogueUI();
            Destroy(currRogueSkeleton);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && switchAvailable3 == false)
        {
            vcam.LookAt = mainChar.transform;
            vcam.Follow = mainChar.transform;
            mainChar.gameObject.SetActive(true);
            currKnightSkeleton.gameObject.SetActive(true);
            currMageSkeleton.gameObject.SetActive(true);
            rogue.gameObject.SetActive(false);
            switchAvailable3 = true;
            OpenMCUI();
            currRogueSkeleton = Instantiate(rogueSkeleton, rogue.transform.position, Quaternion.identity);
        }
    }

    public void OpenWizUI()
    {
        WizUI.SetActive(true);
        MCUI.SetActive(false);
        Debug.Log("Loading Wiz");
    }

    public void OpenKnightUI()
    {
        KnightUI.SetActive(true);
        MCUI.SetActive(false);
        Debug.Log("Loading Knight");
    }

    public void OpenRogueUI()
    {
        RogueUI.SetActive(true);
        MCUI.SetActive(false);
        Debug.Log("Loading Rogue");
    }

    public void OpenMCUI()
    {
        MCUI.SetActive(true);
        WizUI.SetActive(false);
        KnightUI.SetActive(false);
        RogueUI.SetActive(false);
        Debug.Log("Loading MC");
    }

    public void Trans()
    {
        transform.Play();
    }

}
