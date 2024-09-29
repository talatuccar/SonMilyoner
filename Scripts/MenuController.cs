using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject inputPanel;
    public GameObject aboutPanel;
    public  TMP_InputField playerName; 
    void Awake()
    {
        Time.timeScale = 1;
    }
    public void InputPanelActive()
    {
        inputPanel.SetActive(true);
        if (TouchScreenKeyboard.isSupported)
        {
            TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        }
        else
        {         
            Debug.Log("Touch screen keyboard is not supported on this device.");
        }
    }
    public void aboutPanelActive(bool active)
    {     
        aboutPanel.SetActive(active);
    }
    public void ReadyForGame()
    {
        PlayerPrefs.SetString("playerName", playerName.textComponent.text);
        
        inputPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
