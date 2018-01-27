using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    /*
    enum seName
    {
       closely_sun,create,done,game_start,meteor_a,meteor_c,tap

    };

        */

    protected static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SoundManager)FindObjectOfType(typeof(SoundManager));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");
                }
            }

            return instance;
        }
    }


    //音量
    public SoundVolume volume = new SoundVolume();

    // === AudioSource ===
    private AudioSource BGMsource;  //楽曲音源
    private AudioSource[] SEsources = new AudioSource[16];  //効果音音源
    // === AudioClip ===
    public AudioClip[] BGM;         //楽曲
    public AudioClip[] SE;          //効果音
    
    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("SoundManager");
        if (obj.Length > 1)
        {
            //既に存在してるなら削除
            Destroy(gameObject);
        }
        else
        {
            //音管理はシーン遷移では破棄させない
            DontDestroyOnLoad(gameObject);
        }
        // AudioSource関連のコンポーネントの追加

        // BGM AudioSource
        BGMsource = gameObject.AddComponent<AudioSource>();
        // BGMはループを有効にする
        BGMsource.loop = true;

        // SE AudioSource
        for (int i = 0; i < SEsources.Length; i++)
        {
            SEsources[i] = gameObject.AddComponent<AudioSource>();
        }




    }

    // Update is called once per frame
    void Update()
    {
        // ミュート設定
        BGMsource.mute = volume.Mute;
        foreach (AudioSource source in SEsources)
        {
            source.mute = volume.Mute;
        }
        /*foreach(AudioSource source in BMSsources ){
                source.mute = volume.Mute;
            }
            */
        // ボリューム設定
        BGMsource.volume = volume.BGM;
        foreach (AudioSource source in SEsources)
        {
            source.volume = volume.SE;
        }
        /*foreach(AudioSource source in BMSsources ){
			source.volume = volume.BMSSound;
		}*/
    }

    // ***** BGM再生 *****
    // BGM再生
    public void PlayBGM(int index)
    {
        if (0 > index || BGM.Length <= index)
        {
            return;
        }
        // 同じBGMの場合は何もしない
        if (BGMsource.clip == BGM[index])
        {
            return;
        }
        BGMsource.Stop();
        BGMsource.clip = BGM[index];
        BGMsource.Play();
    }

    // BGM停止
    public void StopBGM()
    {
        BGMsource.Stop();
        BGMsource.clip = null;
    }

    // ***** SE再生 *****
    // SE再生
    public void PlaySE(int index)
    {
        if (0 > index || SE.Length <= index)
        {
            return;
        }

        // 再生中で無いAudioSouceで鳴らす
        foreach (AudioSource source in SEsources)
        {
            if (false == source.isPlaying)
            {
                source.clip = SE[index];
                source.Play();
                return;
            }
        }
    }

    // SE停止
    public void StopSE()
    {
        // 全てのSE用のAudioSouceを停止する
        foreach (AudioSource source in SEsources)
        {
            source.Stop();
            source.clip = null;
        }
    }


}
// 音量クラス
public class SoundVolume
{
    public float BGM = 1.0f;
    public float BMSSound = 1.0f;
    public float SE = 1.0f;
    public bool Mute = false;

    public void Init()
    {
        BGM = 1.0f;
        BMSSound = 1.0f;
        SE = 1.0f;
        Mute = false;
    }
}