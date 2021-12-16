using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Auth;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class FirebaseManager : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference databaseRef;

    [Header("Login")]
    public InputField emailLogin;
    public InputField passwordLogin;
    public Text warningLogin;
    public Text confirmLogin;

    [Header("Register")]
    public InputField username;
    public InputField emailRegister;
    public InputField passwordRegister;
    public InputField passwordConfirmRegister;
    public Text warningRegister;


    private string waterDifficulty = "";
    private string volumeDifficulty = "";

    void Awake(){
        //use Firebase check method to check all necessary dependencies are available
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available){InitializeFirebase();}
            else{Debug.LogError("could not find all dependencies: " + dependencyStatus);}
        });
    }

    private void InitializeFirebase(){auth = FirebaseAuth.DefaultInstance; databaseRef = FirebaseDatabase.DefaultInstance.RootReference;
    Debug.Log(databaseRef.ToString());}
    public void LoginButton(){StartCoroutine(Login(emailLogin.text, passwordLogin.text));}
    public void RegisterButton(){StartCoroutine(Register(emailRegister.text, passwordRegister.text, username.text));}

    private IEnumerator Login(string _email, string _password){
        //use Firebase auth sign in method
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        if (LoginTask.Exception != null)
        {
            Debug.LogWarning(message: $"failed:{LoginTask.Exception}");
            FirebaseException firebaseEx = LoginTask.Exception.GetBaseException() as FirebaseException;
            AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

            string message = "login failed";
            switch (errorCode)
            {
                case AuthError.MissingEmail: message = "no email entered"; break;
                case AuthError.MissingPassword: message = "no password entered"; break;
                case AuthError.WrongPassword: message = "incorrect password"; break;
                case AuthError.InvalidEmail: message = "invalid email"; break;
                case AuthError.UserNotFound: message = "no account with this login exists"; break;
            }
            warningLogin.text = message;
        }
        else
        {
            //user is result of log in
            User = LoginTask.Result;
            GameState.fbUser=User;
            Debug.Log(User.ToString());
            warningLogin.text = "";
            confirmLogin.text = "you're logged in";  
            GameState.usernameString=User.DisplayName;
            yield return new WaitForSeconds(2f);
            //start games
            if (User.DisplayName=="teacher") SceneManager.LoadScene(14);
            else SceneManager.LoadScene(6);
        }

    }

    private IEnumerator Register(string email, string password, string username){
        if (username == ""){warningRegister.text = "no username entered";}
        else if(passwordRegister.text != passwordConfirmRegister.text){warningRegister.text = "passwords do not match";}
        else {
            //use Firebase auth sign in method
            var RegisterTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);
            yield return new WaitUntil(predicate: () => RegisterTask.IsCompleted);

            if (RegisterTask.Exception != null){
                Debug.LogWarning(message: $"failed: {RegisterTask.Exception}");
                FirebaseException firebaseEx = RegisterTask.Exception.GetBaseException() as FirebaseException;
                AuthError errorCode = (AuthError)firebaseEx.ErrorCode;

                string message = "failed to register";
                switch (errorCode){
                    case AuthError.MissingEmail: message = "no email entered"; break;
                    case AuthError.MissingPassword: message = "no password entered"; break;
                    // case AuthError.WeakPassword: message = "use a stronger password"; break;
                    case AuthError.EmailAlreadyInUse: message = "there is already an account with this email"; break;
                }
                warningRegister.text = message;
            }
            else{
                User = RegisterTask.Result; //user = result of registering
                if (User != null){
                    //Create a user profile and set the username
                    UserProfile profile = new UserProfile{DisplayName = username};

                    //Call the Firebase auth update user profile function passing the profile with the username
                    var ProfileTask = User.UpdateUserProfileAsync(profile);
                    yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

                    if (ProfileTask.Exception != null){
                        Debug.LogWarning(message: $"failed:{ProfileTask.Exception}");
                        FirebaseException firebaseEx = ProfileTask.Exception.GetBaseException() as FirebaseException;
                        AuthError errorCode = (AuthError)firebaseEx.ErrorCode;
                        warningRegister.text = "failed to set username";
                    }
                    else{SceneManager.LoadScene(10);/*go to login screen for user to log in with newly created account*/}
                }
            }
        }
    }

    //coroutines to update username in database
    private IEnumerator updateUsernameAuth(string username){   //update username in user profile in database
        //create user profile and set username
        UserProfile profile = new UserProfile {DisplayName = username};
        Debug.Log("profile =="+ profile.ToString());
        Debug.Log("user="+User.ToString());
        //Use Firebase method to update user profile with username
        var ProfileTask = User.UpdateUserProfileAsync(profile);
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);
        if (ProfileTask.Exception != null){Debug.LogWarning(message: $"Failed:{ProfileTask.Exception}");}
    }

    private IEnumerator updateUsernameDatabase(string username){
        //set current user's username in database
        var DBTask = databaseRef.Child("users").Child(User.UserId).Child("username").SetValueAsync(username);
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null){Debug.LogWarning(message: $"Failed:{DBTask.Exception}");}
    }

    //coroutines to update database entries for user understanding of concepts
    private IEnumerator updateProgress1(int indicator){
        var DBTask = databaseRef.Child("users").Child(User.UserId).Child("Water Level Understanding").SetValueAsync(indicator);
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null){Debug.LogWarning(message: $"Failed: {DBTask.Exception}");}
    }

    private IEnumerator updateProgress2(int indicator){
        var DBTask =databaseRef.Child("users").Child(User.UserId).Child("Compare Volume Understanding").SetValueAsync(indicator);
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null){Debug.LogWarning(message: $"Failed: {DBTask.Exception}");}
    }

    //call database update methods when buttons are pressed - accepts int to indicate game type
    public void callUpdateMethods(int gameType){
        User = GameState.fbUser;
        StartCoroutine(updateUsernameAuth(GameState.usernameString));
        StartCoroutine(updateUsernameDatabase(GameState.usernameString));
        if (gameType==1){StartCoroutine(updateProgress1(GameState.userUnderstanding));}
        else if (gameType==2){StartCoroutine(updateProgress2(GameState.userUnderstanding));}
    }

    //coroutine to read user data from database
    private IEnumerator getDatabaseInfo(string username){
        Debug.Log(username);
        //get database entries ordered by username
        var DBTask = databaseRef.Child("users").OrderByChild("username").GetValueAsync();
        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);
        if (DBTask.Exception != null){Debug.LogWarning(message: $"Failed:{DBTask.Exception}");}
        else{
            DataSnapshot snapshot = DBTask.Result;
            //loop through all user ids
            foreach (DataSnapshot childSnapshot in snapshot.Children)
            {
                if (childSnapshot.Child("username").Value.ToString() == username){
                    Debug.Log("username found");
                    int waterLevel = int.Parse(childSnapshot.Child("Water Level Understanding").Value.ToString());
                    int volume = int.Parse(childSnapshot.Child("Compare Volume Understanding").Value.ToString());
                    if (waterLevel==0){waterDifficulty = "understood";}
                    else if (waterLevel==1){waterDifficulty = "weren't sure about";}
                    else {waterDifficulty = "didn't understand";}
                    
                    if (volume==0){volumeDifficulty = "understood";}
                    else if (volume==1){volumeDifficulty = "wasn't sure about";}
                    else {volumeDifficulty = "didn't understand";}
                    
                    GameState.userInfo = username+" "+waterDifficulty+" the water level game and "+volumeDifficulty+" the comparing volume game.";
                    Debug.Log(GameState.userInfo);
                }
            }
        }
    }

    public void getInfo(string username){
        StartCoroutine(getDatabaseInfo(username));
    }
}