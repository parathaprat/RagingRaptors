using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDragLine : MonoBehaviour
{
    LineRenderer _lineRenderer;
    GBird _bird;

    // Start is called before the first frame update
    void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _bird = FindObjectOfType<GBird>();

        _lineRenderer.SetPosition(0, _bird.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (_bird.isDragging)
        {
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(1, _bird.transform.position);
        }
        else
        {
            _lineRenderer.enabled = false;
        }
    }
}
