using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CloudManager : MonoBehaviour
{

    public GameObject player;
    private Vector3 playerStartingPosition;
    public TMP_Text deathText;
    public TMP_Text endText;

    public TMP_Text defaultDeathText;

    public Player playerInfo;

    public int levelNumber;
    public int nextLevel;

    public AudioSource levelMusic;

    private Animator playerAnimator;
    private CharacterController playerController;

    [SerializeField]
    private Cloud cloudBoss;

    // Start is called before the first frame update
    void Start()
    {
        nextLevel = levelNumber + 1;
        playerStartingPosition = player.transform.position;
        playerInfo = player.GetComponent<Player>();
        /* switch(levelNumber){
            case 1:

        
        } */
        levelMusic = GetComponent<AudioSource>();

        defaultDeathText.text = deathText.text;

        playerAnimator = player.GetComponent<Animator>();
        playerController = player.GetComponent<CharacterController>();

        cloudBoss = FindObjectOfType<Cloud>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cloudBoss.health);
        if(cloudBoss.health <= 0){
            // end level
           // Debug.Log("Ending level function");
            StartCoroutine(endLevel());
        }
    }

    public void playerDied(string text){
        player.GetComponent<Weapon>().playerCanFire(false);
        if(text != null){
            deathText.text = text;
        }
        else{
            deathText.text = defaultDeathText.text;
        }
        StartCoroutine(respawnPlayer());
    }


    public IEnumerator respawnPlayer(){
        //player.SetActive(false);
        //Debug.Log("respawning player...");
        playerController.freeze();
        deathText.enabled = true;
        //Debug.Log("freezing :'(");
        yield return new WaitForSeconds(3f);
       // Debug.Log("freezing done :'(");
        SceneManager.LoadScene(levelNumber);
        //player.SetActive(true);
        //Debug.Log("player is respawned?");

    }


    public IEnumerator endLevel(){
        //Debug.Log("End level function");
        playerInfo.makeImmune(true);
        endText.enabled = true;
        playerController.freeze();
        playerAnimator.SetBool("isMoving", false);

        yield return new WaitForSeconds(3f);


        // load next scene.... after waiting
        SceneManager.LoadScene(nextLevel); // index is one less than current level... starts at 0


    }

    /* public void RespawnPlayer(){

    } */


}
