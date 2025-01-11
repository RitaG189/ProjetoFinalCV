using UnityEngine;

public class RainSplashEffect : MonoBehaviour
{
    public ParticleSystem splashParticles; // Sistema de partículas para respingos

    private void OnParticleCollision(GameObject other)
    {
        // Verifica se a colisão foi com o chão
        if (other.CompareTag("Chao"))
        {
            // Obtém a posição da colisão
            Vector3 collisionPoint = GetCollisionPoint();

            // Ativa o sistema de partículas dos respingos na posição da colisão
            if (splashParticles != null)
            {
                ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
                {
                    position = collisionPoint
                };
                splashParticles.Emit(emitParams, 10); // Emite 10 partículas no ponto
            }
        }
    }

    private Vector3 GetCollisionPoint()
    {
        // Pode ser implementado para capturar a posição exata da colisão
        // Exemplo com raycasting ou outro método
        return transform.position; // Alterar para a posição correta
    }
}
