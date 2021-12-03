public static class GameState
{
    private static int currentGameScene, answer = 0;
    private static string message = "testing text", solutionMessage = "solution text";
    
    public static int currentScene{
        get{return currentGameScene;}
        set{currentGameScene = value;}
    }
    public static int correctAnswer{ 
        get{return answer;} 
        set{answer = value;}
    }
    public static string displayMessage{ 
        get{return message;} 
        set{message = value;}
    }

    public static string solution{
        get{return solutionMessage;}
        set{solutionMessage = value;}
    }
}

