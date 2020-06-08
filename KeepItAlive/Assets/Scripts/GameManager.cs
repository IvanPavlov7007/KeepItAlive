using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance = null;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GameManager>();
            return _instance;
        }
    }

    [SerializeField]
    CharacterController cowboy;

    public List<RubberMovingObject> rubbers;

    public float CameraWidth;

    bool showCredits = false;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        CameraWidth = 1.999211f;//Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        foreach (var a in GetComponent<PlayerInput>().actions)
        {
            Debug.Log(a.name);
        }
    }

    int currentMovingDirection;

    public void OnMove(InputValue val)
    {
        currentMovingDirection = (int)val.Get<Vector2>().x;
        cowboy.OnMove(currentMovingDirection);
    }

    public void OnEsc(InputValue val)
    {
        showCredits = !showCredits;
    }

    public void Update()
    {
        float normalDist = -currentMovingDirection * Time.deltaTime;
        foreach (var rubber in rubbers)
        {
            rubber.ScrollRubber(normalDist);
        }
    }

    private void OnGUI()
    {
        if(showCredits)
            GUI.Label(new Rect(10, 10, 300, 40), "By Ivan Pavlov");
    }
}
