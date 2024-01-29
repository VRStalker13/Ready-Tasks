using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private GameObject _stonePrefab;
    [SerializeField] private GameObject _roadPrefab;

    public List<GameObject> _stones = new List<GameObject>();

    /// <summary>
    /// Длина участка дороги который дублируется
    /// </summary>
    private float _roadLength;
    /// <summary>
    /// Текущая координата по вертикали для астероида
    /// </summary>
    private float _currentY;
    /// <summary>
    /// Минимальная координата по вертикали для астероида
    /// </summary>
    private float _minY;
    /// <summary>
    /// Максимальная координата по вертикали для астероида
    /// </summary>
    private float _maxY = 3f;
    /// <summary>
    /// Координата по вертикали к которой движется астероид
    /// </summary>
    private float _goal;

    /// <summary>
    /// Расстояние между астероидами 
    /// </summary>
    private float _asteroidsDistance = 100f;
    /// <summary>
    /// Координаты по горизонтали ( координата Z ) в которых появляются астероиды
    /// </summary>
    private float[] _stoneZPoz = new[] { -3.5f, 3.5f, 0f };
    private bool _trigger = true;

    private Random _rand = new Random();

    void Start()
    {
        CreateInstances();
        ResetLevel();
    }

    void Update()
    {
        MoveAsteroid();
        RotateAsteroids();
    }

    private void RotateAsteroids()
    {
        if (_currentY >= _maxY - 0.1f)
            _goal = _minY;
        if (_currentY <= _minY + 0.1f)
            _goal = _maxY;

        _currentY = Mathf.Lerp(_currentY, _goal, 0.0005f);

        foreach (GameObject stones in _stones)
        {
            stones.transform.Rotate(0, 1, 0);
            stones.transform.position =
                new Vector3(stones.transform.position.x, _currentY, stones.transform.position.z);
        }
    }

    private void CreateInstances()
    {
        _currentY = _stonePrefab.transform.position.y;
        _minY = _currentY;
        var roadPrefabTransform = _roadPrefab.transform.localScale;
        _roadLength = roadPrefabTransform.z;
    }

    private void CreateNextStone()
    {
        var pos = new Vector3(10f * ((float)ApplicationData.AppData.GameConfig.MaxStonesCount - 2f), 0, 0);
        pos = pos + new Vector3(((float)_rand.NextDouble() + 1f) * _roadLength / 2f, _stonePrefab.transform.position.y,
            _stoneZPoz[_rand.Next(3)]);

        var stone = Instantiate(_stonePrefab, pos, _stonePrefab.transform.rotation);
        stone.transform.Rotate(0, 1, 0);
        stone.transform.SetParent(transform);
        _stones.Add(stone);
    }

    private void ResetLevel()
    {
        while (_stones.Count > 0)
        {
            Destroy(_stones[0]);
            _stones.RemoveAt(0);
        }

        var poz = new Vector3(10f, 0f, 0f);
        for (var i = 0; i < ApplicationData.AppData.GameConfig.MaxStonesCount; i++)
        {
            if (_rand.Next(2) == 1)
            {
                var commet = Instantiate(_stonePrefab,
                    (i + 1) * poz + new Vector3(((float)_rand.NextDouble() + 1f) * _roadLength / 2f,
                        _stonePrefab.transform.position.y,
                        _stoneZPoz[_rand.Next(3)]), _stonePrefab.transform.rotation);
                commet.transform.SetParent(transform);
                _stones.Add(commet);
            }
        }
    }

    private void MoveAsteroid()
    {
        var appData = ApplicationData.AppData;

        if (_stones[0])
        {
            if (appData.Speed == 0)
                return;

            if (_stones.Count > 0)
            {
                foreach (GameObject stones in _stones)
                    stones.transform.position -= new Vector3(appData.Speed * Time.deltaTime, 0, 0);

                if (_stones[0].transform.position.x <= -10)
                {
                    Destroy(_stones[0]);
                    _stones.RemoveAt(0);
                }
            }

            if (_trigger != appData.Trigger)
            {
                _trigger = appData.Trigger;
                CreateNextStone();
            }
        }
    }
}
