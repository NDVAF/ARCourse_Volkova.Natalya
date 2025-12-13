using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private Color _hoverColor;
    [SerializeField] private Color _clickColor;
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _layerMask;

    private List<int> _clickedObjectsID;
    private int _lastObjectHitedID;
   

    void Start()
    {
        _clickedObjectsID = new List<int>();
    }

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, _layerMask))
        {

            if (Input.GetKeyDown(KeyCode.C))
            {
                var materialC = hit.transform.GetComponent<MeshRenderer>().material;
                materialC.SetColor("_Color", _clickColor);

                if (!_clickedObjectsID.Contains(hit.transform.GetInstanceID()))
                {
                    _clickedObjectsID.Add(hit.transform.GetInstanceID());
                }
            }

            if (_lastObjectHitedID == hit.transform.GetInstanceID())
            {
                return;
            }
            
            if (_clickedObjectsID.Contains(hit.transform.GetInstanceID()))
            {
                return;
            }
            
            var material = hit.transform.GetComponent<MeshRenderer>().material;
            material.SetColor("_Color", _hoverColor);
            _lastObjectHitedID = hit.transform.GetInstanceID();


        }
        else
        {
            _lastObjectHitedID = -1;
        }
    }
}
