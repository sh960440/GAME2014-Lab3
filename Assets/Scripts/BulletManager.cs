using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public GameObject bullet;
    public int maxBullets;
    private Queue<GameObject> m_bulletPool;

    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    private void _BuildBulletPool()
    {
        // create emtpy Queue structrue
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < maxBullets; count++)
        {
            var tempBullet = Instantiate(bullet); // 初始化一個bullet物件
            tempBullet.SetActive(false); // 先把它設置為false
            tempBullet.transform.parent = transform; // 讓生成的子彈歸屬在bullet manager底下
            m_bulletPool.Enqueue(tempBullet); // 把它放進bullet pool(一個queue)
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue(); // 從queue中拿出
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void ReturnBullet(GameObject returnBullet)
    {
        returnBullet.SetActive(false);
        m_bulletPool.Enqueue(returnBullet);
    }
}
