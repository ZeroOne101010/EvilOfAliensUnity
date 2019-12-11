using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMeteorite : Meteorite
{

    public GameObject[] particlePrifab;
    public float offsetSpawnParticle;
    public float timeToSpawn;

    private float timerToSpawn;

    public ParticleMeteorite()
    {
        timerToSpawn = timeToSpawn;
    }

    public void particleMeteoriteUpdate()
    {
        createParticleInTime();
    }

    public void createParticleInTime()
    {
        if(timerToSpawn < 0)
        {
            createParticle();
            timerToSpawn = timeToSpawn;
        }
        else
        {
            timerToSpawn--;
        }
    }

    public void createParticle()
    {
        int idParticle = Random.Range(0, particlePrifab.Length);
        GameObject prifab = particlePrifab[idParticle];
        Vector2 particlePosition = transform.position + new Vector3(Random.Range(-offsetSpawnParticle, offsetSpawnParticle), Random.Range(-offsetSpawnParticle, offsetSpawnParticle), 0);
        GameObject particle = Instantiate(prifab, particlePosition, new Quaternion(0, 0, Random.Range(0, 360), 0));
        Particle meteoriteParticle = particle.GetComponent<Particle>();
        Vector2 direction = ((Vector2)transform.position - particlePosition).normalized;
        float speedParticle = 0;
        if(meteoriteParticle != null)
        {
            speedParticle = Random.Range(meteoriteParticle.speedMin, meteoriteParticle.speedMax);
        }

        if (particle.GetComponent<Rigidbody2D>())
        {
            particle.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity - direction * speedParticle;
        }
    }
}
