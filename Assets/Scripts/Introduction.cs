using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    // Biến để theo dõi trạng thái hiển thị của UI
    private bool isUIVisible = false;

    // Thực hiện khi bấm nút
    public void ToggleUIVisibility()
    {
        // Đảo ngược trạng thái hiển thị
        isUIVisible = !isUIVisible;

        // Hiển thị hoặc ẩn UI dựa trên trạng thái
        gameObject.SetActive(isUIVisible);
    }
}
