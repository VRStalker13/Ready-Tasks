using UnityEngine;

public class Ship : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            Time.timeScale = 0f;
            MusicManager.Music.PlaySound("Burn Music",true);
            gameObject.SetActive(false);
            ViewManager.Instance.Show<EndGameWindow>(false);
        }
    }
}
