using UnityEngine;
using System.Collections;

public class MomentumPlatform : MonoBehaviour
{
    public float drag = .2f;
    // Use this for initialization
    void Start()
    {
        drag = drag * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
