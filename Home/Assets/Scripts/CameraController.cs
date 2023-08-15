using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Объект на который смотрит камера
    /// </summary>
    [SerializeField] private Transform _target;

    /// <summary>
    /// кнопка переключатель режимов движения
    /// </summary>
    [SerializeField] private Button _toggleButton;

    /// <summary>
    /// Скорость вращения камеры в ручном режиме (постоянное значение)
    /// </summary>
    private float _rotationSpeed = 1f;

    /// <summary>
    /// Скорость вращения камеры в ручном режиме (изменяемое при замедлении)
    /// </summary>
    private float _speed = 0f;

    /// <summary>
    /// Флаг для определения текущего режима работы камеры
    /// </summary>
    private bool _isAutoMode = true;

    private Tween _tween = null; 

    private void Start()
    {
        // Запустить автоматическое вращение камеры
        _toggleButton.onClick.AddListener(ToggleCameraMode);
        RotateCameraAutomatically();
    }

    private void Update()
    {
        if (!_isAutoMode)
        {
            _speed = Input.GetKey(KeyCode.LeftArrow) ? _rotationSpeed :
                Input.GetKey(KeyCode.RightArrow) ? -_rotationSpeed : Mathf.Lerp(_speed, 0f, 2f * Time.deltaTime);
            transform.RotateAround(_target.position, Vector3.up, _speed);
        }
    }

    /// <summary>
    /// Автоматическое вращение камеры
    /// </summary>
    private void RotateCameraAutomatically()
    {
        _tween = transform.DORotate(new Vector3(0f, -360f, 0f), 30f, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Restart)
            .SetEase(Ease.Linear);
    }

    /// <summary>
    /// Переключение между режимами при нажатии на кнопку
    /// </summary>
    private void ToggleCameraMode()
    {
        if (_isAutoMode)
            _tween?.Kill();

        _isAutoMode = !_isAutoMode;
        
        if (_isAutoMode)
            RotateCameraAutomatically();
    }
}