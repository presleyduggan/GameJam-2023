using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{

    public TMP_Text displayText;

    public List<string> cutsceneText;
    public List<float> waitTimes;

    public float waitTime = 5f;

    public int nextLevel;

    public bool isWizardTower = false;

    public GameObject player;
    public GameObject wizard;


    private void Start() {
        StartCoroutine(playCutscenes());
    }



    
    public IEnumerator playCutscenes(){
        
        for(int i = 0; i < cutsceneText.Count; i++){
            displayText.text = cutsceneText[i];
            yield return new WaitForSecondsRealtime(waitTimes[i]);
           // Debug.Log("Finished cutscene text "+ i);
            if(i == 4 && isWizardTower){
                killMailman();
                yield return new WaitForSecondsRealtime(1f);
                player.GetComponent<Animator>().SetBool("dead", true);
            }

        }


        SceneManager.LoadScene(nextLevel);
        

    }

    private void killMailman(){
        // fire spell
        StartCoroutine(wizard.GetComponent<Weapon>().Shoot());
    }


   


}
