using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

    private Slider slider;
    public float speed = 0.3f;
    private float targetProgress = 0;
	// Use this for initialization
	private void Awake () {
        slider = gameObject.GetComponent<Slider>();
	}

    private void Start()
    {
        IncreaseProgress(1.0f);   
    }

    // Update is called once per frame
    void Update () {
		if (slider.value < targetProgress)
        {
            slider.value += speed * Time.deltaTime;
        }
	}

    public void IncreaseProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
