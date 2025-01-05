using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    [SerializeField] private Transform teleportDestination; 
    [SerializeField] private GameObject player; 
    private CharacterController _controller;

private void Start() {
    _controller = player.GetComponent<CharacterController>();

}
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        print("enter");
        
        // Desativa a física durante o teletransporte
        _controller.enabled = false;

        // Teletransporta o jogador
        other.transform.position = teleportDestination.position;

        // Reativa a física
        _controller.enabled = true;
    }
}
}