using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable_Object : MonoBehaviour
{

 //this script compliments Cursor_Visible, which it calls below. When placed on a game object (say, an NPC) it notifies that
 //script that it should change the cursor when it hovers over it. It is useful with Yarn Spinner so that the Player can
 //know who they can speak to. 
    private void OnMouseEnter()
    {
        Cursor_Visible.instance.Clickable();    
    }

    private void OnMouseExit()
    {
        Cursor_Visible.instance.Default();
    }


}
