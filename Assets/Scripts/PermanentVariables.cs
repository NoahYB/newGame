using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class PermanentVariables
{
    static float speed;
    static bool toggle;
    static string nameCharacter;

    public static string getName()
    {

        return nameCharacter;
    }
    public static float getSpeed()
    {
        speed = GetTuningVar.getSpeed();
        return speed;
    }
    public static bool getToggle()
    {
        toggle = GetTuningVar.getToggle();
        return toggle;
    }
}
