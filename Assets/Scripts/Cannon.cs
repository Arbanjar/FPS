using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private GameObject bulletPoint;
    [SerializeField]
    private float bulletSpeed = 600f;

    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    // Start is called before the first frame update
    void Start()
    {
        keywordActions.Add("Fire", Fire);
        keywordActions.Add("turn right", TurnRight );

        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnkeyWordRecognized;
        keywordRecognizer.Start();
    }

    private void OnkeyWordRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("keyword: " + args.text);
        keywordActions[args.text].Invoke();
        throw new NotImplementedException();
    }

    private void Fire()
    {
        Debug.Log("Fire Hooray!");
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
        Destroy(bullet, 1);
    }

    private void TurnRight()
    {
        Debug.Log("Turn right!");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
