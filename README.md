# Workshop-2
Нужно больше золота

Отчет по лабораторной работе #2 выполнил(а):
- Штаппер Григорий Алексеевич
- РИ-220944
  
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

- Задание 1.
- Ссылка на Google Документы.
- Задание 2.
- Код реализации выполнения задания.

## Задание 1
### Выюрать и описать игровую переменную.

https://docs.google.com/document/d/1BdR4GflQkZ-MsZWAzLFT74Pz3evNDH4-li2W9z5dcjA/edit

## Задание 2
### С помощью скрипта на языке Python заполнить и визуализировать таблицу.

https://docs.google.com/spreadsheets/d/1v71SE_Vm_f_ZZyP7X1RBMFwWsIxJbkU6vHCb_LhmTzU/edit#gid=0

```py

import gspread
import numpy as np

gc = gspread.service_account(filename="atomic-heart-resources-b5be789ab3a6.json")
sh = gc.open("Atomic Heart Resources")
countRes = np.random.randint(0, 700, 8)
priceRes = np.random.randint(1, 500, 8)

mon = list(range(1, 7))
i = 0

while i <= len(mon):
    i += 1
    if i == 0: continue
    else:
        possibilityCreation = priceRes[i] - countRes[i]
        possibilityCreation = str(possibilityCreation)
        possibilityCreation = possibilityCreation.replace('.', ',')        
        sh.sheet1.update(('A' + str(i)), int(i))
        sh.sheet1.update(('B' + str(i)), int(priceRes[i]))
        sh.sheet1.update(('C' + str(i)), int(countRes[i]))
        sh.sheet1.update(('D' + str(i)), int(possibilityCreation))
        print(possibilityCreation)

```

## Задание 3
### Настроить на сцене Unity воспроизведение звуковых файлов.

https://github.com/Gashap/Workshop-2/tree/adf92f93e6b0eb86aa5b5b5ea9c13ae7264e0f91/My%20project

## Выводы

- Была описана игровая переменная.
- С помощью скрипта на языке Python была заполнена и визуализирована таблица изменения игровой переменной.
- Была настроена сцена Unity для воспроизведения звуковых файлов. 

## Powered by

**BigDigital Team: Denisov | Fadeev | Panov**
