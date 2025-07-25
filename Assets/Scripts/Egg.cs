using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void HideEggShowPlayer()
    {
        AudioManager.instance.PlayCrackEggClip(); // Play the egg cracking sound
        gameObject.SetActive(false); // Hide the egg
        player.SetActive(true); // Show the player
    }
}
