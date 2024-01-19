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
        ApplicationData.AppData.Speed = ApplicationData.AppData.GameConfig.StartSpeed;
    }

    private void IncreaseSpeed()
    {
        var appData = ApplicationData.AppData;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            appData.Acceleration = 2f;
            appData.Speed *= 2f;

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            appData.Acceleration = 1f;
            appData.Speed /= 2f;
        } 
        
        appData.Speed += appData.Acceleration * 0.1f * Time.deltaTime;
    }

    private void MoveRoad()
    {
        var appData = ApplicationData.AppData;
        
        if(appData.Speed == 0 )
            return;

        foreach (GameObject road in _roads)
            road.transform.position -= new Vector3(appData.Speed * Time.deltaTime, 0, 0);

        if (_roads[0].transform.position.x <= -10)
        {
            Destroy(_roads[0]);
           _roads.RemoveAt(0);
        }

        if (_roads.Count < appData.GameConfig.MaxRoadCount)
        {
            appData.Trigger = !appData.Trigger;
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
        ApplicationData.AppData.Speed = 0;

        while (_roads.Count > 0)
        {
            Destroy(_roads[0]);
            _roads.RemoveAt(0);
        }

        for (var i = 0; i < ApplicationData.AppData.GameConfig.MaxRoadCount; i++)
            CreateNextRoad();
    }
}
