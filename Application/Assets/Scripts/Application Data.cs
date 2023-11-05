using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationData 
{
    public static ApplicationData AppData = new ApplicationData();
    
    public List<Human> ListHum = new List<Human>();// Список Всех людей
    public int ChoosenNumberOfHuman;// Номер выбранного человека
    public int ChoosenNumberOfParam;// Порядковый номер параметра для изменения
}
