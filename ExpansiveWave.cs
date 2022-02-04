using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpansiveWave : MonoBehaviour
{
    public float duration;
    public AnimationCurve curve;
    public Gradient grad;
    public ParticleSystem particulas;

    public ParticleSystem.ShapeModule shape;
    public ParticleSystem.ColorOverLifetimeModule color;

    public AudioSource source;
    public Light luz;

    private float t;
    void Start()
    {
        particulas.Play();
        source.Play();

        shape = particulas.shape;
        color = particulas.colorOverLifetime;

        color.color = grad;
    }

    void Update()
    {
        t += Time.deltaTime;

        shape.radius = 5 * curve.Evaluate(t / duration);
        source.volume = curve.Evaluate(t / duration);
        luz.color = grad.Evaluate(t/duration);
    }
}
