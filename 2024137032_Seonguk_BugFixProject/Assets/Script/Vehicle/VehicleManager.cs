using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public Vehicle[] vehicles;  //탈것 객체 배열 선언한다.

    public Car car; //자동차 선언
    public Bicycle bicycle; //자전거 선언

    float Timer; //간단한 시간 float 변수 선언 

    void Update()
    {
        car.Move();  //이동 함수 호출
        bicycle.Move(); 
        Timer -= Time.deltaTime;  //시간을 줄인다

        if(Timer < 0)  //1초마다 호출되게 한다
        {
            car.Horn();  //경적 함수 호출 
            bicycle.Horn();
            Timer = 1;
        }
    }
}
