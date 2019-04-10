using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetTuningVar : MonoBehaviour
{
    public Slider speedSlider;
    public Toggle toggleTest;
    public InputField characterName;
    public GameObject scriptHolder;

    static float speed;
    static bool toggle;
    static string nameCharacter;
    static string n;

    public static string getName()
    {
        return nameCharacter;
    }
    public static float getSpeed()
    {
        return speed;
    }
    public static bool getToggle()
    {
        return toggle;
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = speedSlider.value;

        toggle = toggleTest.isOn;

        DontDestroyOnLoad(scriptHolder);
    }
    // Update is called once per frame
    void Update()
    {
        nameCharacter = characterName.text;
    }
}
