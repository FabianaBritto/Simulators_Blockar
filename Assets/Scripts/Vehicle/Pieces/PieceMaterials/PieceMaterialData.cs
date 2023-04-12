using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "PieceMaterialData", menuName = "Pieces/PieceMaterialData", order = 1)]
public class PieceMaterialData : ScriptableObject
{
    [Tooltip("The Material that shows in when you mouse over block in DestroyMode")]
    [SerializeField]private Material destroyMaterial;
    public Material GetDestroyMaterial => destroyMaterial;
    [Tooltip("The Material that shows in when block is over another block")]
    [SerializeField]private Material collisionMaterial;
    public Material GetCollisionMaterial => collisionMaterial;
    [Tooltip("The Material that shows in the placeHolder by default")]
    [SerializeField]private Material transparentMaterial;
    public Material GetTransparentMaterial => transparentMaterial;
}
