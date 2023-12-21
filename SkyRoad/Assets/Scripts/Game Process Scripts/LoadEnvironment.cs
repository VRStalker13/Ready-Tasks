using UnityEngine;

public class LoadEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject _planet;
    
    void Start()
    {
        var planet= Instantiate(_planet, _planet.transform.position, _planet.transform.rotation);
        planet.transform.SetParent(transform);
    }

}
