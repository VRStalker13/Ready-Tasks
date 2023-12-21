using UnityEngine;

public class Ship : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            Time.timeScale = 0f;
            GameMusic.Music.PlayBurnMusic();
            gameObject.SetActive(false);
            ViewManager.Instance.Show<EndGameWindow>(false);
        }
    }
}
