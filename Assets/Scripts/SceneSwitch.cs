using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {

    public void SwitchToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void backToMainScene()
    {
        SceneManager.LoadScene("Start_menu");
    }

    public void backToMapSelectionScene()
    {
        SceneManager.LoadScene("Level_menu");
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
