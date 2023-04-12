using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMaterial : MonoBehaviour
{
    [Header("Materials")]
    [Space(10)]
    // [Tooltip("The Destroy Material, Gets on start by the GameManager.cs")]
    // [SerializeField] private Material destroyMaterial;
    [Tooltip("The Default Material, Gets on start by the block")]
    [SerializeField] private List<List<Material>> defaultMaterials = new();
    [SerializeField] private List<Renderer> renderers = new();

    [SerializeField] private bool mouseOver = false;
    public bool MouseOver
    {
        get { return mouseOver; }
        set { mouseOver = value; }
    }

    // [Header("Utility")]    
    // [Space(10)]
    // [Tooltip("The MainBlock, Gets on start by the GameManager.cs")]
    // [SerializeField] private GameObject mainBlock;

    [Header("Data")]
    [Space(10)]
    [SerializeField] private PieceMaterialData pieceData;

    private void Start()
    {
        // mainBlock = GameManager.instance.GetMainBlock;
        // Debug.Log(this.gameObject.name);
        // Debug.Log(renderers.Count);
        // Debug.Log(defaultMaterials.Count);
        foreach (var item in GetComponentsInChildren<Renderer>())
        {
            if (!renderers.Contains(item))
            {
                renderers.Add(item);
            }
            List<Material> _materials = new();
            foreach (var i in item.materials)
            {
                _materials.Add(i);
            }
            if (!defaultMaterials.Contains(_materials))
            {
                defaultMaterials.Add(_materials);
            }
        }
        // defaultMaterial = GetComponentsInChildren<Renderer>().material;
        // destroyMaterial = pieceData.GetDestroyMaterial;
    }

    private void Update()
    {
        // if (this.gameObject.transform.parent != null)
        // {
        //     if (this.gameObject.transform.parent.parent.name == "Vehicle")
        //     {
        //         if (MouseOver)
        //             SetToDestroyMaterial();
        //         else
        //             SetToDefaultMaterial();
        //         ResetMaterial();
        //     }
        // }
    }

    /// <summary>
    ///     This function resets the block to the default material, 
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         Observation
    ///     </para>
    ///     <para>
    ///         The difference of this and the SetToDefaultMaterial is that this function will be called on the update function and this function was made for we can reset material by exiting the EditMode or the DestroyMode without remove mouse over the block that we suposed want to delete.
    ///     </para>
    /// </remarks>
    public void ResetMaterial()
    {
        if ((!GameManager.instance.GetCanDestroy || !GameManager.instance.GetIsEditing))
        {
            SetToDefaultMaterial();
        }
    }

    /// <summary>
    ///     This function set the block to the destroy material.
    /// </summary>
    public void SetToDestroyMaterial()
    {
        // this.gameObject.GetComponentInChildren<Renderer>().material = pieceData.GetDestroyMaterial;
        // foreach (var renderer in renderers)
        // {
        //     renderer.material = pieceData.GetDestroyMaterial;
        //     for (int i = 0; i < renderer.materials.Length; i++)
        //     {
        //         renderer.materials[i] = pieceData.GetDestroyMaterial;
        //     }
        // }
        Material[] _DestroyMaterial = { pieceData.GetDestroyMaterial };
        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].materials = _DestroyMaterial;
        }
    }

    /// <summary>
    ///     This function set the block to the default material.
    /// </summary>
    public void SetToDefaultMaterial()
    {
        // this.gameObject.GetComponentInChildren<Renderer>().material = defaultMaterial;

        for (int i = 0; i < renderers.Count; i++)
        {
            renderers[i].materials = defaultMaterials[i].ToArray();
        }
    }

    /// <summary>
    ///     This function gets the current material used by block.
    /// </summary>
    private Material GetCurrentMaterial()
    {
        return this.gameObject.GetComponentInChildren<Renderer>().material;
    }

    // /// <summary>
    // ///     This is native function that check if the mouse exited over the block, i used this function to reset the block to the default material.
    // /// </summary>
    // private void OnMouseExit()
    // {
    //     if (GameManager.instance.GetCanDestroy /* && (this.gameObject != mainBlock) */)
    //     {
    //         SetToDefaultMaterial();
    //     }
    // }

    // /// <summary>
    // ///     This is native function that check if the mouse is over the block, i used this function to set the block to the destroy material.
    // /// </summary>
    // private void OnMouseEnter()
    // {
    //     if (GameManager.instance.GetCanDestroy /* && (this.gameObject != mainBlock) */)
    //     {
    //         SetToDestroyMaterial();
    //     }
    // }
}
