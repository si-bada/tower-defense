using UnityEngine;

public class MainMenu : MonoBehaviour
{
    #region Script Parameters
    public GameObject MainCanvas;
    public GameObject LoginCanvas;
    public GameObject SignupCanvas;
    #endregion

    #region Methods
    public void Login()
    {
        LoginCanvas.SetActive(true);
        MainCanvas.SetActive(false);
    }
    public void Signup()
    {
        SignupCanvas.SetActive(true);
        MainCanvas.SetActive(false);
    }
    public void Back(GameObject gameObject)
    {
        gameObject.SetActive(false);
        MainCanvas.SetActive(true);
    }
    #endregion

}
