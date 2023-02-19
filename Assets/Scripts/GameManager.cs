using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
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

    public bool isWizardFireLevel = false;

    public bool isWizard = false;

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

        levelMusic.Play();

        playerAnimator = player.GetComponent<Animator>();
        playerController = player.GetComponent<CharacterController>();

        if(isWizardFireLevel){
            StartCoroutine(wizardFireLevel());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playerDied(string text){
        if(text != null){
            deathText.text = text;
        }
        else{
            deathText.text = defaultDeathText.text;
        }
        StartCoroutine(respawnPlayer());
    }


    public IEnumerator respawnPlayer(){
        if(isWizard){
            player.GetComponent<Weapon>().playerCanFire(false);
        }
        //player.SetActive(false);
        //Debug.Log("respawning player...");
        playerController.freeze();
        deathText.enabled = true;
        //Debug.Log("freezing :'(");
        yield return new WaitForSeconds(3f);
        //Debug.Log("freezing done :'(");
        deathText.enabled = false;
        player.transform.position = playerStartingPosition;
        var renderer = player.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.white);
        playerInfo.resetHP();
        playerAnimator.SetBool("dead", false);
        playerController.unfreeze();
        if(isWizard){
            player.GetComponent<Weapon>().playerCanFire(true);
        }
        //player.SetActive(true);
        //Debug.Log("player is respawned?");

    }


    public void updateRespawnPoint(Transform newRespawn)
    {
        playerStartingPosition = newRespawn.position;
    }

    public IEnumerator endLevel(){
        playerInfo.makeImmune(true);
        endText.enabled = true;
        playerController.freeze();
        playerAnimator.SetBool("isMoving", false);

        yield return new WaitForSeconds(3f);


        // load next scene.... after waiting
        SceneManager.LoadScene(nextLevel); // index is one less than current level... starts at 0


    }

    public IEnumerator wizardFireLevel(){
        deathText.color = Color.white;
        deathText.text = "As the wizard you may now hold left mouse to fire";
        deathText.enabled = true;
        yield return new WaitForSeconds(3f);
        deathText.enabled = false;
        deathText.color = Color.black;
        deathText.text = defaultDeathText.text;
    }

    public bool returnIsWizard(){
        return isWizard;
    }

    /* public void RespawnPlayer(){

    } */


}
