using UnityEngine;

public enum FeatureUsage
{
    Once, //use once
    Toggle //use more than once
}

public class CoreFeatures : MonoBehaviour
{
   //Accessors - Accessing code outside of this specific class
   //This can be done with public variables, this is a more condensed approach.
   //PROPERTIES - Encapuslates filed
   //GET Accessor (READ) - returns encapsulated values
   //SET Accessor (WRITE) - allocates/assigns new values to field.
   //Note: Must use Pascal case for Property - example: PropertyName

    public bool AudioSFXSourceCreated { get; set; }

    //Audio plays when something opens
    [field: Header("Core Audio")]
    [field: SerializeField]
    public AudioClip AudioClipOnStart { get; set; }

    //Audio plays on exit (on closing the door)
    [field: SerializeField]
    public AudioClip AudioClipOnEnd { get; set; }

    private AudioSource audioSource;

    [Header("Core Features")]

    public FeatureUsage featureUsage = FeatureUsage.Once;

    protected virtual void Awake()
    {
        MakeSFXAudioSource();
    }

    private void MakeSFXAudioSource()
    {
        audioSource = GetComponent<AudioSource>();

        //if this is equal to null, create it here
        if(audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        //whether it's null or not, we still need to make sure it's true
        //On awake, create this audioSource
        AudioSFXSourceCreated = true;

    }

    //Audio play commands
    protected void PlayOnStart()
    {
        if(AudioSFXSourceCreated && AudioClipOnStart != null)
        {
            //I have a source, but I need to associate it with a clip
            audioSource.clip = AudioClipOnStart;
            audioSource.Play();
        }
    }

    protected void PlayOnEnd()
    {
        if (AudioSFXSourceCreated && AudioClipOnEnd != null)
        {
            //I have a source, but I need to associate it with a clip
            audioSource.clip = AudioClipOnEnd;
            audioSource.Play();
        }
    }
}
