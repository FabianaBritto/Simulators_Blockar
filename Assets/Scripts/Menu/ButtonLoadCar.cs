using Audio;
using UnityEngine;
using UnityEngine.UI;
using SaveCar;

namespace Menu
{
    public class ButtonLoadCar : MonoBehaviour
    {
        private Button button;
        [SerializeField] private int id;

        [SerializeField] private PieceData pieceData;

        // Start is called before the first frame update
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(HandleClick);
        }

        // Update is called once per frame
        private void HandleClick()
        {
            Vehicle2 vehicle;
            if (GameManager.instance.GetVehicle.TryGetComponent<Vehicle2>(out vehicle))
            {
                vehicle.ClearVehicle();
                PieceSaveData[] _pieces = SaveManager.Load(id, pieceData);
                if (_pieces.Length > 0)
                {
                    foreach (var pieceIndex in _pieces)
                    {
                        GameObject _piece = pieceData.FindPiece(pieceIndex.name);
                        if (_piece != null)
                        {
                            GameObject block = Instantiate(_piece, pieceIndex.position, Quaternion.Euler(pieceIndex.rotation));
                            Block.BlockBehavior blockBehavior;
                            if (block.TryGetComponent<Block.BlockBehavior>(out blockBehavior))
                            {
                                switch (blockBehavior.type)
                                {
                                    case Block.BlockBehavior.Types.Standard:
                                        blockBehavior.transform.SetParent(GameManager.instance.GetVehicle.transform.GetChild(1));
                                        break;
                                    case Block.BlockBehavior.Types.Wheel:
                                        blockBehavior.transform.SetParent(GameManager.instance.GetVehicle.transform.GetChild(2));
                                        blockBehavior.GetComponent<ConfigureWheelMesh>().currentDirection = 0;
                                        GameManager.instance.AddWheelCollider(blockBehavior.GetComponent<WheelCollider>());
                                        break;
                                    case Block.BlockBehavior.Types.Engine:
                                        blockBehavior.transform.SetParent(GameManager.instance.GetVehicle.transform.GetChild(3));
                                        break;
                                    default:
                                        blockBehavior.transform.SetParent(GameManager.instance.GetVehicle.transform.GetChild(1));
                                        break;
                                }
                            }
                            GameManager.instance.GetVehicle.GetComponent<Vehicle2>().Pieces.Add(block);
                        }
                    }
                }
            }
        }
    }
}
