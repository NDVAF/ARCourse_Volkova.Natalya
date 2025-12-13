using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectApiSample : MonoBehaviour
{
    //example1+
    //[SerializeField] private GameObject _prefab;
    //[SerializeField] private GameObject _objectToDestroy;
    //[SerializeField] private GameObject _objectToDeactivate;
    //[SerializeField] private GameObject _objectToActivate;
    //example1-
    //example2+
    //[SerializeField] private string _desiredTag;
    //example2-
    //example3+
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Vector3 _movementDirection;
    [SerializeField] private Vector3 _rotationDirection;
    //example3-

    void Start()
    {
        //example1+
        //Instantiate(_prefab); 
        //Destroy(_objectToDestroy);
        //_objectToActivate.SetActive(true);
        //_objectToDeactivate.SetActive(false);
        //example1-

        //example2+
        //Debug.Log($"tag {tag}, layer {gameObject.layer}");
        //Debug.Log($"is tag desired {CompareTag(_desiredTag)}");
        //example2-
        //example3+
        transform.SetParent(null);
        //example3-

    }
    private void FindSample()
    {
        FindableComponent getComponent = gameObject.GetComponent<FindableComponent>();
        Debug.Log($"GetComponent {getComponent.name}");

        FindableComponent[] findableComponents = gameObject.GetComponents<FindableComponent>();
        Debug.Log($"GameObject id {gameObject.GetInstanceID()}");
        foreach (FindableComponent component in findableComponents)
        {
            Debug.Log($"findableComponents {component.GetInstanceID()}");
        }

        GameObject find = GameObject.Find("SeparateObject");
        FindableComponent onFinded = find.GetComponent<FindableComponent>();
        Debug.Log($"findedGameobject {onFinded.name}");

        FindableComponent inChildren = GameObject.Find("ParentWithoutComponent").GetComponentInChildren<FindableComponent>();
        Debug.Log($"inChildren {inChildren.name}");

        var componentsInChildren = GameObject.Find("ParentWithoutComponent").GetComponentsInChildren<FindableComponent>();
        foreach (FindableComponent component in componentsInChildren)
        {
            Debug.Log($"componentsInChildren {component.name}, id {component.GetInstanceID()}");
        }

        FindableComponent inParent = GameObject.Find("ComponentInParent").GetComponentInParent<FindableComponent>();
        Debug.Log($"inParent {inParent.name}");

    }
    
    void Update()
    {
        //example3+
        var tr = transform;
        tr.Translate(_movementDirection * _movementSpeed * Time.deltaTime);
        tr.Rotate(_rotationDirection * _rotationSpeed * Time.deltaTime);
        //example3-
    }
}
