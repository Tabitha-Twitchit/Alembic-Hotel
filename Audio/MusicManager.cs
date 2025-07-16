using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    public AudioSource musicSource;
    public List<SceneMusicPair> musicLibrary;

    private Dictionary<string, AudioClip> musicDict;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeMusicDictionary();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeMusicDictionary()
    {
        musicDict = new Dictionary<string, AudioClip>();
        foreach (var pair in musicLibrary)
        {
            if (!musicDict.ContainsKey(pair.sceneName)) 
                musicDict.Add(pair.sceneName, pair.clip);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (musicDict.TryGetValue(scene.name, out AudioClip clip))
        {
            musicSource.clip = clip;
            musicSource.Play();
            Debug.Log("Scene Name: " + scene.name);
            Debug.Log("Track Title: " + clip);
        }
    }
}

[System.Serializable]
public class SceneMusicPair
{
    public string sceneName;
    public AudioClip clip;
}