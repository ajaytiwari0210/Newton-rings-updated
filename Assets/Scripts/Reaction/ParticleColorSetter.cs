using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColorSetter : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private ParticleCompositionManager particleCompositionManager;
    // Start is called before the first frame update
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        particleCompositionManager = GetComponent<ParticleCompositionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var renderer = particleCompositionManager.compositionManager.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            var main = particleSystem.main;
            main.startColor = renderer.material.color;
        }
    }
}
