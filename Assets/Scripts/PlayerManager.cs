using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    rifleIdle = 0,
    rifleWalkingForward = 1
}

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public float health;
    public float maxHealth = 100f;
    public int itemCount = 0;
    public MeshRenderer model;
    public State state;

    public Animator animator;

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        health = maxHealth;
        state = State.rifleIdle;
    }

    public void SetHealth(float _health)
    {
        health = _health;

        if(health <= 0f)
        {
            Die();
        }
    }

    public void SetState(int _state)
    {
        if(_state != (int)state)
        {
            state = (State)_state;
            animator.SetInteger("State", _state);
        }
    }

    public void SetState(State _state)
    {
        SetState((int)_state);
    }

    public void Die()
    {
        //model.enabled = false;
    }

    public void Respawn()
    {
        //model.enabled = true;
        SetHealth(maxHealth);
    }
}
