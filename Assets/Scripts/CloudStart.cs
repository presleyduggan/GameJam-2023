using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;


public class CloudStart : MonoBehaviour {

    public GameObject circle;
    public GameObject beam;
    public TMP_Text dangerText;

    public GameObject player;

    public GameManager gm;

    private void Start() {
        //child = gameObject.transform.GetChild(0).gameObject;
        
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            StartCoroutine(startCloudScene());
        }
    }

    public IEnumerator startCloudScene(){
        player.GetComponent<Animator>().SetBool("isMoving", false);
        player.GetComponent<Animator>().SetBool("isFiring", false);
        player.GetComponent<CharacterController>().freeze();
        player.GetComponent<Weapon>().playerCanFire(false);
        circle.SetActive(true);
        dangerText.enabled = true;
        yield return new WaitForSeconds(3f);
        beam.SetActive(true);
      //  yield return new WaitForSeconds(3f);
        dangerText.text = "You'll have to get past me first....";
        yield return new WaitForSeconds(3f);


        // load next scene
        SceneManager.LoadScene(gm.nextLevel);

    }


}