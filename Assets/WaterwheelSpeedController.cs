using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterwheelSpeedController : MonoBehaviour
{
    public float animationSpeed = 1.0f;
    private Animator animator;

    float getSpeedByLevel() {
        // 레벨에 따른 값 가져오는 것으로 변경
        return 2.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputSpeed = getSpeedByLevel();
        float newSpeed = animationSpeed * inputSpeed;

        animator.SetFloat("AnimSpeed", newSpeed);
    }
}
