using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Destructible
{
    [SerializeField] private float speed;
    [SerializeField] private float obstacleRange;
    [SerializeField] private ParticleSystem particalFire;
    [SerializeField] private AudioSource audioFire;
    [SerializeField] private AudioSource audioExplosive;
    [SerializeField] private CharacterController characterController;
    private float gravity = -9.8f;
    public enum State
    {
        run,
        attack
    }
    State state = State.run;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (state == State.run)
        {
            Move();
        }
        if (state == State.attack)
        {
            Fire();
        }
    }

    private void Fire()
    {
        
        print("Атака");
        particalFire.Play();
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            
            audioFire.Play();
            if (hit.collider.tag != "Player")
            {
                particalFire.Play();
                state = State.run;
            }
            else
            {
                hit.collider.GetComponent<Destructible>().ApplyDamage(1);
                Debug.Log(GuiPlayer.instance);
                GuiPlayer.instance.HpUpdate();
            }
        }
    }

    private void Move()
    {
        Vector3 movement = new Vector3(0, 0, speed);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        characterController.Move(movement);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = UnityEngine.Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
            if (hit.collider.tag == "Player")
            {
                state = State.attack;
            }
            else
            {
                state = State.run;
            }
        }
    }
}
