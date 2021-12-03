using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [SerializeField] private GameObject character1, character2;
    [SerializeField] private Material char1mat, char2mat;

    public void changeCharactersMaterial(){
        character1.GetComponentInChildren<Renderer>().material = char1mat;
        character2.GetComponentInChildren<Renderer>().material = char2mat;
    }
}
