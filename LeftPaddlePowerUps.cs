using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Written by Zane
public class LeftPaddlePowerUps : MonoBehaviour
{
    [Header("Fast Ball Power-Up")]
    [SerializeField] private KeyCode fastBallKey;
    [SerializeField] private float fastBallCooldownTime;
    [SerializeField] private LeftPaddleFastBall fastBallScript;
    [SerializeField] private Material fastBallMaterial;
    [SerializeField] private GameObject fastBallIcon;

    [Header("Curve Ball Power-Up")]
    [SerializeField] private KeyCode curveBallKey;
    [SerializeField] private float curveBallCooldownTime;
    [SerializeField] private LeftPaddleCurveBall curveBallScript;
    [SerializeField] private Material curveBallMaterial;
    [SerializeField] private GameObject curveBallIcon;

    [Header("Paddle Grow Power-Up")]
    [SerializeField] private KeyCode paddleGrowKey;
    [SerializeField] private float paddleGrowCooldownTime;
    [SerializeField] private LeftPaddleGrow growPaddleScript;
    [SerializeField] private Material paddleGrowMaterial;
    [SerializeField] private GameObject paddleGrowIcon;

    [Header("Paddle Accelerate Power-Up")]
    [SerializeField] private KeyCode paddleAccelerateKey;
    [SerializeField] private float paddleAccelerateCooldownTime;
    [SerializeField] private LeftPaddleAccelerate acceleratePaddleScript;
    [SerializeField] private Material paddleAccelerateMaterial;
    [SerializeField] private GameObject paddleAccelerateIcon;

    private bool powerupActive = false;
    private bool deactivateFastBall;
    private bool deactivateCurveBall;
    private bool deactivatePaddleGrow;
    private bool deactivatePaddleAccelerate;

    private SpriteRenderer fastBallRenderer;
    private SpriteRenderer curveBallRenderer;
    private SpriteRenderer paddleGrowRenderer;
    private SpriteRenderer paddleAccelerateRenderer;
    private MeshRenderer meshRenderer;
    private Material oldMaterial;

    private void Start()
    {
        // gets the sprite renderers from each power-up icon
        fastBallRenderer = fastBallIcon.GetComponent<SpriteRenderer>();
        curveBallRenderer = curveBallIcon.GetComponent<SpriteRenderer>();
        paddleGrowRenderer = paddleGrowIcon.GetComponent<SpriteRenderer>();
        paddleAccelerateRenderer = paddleAccelerateIcon.GetComponent<SpriteRenderer>();

        // get the mesh renderer component from the paddle
        meshRenderer = GetComponentInParent<MeshRenderer>();

        // get the default material applied on the paddle
        oldMaterial = meshRenderer.material;

    }

    private void Update()
    {
        ActivateCurveBall();
        ActivatePaddleGrow();
        ActivateFastBall();
        ActivatePaddleAccelerate();
    }

    private void ActivateFastBall()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(fastBallKey) && deactivateFastBall == false)
            {
                fastBallScript.activateLeftFastBall = true;
                deactivateFastBall = true;
                ///Debug.Log("LEFT PADDLE FAST BALL ACTIVATED");
                meshRenderer.material = fastBallMaterial;
                powerupActive = true;
            }
        }

        if (fastBallScript.usedLeftFastBall == true)
        {
            fastBallScript.usedLeftFastBall = false;
            fastBallScript.activateLeftFastBall = false;
            ///Debug.Log("LEFT PADDLE FAST BALL DEACTIVATED");
            meshRenderer.material = oldMaterial;
            powerupActive = false;
            StartCoroutine(FastBallCooldown());
        }
    }

    IEnumerator FastBallCooldown()
    {
        fastBallRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        yield return new WaitForSeconds(fastBallCooldownTime);
        fastBallRenderer.color = new Color(1f, 1f, 1f, 1f);
        deactivateFastBall = false;
        ///Debug.Log("LEFT PADDLE FAST BALL READY");
    }

    private void ActivateCurveBall()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(curveBallKey) && deactivateCurveBall == false)
            {
                curveBallScript.activateLeftCurveBall = true;
                deactivateCurveBall = true;
                ///Debug.Log("LEFT PADDLE CURVE BALL ACTIVATED");
                meshRenderer.material = curveBallMaterial;
                powerupActive = true;
            }
        }

        if (curveBallScript.usedLeftCurveBall == true)
        {
            curveBallScript.usedLeftCurveBall = false;
            curveBallScript.activateLeftCurveBall = false;
            ///Debug.Log("LEFT PADDLE CURVE BALL DEACTIVATED");
            meshRenderer.material = oldMaterial;
            powerupActive = false;
            StartCoroutine(CurveBallCooldown());
        }
    }

    IEnumerator CurveBallCooldown()
    {
        curveBallRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        yield return new WaitForSeconds(curveBallCooldownTime);
        curveBallRenderer.color = new Color(1f, 1f, 1f, 1f);
        deactivateCurveBall = false;
        ///Debug.Log("LEFT PADDLE CURVE BALL READY");
    }

    private void ActivatePaddleGrow()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(paddleGrowKey) && deactivatePaddleGrow == false)
            {
                growPaddleScript.activateLeftPaddleGrow = true;
                deactivatePaddleGrow = true;
                ///Debug.Log("LEFT PADDLE GROW ACTIVATED");
                meshRenderer.material = paddleGrowMaterial;
                powerupActive = true;
            }
        }

        if (growPaddleScript.usedLeftPaddleGrow == true)
        {
            growPaddleScript.usedLeftPaddleGrow = false;
            ///Debug.Log("LEFT PADDLE GROW DEACTIVATED");
            meshRenderer.material = oldMaterial;
            powerupActive = false;
            StartCoroutine(GrowPaddleCooldown());
        }
    }

    IEnumerator GrowPaddleCooldown()
    {
        paddleGrowRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        yield return new WaitForSeconds(paddleGrowCooldownTime);
        paddleGrowRenderer.color = new Color(1f, 1f, 1f, 1f);
        deactivatePaddleGrow = false;
        ///Debug.Log("LEFT PADDLE GROW READY");
    }

    private void ActivatePaddleAccelerate()
    {
        if (powerupActive == false)
        {
            if (Input.GetKeyDown(paddleAccelerateKey) && deactivatePaddleAccelerate == false)
            {
                acceleratePaddleScript.activateLeftPaddleAccelerate = true;
                deactivatePaddleAccelerate = true;
                ///Debug.Log("RIGHT PADDLE ACCELERATE ACTIVATED");
                meshRenderer.material = paddleAccelerateMaterial;
                powerupActive = true;
            }
        }

        if (acceleratePaddleScript.usedLeftPaddleAccelerate == true)
        {
            acceleratePaddleScript.usedLeftPaddleAccelerate = false;
            ///Debug.Log("RIGHT PADDLE ACCELERATE DEACTIVATED");
            meshRenderer.material = oldMaterial;
            powerupActive = false;
            StartCoroutine(AcceleratePaddleCooldown());
        }
    }

    IEnumerator AcceleratePaddleCooldown()
    {
        paddleAccelerateRenderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
        yield return new WaitForSeconds(paddleAccelerateCooldownTime);
        paddleAccelerateRenderer.color = new Color(1f, 1f, 1f, 1f);
        deactivatePaddleAccelerate = false;
        ///Debug.Log("RIGHT PADDLE ACCELERATE READY");
    }
}
