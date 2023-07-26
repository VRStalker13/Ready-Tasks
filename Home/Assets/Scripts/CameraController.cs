using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform Target; // Дом, на который будет смотреть камера
    public float RotationSpeed = 100f; // Скорость вращения камеры в не автоматическом режиме
    public float RotationTime = 30f; // Время для совершения одного оборота в автоматическом режиме
    private bool _IsAutoMode = true; // Флаг для определения текущего режима работы камеры
    public Button ToggleButton;    

    public void Start()
    {
        ToggleButton.onClick.AddListener(ToggleCameraMode);
    }

    private void Update()
    {        
        if (_IsAutoMode)
        {
            // Автоматический режим
            // Вращение камеры вокруг дома
            transform.RotateAround(Target.position, Vector3.up, 360f / RotationTime * Time.deltaTime);
        }
        else
        {
            // Ручной режим
            // Перемещение камеры вокруг дома при помощи клавиш влево и вправо
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.RotateAround(Target.position, Vector3.up, -RotationSpeed * 0.05f );
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.RotateAround(Target.position, Vector3.up, RotationSpeed * 0.05f);
            }
        }
    }

    private void ToggleCameraMode()
    {
        if (_IsAutoMode)
            SmoothStopRotation();

        _IsAutoMode = !_IsAutoMode;
    }

    private IEnumerator SmoothStopRotation()
    {
        // Плавное замедление скорости вращения камеры до полной остановки
        while (RotationSpeed > 0f)        
            RotationSpeed = Mathf.Lerp(RotationSpeed, 0f, Time.deltaTime);

        yield return null;
    }
}
        



