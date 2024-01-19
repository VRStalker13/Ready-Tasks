using UnityEngine;

public class CameraMethods : CameraManager
{
    public static CameraMethods CamMethods;

    private void Awake()
    {
        CamMethods = this;
        Initialize();
    }

    public void HorizontalMovingCamera(string cameraName, float newZPosition)
    {
        if (Cams.ContainsKey(cameraName))
        {
            var position = CamMethods.Cams[cameraName].gameObject.transform.position;
            position = new Vector3(position.x,position.y,newZPosition);
            CamMethods.Cams[cameraName].gameObject.transform.position = position;
        }
    }
}
