public static class GameState
{
    private static int currentGameScene, answer = 0;
    private static string message = "testing text", solutionMessage = "solution text";
    private static bool userChoseCorrectAnswer = false;
    
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

    public static bool choseCorrectly{
        get{return userChoseCorrectAnswer;}
        set{userChoseCorrectAnswer = value;}
    }
}

