using UnityEngine;
using System.Collections;

public class GUImenu : MonoBehaviour {
    private Vector2 res;

    private Vector2[] currentSize;
    private Vector2[] targetSize;

    private Vector2 inactiveSize;
    private Vector2 activeSize;
    private float xSizeActive;
    private float ySizeActive;

    public bool exitActive;

    public GUISkin voteMenuSkin;
    public string[] GUIString;


    public bool[] votes;
    private int voteSum;
    private string currentVote;

    void Awake()
    {
        res = new Vector2(Screen.width, Screen.height);
        currentSize = new Vector2[4];
        targetSize = new Vector2[4];
        votes = new bool[4];
        Resize();
        for (int i = 0; i < 4; i++)
        {
            Inactive(i);
        }
    }

    //adjusts size of GUI depending on screen size
    public void Resize()
    {
        inactiveSize = new Vector2(Screen.width / 10.5f, Screen.height / 11);
        activeSize = new Vector2(Screen.width / 12, Screen.height / 5);
    }

    void OnGUI()
    {
        GUI.skin = voteMenuSkin;
        GUI.skin.box.fontSize = Screen.height / 30;

        //GUI box size, string contents, position, etc
        GUI.Box(new Rect((Screen.width / 2) - currentSize[0].x - (Screen.width / 200), (Screen.height / 2) - currentSize[0].y - (Screen.height / 100), currentSize[0].x, currentSize[0].y), GUIString[0]);
        GUI.Box(new Rect((Screen.width) - currentSize[1].x - (Screen.width / 200), (Screen.height / 2) - currentSize[1].y - (Screen.height / 100), currentSize[1].x, currentSize[1].y), GUIString[1]);
        GUI.Box(new Rect((Screen.width / 2) - currentSize[2].x - (Screen.width / 200), (Screen.height) - currentSize[2].y - (Screen.height / 100), currentSize[2].x, currentSize[2].y), GUIString[2]);
        GUI.Box(new Rect((Screen.width) - currentSize[3].x - (Screen.width / 200), (Screen.height) - currentSize[3].y - (Screen.height / 100), currentSize[3].x, currentSize[3].y), GUIString[3]);
    }

    void Update()
    {
        //if screen size changes, resize GUI elements and set their states to inactive
        if (res != new Vector2(Screen.width, Screen.height))
        {
            Resize();
            for (int i = 0; i < 4; i++)
            {
                Inactive(i);
            }
        }

        //changes size of GUImenu if target size is different from present size
        for (int i = 0; i < 4; i++)
        {
            if (Vector2.Distance(new Vector2(currentSize[i].x, currentSize[i].y), new Vector2(targetSize[i].x, targetSize[i].y)) > 1)
            {
                currentSize[i] = Vector2.Lerp(currentSize[i], targetSize[i], Time.fixedDeltaTime * 10);
            }
        }


        //press b returns menu to inactive
        if (Input.GetKeyDown("joystick 1 button 1") && !exitActive)
            Inactive(0);
        if (Input.GetKeyDown("joystick 2 button 1") && !exitActive)
            Inactive(1);
        if (Input.GetKeyDown("joystick 3 button 1") && !exitActive)
            Inactive(2);
        if (Input.GetKeyDown("joystick 4 button 1") && !exitActive)
            Inactive(3);

        //pressing y opens their GUI menu
        if (Input.GetKeyDown("joystick 1 button 3") && !exitActive)
            targetSize[0] = activeSize;
        if (Input.GetKeyDown("joystick 2 button 3") && !exitActive)
            targetSize[1] = activeSize;
        if (Input.GetKeyDown("joystick 3 button 3") && !exitActive)
            targetSize[2] = activeSize;
        if (Input.GetKeyDown("joystick 4 button 3") && !exitActive)
            targetSize[3] = activeSize;

        //takes vote bools and creates sum of how many are true
        voteSum = 0;
        foreach(bool v in votes)
        {
            if (v == true)
                voteSum++;
        }

        //if a player is in exit area, pressing y votes for exiting
        if (Input.GetKeyDown("joystick 1 button 3") && exitActive)
        {
            //player one vote
            if (votes[0] == false)
            {
                votes[0] = true;
                return;
            }
            if (votes[0] == true)
            {
                votes[0] = false;
                return;
            }
        }

       //if simple majority votes yes, call whatever action is active
        if(voteSum >= 3)
        {
            if(currentVote == "ExitLevel")
                ExitLevel();

        }
    }

    //sets GUI box to inactive state
    public void Inactive(int p)
    {
        targetSize[p] = inactiveSize;
        GUIString[p] = "Call Vote";
        currentVote = null;
        votes[0] = false;
        votes[1] = false;
        votes[2] = false;
        votes[3] = false;
    }
    
    //when a player is in exit level area, GUI box prompts player to vote on level ending
    public void ExitLevelVote()
    {
        for (int i = 0; i < 4; i++)
        {
            targetSize[i] = inactiveSize;
            GUIString[i] = "Exit Level?";
        }
    }

    public void ExitLevel()
    {
        print("exit level");
    }
}