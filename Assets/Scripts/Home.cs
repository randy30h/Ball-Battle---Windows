using UnityEngine;
using UnityEngine.SceneManagement;
public class Home : MonoBehaviour
{
    public GameObject loading;
    public GameObject optionDialogue;
    public Animator[] switchButtonAnim;

    [Header("Sounds")]
    public AudioSource[] soundEffects;
    public AudioSource music;

    private void Update()
    {
        if (PlayerPrefs.GetInt("SoundEffectMute") == 0)
        {
            for (int i = 0; i < soundEffects.Length; i++) soundEffects[i].mute = false;
        }
        else 
        {
            for (int i = 0; i < soundEffects.Length; i++) soundEffects[i].mute = true;
        }

        if (PlayerPrefs.GetInt("MusicMute") == 0) music.mute = false;
        else music.mute = true;
    }

    public void OptionManager()
    {
        if (optionDialogue.activeSelf) optionDialogue.SetActive(false);
        else optionDialogue.SetActive(true);
    }

    public void Play()
    {
        loading.SetActive(true);
        Invoke("LoadScene", 1.5f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void SoundManager()
    {
        if (PlayerPrefs.GetInt("SoundEffectMute") == 0)
        {
            switchButtonAnim[0].SetBool("on", false);
            PlayerPrefs.SetInt("SoundEffectMute", 1);
        }
        else
        {
            switchButtonAnim[0].SetBool("on", true);
            PlayerPrefs.SetInt("SoundEffectMute", 0);
        }
    }

    public void MusicManager()
    {
        if (PlayerPrefs.GetInt("MusicMute") == 0)
        {
            switchButtonAnim[1].SetBool("on", false);
            PlayerPrefs.SetInt("MusicMute", 1);
        }
        else
        {
            switchButtonAnim[1].SetBool("on", true);
            PlayerPrefs.SetInt("MusicMute", 0);
        }
    }
}
