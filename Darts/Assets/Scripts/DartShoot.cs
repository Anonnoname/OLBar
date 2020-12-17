using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DartShoot : MonoBehaviour
{
    public static DartShoot _instance;

    Rigidbody rg;
    public bool isShoot = false;

    public int playerScore = 0;

    public Text playerScoreText;

    public AudioSource shootAudio;

    public List<GameObject> dartList=new List<GameObject>();

    public bool isGameOver = false;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    //Checks to see if there are still enough darts left, if not does not allow player to throw dart
    void Update()
    {
        playerScoreText.text = "Score: " + playerScore;
        print(dartList.Count);
        if (isShoot==false)
        {
            MouseFollow();         
        }
        if (dartList.Count==0)
        {
            isGameOver = true;
        }

        if (Input.GetMouseButtonDown(0) && isGameOver == false && dartList.Count>0 && isShoot==false)
        {
            isShoot = true;
            rg.AddForce(Vector3.forward * 170);

            dartList[0].SetActive(false);
            dartList.Remove(dartList[0]);      
        }
    }

    //Add points for when the dart hits the dart board
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DartField")
        {
            shootAudio.Play();
            switch (collision.gameObject.name)
            {
                case "s_01":
                    DartShoot._instance.playerScore += 1;
                    break;
                case "s_02":
                    DartShoot._instance.playerScore += 2;
                    break;
                case "s_03":
                    DartShoot._instance.playerScore += 3;
                    break;
                case "s_04":
                    DartShoot._instance.playerScore += 4;
                    break;
                case "s_05":
                    DartShoot._instance.playerScore += 5;
                    break;
                case "s_06":
                    DartShoot._instance.playerScore += 6;
                    break;
                case "s_07":
                    DartShoot._instance.playerScore += 7;
                    break;
                case "s_08":
                    DartShoot._instance.playerScore += 8;
                    break;
                case "s_09":
                    DartShoot._instance.playerScore += 9;
                    break;
                case "s_10":
                    DartShoot._instance.playerScore += 10;
                    break;
                case "s_11":
                    DartShoot._instance.playerScore += 11;
                    break;
                case "s_12":
                    DartShoot._instance.playerScore += 12;
                    break;
                case "s_13":
                    DartShoot._instance.playerScore += 13;
                    break;
                case "s_14":
                    DartShoot._instance.playerScore += 14;
                    break;
                case "s_15":
                    DartShoot._instance.playerScore += 15;
                    break;
                case "s_16":
                    DartShoot._instance.playerScore += 16;
                    break;
                case "s_17":
                    DartShoot._instance.playerScore += 17;
                    break;
                case "s_18":
                    DartShoot._instance.playerScore += 18;
                    break;
                case "s_19":
                    DartShoot._instance.playerScore += 19;
                    break;
                case "s_20":
                    DartShoot._instance.playerScore += 20;
                    break;
                default:
                    break;
            }
            Invoke("InitDart", 2.0f);
        }
    }

    //Creates the dart that follows the mouse
    public void InitDart()
    {
        transform.position = new Vector3(0, 0, -0.3009f);
        isShoot = false;
    }

    //Create instance for exiting game
    public void OnBtnExitClick()
    {
        Application.Quit();
    }

    //Makes the dart instance follow the mouse
    void MouseFollow()
    {
        
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        
        Vector3 mousePositionOnScreen = Input.mousePosition;
        
        mousePositionOnScreen.z = screenPosition.z;
        
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        
        transform.position = mousePositionInWorld;
    }
}
