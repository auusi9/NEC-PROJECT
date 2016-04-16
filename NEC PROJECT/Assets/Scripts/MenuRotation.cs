using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MenuRotation : MonoBehaviour
{
    float ang;
    static bool firstTimeLoad = true;
    bool GoTo = false;
    float angleToGo = 325;
    float currentAngle = 135;
    float baseAngle2;
    bool Sound;
    public AudioClip OnClick;
    private AudioSource MenuAudio;

    void Start()
    {
        MenuAudio = GetComponent<AudioSource>();

        Time.timeScale = 1.0f;
        if (firstTimeLoad)
        {
            angleToGo = 325;
            currentAngle = 135;
            transform.rotation = Quaternion.AngleAxis(135, Vector3.forward);
            GoTo = true;
            firstTimeLoad = false;
        }
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    public void LoadAboutUsScene()
    {
        SceneManager.LoadScene("AboutUs");
    }
  
   
    public void OnStartGame()
    {
        //Debug.Log("You pressed play button!");
        //Add load for new scene here.

        
        MenuAudio.PlayOneShot(OnClick,1);
        LoadPlayScene();

    }
    public void OnSettingsGame()
    {
        //Add load for new scene here.
        SceneManager.LoadScene("Settings");
    }
    public void OnStatsGame()
    {
        Debug.Log("You pressed Stats button!");
        SceneManager.LoadScene("StatsScene");
    }
    public void OnAboutGame()
    {
        SceneManager.LoadScene("AboutUs");
    }

    void Update()
    {
        if(GoTo == true)
        {
            GoToAngle();
        }
    }
    public void DeleteData()
    {
        PlayerPrefs.DeleteAll();
    }
    
   

    void onTouchDown(Vector3 position)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = position - pos;
        baseAngle2 = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        baseAngle2 -= Mathf.Atan2(transform.right.y, transform.right.x) * Mathf.Rad2Deg;
         
    }

    void onTouchStay(Vector3 position)
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos = position - pos;
        ang = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - baseAngle2;
        transform.rotation = Quaternion.AngleAxis(ang, Vector3.forward);
    }

    void onTouchUp()
    {
        float angle = transform.rotation.eulerAngles.z;

        if (angle > 45f && angle < 135f )
        {
            GoTo = true;
            angleToGo = 90;
            
        }
        else if (angle >= 135f  && angle < 225f)
        {
            GoTo = true;
            angleToGo = 180;
            
        }
        else if (angle >= 225f  && angle < 315f)
        {
            GoTo = true;
            angleToGo = 270;
            
           
        }
        else if (angle > 315f || angle < 45f)
        {
            GoTo = true;
            angleToGo = 0;
        }
        currentAngle = angle;
        if (currentAngle == 45 || currentAngle == 225 || currentAngle == 315 || currentAngle == 135) currentAngle++;
    }
    void onTouchExit()
    {
        //Add Code 
    }

    void GoToAngle()
    {
        
        currentAngle = Mathf.Round(currentAngle);
        if(currentAngle == angleToGo)
        {
            currentAngle = angleToGo;
            GoTo = false;
        }
         if (currentAngle > angleToGo && currentAngle <= 315)
            currentAngle--;
        else if (currentAngle < angleToGo || currentAngle > 315)
            currentAngle++;
        if (currentAngle == 360) currentAngle = 0;

        transform.rotation = Quaternion.AngleAxis(currentAngle, Vector3.forward);

    }


}
