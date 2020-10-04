using UnityEngine;
using UnityEngine.UI;

public class SavePeople : MonoBehaviour {

    public GameObject people;
    public Canvas canvas;
    public Slider slider;

    private void Update()
    {
        if (slider.value == 1.0f)
        {
            people.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canvas.gameObject.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        slider.value = 0.0f;
        canvas.gameObject.SetActive(false);
    }
}
