public static class GameState
{
    private static int answer = 0;
    private static string message ="testing text";
    public static int correctAnswer{ 
        get{return answer;} 
        set{answer = value;}
    }
    public static string displayMessage{ 
        get{return message;} 
        set{message = value;}
    }
}
