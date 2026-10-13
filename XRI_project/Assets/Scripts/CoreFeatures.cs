using UnityEngine;

public class CoreFeatures : MonoBehaviour
{
    //Accessors - accesssing code outside of this specific class
    //this can be done with public variables, amore condensed approuch.
    //PROPERTIES - Encapsulates filed
    //GET Accessor (READ) - returns encapsulated values
    //SET Accessor (WRITE) - allocates/assigns new values to a field
    //Note: most use pascal case for Property - example: PropertyName

    public bool AudioSFXSourceCreated { get; set; }


}
