using UnityEngine;

public class RainSplashEffect : MonoBehaviour
{
    public ParticleSystem splashParticles; // Sistema de part�culas para respingos

    private void OnParticleCollision(GameObject other)
    {
        // Verifica se a colis�o foi com o ch�o
        if (other.CompareTag("Chao"))
        {
            // Obt�m a posi��o da colis�o
            Vector3 collisionPoint = GetCollisionPoint();

            // Ativa o sistema de part�culas dos respingos na posi��o da colis�o
            if (splashParticles != null)
            {
                ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
                {
                    position = collisionPoint
                };
                splashParticles.Emit(emitParams, 10); // Emite 10 part�culas no ponto
            }
        }
    }

    private Vector3 GetCollisionPoint()
    {
        // Pode ser implementado para capturar a posi��o exata da colis�o
        // Exemplo com raycasting ou outro m�todo
        return transform.position; // Alterar para a posi��o correta
    }
}
