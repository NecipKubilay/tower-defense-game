using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class waveSistem : MonoBehaviour
{
    [Header("ses----------------")]
    [SerializeField] AudioSource muz�k;
    
    public enum SpawnState { SPAWN�NG, WA�T�NG, COUNT�NG };

    

    public Transform[] spawnPoints;

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;


    public float timeBetweenWaves = 10f;
    public float waveCountdown;

    private float searchCountDown = 1f;

    public SpawnState state = SpawnState.COUNT�NG;

    public bool zamanAc�ls�nm�;

    public static waveSistem instance;
    private void Awake()
    {
        


        if (instance == null)
        {
            instance = this;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Start()
    {

        

        waveCountdown = timeBetweenWaves;

        currentTime = duration;
        timerText.text = currentTime.ToString();

        StartCoroutine(UpdateTime());
    }


    void Update()
    {
        if (state == SpawnState.WA�T�NG)
        {
            //Check if enemies are still alive!!
            if (!EnemyIsAlive())
            {
                //yeni round baslas�n          
                WaveCompleted();
                StartCoroutine(UpdateTime());
                //return;
            }
            else
            {
                return;
            }
        }


        
        



        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWN�NG)
            {
                //start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }


    void WaveCompleted()
    {
        Debug.Log("wave bitti");

        muz�k.Stop();

        state = SpawnState.COUNT�NG;
        


        waveCountdown = timeBetweenWaves;



        //--------------ZAMAN �SLEMLER�-------------------

        currentTime = duration;
        timerText.text = currentTime.ToString();

        //------------------------------------------------

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("all waves complete!!");
        }
        
        nextWave++;
    }

    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                return false; //dusmanlar hayatta degilse false dondur
            }
        }
        return true;
    }


    IEnumerator SpawnWave(Wave _wave)
    {
        
        Debug.Log("spawning wave" + _wave.name);

        state = SpawnState.SPAWN�NG;

        muz�k.Play();
        //spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        
        state = SpawnState.WA�T�NG;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //spawn enemy
        int randomIndex = Random.Range(0, spawnPoints.Length); // Rastgele bir indeks se�
        Transform spawnLocation = spawnPoints[randomIndex]; // Se�ilen indekse g�re spawn noktas�n� al
        Debug.Log("Spawning enemy" + _enemy.name);
        Instantiate(_enemy, spawnLocation.transform.position, Quaternion.identity);

    }

    //void StartCounting()
    //{
    //    geriSayim.instance.UpdateTime();
    //}

    //---------------------------------------------------------------------------




    public Text timerText; // Geri say�m metni nesnesi
    private float currentTime; // Geri say�m s�resi (saniye)
    [SerializeField] private float duration;

    float colorValue = 1f;
    public IEnumerator UpdateTime()
    {
        colorValue = 1f;

        while (currentTime >= 0)
        {
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);

            // Renk de�erini her saniye 0.1 azalt�n
            colorValue -= 0.1f;

            // Renk de�erini s�n�rlay�n (0 ile 1 aras�nda)
            colorValue = Mathf.Clamp01(colorValue);

            // TimerText'in rengini ayarlay�n
            timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, colorValue);

            currentTime--;
        }

        yield return null;
        
    }


    //---------------------------------------------------------------------------
}
