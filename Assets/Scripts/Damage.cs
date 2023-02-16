using UnityEngine;
using System.Collections.Generic;


public class Damage : MonoBehaviour {
    public int damage;

    [SerializeField]
    private List<string> damageText = new List<string>();

    private int count;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            if(count == 0) {
                string returnText = null;
                if(damageText.Count > 0){
                    returnText = returnRandomText();
                }
                other.gameObject.GetComponent<Player>().TakeDamage(damage, returnText);
            }
            count++;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            count--;
        }
    }

    private string returnRandomText(){
        int rand = Random.Range(0,damageText.Count);
        return damageText[rand];
    }

}