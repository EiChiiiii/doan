using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public int maxPositions = 100; // Số lượng vị trí tối đa lưu trữ
    public float lineDuration = 2f; // Thời gian hiển thị đường đi
    public bool keepDrawing = true; // Cho phép vẽ đường đi sau khi viên đạn bị hủy

    private List<Vector3> positions = new List<Vector3>();
    private Vector2 moveDirection; // Hướng di chuyển của viên đạn

    void Start()
    {
        // Lấy hoặc tạo một LineRenderer nếu chưa có
        if (!lineRenderer)
        {
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // Tùy chỉnh thuộc tính của LineRenderer
        lineRenderer.positionCount = 0; // Khởi đầu với 0 điểm
        lineRenderer.startWidth = 0.1f; // Độ rộng ở điểm xuất phát
        lineRenderer.endWidth = 0.1f; // Độ rộng ở điểm kết thúc
        lineRenderer.enabled = false; // Ẩn đường đi khi không cần thiết
    }

    void Update()
    {
        // Nếu keepDrawing là false và đường đi đã được hiển thị, thoát khỏi hàm Update
        if (!keepDrawing && lineRenderer.enabled)
            return;

        // Xử lý vận tốc của đạn
        // ...

        // Lưu trữ vị trí hiện tại của đạn vào danh sách
        positions.Add(transform.position);

        // Cắt bớt danh sách nếu nó quá dài
        if (positions.Count > maxPositions)
        {
            positions.RemoveAt(0);
        }

        // Cập nhật đường đi
        UpdateLineRenderer();
    }

    void UpdateLineRenderer()
    {
        // Cập nhật số lượng điểm trên LineRenderer
        lineRenderer.positionCount = positions.Count;

        // Đặt vị trí cho từng điểm trên LineRenderer
        for (int i = 0; i < positions.Count; i++)
        {
            lineRenderer.SetPosition(i, positions[i]);
        }

        // Hiển thị đường đi trong một khoảng thời gian
        if (lineDuration > 0f)
        {
            lineDuration -= Time.deltaTime;
        }

        // Ẩn LineRenderer khi thời gian hiển thị kết thúc và keepDrawing là false
        if (lineDuration <= 0f && !keepDrawing)
        {
            lineRenderer.enabled = false;
        }
        else
        {
               // Hiển thị LineRenderer trong thời gian lineDuration hoặc khi keepDrawing là true
            lineRenderer.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Xử lý va chạm ở đây (ví dụ: hủy đạn)
        Destroy(gameObject);
    }
}
