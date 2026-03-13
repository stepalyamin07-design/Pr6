# Pr6
<img width="728" height="242" alt="image" src="https://github.com/user-attachments/assets/82f269b6-b95b-44ba-a76b-2bf96492a44d" />
<img width="976" height="215" alt="image" src="https://github.com/user-attachments/assets/ab73932f-65da-4297-aeea-3c750cd1bed1" />
Тест 1: Debit_WithValidAmount_UpdatesBalance

Цель: Проверка корректного уменьшения баланса при валидных данных.

Логика: Создается счет (11.99), снимается 4.55. Проверяется, что остаток равен 7.44.

Статус: Успешно (баланс обновляется верно).

Тест 2: Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange

Цель: Проверка защиты от "ухода в минус".

Логика: Попытка снять 20.0 при балансе 11.99.

Ожидаемый результат: Выброс исключения ArgumentOutOfRangeException с сообщением "Debit amount exceeds balance".

Статус: Успешно (ошибка перехвачена).

Тест 3: Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange

Цель: Проверка запрета на списание отрицательной суммы.

Логика: Попытка снять -100.00.

Ожидаемый результат: Выброс исключения ArgumentOutOfRangeException.

Статус: Успешно (система блокирует некорректный ввод).

Блок 2: Тестирование метода Credit (Пополнение)

Тест 4: Credit_WithValidAmount_UpdatesBalance

Цель: Проверка корректного увеличения баланса.

Логика: Создается счет (11.99), вносится 5.01 (или 5.0 в зависимости от кода). Проверяется соответствие ожидаемой сумме.

Статус: Успешно (баланс увеличивается корректно).

Тест 5: Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange

Цель: Проверка запрета на пополнение счета отрицательным числом.

Логика: Попытка внести -5.0.

Ожидаемый результат: Выброс исключения ArgumentOutOfRangeException.

Статус: Успешно (метод отклоняет отрицательные суммы).
