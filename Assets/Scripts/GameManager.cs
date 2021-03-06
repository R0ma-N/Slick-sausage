using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton class

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] Camera cam;

    public Sausage sausage;
    public Trajectory trajectory;

    [SerializeField] float pushForce = 4f;

    bool isDragging = false;

    Vector2 startPoint, endPoint, direction, force;
    float distance;

    [SerializeField] GameObject failPanel;

    private void Start()
    {
        Time.timeScale = 1;
        sausage.DisactivateRb();
    }

    private void Update()
    {
        sausage.ChekTheGround();

        if (sausage.onTheGround)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isDragging = true;
                OnDragStart();
            }
            
            if (Input.GetMouseButtonUp (0))
            {
                isDragging = false;
                OnDragEnd();
            }
            
            if (isDragging)
            {
                OnDrag();
            }
        }


        if (sausage.isFailed)
        {
            Failed();
        }
    }

    void OnDragStart()
    {
        sausage.DisactivateRb();
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);

        trajectory.Show();
    }

    void OnDrag()
    {
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        distance = Vector2.Distance(startPoint, endPoint);
        direction = (startPoint - endPoint).normalized;
        force = direction * distance * pushForce;

        Debug.DrawLine(startPoint, endPoint);

        trajectory.UpdateDots(sausage.pos, force);
    }

    void OnDragEnd()
    {
        sausage.ActivateRb();
        sausage.Push(force);

        trajectory.Hide();
    }

    private void Failed()
    {
        Time.timeScale = 0;
        failPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
