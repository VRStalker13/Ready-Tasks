using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    [SerializeField] private GameObject _planet;

    void Start()
    {
        LoadEnvironment();
    }

    private void LoadEnvironment()
    {
        var planet = Instantiate(_planet, _planet.transform.position, _planet.transform.rotation);
        planet.transform.SetParent(transform);
    }
}
