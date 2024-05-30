using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARroomInstance : MonoBehaviour
{
    public Transform contents;

    public float starttime;

    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
        contents.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float deltaTime = Time.time - starttime;
        if (deltaTime > 0.5f && deltaTime < 1f)
        {
            float scale = (deltaTime - 0.5f) * 2;
            contents.localScale = new Vector3(scale, scale, scale);
        }
    }
}
