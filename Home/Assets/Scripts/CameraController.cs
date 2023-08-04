using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    public Transform target; // Дом, на который будет смотреть камера
    public float rotationSpeed = 1f; // Скорость вращения камеры в ручном режиме
    private bool _IsAutoMode = true; // Флаг для определения текущего режима работы камеры
    private bool _IsMoving = false; // Флаг для определения, движется ли камера в ручном режиме
    private bool _IsLeftArrow = true; 
    public Button toggleButton;

    private void Start()
    {
        // Запустить автоматическое вращение камеры
        RotateCameraAutomatically();
        toggleButton.onClick.AddListener(ToggleCameraMode);
    }
    private void Update()
    {
        if (!_IsAutoMode)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _IsLeftArrow = true;
                transform.RotateAround(target.position, Vector3.up, -rotationSpeed);
            }
            else if(Input.GetKey(KeyCode.RightArrow))
            {
                _IsLeftArrow = false;
                transform.RotateAround(target.position, Vector3.up, rotationSpeed);
            }
            else
            {
                SmoothStopRotation();
            }
        }
        else
        {
            RotateCameraAutomatically();
        }
    }

    private void RotateCameraAutomatically()
    {
        // Автоматическое вращение камеры вокруг дома
        transform.DORotate(new Vector3(0f, -360f, 0f), 30f, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    private void StopCameraRotation()
    {
        // Остановить автоматическое вращение камеры
        transform.DOKill();
    }

    private void StopCameraMovement()
    {
        // Остановить камеру
        _IsMoving = false;
    }

    private void ToggleCameraMode()
    {
        if (_IsAutoMode)
        {
            // Остановить автоматическое вращение камеры и включить ручной режим
            StopCameraRotation();
            _IsMoving = false;
        }
        // Переключение между режимами при нажатии на кнопку
        _IsAutoMode = !_IsAutoMode;
    }

    private IEnumerator SmoothStopRotation()
    {
        // Плавное замедление скорости вращения камеры до полной остановки
        while (rotationSpeed > 0f)
            rotationSpeed = Mathf.Lerp(rotationSpeed, 0f, Time.deltaTime);

        yield return null;
    }
}