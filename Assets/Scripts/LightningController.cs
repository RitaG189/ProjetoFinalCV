using UnityEngine;

public class LightningController : MonoBehaviour
{
    public Light lightningLight; // Associe sua luz no inspetor
    public float minDelay = 2f;  // Atraso m�nimo entre flashes
    public float maxDelay = 5f;  // Atraso m�ximo entre flashes
    public float flashDuration = 0.1f; // Dura��o de cada flash

    private void Start()
    {
        ScheduleNextFlash();
    }

    private void FlashLightning()
    {
        // Ativar o flash
        lightningLight.enabled = true;

        // Desativar o flash ap�s a dura��o
        Invoke(nameof(EndFlash), flashDuration);

        // Agendar o pr�ximo flash
        ScheduleNextFlash();
    }

    private void EndFlash()
    {
        lightningLight.enabled = false;
    }

    private void ScheduleNextFlash()
    {
        // Agendar o pr�ximo rel�mpago com um atraso aleat�rio
        float delay = Random.Range(minDelay, maxDelay);
        Invoke(nameof(FlashLightning), delay);
    }
}
