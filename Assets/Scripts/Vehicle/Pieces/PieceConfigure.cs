using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceConfigure : MonoBehaviour
{
    [Header("Only rayDistance, breakForce and\nbreakTorque must be sets by hand.")]
    [Space(30)]
    [Tooltip("The MainBlock, Gets on start by the GameManager.cs")]
    [SerializeField] private GameObject mainBlock;

    [Header("Lists")]
    [Space(10)]
    [Tooltip("List of all directions that not have a block")]
    [SerializeField] private List<int> nonCollidingDirs;
    [Tooltip("List of all blocks jointed to this block")]
    [SerializeField] private List<GameObject> blocksAround;
    [Tooltip("Ray Distance to capture other block around this block")]

    [Header("Floats")]
    [Space(10)]
    [SerializeField] private float rayDistance = 0.75f;
    public Transform rayOrigin;
    private readonly RaycastHit[] _hit = new RaycastHit[6];
    private readonly Vector3[] _directions = {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
        Vector3.up,
        Vector3.down
    };
    [SerializeField] private List<GameObject> connectedBlocks = new List<GameObject>();

    void Start()
    {
        /* mainBlock = GameObject.Find("BlockMain");  */
        mainBlock = GameManager.instance.GetMainBlock;
        if (rayOrigin == null)
        {
            rayOrigin = this.transform;
        }
        Configure();
        IdentityBlocks();
        if (this.gameObject.name == mainBlock.name)
        {
            if (this.transform.parent.name != "Vehicle")
            {
                DiscoverAllBlocksConnected(this.gameObject,this.gameObject, new List<GameObject>());
                // this.transform.parent.GetComponent<Vehicle2>().BroadcastMessage("AddToPiecesList");
                DisconnectBlockUnlinked();
                CreateOutline();
            }
            // else
            //     AddToPiecesList();
        }
        else if (this.transform.parent.parent.name != "Vehicle")
        {
            CreateOutline();
        }
    }
    void Update()
    {
        TestDraw();
    }

    /// <summary>
    ///     Function that must be called in the main function, this function creates a ray in all directions and add to list linked all blocks found
    /// </summary>
    private void Configure()
    {
        // if (this.gameObject != mainBlock)
        // {
        //Here we tells which block is around then this
        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(rayOrigin.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);

            if (colliding && (_hit[i].collider.gameObject.tag == "Block" || _hit[i].collider.gameObject.tag == "Wheel"))
            {
                blocksAround.Add(_hit[i].collider.gameObject);//Here we add to the blocksAround list all blocks linked to the block created
                PieceConfigure hitObject;
                if(_hit[i].collider.gameObject.TryGetComponent<PieceConfigure>(out hitObject)){
                    if(hitObject.rayOrigin == null){
                        hitObject.rayOrigin = hitObject.transform;
                    }
                    hitObject.IdentityBlocks();
                    if (!hitObject.BlocksAround.Contains(this.gameObject))
                    {
                        hitObject.BlocksAround.Add(this.gameObject);
                    }
                }
                // _hit[i].collider.gameObject.GetComponent<PieceConfigure>().IdentityBlocks();
                // if ((!_hit[i].collider.gameObject.GetComponent<PieceConfigure>().BlocksAround.Contains(this.gameObject)) /* && _hit[i].collider.gameObject.GetComponent<PieceConfigure>().GetBlocksAround().Count > 0 */)
                // {
                //     _hit[i].collider.gameObject.GetComponent<PieceConfigure>().BlocksAround.Add(this.gameObject);
                //    // List<GameObject> _blocksAround = _hit[i].collider.gameObject.GetComponent<PieceConfigure>().BlocksAround;
                //    // _blocksAround.Add(this.gameObject);
                //    // _hit[i].collider.gameObject.GetComponent<PieceConfigure>().BlocksAround = _blocksAround;
                // }
            }
        }
        // }
    }
    /// <summary>
    ///     This is native function that check if the object was destroyed, i use this function to order all blocks linked in this, check the new direction without a block.
    /// </summary>
    private void OnDestroy()
    {
        foreach (GameObject block in blocksAround)
        {
            if (block != null)
            {
                PieceConfigure pieceConfigure;
                if(block.TryGetComponent<PieceConfigure>(out pieceConfigure)){
                    pieceConfigure.IdentityBlocks();
                    pieceConfigure.IdentityBlocksAround();
                }
            }
        }
    }

    private void CreateOutline(){
        Outlines outlines;
        if (!this.gameObject.TryGetComponent<Outlines>(out outlines))
        {
            outlines = this.gameObject.AddComponent<Outlines>();
        }
        else
        {
            outlines.OutlineWidth = 2.0f;
        }
    }
    private void AddToPiecesList(){
        if (this.gameObject.name != "BlockMain")
        {
            this.transform.parent.parent.gameObject.GetComponent<Vehicle2>().Pieces.Add(this.gameObject);
            // if (this.gameObject.tag == "Wheel")
            // {
            //     this.transform.parent.parent.gameObject.GetComponent<Vehicle2>().Pieces.Add(this.gameObject);
            // }
            // else
            // {
            // }
        }
    }
    public void DisconnectBlockUnlinked()
    {
        foreach (GameObject block in this.gameObject.transform.parent.GetComponent<Vehicle2>().Pieces)
        {
            if (!connectedBlocks.Contains(block))
            {
                Destroy(block.gameObject.GetComponent<Block.BlockBehavior>());
                Destroy(block.gameObject.GetComponent<PieceMaterial>());
                Destroy(block.gameObject.GetComponent<PieceConfigure>());
                block.gameObject.AddComponent<Rigidbody>().mass = 40;
                block.transform.SetParent(null);
            }
        }
    }


    /// <summary>
    ///     This public function is used for check directions that's not contains a block.
    /// </summary>
    public void IdentityBlocks()
    {
        nonCollidingDirs.Clear();
        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(rayOrigin.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);
            if (!colliding)
            {
                nonCollidingDirs.Add(i);
            }
        }
    }
    public void IdentityBlocksAround()
    {
        blocksAround.Clear();
        for (int i = 0; i < _directions.Length; i++)
        {
            bool colliding = Physics.Raycast(rayOrigin.position, transform.TransformDirection(_directions[i]), out _hit[i], rayDistance);
            if (colliding && (_hit[i].collider.gameObject.tag == "Block" || _hit[i].collider.gameObject.tag == "Wheel"))
            {
                blocksAround.Add(_hit[i].collider.gameObject);
            }
        }
    }
    public void DiscoverAllBlocksConnected(GameObject startPiece, GameObject lastPieceFound, List<GameObject> piecesRead){
        PieceConfigure pieceConfigure;
        PieceConfigure startPieceConfigure;
        if (!piecesRead.Contains(this.gameObject))
        {
            foreach (GameObject piece in blocksAround)
            {
                if (piece != lastPieceFound && piece != startPiece)
                {
                    if (this.gameObject.name == mainBlock.name){
                        if (!ConnectedBlocks.Contains(piece)){
                            ConnectedBlocks.Add(piece);
                        }
                    }
                    else{
                        if (startPiece.TryGetComponent<PieceConfigure>(out startPieceConfigure)){
                            if (!startPieceConfigure.ConnectedBlocks.Contains(piece)){
                                startPieceConfigure.ConnectedBlocks.Add(piece);
                            }
                        }
                    }
                    if (piece.TryGetComponent<PieceConfigure>(out pieceConfigure)){
                        piecesRead.Add(this.gameObject);
                        pieceConfigure.DiscoverAllBlocksConnected(startPiece, this.gameObject, piecesRead);
                    }
                }
            }
        }
    }
    /// <summary>
    ///     Private function that is used to draw and debug casted rays
    /// </summary>
    private void TestDraw()
    {
        for (int i = 0; i < _directions.Length; i++)
        {
            if (Physics.Raycast(rayOrigin.position, _directions[i], out _hit[i], rayDistance))
            {
                if (_hit[i].collider.gameObject.tag == "Block" || _hit[i].collider.gameObject.tag == "Wheel")
                {
                    Debug.DrawRay(rayOrigin.position, transform.TransformDirection(_directions[i]) * _hit[i].distance, Color.red);
                }
            }
            else
            {
                Debug.DrawRay(rayOrigin.position, _directions[i] * rayDistance, Color.white);
            }
        }
    }
    /// <summary>
    ///     Get and Sets <paramref name="connectedBlocks"/> list.
    /// </summary>
    /// <returns>
    ///     <paramref name="connectedBlocks"/> list
    /// </returns>
    public List<GameObject> ConnectedBlocks 
    {
        get {return connectedBlocks;}
        set {connectedBlocks = value;}
    }
    // public List<GameObject> GetConnectedBlocks => connectedBlocks;
    /// <summary>
    ///     Get and Sets <paramref name="blocksAround"/> list
    /// </summary>
    /// <returns>
    ///     blocksAround list
    /// </returns>
    public List<GameObject> BlocksAround 
    {
        get {return blocksAround;}
        set {blocksAround = value;}
    }
    /// <summary>
    ///     Get the <paramref name="nonCollidingDirs"/> list.
    /// </summary>
    /// <returns>
    ///     <paramref name="nonCollidingDirs"/> list
    /// </returns>
    public List<int> GetNonColliderDirs => nonCollidingDirs;
}
