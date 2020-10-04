using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour {
    bool isStop = true;
    public bool pass = false;
    public GameObject option;
    public GameObject passCanvas;
    public GameObject failCanvas;
    public float time = 60.0f;
	public Text timer;
    public Text hostige;
    private GameObject[] npcs;
    private int numberOfNPCS;
    //private GameObject failConvas;
    //private GameObject passConvas;
    private GameObject userControl;

    void Start () {
        Time.timeScale = 1;
        isStop = true;
        pass = false;
        option.SetActive(false);
        passCanvas.SetActive(false);
        failCanvas.SetActive(false);

        timer.text = "Remaining Time: " + (time).ToString("0.0");
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        numberOfNPCS = npcs.Length;
        hostige.text = "Remaining Hostiges: " + numberOfNPCS.ToString("0");

        //failConvas = GameObject.FindGameObjectWithTag("FailCanvas");
        //failConvas.SetActive(false);

        //passConvas = GameObject.FindGameObjectWithTag("PassCanvas");
        //passConvas.SetActive(false);

        userControl = GameObject.FindGameObjectWithTag("Player");
        userControl.GetComponent<CarUserControl>().enabled = true;
        //userControl.GetComponent<CarAudio>().enabled = true;
    }


    // Update is called once per frame
    void Update () {
        
        time -= Time.deltaTime;
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        numberOfNPCS = npcs.Length;
        if (time <= 0){
            Time.timeScale = 0;
            //failConvas.SetActive(true);
            failCanvas.SetActive(true);
        }
		else
        {
            timer.text = "Remaining Time: " + (time).ToString("0.0");
            hostige.text = "Remaining Hostiges: " + numberOfNPCS.ToString("0");
        }
			
        if (pass == true)
        {
            Time.timeScale = 0;
            //passConvas.SetActive(true);
            passCanvas.SetActive(true);
        }

        if (isStop == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                isStop = false;
                option.SetActive(true);
            }
        }
        else {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                isStop = true;
                option.SetActive(false);
            }
        }
      }

    public void reloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void backToMainScene()
    {
        SceneManager.LoadScene("Start_menu");
    }

    public void backToMapSelectionScene()
    {
        SceneManager.LoadScene("Level_menu");
    }

    public void LoadToScene(string name){
        //isStop = true;
        //option.SetActive(false);
		SceneManager.LoadScene(name);
	}


	public void returnBack(){
		Time.timeScale = 1;
        isStop = true;
        option.SetActive(false);
	}

	public void exitGame(){
		Application.Quit();
	}


}