using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public float speed = 0.0f;

    private void Update()
    {
        if(RouteCanvasSliderController.Instance.isEnd == false)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}