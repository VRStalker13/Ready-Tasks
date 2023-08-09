using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Объект на который смотрит камера
    /// </summary>
    [SerializeField] private Transform _Target; 
    /// <summary>
    /// кнопка переключатель режимов движения
    /// </summary>
    [SerializeField] private Button _ToggleButton;

    /// <summary>
    /// Скорость вращения камеры в ручном режиме (постоянное значение)
    /// </summary>
    private float _RotationSpeed = 1f;
    /// <summary>
    /// Скорость вращения камеры в ручном режиме (изменяемое при замедлении)
    /// </summary>
    private float _Speed = 0f;

    /// <summary>
    /// Флаг для определения текущего режима работы камеры
    /// </summary>
    private bool _IsAutoMode = true;
    
    private void Start()
    {
        // Запустить автоматическое вращение камеры
        RotateCameraAutomatically();
        _ToggleButton.onClick.AddListener(ToggleCameraMode);
    }

    private void Update()
    {
        if (!_IsAutoMode)
        {
            _Speed = Input.GetKey(KeyCode.LeftArrow) ? _RotationSpeed :
                Input.GetKey(KeyCode.RightArrow) ? -_RotationSpeed : Mathf.Lerp(_Speed, 0f, 2f * Time.deltaTime);            
            transform.RotateAround(_Target.position, Vector3.up, _Speed);
        }
        else        
            RotateCameraAutomatically();
        
    }

    /// <summary>
    /// Автоматическое вращение камеры
    /// </summary>
    private void RotateCameraAutomatically()
    {
        transform.DORotate(new Vector3(0f, -360f, 0f), 30f, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    /// <summary>
    /// Переключение между режимами при нажатии на кнопку
    /// </summary>
    private void ToggleCameraMode()
    {
        if (_IsAutoMode)
        {
            transform.DOKill();
        }
        
        _IsAutoMode = !_IsAutoMode;
    }
}