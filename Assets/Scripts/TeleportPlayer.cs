using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private Transform teleportDestination; 
    [SerializeField] private GameObject player; 
    [SerializeField] private string sceneName;
    private CharacterController _controller;
    

private void Start() {
    _controller = player.GetComponent<CharacterController>();

}
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {        
        PlayerPrefs.SetString("CurrentScene", sceneName);

        // Desativa a física durante o teletransporte
        _controller.enabled = false;

        // Teletransporta o jogador
        other.transform.position = teleportDestination.position;

        // Reativa a física
        _controller.enabled = true;
    }
}
}