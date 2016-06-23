using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class PauseMenu : MonoBehaviour {

    [SerializeField] GameObject panel;
    bool Panel;

    public void PauseGame(bool escape)
    {
        if (escape == true)
        {
            panel.SetActive(true);
            Panel = true;
            Time.timeScale = 0.0f;
        }
        if (Panel == true || escape == true)
        {
            panel.SetActive(false);
            Panel = false;
            Time.timeScale = 1.0f;
        }
    }
    public void TogglePause()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}


























































/*======================*\
|************************|
|************************|
|************************|
|*****#DylanFuckedUp*****|
|************************|
|************************|
|************************|
\*======================*/