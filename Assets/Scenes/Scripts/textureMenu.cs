using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textureMenu : MonoBehaviour
{
    public GameObject livRoom_floor;    //id = 0, room_id = 0
    public GameObject livRoom_wall;     //id = 1, room_id = 0
    public GameObject room1_floor;    //id = 0, room_id = 1
    public GameObject room1_wall;     //id = 1, room_id = 1
    public GameObject room2_floor;    //id = 0, room_id = 2
    public GameObject room2_wall;     //id = 1, room_id = 2
    public GameObject floor_btn;
    public GameObject wall_btn;
    public GameObject back_button;
    public GameObject close_button;
    public GameObject textureList;
    public GameObject SelectRoom;
    public GameObject SelectTile;
    int back_style = 0;
    int room_id = 0;
    int id = 0;
    private string str;
    Renderer SetColor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void back_btn_clicked()
    {
        if(back_style == 0)
        {
            SelectRoom.SetActive(true);
            SelectTile.SetActive(false);
            textureList.SetActive(false);
            back_button.SetActive(false);
            close_button.SetActive(true);
        }
        if(back_style == 1)
        {
            back_style = 0;
            SelectTile.SetActive(true);
            textureList.SetActive(false);
            back_button.SetActive(true);
            close_button.SetActive(false);
        }
    }

    public void livingRoom_selected()
    {
        room_id = 0;
        back_style = 0;
        SelectRoom.SetActive(false);
        SelectTile.SetActive(true);
        textureList.SetActive(false);
        back_button.SetActive(true);
        close_button.SetActive(false);
    }

    public void Room1_selected()
    {
        room_id = 1;
        back_style = 0;
        SelectRoom.SetActive(false);
        SelectTile.SetActive(true);
        textureList.SetActive(false);
        back_button.SetActive(true);
        close_button.SetActive(false);
    }

    public void Room2_selected()
    {
        room_id = 2;
        back_style = 0;
        SelectRoom.SetActive(false);
        SelectTile.SetActive(true);
        textureList.SetActive(false);
        back_button.SetActive(true);
        close_button.SetActive(false);
    }

    public void floor_selected()    // floor 텍스쳐 변경 선택
    {
        id = 0;
        back_style = 1;
        SelectTile.SetActive(false);
        textureList.SetActive(true);
        back_button.SetActive(true);
        close_button.SetActive(false);
    }

    public void wall_selected() // wall 텍스쳐 변경 선택
    {
        id = 1;
        back_style = 1;
        SelectTile.SetActive(false);
        textureList.SetActive(true);
        back_button.SetActive(true);
        close_button.SetActive(false);
    }

    public void apply_texture(string str)   // 텍스쳐 적용 함수
    {
        // id 값을 확인하여 선택한 타일을 벽에 적용할지, 바닥에 적용할지 선택
        if (id == 0)
        {
            if(room_id == 0)
            {
                MeshRenderer mesh = livRoom_floor.GetComponent<MeshRenderer>();
                Material mat = Resources.Load(str) as Material;
                mesh.material = mat;
                //Debug.Log(gameObject.name);
            }
            if(room_id == 1)
            {
                MeshRenderer mesh = room1_floor.GetComponent<MeshRenderer>();
                Material mat = Resources.Load(str) as Material;
                mesh.material = mat;
                //Debug.Log(gameObject.name);
            }
            if(room_id == 2)
            {
                MeshRenderer mesh = room2_floor.GetComponent<MeshRenderer>();
                Material mat = Resources.Load(str) as Material;
                mesh.material = mat;
                //Debug.Log(gameObject.name);
            }
        }
        else if (id == 1)
        {
            if(room_id == 0)
            {
                MeshRenderer mesh = livRoom_wall.GetComponent<MeshRenderer>();
                Material mat = Resources.Load(str) as Material;
                mesh.material = mat;
                //Debug.Log(gameObject.name);
            }
            if(room_id == 1)
            {
                MeshRenderer mesh = room1_wall.GetComponent<MeshRenderer>();
                Material mat = Resources.Load(str) as Material;
                mesh.material = mat;
                //Debug.Log(gameObject.name);
            }
            if(room_id == 2)
            {
                MeshRenderer mesh = room2_wall.GetComponent<MeshRenderer>();
                Material mat = Resources.Load(str) as Material;
                mesh.material = mat;
                //Debug.Log(gameObject.name);
            }
        }
    }

    // 각 텍스쳐를 선택할 경우 str에 해당 material의 경로를 문자열로 할당 
    public void default_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/1. default_floor";
            apply_texture(str); // apply_texture 함수에 str을 인자로 전달하여 해당 material을 적용해준다.
        }
        if (id == 1)
        {
            str += "_wall/1. default";
            apply_texture(str); // apply_texture 함수에 str을 인자로 전달하여 해당 material을 적용해준다.
        }
    }

    public void brick_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/7. brick_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/7. brick";
            apply_texture(str);
        }
    }

    public void brown_marble1_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/8. brown_marble1_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/8. brown_marble1";
            apply_texture(str);
        }
    }

    public void brown_marble2_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/9. brown_marble2_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/9. brown_marble2";
            apply_texture(str);
        }
    }

    public void fabric1_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/10. fabric1_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/10. fabric1";
            apply_texture(str);
        }
    }

    public void fabric2_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/11. fabric2_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/11. fabric2";
            apply_texture(str);
        }
    }

    public void fabric3_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/12. fabric3_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/12. fabric3";
            apply_texture(str);
        }
    }

    public void grey_marble1_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/13. grey_marble1_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/13. grey_marble1";
            apply_texture(str);
        }
    }

    public void grey_marble2_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/14. grey_marble2_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/14. grey_marble2";
            apply_texture(str);
        }
    }

    public void mix_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/15. mix_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/15. mix";
            apply_texture(str);
        }
    }

    public void pattern1_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/16. pattern1_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/16. pattern1";
            apply_texture(str);
        }
    }

    public void pattern2_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/17. pattern2_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/17. pattern2";
            apply_texture(str);
        }
    }

    public void stone1_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id ==0)
        {
            str += "_floor/18. stone1_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/18. stone1";
            apply_texture(str);
        }
    }

    public void white_grey_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/19. white_grey_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/19. white_grey";
            apply_texture(str);
        }
    }

    public void wood1_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/20. wood1_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/20. wood1";
            apply_texture(str);
        }
    }

    public void wood2_floor_wall()
    {
        str = "Materials";
        if (SelectMenu.room_num == 0){
            str += "/OneRoom1";
        }
        if (SelectMenu.room_num == 1){
            str += "/OneRoom2";
        }
        if (SelectMenu.room_num == 3){
            str += "/TwoRoom";
        }
        if (room_id == 0)
        {
            str += "/livingRoom";
        }
        if (room_id == 1)
        {
            str += "/room1";
        }
        if (room_id == 2)
        {
            str += "/room2";
        }
        if (id == 0)
        {
            str += "_floor/21. wood2_floor";
            apply_texture(str);
        }
        if (id == 1)
        {
            str += "_wall/21. wood2";
            apply_texture(str);
        }
    }
}