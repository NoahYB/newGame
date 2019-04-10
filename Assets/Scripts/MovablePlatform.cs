using UnityEngine;
using System.Collections;

public class MovablePlatform : MonoBehaviour
{
    public float speed = .02f;
    public float distance = 1;
    Vector3 initPos;
    // Use this for initialization
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0);
        if (initPos.x > transform.position.x+distance)
        {
            speed *= -1;
        }
        if (initPos.x < transform.position.x - distance)
        {
            speed *= -1;
        }
    }
}
