using UnityEngine;

public class Road : MonoBehaviour
{
    [SerializeField] private GameObject _roadPrefab;
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

        foreach (GameObject road in ApplicationData.AppData._roads)
            road.transform.position -= new Vector3(ApplicationData.AppData._speed * Time.deltaTime, 0, 0);

        if (ApplicationData.AppData._roads[0].transform.position.x <= -10)
        {
            Destroy(ApplicationData.AppData._roads[0]);
            ApplicationData.AppData._roads.RemoveAt(0);
        }

        if (ApplicationData.AppData._roads.Count < ApplicationData.AppData._maxRoadCount)
        {
            ApplicationData.AppData._trigger = !ApplicationData.AppData._trigger;
            CreateNextRoad();
        }
    }

    private void CreateNextRoad()
    {
        var pos = Vector3.zero;
        if (ApplicationData.AppData._roads.Count > 0)
            pos = ApplicationData.AppData._roads[ApplicationData.AppData._roads.Count - 1].transform.position + new Vector3(10, 0, 0);
        
        var go = Instantiate(_roadPrefab, pos, _roadPrefab.transform.rotation);
        go.transform.SetParent(transform);
        ApplicationData.AppData._roads.Add(go);
    }

    private void ResetLevel()
    {
        ApplicationData.AppData._speed = 0;

        while (ApplicationData.AppData._roads.Count > 0)
        {
            Destroy(ApplicationData.AppData._roads[0]);
            ApplicationData.AppData._roads.RemoveAt(0);
        }

        for (var i = 0; i < ApplicationData.AppData._maxRoadCount; i++)
            CreateNextRoad();
    }
}
