# АНАЛИЗ ДАННЫХ И ИСКУССТВЕННЫЙ ИНТЕЛЛЕКТ [in GameDev]
Отчет по лабораторной работе #4 - "Перцептрон" выполнил:
- Максименков Савелий Андреевич
- НМТ-220703

Отметка о выполнении заданий (заполняется студентом):

| Задание | Выполнение | Баллы |
| ------ | ------ | ------ |
| Задание 1 | * | 60 |
| Задание 2 | * | 20 |
| Задание 3 | * | 20 |

знак "*" - задание выполнено; знак "#" - задание не выполнено;

Работу проверили:
- к.т.н., доцент Денисов Д.В.
- к.э.н., доцент Панов М.А.
- ст. преп., Фадеев В.О.

Структура отчета

- Данные о работе: название работы, фио, группа, выполненные задания.
- Цель работы.
- Задание 1.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Задание 2.
- Код реализации выполнения задания. Визуализация результатов выполнения (если применимо).
- Выводы.

## Цель работы
В проекте Unity реализовать перцептрон.

## Задание 1
### В проекте Unity реализовать перцептрон, который умеет производить вычисления: OR, AND, NAND, XOR, также дать комментарии о корректности работы.
Ход работы:  
 * создал пустой 3D проект Unity.  
 * скачал скрипт ```Perceptron.cs``` с репозитория и добавил его в свой проект.  
   Содержание скрипта:
   ```cs
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;

   [System.Serializable]
   public class TrainingSet
   {
      public double[] input;
      public double output;
   }

   public class Perceptron : MonoBehaviour {

      public TrainingSet[] ts;
      double[] weights = {0,0};
      double bias = 0;
      double totalError = 0;
      public int trainingAmount;
      double DotProductBias(double[] v1, double[] v2) 
      {
         if (v1 == null || v2 == null)
            return -1;
      
         if (v1.Length != v2.Length)
            return -1;
      
         double d = 0;
         for (int x = 0; x < v1.Length; x++)
         {
            d += v1[x] * v2[x];
         }

         d += bias;
      
         return d;
      }

      double CalcOutput(int i)
      {
         double dp = DotProductBias(weights,ts[i].input);
         if(dp > 0) return(1);
         return (0);
      }

      void InitialiseWeights()
      {
         for(int i = 0; i < weights.Length; i++)
         {
            weights[i] = Random.Range(-1.0f,1.0f);
         }
         bias = Random.Range(-1.0f,1.0f);
      }

      void UpdateWeights(int j)
      {
         double error = ts[j].output - CalcOutput(j);
         for(int i = 0; i < weights.Length; i++)
         {			
            weights[i] = weights[i] + error*ts[j].input[i]; 
         }
         bias += error;
      }

      double CalcOutput(double i1, double i2)
      {
         double[] inp = new double[] {i1, i2};
         double dp = DotProductBias(weights,inp);
         if(dp > 0) return(1);
         return (0);
      }

      void Train(int epochs)
      {
         InitialiseWeights();
         
         for(int e = 0; e < epochs; e++)
         {
            totalError = 0;
            for(int t = 0; t < ts.Length; t++)
            {
               UpdateWeights(t);
               Debug.Log("W1: " + (weights[0]) + " W2: " + (weights[1]) + " B: " + bias);
            }
            for(int t = 0; t < ts.Length; t++)
            {
               double error = ts[t].output - CalcOutput(t);
               totalError += Mathf.Abs((float)error);
            }
            Debug.Log("TOTAL ERROR: " + totalError);
         }
      }

      void Start () {
         Train(trainingAmount);
         Debug.Log("Test 0 0: " + CalcOutput(0,0));
         Debug.Log("Test 0 1: " + CalcOutput(0,1));
         Debug.Log("Test 1 0: " + CalcOutput(1,0));
         Debug.Log("Test 1 1: " + CalcOutput(1,1));		
      }
      
      void Update () {
         
      }
   }
```  

 * Был создан пустой объект с названием **Perceptron** и накинул на него скрипт **Perceptron.cs**  
 * Далее, он был научен " производить вычисление операции OR, для этого соответствующе OR заполнена таблица истинности

   - Для безошибочного выполнения операции потребовалось 5 эпох обучения

 * Далее, перцептрон научен производить вычисление операции AND, для этого соответствующе AND заполнена таблицу истинности
   
   -Для безошибочного выполнения операции потребовалось 6 эпох обучения
  
 * Далее, перцептрон научен производить вычисление операции NAND, для этого соответствующе NAND заполнена таблицу истинности
   *(При операции NAND вначале происходит операция логического умножение, а затем операция логического отрицания)* 
  
   - Для безошибочного выполнения операции потребовалось 7 эпох обучения
  
 * С операцией XOR возникает проблема, т.к. научить "перцептрон" производить вычисление операции XOR не получится даже при большом кол-ве эпох обучения, так как нейронная сеть с одним перцептроном может "справиться" только с линейными методом класс-ии, поэтому для решения данной задачи следует добавить дополнительный - скрытый слой нейронов. 

 -


## Задание 2  
### Построить графики зависимости количества эпох от ошибки  обучения. Указать от чего зависит необходимое количество эпох обучения. 

## Задание 3
### Построить визуальную модель работы перцептрона на сцене Unity.


## Выводы
В результате проделанной работы я узнал что такое персептрон, как он работает и какие задачи можно решать с помощью него. Также узнал, как персептрон используется в  машинном обучении. 

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**