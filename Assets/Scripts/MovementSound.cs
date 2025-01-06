using UnityEngine;
using UnityEngine.InputSystem;

public class MovementSound : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction moveAction;
    private AudioSource movementAudioSource;

    [SerializeField] private AudioClip stepsAudioClip;
    [SerializeField] private AudioClip walkingOutsideAudioClip;


    private void Start()
    {
        // Obtém o PlayerInput e a ação de movimento
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];

        // Obtém o AudioSource existente
        movementAudioSource = gameObject.GetComponentInChildren<AudioSource>();
        if (movementAudioSource == null)
        {
            Debug.LogError("Não foi encontrado um AudioSource no GameObject!");
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("CurrentScene") == "Museum")
        {
            movementAudioSource.clip = stepsAudioClip;
        }
        else if(PlayerPrefs.GetString("CurrentScene") == "Painting")
        {
            movementAudioSource.clip = walkingOutsideAudioClip;
        }

        // Verifica se há um AudioSource configurado
        if (movementAudioSource == null) return;

        // Lê o input de movimento
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        bool isMoving = moveInput.magnitude > 0.1f;

        if (isMoving)
        {
            // Toca o som de movimento, se não estiver a tocar
            if (!movementAudioSource.isPlaying)
            {
                movementAudioSource.Play();
            }
        }
        else
        {
            // Para o som imediatamente quando o jogador para
            if (movementAudioSource.isPlaying)
            {
                movementAudioSource.Stop();
            }
        }
    }
}
