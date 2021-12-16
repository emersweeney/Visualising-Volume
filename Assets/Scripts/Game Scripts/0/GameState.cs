using Firebase;
using Firebase.Database;
using Firebase.Auth;
public static class GameState
{
    private static int currentGameScene, answer = 0;
    private static string message = "testing text", solutionMessage = "solution text";
    private static bool userChoseCorrectAnswer = false;
    private static int understandingIndicator=0; //0=happy, 1=not sure, 2=not happy
    private static string username;
    private static FirebaseUser user;
    private static string userData;
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

    public static int userUnderstanding{
        get{return understandingIndicator;}
        set{understandingIndicator = value;}    
    }

    public static string usernameString{
        get{return username;}
        set{username = value;}
    }

    public static FirebaseUser fbUser{
        get{return user;}
        set{user = value;}
    }

    public static string userInfo{
        get{return userData;}
        set{userData = value;}    
    }
}

