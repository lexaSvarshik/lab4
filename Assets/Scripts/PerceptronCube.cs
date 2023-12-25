using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Perceptron))]
public class PerceptronCube : MonoBehaviour
{
    [SerializeField] public Material zero1;
    [SerializeField] public Material one1;

    private Perceptron perceptron;

    public void Start()
    {
        perceptron = GetComponent<Perceptron>();
        GetComponent<MeshRenderer>().material = perceptron.CalcOutput(0, 0) == 0 ? zero1 : one1;
    }
 
    public void OnTriggerEnter(Collider other)
    {
        GetComponent<MeshRenderer>().material = perceptron.CalcOutput(0, 1) == 0 ? zero1 : one1;
    }

    public void OnCollisionEnter(Collision other)
    {
        GetComponent<MeshRenderer>().material = perceptron.CalcOutput(1, 1) == 0 ? zero1 : one1;
    }
}