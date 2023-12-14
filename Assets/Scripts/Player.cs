using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Button khaihoa;

    private void Start()
    {
        //tạo sự kiện cho nút
        khaihoa.onClick.AddListener(Shoot);
    }


    void Update()
    {
        // Kiểm tra khi chuột trái được nhấn
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Tạo một viên đạn từ prefab
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Thực hiện các thiết lập khác (vận tốc, hướng, độ hủy sau thời gian, v.v.)
        // Điều này phụ thuộc vào cách bạn muốn xử lý viên đạn.

        // Ví dụ: Đặt vận tốc của viên đạn
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(90f, 90f);
    }
}
