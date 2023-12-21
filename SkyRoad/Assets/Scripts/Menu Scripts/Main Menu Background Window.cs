using UnityEngine;

public class MainMenuBackgroundWindow : ViewMethods
{
    [SerializeField] private GameObject _leftShip;
    [SerializeField] private GameObject _rightShip;
    
    public float horizontalSpeed = 4.0F;
    public float verticalSpeed = 4.0F;
    public bool isleft;
     
    void Update()
    {
        RotateToMouse(_leftShip,true);
        RotateToMouse(_rightShip,false);
    }

    private void RotateToMouse(GameObject obj, bool isleft)
    {
        var index = isleft ? -1f : 1f;
        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = verticalSpeed * Input.GetAxis("Mouse Y");
        obj.transform.Rotate(0, index * v , 0);
        var m = Input.acceleration.y;
    }
}
