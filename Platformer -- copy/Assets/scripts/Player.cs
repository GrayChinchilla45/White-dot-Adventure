﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
    public int variable;
    public float fallLeeway;
    private bool jumping;
    private float lastGround;
    public float fallMulti = 2;
    public float lowJumpMulti = 1.5f;
    public SpriteRenderer spriterenderer;
    public float speed = 5f;
    public Collider2D collider;
    public Rigidbody2D rb;
    private float groundDistance = 1.25f;
    private float jumpVelocity = 12f;
    public static int score = 0;
    public Vector3 spawnPos;
    public static Player main;
    public Image blackBox;
    public float deathTime = 1.5f;
    private bool freeze = false;
    private float timeOfDeath;
    private bool isFadingOut;
    public UnityEvent death;
    // Start i`s called before the first frame update
    void Start()
    {
        main = this;
        spawnPos = transform.position;
        if (death == null)
        {
            death = new UnityEvent();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze)
        {
            return;
        }
        if (Input.GetButton("Jump") && !jumping)
        {
            jump();
        }
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.position += new Vector3(-1 * speed, 0, 0) * Time.deltaTime;

        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        //}
        float h = Input.GetAxis("Horizontal");
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime * h;
        if (Input.GetKey(KeyCode.DownArrow))
        {

        }
        if (jumping && rb.velocity.y <= 0)
        {
            jumping = false;
        }
        Fall();
    }
    void jump()
    {
        if (isOnGround() || lastGround + fallLeeway > Time.time)
        {
            rb.velocity = new Vector2(0, jumpVelocity);
            jumping = true;
        }
    }
    bool isOnGround()
    {
        ContactFilter2D cf = new ContactFilter2D();
        cf.useTriggers = false;
        LayerMask thing = LayerMask.GetMask("Default", "Wall");
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -Vector2.up, groundDistance, thing);
        foreach (RaycastHit2D hit in hits)
        {


            if (hit.collider != null && hit.collider.gameObject != gameObject)
            {
                Debug.DrawLine(transform.position, hit.point);
                lastGround = Time.time;
                return true;
            }
        }
        return false;
    }
    public void Test(Coin c)
    {
        score += c.value;
        Debug.Log(score);
    }
    public void OnDeath()
    {
        if (!freeze)
        {
            freeze = true;
            FadeOut(1.5f);
            transform.position = spawnPos;
            death.Invoke();
     //       FadeIn(1.5f);
            freeze = false;
        }
    }
    void Fall()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * Time.deltaTime * (fallMulti - 1);
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * Time.deltaTime * (lowJumpMulti - 1);
        }
    }
    public void FadeOut(float duration)
    {
        float timeStarted = Time.time;
        while (timeStarted + duration > Time.time)
        {
            float timePassed = Time.time - timeStarted;
            float ratiopassed = timePassed / deathTime;
            byte ratio = (byte)(ratiopassed * 255);
            blackBox.color = new Color32(0, 0, 0, ratio);
        }
    }
    public void FadeIn(float duration)
    {
        float timeStarted = Time.time;
        while (timeStarted + duration > Time.time)
        {
            float timePassed = Time.time - timeStarted;
            float ratiopassed = timePassed / deathTime;
            byte ratio = (byte)(255 - ratiopassed * 255);
            blackBox.color = new Color32(0, 0, 0, ratio);
        }
    }
}