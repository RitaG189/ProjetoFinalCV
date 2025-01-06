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
        // Obt�m o PlayerInput e a a��o de movimento
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];

        // Obt�m o AudioSource existente
        movementAudioSource = gameObject.GetComponentInChildren<AudioSource>();
        if (movementAudioSource == null)
        {
            Debug.LogError("N�o foi encontrado um AudioSource no GameObject!");
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

        // Verifica se h� um AudioSource configurado
        if (movementAudioSource == null) return;

        // L� o input de movimento
        Vector2 moveInput = moveAction.ReadValue<Vector2>();
        bool isMoving = moveInput.magnitude > 0.1f;

        if (isMoving)
        {
            // Toca o som de movimento, se n�o estiver a tocar
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
