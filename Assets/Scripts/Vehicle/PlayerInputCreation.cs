using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
public class PlayerInputCreation : MonoBehaviour
{
    [Header("Game Objects")]
    [Space(5)]
    [Tooltip("The GameObject used to view where the block will be placed")]
    [SerializeField] private GameObject placeHolder;
    [SerializeField] private GameObject block;
    [Tooltip("The MainBlock, Gets on start by the GameManager.cs")]
    [SerializeField] private GameObject mainBlock;

    [Header("Booleans")]
    [Space(5)]
    [Tooltip("Bool posteriorly used for checks if found a block and posed placeHolder, when i release the EditMode the placeHolder must back to the Vector3.thousand pos")]
    [SerializeField] private bool isColliding = false;
    [Tooltip("Bool for checks if you are putting a wheel")]
    [SerializeField] private bool isWheel = false;

    [Header("Adjusts")]
    [Space(5)]
    [Tooltip("Distance to position the block will be created")]
    [SerializeField] private float distanceOffset = 1.0f;
    [Tooltip("Distance to position mouse when i found block and check in what direction it is, i made this because gets over the face of the block and i can't get the direction correctly, so i put i little bit back to check correctly")]
    [SerializeField] private float offset = 0.05f;
    [Tooltip("Distance of ray to check block")]
    [SerializeField] private float rayDistance = 0.5f;

    [Header("Debug/Utility")]
    [Space(5)]
    [Tooltip("Position that mouse is in 3D space")]
    [SerializeField] private Vector3 hitPoint;
    [Tooltip("Vector 3(1000 1000 1000) to put the placeHolder when i don't using he")]
    [SerializeField] private Vector3 thousand = new Vector3(1000.0f, 1000.0f, 1000.0f);
    [Tooltip("The block that i found when i moving mouse in edit mode")]
    [SerializeField] private GameObject foundBlock = null;
    [Tooltip("The last block that i found when i moving mouse in edit mode")]
    [SerializeField] private GameObject lastFoundBlock = null;
    [Tooltip("The direction that's the block was found, -1 when i dont found any block")]
    [SerializeField] private int foundBlockDir = -1;


    private readonly RaycastHit[] _hit = new RaycastHit[6];
    private readonly Vector3[] _directions = {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right,
        Vector3.up,
        Vector3.down
    };
    private void Start()
    {
        mainBlock = GameManager.instance.GetMainBlock;
        GameManager.instance.SetPlaceHolder("BlockPlaceHolder");
        SetPlaceHolderGameObject(GameManager.instance.GetPlaceHolder);
    }

    private void Update()
    {
        //ChangeMode();
        Arububabu();

    }
    /// <summary>
    ///     Function that makes everything happen
    /// </summary>
    private void Arububabu()
    {
        if (GameManager.instance.GetIsEditing)// Checks if is in EditMode
        {
            DefinePosition();
            TestDraw();
            if (Input.GetMouseButtonDown(0) && (IdentifyFoundBlock().Item1 != null))
            {
                CreateOutline(IdentifyFoundBlock().Item1);
            }
            if (GameManager.instance.GetCanCreate)
            {
                (foundBlock, foundBlockDir) = IdentifyFoundBlock();
                if (foundBlock != null)
                    if (foundBlock.tag == "Wheel")
                    {
                        foundBlock = null;
                        foundBlockDir = -1;
                    }
                ControllBlocks();
                SetPlaceHolderPos(foundBlock, foundBlockDir);
                GenerateBlock(foundBlock, foundBlockDir);
            }
            else if (GameManager.instance.GetCanDestroy)
            {
                ResetPlaceHolderPos();
                (foundBlock, foundBlockDir) = IdentifyFoundBlock();

                if (lastFoundBlock != null)
                {
                    PieceMaterial pieceMaterial;
                    bool hasPieceMaterial = lastFoundBlock.TryGetComponent<PieceMaterial>(out pieceMaterial);
                    if(hasPieceMaterial && (foundBlock == lastFoundBlock))
                        pieceMaterial.SetToDestroyMaterial();
                        // pieceMaterial.MouseOver = true;
                    else if(hasPieceMaterial)
                        pieceMaterial.SetToDefaultMaterial();
                        // pieceMaterial.MouseOver = false;
                }
                if (foundBlock != null)
                    lastFoundBlock = foundBlock;
                
                DestroyBlock(foundBlock);
            }
            else
            {
                ResetPlaceHolderPos();
            }
        }
        else
        {
            ResetPlaceHolderPos();
        }
    }
    /// <summary>
    ///     Controls the current mode. Example: Edit Mode, Destroying, Creation.
    /// </summary>
    /*
    private void ChangeMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.SetEditMode(!GameManager.instance.IsEditing());
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameManager.instance.SetCanCreate(!GameManager.instance.IsCreating());
            GameManager.instance.SetCanDestroy(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameManager.instance.SetCanDestroy(!GameManager.instance.IsDestroying());
            GameManager.instance.SetCanCreate(false);
        }
        if (Input.GetMouseButtonDown(1))//Cancels create and destroy
        {
            GameManager.instance.SetCanCreate(false);
            GameManager.instance.SetCanDestroy(false);
        }
    }
    */

