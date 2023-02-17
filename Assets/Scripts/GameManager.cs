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

    public AudioSource levelMusic;

    // Start is called before the first frame update
    void Start()
    {
        playerStartingPosition = player.transform.position;
        playerInfo = player.GetComponent<Player>();
        /* switch(levelNumber){
            case 1:

        
        } */
        levelMusic = GetComponent<AudioSource>();

        defaultDeathText.text = deathText.text;

        levelMusic.Play();
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
        //player.SetActive(false);
        Debug.Log("respawning player...");
        player.GetComponent<CharacterController>().freeze();
        deathText.enabled = true;
        yield return new WaitForSeconds(3f);
        deathText.enabled = false;
        player.transform.position = playerStartingPosition;
        var renderer = player.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.white);
        player.GetComponent<Player>().resetHP();
        player.GetComponent<Animator>().SetBool("dead", false);
        player.GetComponent<CharacterController>().unfreeze();
        //player.SetActive(true);
        Debug.Log("player is respawned?");

    }


    public void updateRespawnPoint(Transform newRespawn)
    {
        playerStartingPosition = newRespawn.position;
    }

    public void endLevel(){
        playerInfo.makeImmune(true);
        endText.enabled = true;
        player.GetComponent<CharacterController>().freeze();
        player.GetComponent<Animator>().SetBool("isMoving", false);

        // load next scene.... after waiting

    }

    /* public void RespawnPlayer(){

    } */


}
