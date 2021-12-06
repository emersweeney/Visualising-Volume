using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonReader : MonoBehaviour
{
    [SerializeField] private TextAsset textJSON;
    DecisionData[] dummy = new DecisionData[1];

    [System.Serializable]
    public class DecisionData{
        public int state;
        public string message;
        public string solution;

        public int getState(){return state;}
        public string getMessage(){return message;}
        public string getSoluion(){return solution;}

        public override string ToString(){
            return "state: " + state + "message: " +message + "solution: " + solution;
        }
    }

    [System.Serializable]
    public class DecisionArrays{
        public DecisionData[] bath_buckets;
        public DecisionData[] teapot_teacups;
    }

    private DecisionArrays decisions = new DecisionArrays();

    private void Start() {
        decisions = JsonUtility.FromJson<DecisionArrays>(textJSON.text);
        DecisionData test = (DecisionData)decisions.bath_buckets.GetValue(0);
        
    }

    public ref DecisionData[] getDecisionArray(int version){
        decisions = JsonUtility.FromJson<DecisionArrays>(textJSON.text);
        switch (version)
        {
            case 0: return ref decisions.bath_buckets;
            case 1: return ref decisions.teapot_teacups;     
        }
        print("Invalid game version number");
        return ref dummy;
    }
}
