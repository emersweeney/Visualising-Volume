using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour
{
    public int gameType;
    public GameObject fbManager;
    public InputField input;
    public Text text;
    public void ReplayLevel(){SceneManager.LoadScene(GameState.currentScene);}

    public void NextLevel(){
        if (GameState.currentScene==7) goToCheck1();
        else SceneManager.LoadScene(GameState.currentScene+1);
    }

    public void goHome(){SceneManager.LoadScene(0);}
    public void startButton(){SceneManager.LoadScene(10);}
    public void registerButton(){SceneManager.LoadScene(11);}
    public void loginButton(){SceneManager.LoadScene(6);}

    public void okButtonNormal(){
        if (GameState.currentScene==9) goToCheck2();
        else SceneManager.LoadScene(1);
    }

    public void goToCheck1(){SceneManager.LoadScene(12);}
    public void goToCheck2(){SceneManager.LoadScene(13);}
    private void Update(){if (Input.GetKey("escape")){Application.Quit();}}
    public void happyUnderstandingButton(){
        GameState.userUnderstanding=0; 
        fbManager.GetComponent<FirebaseManager>().callUpdateMethods(gameType); 
        checkEnd();}
    public void okUnderstandingButton(){
        GameState.userUnderstanding=1; 
        fbManager.GetComponent<FirebaseManager>().callUpdateMethods(gameType); 
        checkEnd();
    }
    public void sadUnderstandingButton(){
        GameState.userUnderstanding=2; 
        fbManager.GetComponent<FirebaseManager>().callUpdateMethods(gameType); 
        checkEnd();
    }

    private void checkEnd(){
        if (GameState.currentScene == 9) SceneManager.LoadScene(5);
        else SceneManager.LoadScene(GameState.currentScene+1);
    }

    public void getUserData(){
        GameState.userInfo="";
        fbManager.GetComponent<FirebaseManager>().getInfo(input.text);
        StartCoroutine(wait());

    }

    private IEnumerator wait(){
        yield return new WaitForSeconds(2f);
        if (GameState.userInfo==""){text.text = "username not found";}
        else {text.text = GameState.userInfo;}
    }
}
