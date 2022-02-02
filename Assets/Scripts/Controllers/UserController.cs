using UnityEngine;
using UnityEngine.SceneManagement;

public class UserController : MonoBehaviour
{
    #region Static
    public static UserController sInstance;
    #endregion

    #region Script Parameters
    public User CurrentUser;
    public LoginPresenter LoginPresenter;
    public SignupPresenter SignupPresenter;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        sInstance = this;
    }
    #endregion

    #region Methods
    public void Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        string url = Endpoints.baseURL + Endpoints.Login;
        StartCoroutine(WebRequestHandeler.sInstance.HttpsPost(url, form, OnUserLogin));
    }
   
    public void SignUp(string first_name, string last_name, string email,  string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("first_name", first_name);
        form.AddField("last_name", last_name);
        form.AddField("email", email);
        form.AddField("username", username);
        form.AddField("password", password);
        string url = Endpoints.baseURL + Endpoints.Signup;
        StartCoroutine(WebRequestHandeler.sInstance.HttpsPost(url, form, OnUserSignup));
    }
    

    public void Save(int id, int score, int level_reached)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);
        form.AddField("score", score);
        form.AddField("level", level_reached);
        string url = Endpoints.baseURL + Endpoints.SaveScore;
        StartCoroutine(WebRequestHandeler.sInstance.HttpsPost(url, form, OnUserSaveScore));
    }
    #endregion

    #region Implementation
    private void OnUserLogin(string data)
    {
        try
        {
            var response = JsonUtility.FromJson<User>(data);
            if (response != null)
            {
                CurrentUser = response;
                SceneManager.LoadSceneAsync("LevelSelector");
            }
        }
        catch (System.Exception)
        {
            LoginPresenter.errorText.SetActive(true);
        }

    }
    private void OnUserSignup(string data)
    {
        try
        {
            Debug.LogWarning(data);
            var response = JsonUtility.FromJson<User>(data);
            if (response != null)
            {
                CurrentUser = response;
                SceneManager.LoadSceneAsync("LevelSelector");
            }
        }
        catch (System.Exception)
        {
            LoginPresenter.errorText.SetActive(true);
        }

    }
    private void OnUserSaveScore(string data)
    {
        var response = JsonUtility.FromJson<User>(data);
        if (response != null)
        {
            CurrentUser = response;
        }
    }
    #endregion
}
