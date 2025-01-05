using UnityEngine;

public class LightningController : MonoBehaviour
{
    public Light lightningLight; // Associe sua luz no inspetor
    public float minDelay = 2f;  // Atraso mínimo entre flashes
    public float maxDelay = 5f;  // Atraso máximo entre flashes
    public float flashDuration = 0.1f; // Duração de cada flash

    private void Start()
    {
        ScheduleNextFlash();
    }

    private void FlashLightning()
    {
        // Ativar o flash
        lightningLight.enabled = true;

        // Desativar o flash após a duração
        Invoke(nameof(EndFlash), flashDuration);

        // Agendar o próximo flash
        ScheduleNextFlash();
    }

    private void EndFlash()
    {
        lightningLight.enabled = false;
    }

    private void ScheduleNextFlash()
    {
        // Agendar o próximo relâmpago com um atraso aleatório
        float delay = Random.Range(minDelay, maxDelay);
        Invoke(nameof(FlashLightning), delay);
    }
}
