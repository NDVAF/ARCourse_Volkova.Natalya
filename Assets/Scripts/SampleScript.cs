using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("ARCourse/Sample Script")]
public class SampleScript : MonoBehaviour
{
    public int IntValue = 5;
    public float FloatValue = 10;
    public double DoubleValue = 15;
    public string StringValue = "Hello";
    public bool BoolValue = true;

    [Header("Color for material")]
    [TooltipAttribute("This color will be applied on choosen material")]
    public Color ColorMaterial = Color.red;
    [Space(10)]

    public SampleScript SampleCommponent;
    [HideInInspector] public float HidenFloat;
    [SerializeField][Range(1.0f, 10.0f)] private float _privateFloatValue;

    [SerializeField] private MessageLogger _logger;

    private void Start()
    {
        _logger.LogMessage(); 

        Debug.Log($"@IntValue {IntValue}"); 
        Debug.Log($"@FloatValue {FloatValue}");
        Debug.Log($"@DoubleValue {DoubleValue}");
        Debug.Log($"@StringValue {StringValue}");
        Debug.Log($"@BoolValue {BoolValue}");
    }

    private void Update()
    {
        Debug.Log($"IntValue {IntValue}");
        Debug.Log($"FloatValue {FloatValue}");
        Debug.Log($"DoubleValue {DoubleValue}");
        Debug.Log($"StringValue {StringValue}");
        Debug.Log($"BoolValue {BoolValue}");
    }
}
