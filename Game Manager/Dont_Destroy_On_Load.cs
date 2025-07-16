using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_On_Load : SingletonDontDestroy<Dont_Destroy_On_Load>
{
    //this script pairs with SingletonDontDestroy and is simply added to an object so that it inherits Don't Destroy on Load from it,
    //regardless of syntax etc.
}
