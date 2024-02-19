using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillSpeedController : MonoBehaviour
{
    public float animationSpeed = 1.0f;
    private Animator animator;
    public int level;
    public float speed;

    float getSpeedByLevel()
    {
        // 레벨에 따른 값 가져오는 것으로 변경
        level = GameManager.Instance.prefabs[0].GetComponent<Automata>().quantity;
        speed = 9.0f - 8.5f / (1 + 0.01f * level);
        return speed;
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
