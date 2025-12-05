using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("ARCourse/Material Color Changer")]
[RequireComponent(typeof(MeshRenderer))]

public class MaterialColorChanger : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    [SerializeField] private Color _color;

    public void SetColor(Color newColor)
    {
        _color = newColor;
    }

    // Start is called before the first frame update
    void Start()
    {
       _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _meshRenderer.material.color = _color;
            
    }
}

