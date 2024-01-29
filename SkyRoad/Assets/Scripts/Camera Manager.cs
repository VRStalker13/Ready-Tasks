using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuCamera;
    [SerializeField] private GameObject _gameCamera;

    protected Dictionary<string, GameObject> Cams;

    protected void Initialize()
    {
        CameraMethods.CamMethods.Cams = new Dictionary<string, GameObject>()
        {
            { "Menu Camera", _menuCamera },
            { "Game Camera", _gameCamera }
        };
    }

    public void OpenCamera(string cameraName)
    {
        if (!CameraMethods.CamMethods.Cams.ContainsKey(cameraName)) return;

        foreach (var cam in CameraMethods.CamMethods.Cams)
            cam.Value.gameObject.SetActive(cam.Key.Equals(cameraName));
    }
}
        