    private void CreateOutline(GameObject outlineObject){
        Outlines outlines;
        if (GameManager.instance.GetSelectedBlock().TryGetComponent<Outlines>(out outlines) || outlineObject.TryGetComponent<Outlines>(out outlines))
            Destroy(outlines);
        GameManager.instance.SetSelectedBlock(outlineObject);
        if (!GameManager.instance.GetSelectedBlock().TryGetComponent<Outlines>(out outlines))
        {
            outlineObject.AddComponent<Outlines>().OutlineWidth = 4.0f;
        }
    }

    /// <summary>
    ///     Instantiate a new block.
    /// </summary>
    /// <param name="obj">
    ///     Block that was found
    /// </param>
    /// <param name="dir">
    ///     Direction that was positioned a block, to tells found block that this direction filled
    /// </param>
    private void GenerateBlock(GameObject obj, int dir)
    {
        if (obj != null)
        {
            if (Input.GetMouseButtonDown(0) && isColliding && !placeHolder.GetComponent<PiecePlaceHolder>().GetHasPieceOver)
            {
                GameObject myBlock = Instantiate<GameObject>(block, placeHolder.transform.position, placeHolder.transform.rotation);
                switch (GameManager.instance.GetCurrentPieceType)
                {
                    case Block.BlockBehavior.Types.Standard:
                        myBlock.transform.SetParent(GameManager.instance.GetVehicle.transform.GetChild(1));
                        break;
                    case Block.BlockBehavior.Types.Wheel:
                        myBlock.transform.SetParent(GameManager.instance.GetVehicle.transform.GetChild(2));
                        myBlock.GetComponent<ConfigureWheelMesh>().currentDirection = dir;
                        GameManager.instance.AddWheelCollider(myBlock.GetComponent<WheelCollider>());
                        break;
                    case Block.BlockBehavior.Types.Engine:
                        myBlock.transform.SetParent(GameManager.instance.GetVehicle.transform.GetChild(3));
                        break;
                    default:
                        myBlock.transform.SetParent(GameManager.instance.GetVehicle.transform.GetChild(1));
                        break;
                }
                AudioManager.Instance.Play("Pull Block", false);
                GameManager.instance.GetVehicle.GetComponent<Vehicle2>().Pieces.Add(myBlock);
                // obj.GetComponent<PieceConfigure>().GetNonColliderDirs().Remove(dir);
            }
        }
    }
    /// <summary>
    ///     Destroy a block
    /// </summary>
    /// <param name="obj">
    ///     Block that was found
    /// </param>
    private void DestroyBlock(GameObject obj)
    {
        if (obj != mainBlock && obj != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.instance.GetVehicle.GetComponent<Vehicle2>().Pieces.Remove(obj);
                Destroy(obj);
                AudioManager.Instance.Play("Delete Blocks", false);
            }
        }
    }
    /// <summary>
    ///     Controls wich block will be instantiated
    /// </summary>
    private void ControllBlocks()
    {
        ChangeBlock(GameManager.instance.GetPieceToCreate);
        SetPlaceHolderGameObject(GameManager.instance.GetPlaceHolder);
    }
    /// <summary>
    ///     Change block to instantiate
    /// </summary>
    private void ChangeBlock(GameObject instantiateObject)
    {
        block = instantiateObject;
    }
    /// <summary>
    ///     Sets place holder position, this function verifies which block was encountered and which direction by block point of view that the place holder is in
    /// </summary>
    /// <param name="obj">
    ///     Block that was found
    /// </param>
    /// <param name="direction">
    ///     Direction that was positioned a block, to tells found block that this direction filled
    /// </param>
    private void SetPlaceHolderPos(GameObject obj, int direction)
    {
        if (obj != null)
        {
            if (obj.GetComponent<PieceConfigure>().GetNonColliderDirs.Contains(direction))//verifies if this direction already have a block
            {
                Vector3 objPos = obj.transform.position;
                switch (direction)
                {
                    case 0://forward
                        objPos.z += distanceOffset;
                        // if (/* GetIsWheel() */GameManager.instance.GetCurrentPieceType == Block.BlockBehavior.Types.Wheel)
                        // {
                        //     placeHolder.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                        // }
                        // else
                        //    DefinePlaceHolderPos(objPos);
                        switch(GameManager.instance.GetPieceToCreate.name)
                        {
                            case "WheelSimple":
                            case "WheelSimpleBack":
                            case "WheelSimpleFront":
                                break;
                            case "WheelTop":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,0.0f,0.56f);
                                placeHolder.transform.eulerAngles = new Vector3(270.0f, 0.0f, 0.0f);
                                break;
                            case "WheelTopBack":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,-0.5f,0.56f);
                                placeHolder.transform.eulerAngles = new Vector3(270.0f, 0.0f, 0.0f);
                                break;
                            case "WheelTopFront":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,0.5f,0.56f);
                                placeHolder.transform.eulerAngles = new Vector3(270.0f, 0.0f, 0.0f);
                                break;
                            default:
                                DefinePlaceHolderPos(objPos);
                                break;
                        }
                        isColliding = true;
                        break;
                    case 1://back
                        objPos.z += -distanceOffset;
                        // if (/* GetIsWheel() */GameManager.instance.GetCurrentPieceType == Block.BlockBehavior.Types.Wheel)
                        // {
                        //     placeHolder.transform.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
                        //     // placeHolder.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
                        // }
                        // else
                        //     DefinePlaceHolderPos(objPos);
                        switch(GameManager.instance.GetPieceToCreate.name)
                        {
                            case "WheelSimple":
                            case "WheelSimpleBack":
                            case "WheelSimpleFront":
                                break;
                            case "WheelTop":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,0.0f,-0.56f);
                                placeHolder.transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                                break;
                            case "WheelTopBack":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,0.5f,-0.56f);
                                placeHolder.transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                                break;
                            case "WheelTopFront":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,-0.5f,-0.56f);
                                placeHolder.transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
                                break;
                            default:
                                DefinePlaceHolderPos(objPos);
                                break;
                        }
                        isColliding = true;
                        break;
                    case 2://left
                        objPos.x += -distanceOffset;
                        // DefinePlaceHolderPos(objPos);
                        // if (/* GetIsWheel() */GameManager.instance.GetCurrentPieceType == Block.BlockBehavior.Types.Wheel)
                        // {
                        //     placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                        // }
                        switch(GameManager.instance.GetPieceToCreate.name)
                        {
                            case "WheelSimple":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                                break;
                            case "WheelSimpleBack":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,0.0f,-0.5f);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                                break;
                            case "WheelSimpleFront":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,0.0f,0.5f);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                                break;
                            case "WheelTop":
                            case "WheelTopBack":
                            case "WheelTopFront":
                                break;
                            default:
                                DefinePlaceHolderPos(objPos);
                                break;
                        }
                        isColliding = true;
                        break;
                    case 3://right
                        objPos.x += distanceOffset;
                        // DefinePlaceHolderPos(objPos);
                        // if (/* GetIsWheel() */GameManager.instance.GetCurrentPieceType == Block.BlockBehavior.Types.Wheel)
                        // {
                        //     placeHolder.transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
                        // }
                        switch(GameManager.instance.GetPieceToCreate.name)
                        {
                            case "WheelSimple":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                                break;
                            case "WheelSimpleBack":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,0.0f,-0.5f);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                                break;
                            case "WheelSimpleFront":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.position += new Vector3(0.0f,0.0f,0.5f);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                                break;
                            case "WheelTop":
                            case "WheelTopBack":
                            case "WheelTopFront":
                                break;
                            default:
                                DefinePlaceHolderPos(objPos);
                                break;
                        }
                        isColliding = true;
                        break;
                    case 4://up
                        objPos.y += distanceOffset;
                        // if (/* GetIsWheel() */GameManager.instance.GetCurrentPieceType == Block.BlockBehavior.Types.Wheel)
                        // {
                        //     placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
                        // }
                        // else
                        //     DefinePlaceHolderPos(objPos);
                        switch(GameManager.instance.GetPieceToCreate.name)
                        {
                            case "WheelSimple":
                            case "WheelSimpleBack":
                            case "WheelSimpleFront":
                            case "WheelTop":
                            case "WheelTopBack":
                            case "WheelTopFront":
                                break;
                            default:
                                DefinePlaceHolderPos(objPos);
                                break;
                        }
                        isColliding = true;
                        break;
                    case 5://down
                        objPos.y += -distanceOffset;
                        // if (/* GetIsWheel() */GameManager.instance.GetCurrentPieceType == Block.BlockBehavior.Types.Wheel)
                        // {
                        //     placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                        //     // placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                        // }
                        // else
                        //     DefinePlaceHolderPos(objPos);
                        switch(GameManager.instance.GetPieceToCreate.name)
                        {
                            case "WheelSimple":
                            case "WheelSimpleBack":
                            case "WheelSimpleFront":
                                break;
                            case "WheelTop":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                                placeHolder.transform.position += new Vector3(0.0f,-0.56f,0.0f);
                                break;
                            case "WheelTopBack":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                                placeHolder.transform.position += new Vector3(0.0f,-0.56f,-0.5f);
                                break;
                            case "WheelTopFront":
                                DefinePlaceHolderPos(objPos);
                                placeHolder.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                                placeHolder.transform.position += new Vector3(0.0f,-0.56f,0.5f);
                                break;
                            default:
                                DefinePlaceHolderPos(objPos);
                                break;
                        }
                        isColliding = true;
                        break;
                    default:
                        break;
                }
            }
        }
        else
        {
            isColliding = false;
            DefinePlaceHolderPos(1000.0f, 1000.0f, 1000.0f);
        }
    }
    /// <summary>
    ///     Sets place holder position, this function verifies which block was encountered and which direction by block point of view that the place holder is in
    /// </summary>
    /// <returns>
    ///     <para>
    ///         GameObject that was found
    ///     </para>
    ///     <para>
    ///         Direction that was positioned a block, to tells found block that this direction filled
    ///     </para>
    /// </returns>
    /// <example>
    /// This show how dir works, on the _directions array always the next position of the array is your opposite, so when i found a position if is pair the next is your opposite if is odd the previous is your opposite
    /// </example>
    private (GameObject, int) IdentifyFoundBlock()
    {
        GameObject obj = null;
        int dir = -1;

        for (int i = 0; i < _directions.Length; i++)
        {
            // shoots ray in all directions
            if (Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance))
            {
                // check if it found a block
                if (_hit[i].collider.gameObject.layer == LayerMask.NameToLayer("Block"))
                {
                    // set the found opposite to the object that found the block, must be opposite because in the future we use this to tell that direction is filled by other blocks
                    obj = _hit[i].collider.gameObject;
                    if (i % 2 == 0)
                    {
                        dir = i + 1;
                    }
                    else
                    {
                        dir = i - 1;
                    }
                    break;
                }
            }
        }
        return (obj, dir);
    }
    /// <summary>
    ///     Native function that Draw Gizmos, used in editor of unity to see where my mouse is on 3D space.
    /// </summary>
    private void OnDrawGizmos()
    {
        Color nColor = Color.white;
        nColor.a = 0.3f;
        Gizmos.color = nColor;
        Gizmos.DrawSphere(transform.position, 1);
    }
    /// <summary>
    ///     Private function that is used to draw and debug casted rays
    /// </summary>
    private void TestDraw()
    {
        for (int i = 0; i < _directions.Length; i++)
        {
            if (Physics.Raycast(transform.position, _directions[i], out _hit[i], rayDistance))
            {
                if (_hit[i].collider.gameObject.layer == LayerMask.NameToLayer("Block"))
                {
                    Debug.DrawRay(transform.position, _directions[i] * rayDistance, Color.blue);
                }
            }
            else
            {
                Debug.DrawRay(transform.position, _directions[i] * rayDistance, Color.white);
            }
        }
    }
    /// <summary>
    ///     Private function that uses the offset value. This function cast a ray to see the mouse position on the 3d space when it found any object the mouse is offseted for keeps a little bit distance of the object found
    /// </summary>
    private void DefinePosition()
    {
        RaycastHit hit;// hit
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// ray to camera to mouse position on 3D space.

        if (Physics.Raycast(ray, out hit))//
        {
            Vector3 pos = hit.point;
            hitPoint = hit.point;

            if (hit.normal.x < 0)
            {
                pos.x -= offset;
            }
            else if (hit.normal.x > 0)
            {
                pos.x += offset;
            }
            if (hit.normal.y < 0)
            {
                pos.y -= offset;
            }
            else if (hit.normal.y > 0)
            {
                pos.y += offset;
            }
            if (hit.normal.z < 0)
            {
                pos.z -= offset;
            }
            else if (hit.normal.z > 0)
            {
                pos.z += offset;
            }
            this.gameObject.transform.position = pos;
        }
    }
    /// <summary>
    ///     Private function that used for define place holder position passing xyz as parameter.
    /// </summary>
    private void DefinePlaceHolderPos(float x, float y, float z)
    {
        placeHolder.transform.position = new Vector3(x, y, z);
    }
    /// <summary>
    ///     Private function that used for define place holder position passing Vector3 as parameter.
    /// </summary>
    private void DefinePlaceHolderPos(Vector3 pos)
    {
        placeHolder.transform.position = pos;
    }
    /// <summary>
    ///     Private function that used for define place holder GameObject
    /// </summary>
    private void SetPlaceHolderGameObject(GameObject obj)
    {
        placeHolder = obj;
    }
    /// <summary>
    ///     Private function that gets and return the placeHolder current position.
    /// </summary>
    /// <returns>
    ///     The placeHolder position.
    /// </returns>
    private Vector3 GetPlaceHolderPos()
    {
        return placeHolder.transform.position;
    }
    /// <summary>
    ///     Private function that reset the placeHolder to Vector3 <paramref name="thousand"/> position.
    /// </summary>
    private void ResetPlaceHolderPos()
    {
        if (GetPlaceHolderPos() != thousand)
        {
            DefinePlaceHolderPos(thousand);
        }
    }
    /// <summary>
    ///     Private function that gets and return the if is adding wheel.
    /// </summary>
    /// <returns>
    ///     Booleans if is putting wheel or not
    /// </returns>
    private bool GetIsWheel()
    {
        return isWheel;
    }
    /// <summary>
    ///     Private function that sets the if is adding wheel.
    /// </summary>
    private void SetIsWheel(bool value)
    {
        isWheel = value;
    }
}
