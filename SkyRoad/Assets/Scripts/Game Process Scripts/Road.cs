using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject _roadPrefab;
    public List<GameObject> _roads = new List<GameObject>();
    void Start()
    {
        ResetLevel();
        StartLevel();
    }
    
    void Update()
    {
        MoveRoad();
        IncreaseSpeed();
    }

    private void StartLevel()
    {
        ApplicationData.AppData._speed = ApplicationData.AppData._startSpeed;
    }

    private void IncreaseSpeed()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplicationData.AppData.Acceleration = 2f;
            ApplicationData.AppData._speed *= 2f;

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ApplicationData.AppData.Acceleration = 1f;
            ApplicationData.AppData._speed /= 2f;
        } 
        
        ApplicationData.AppData._speed += ApplicationData.AppData.Acceleration * 0.1f * Time.deltaTime;
    }

    private void MoveRoad()
    {
        if(ApplicationData.AppData._speed == 0 )
            return;

        foreach (GameObject road in _roads)
            road.transform.position -= new Vector3(ApplicationData.AppData._speed * Time.deltaTime, 0, 0);

        if (_roads[0].transform.position.x <= -10)
        {
            Destroy(_roads[0]);
           _roads.RemoveAt(0);
        }

        if (_roads.Count < ApplicationData.AppData._maxRoadCount)
        {
            ApplicationData.AppData._trigger = !ApplicationData.AppData._trigger;
            CreateNextRoad();
        }
    }

    private void CreateNextRoad()
    {
        var pos = Vector3.zero;
        if (_roads.Count > 0)
            pos = _roads[_roads.Count - 1].transform.position + new Vector3(10, 0, 0);
        
        var go = Instantiate(_roadPrefab, pos, _roadPrefab.transform.rotation);
        go.transform.SetParent(transform);
        _roads.Add(go);
    }

    private void ResetLevel()
    {
        ApplicationData.AppData._speed = 0;

        while (_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }

        for (var i = 0; i < ApplicationData.AppData._maxRoadCount; i++)
            CreateNextRoad();
    }
}
