using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCompositionManager : MonoBehaviour
{
    public Dictionary<string, float> composition;
    public CompositionManager compositionManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // foreach (var chemical in composition)
        // {
        //     if (compositionManager.composition.ContainsKey(chemical.Key))
        //     {
        //         compositionManager.composition[chemical.Key] = chemical.Value;
        //     }
        //     else
        //     {
        //         compositionManager.composition.Add(chemical.Key, chemical.Value);
        //     }
        // }
        composition = compositionManager.composition;
    }
}
