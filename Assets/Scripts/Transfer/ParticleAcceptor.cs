using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAcceptor : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        Debug.Log("Collision with " + other.name);
        if (LayerMask.LayerToName(other.layer) == "Grab")
        {
            Debug.Log("Collision with fluid");
            var fluid = other.transform.Find("Fluid");
            if (fluid == null)
            {
                return;
            }
            var baseMesh = fluid.transform.Find("BaseMesh");
            if (baseMesh == null)
            {
                return;
            }
            var compositionManager = baseMesh.GetComponent<CompositionManager>();
            if (compositionManager == null)
            {
                return;
            }

            ParticleCompositionManager selfCompositionManager = GetComponent<ParticleCompositionManager>();

            if (selfCompositionManager == null)
            {
                return;
            }

            if (selfCompositionManager.compositionManager == compositionManager)
            {
                return;
            }

            Dictionary<string, float> selfComposition = selfCompositionManager.composition;
            float volumeOccupied = selfCompositionManager.compositionManager.volumeOccupied;
            // loop over all chemicals in the fluid
            foreach (var chemical in selfComposition)
            {
                // add the chemical to the particle
                compositionManager.AddChemical(chemical.Key, FluidFlowController.dropVolume * numCollisionEvents * chemical.Value / volumeOccupied);
            }
            // compositionManager.AddChemical("H2O", FluidFlowController.dropVolume * numCollisionEvents);
            // Debug.Log(other.transform.Find("Fluid").transform.Find("BaseMesh").GetComponent<CompositionManager>().composition["H2O"]);
        }
    }
}
