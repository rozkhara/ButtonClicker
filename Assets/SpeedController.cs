using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour
{
    public float animationSpeed = 1.0f;
    private Animator animator;
    public float levelUpSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float newSpeed = animationSpeed * levelUpSpeed;

        animator.SetFloat("AnimSpeed", newSpeed);
    }
}
