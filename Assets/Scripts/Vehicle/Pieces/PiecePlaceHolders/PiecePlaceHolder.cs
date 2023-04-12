using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecePlaceHolder : MonoBehaviour
{
    [SerializeField] private bool hasPieceOver = false;
    // [SerializeField] private Material defaultMaterial;
    // [SerializeField] private Material collisionMaterial;
    [SerializeField] private Vector3 sizeToDetect = new Vector3(0.5f, 0.5f, 0.5f);
    [SerializeField] private Vector3 collisionPos = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] private Mesh meshToDraw;
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private PieceMaterialData pieceMaterialData;

    public bool GetHasPieceOver => hasPieceOver;
    public void SetHasPieceOver(bool value){
        hasPieceOver = value;
    }
    private void Start() {
        // defaultMaterial = this.gameObject.GetComponentInChildren<Renderer>().material;
        renderers = GetComponentsInChildren<Renderer>();
    }
    private void Update() {
        SetHasPieceOver(Physics.CheckBox(this.transform.position + collisionPos, sizeToDetect/2, this.transform.rotation/* , LayerMask.NameToLayer("Block") */));
        if(GetHasPieceOver)
            SetToCollisionMaterial();
        else
            SetToDefaultMaterial();
    }

    private void OnDrawGizmos() {
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f, 0.5f);
        if(GetHasPieceOver)
            Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        Gizmos.DrawMesh(meshToDraw,this.transform.position + collisionPos, this.transform.rotation, sizeToDetect);
    }
    
    /// <summary>
    ///     This function set the block to the collision material.
    /// </summary>
    private void SetToCollisionMaterial()
    {
        if (GetCurrentMaterial != pieceMaterialData.GetCollisionMaterial)
            foreach (var item in renderers)
            {
                item.material = pieceMaterialData.GetCollisionMaterial;
            }
            // this.gameObject.GetComponentInChildren<Renderer>().material = pieceMaterialData.GetCollisionMaterial;
    }
    /// <summary>
    ///     This function set the block to the default material.
    /// </summary>
    private void SetToDefaultMaterial()
    {
        if (GetCurrentMaterial != pieceMaterialData.GetTransparentMaterial)
            foreach (var item in renderers)
            {
                item.material = pieceMaterialData.GetTransparentMaterial;
            }
            // this.gameObject.GetComponentInChildren<Renderer>().material = pieceMaterialData.GetTransparentMaterial;
    }
    /// <summary>
    ///     This function gets the current material used by block.
    /// </summary>
    private Material GetCurrentMaterial => this.gameObject.GetComponentInChildren<Renderer>().material;
}
