using UnityEngine;

public class ShipDrive : MonoBehaviour
{
    [SerializeField] private GameObject _shipPrefab;
    
    [SerializeField] private GameObject[] _rightRedFire;
    [SerializeField] private GameObject[] _rightBueFire;
    [SerializeField] private GameObject[] _leftRedFire;
    [SerializeField] private GameObject[] _leftBlueFire;
    
    private GameObject _ship;
    private float _maxModuleZ = 3.2f;
    private float _maxModuleAngle = 30f;
    private float _angle;
    
    void Start()
    {
        _ship = Instantiate(_shipPrefab, _shipPrefab.transform.position, _shipPrefab.transform.rotation);
        _ship.transform.SetParent(transform);
        _angle = _ship.transform.rotation.z;
        _rightRedFire = GameObject.FindGameObjectsWithTag("rightRedFire");
        _rightBueFire = GameObject.FindGameObjectsWithTag("rightBlueFire");
        _leftRedFire = GameObject.FindGameObjectsWithTag("leftRedFire");
        _leftBlueFire = GameObject.FindGameObjectsWithTag("leftBlueFire");
        ActivateRedFire(true);
    }
    
    void Update()
    {
        MoveShip();
        CameraMethods.CamMethods.HorizontalMovingCamera("Game Camera",_ship.transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ActivateRedFire(false);
            GameMusic.Music.PlaySpeedMusic(true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ActivateRedFire(true);
            GameMusic.Music.PlaySpeedMusic(false);
        }
    }
    
    private void ActivateRedFire(bool isActive)
    {
        _rightRedFire[0].SetActive(isActive);
        _leftRedFire[0].SetActive(isActive);
        _leftBlueFire[0].SetActive(!isActive);
        _rightBueFire[0].SetActive(!isActive);
    }

    private void MoveShip()
    {        
        if(!_shipPrefab)
            return;
        
        var rotation = _ship.transform.rotation;
        var position = _ship.transform.position;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (_angle < _maxModuleAngle)
                _angle = Mathf.Lerp(_angle, 30f, 0.02f);
            
            if(_ship.transform.position.z <= 3.2f)
                _ship.transform.position = new Vector3(position.x,position.y,position.z + 0.05f);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (_angle > -1f*_maxModuleAngle)
                _angle = Mathf.Lerp(_angle, -30f, 0.02f);
            
            if(_ship.transform.position.z >= -3.2f)
                _ship.transform.position = new Vector3(position.x,position.y,position.z - 0.05f);
        }
        
        else
        {
            _angle = Mathf.Lerp(_angle, 0f, 0.02f);
        }
        
        _ship.transform.rotation = Quaternion.Euler(rotation.eulerAngles.x,rotation.eulerAngles.y ,_angle);
    }
}