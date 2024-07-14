using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class waveSistem : MonoBehaviour
{
    [Header("ses----------------")]
    [SerializeField] AudioSource muzýk;
    
    public enum SpawnState { SPAWNÝNG, WAÝTÝNG, COUNTÝNG };

    

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

    public SpawnState state = SpawnState.COUNTÝNG;

    public bool zamanAcýlsýnmý;

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
        if (state == SpawnState.WAÝTÝNG)
        {
            //Check if enemies are still alive!!
            if (!EnemyIsAlive())
            {
                //yeni round baslasýn          
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
            if (state != SpawnState.SPAWNÝNG)
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

        muzýk.Stop();

        state = SpawnState.COUNTÝNG;
        


        waveCountdown = timeBetweenWaves;



        //--------------ZAMAN ÝSLEMLERÝ-------------------

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

        state = SpawnState.SPAWNÝNG;

        muzýk.Play();
        //spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        
        state = SpawnState.WAÝTÝNG;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //spawn enemy
        int randomIndex = Random.Range(0, spawnPoints.Length); // Rastgele bir indeks seç
        Transform spawnLocation = spawnPoints[randomIndex]; // Seçilen indekse göre spawn noktasýný al
        Debug.Log("Spawning enemy" + _enemy.name);
        Instantiate(_enemy, spawnLocation.transform.position, Quaternion.identity);

    }

    //void StartCounting()
    //{
    //    geriSayim.instance.UpdateTime();
    //}

    //---------------------------------------------------------------------------




    public Text timerText; // Geri sayým metni nesnesi
    private float currentTime; // Geri sayým süresi (saniye)
    [SerializeField] private float duration;

    float colorValue = 1f;
    public IEnumerator UpdateTime()
    {
        colorValue = 1f;

        while (currentTime >= 0)
        {
            timerText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);

            // Renk deðerini her saniye 0.1 azaltýn
            colorValue -= 0.1f;

            // Renk deðerini sýnýrlayýn (0 ile 1 arasýnda)
            colorValue = Mathf.Clamp01(colorValue);

            // TimerText'in rengini ayarlayýn
            timerText.color = new Color(timerText.color.r, timerText.color.g, timerText.color.b, colorValue);

            currentTime--;
        }

        yield return null;
        
    }


    //---------------------------------------------------------------------------
}
