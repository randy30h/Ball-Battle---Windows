using UnityEngine;

public class ArSwitcher : MonoBehaviour
{
    public Animator buttonAnim;
    private bool isEnabled;
    private bool on;

    private void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            isEnabled = true;
            buttonAnim.SetBool("enabled", true);
        }
        else
        {
            isEnabled = false;
            buttonAnim.SetBool("enabled", false);
        }
    }

    public void SwitchAR()
    {
        if(isEnabled)
        {
            if (on)
            {
                on = false;
                buttonAnim.SetBool("on", false);
            }
            else
            {
                on = true;
                buttonAnim.SetBool("on", true);
            }
        }
    }
}
