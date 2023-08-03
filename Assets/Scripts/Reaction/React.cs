using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class React : MonoBehaviour
{
    [SerializeField] CompositionManager compositionManager;
    [SerializeField] Material material;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] ChemicalsList chemicalsList;

    public Color color;
    // Start is called before the first frame update
    void Start()
    {
        compositionManager = GetComponent<CompositionManager>();
        chemicalsList = GameObject.FindGameObjectWithTag("ChemicalsList").GetComponent<ChemicalsList>();
        meshRenderer = GetComponent<MeshRenderer>();

        Renderer rend = GetComponent<Renderer>();
        rend.material = new Material(Shader.Find("Specular"));
    }

    // Update is called once per frame
    void Update()
    {
        if (compositionManager.composition["HCl"] > 0 && compositionManager.composition["NaOH"] > 0)
        {
            if (compositionManager.composition["HCl"] > compositionManager.composition["NaOH"])
            {
                compositionManager.composition["NaOH"] = 0;
                compositionManager.composition["HCl"] -= compositionManager.composition["NaOH"];
                compositionManager.composition["NaCl"] += compositionManager.composition["NaOH"];
                compositionManager.composition["H2O"] += compositionManager.composition["NaOH"];
            }
            else
            {
                compositionManager.composition["HCl"] = 0;
                compositionManager.composition["NaOH"] -= compositionManager.composition["HCl"];
                compositionManager.composition["NaCl"] += compositionManager.composition["HCl"];
                compositionManager.composition["H2O"] += compositionManager.composition["HCl"];
            }
        }

        if (compositionManager.composition["NaOH"] > 0 && compositionManager.composition["Phenolphthalein"] > 0)
        {
            Debug.Log("NaOH: " + compositionManager.composition["NaOH"]);
            Debug.Log("Phenolphthalein: " + compositionManager.composition["Phenolphthalein"]);
            // material.CopyPropertiesFromMaterial(meshRenderer.material);
            Renderer rend = GetComponent<Renderer>();
            color = Color.Lerp(chemicalsList.H2OColor, chemicalsList.NaOHPhenolphthalineColor, compositionManager.composition["NaOH"] / compositionManager.volumeOccupied);
            rend.material.color = color;
        }


        Debug.Log("% NaOH: " + compositionManager.composition["NaOH"] / compositionManager.volumeOccupied);
        Debug.Log("% HCl: " + compositionManager.composition["HCl"] / compositionManager.volumeOccupied);
    }
}
