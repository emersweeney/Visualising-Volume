using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SolutionScript : MonoBehaviour
{
    [SerializeField] private Text textMessage;
    private string message;
    private bool userChoseCorrectly;

    private void Start(){
        message = GameState.solution;
        userChoseCorrectly = GameState.choseCorrectly;
        if (userChoseCorrectly){textMessage.text = "That's correct, well done!! "+message;}
        else {textMessage.text = "Oops, that's not quite right! "+message;}
    }

}
