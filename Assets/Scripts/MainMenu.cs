using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public int firstLevel = 1;

    public void startGame(){
        SceneManager.LoadScene(firstLevel);
    }

    public void quitGame(){
        Application.Quit();
    }
}