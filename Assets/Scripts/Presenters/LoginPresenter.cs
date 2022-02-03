using UnityEngine;
using TMPro;

public class LoginPresenter : MonoBehaviour
{
    #region Script Parameters
    public TMP_InputField Username;
    public TMP_InputField Password;
    public GameObject errorText;
    #endregion

    #region Methods
    public void Login()
    {
        UserController.sInstance.Login(Username.text, Password.text);
    }
    #endregion

}
