using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float length, startpos;
    public new GameObject camera;

    public float temp;

    public float parallaxEffect;

    private void Start()
    {
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void FixedUpdate()
    {
        float temp = (camera.transform.position.y * (1 - parallaxEffect));
        float distance = (camera.transform.position.y * parallaxEffect);

        transform.position = new Vector3(this.transform.position.x, startpos + distance , transform.position.z);

        if (temp > startpos + length - 4) startpos += length;
        else if (temp < startpos - length + 4) startpos -= length;

    }

}
