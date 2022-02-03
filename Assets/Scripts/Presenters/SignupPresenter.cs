using TMPro;
using UnityEngine;

public class SignupPresenter : MonoBehaviour
{
    #region Script Parameters
    public TMP_InputField FirstName;
    public TMP_InputField LastName;
    public TMP_InputField email;
    public TMP_InputField Username;
    public TMP_InputField Password;
    #endregion

    #region Methods
    public void Signup()
    {
        UserController.sInstance.SignUp(FirstName.text, LastName.text, email.text, Username.text, Password.text);
    }
    #endregion
}
