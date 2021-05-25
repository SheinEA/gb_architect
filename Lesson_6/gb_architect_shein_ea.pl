/*
Составить программу, т.е. модель предметной области – базу знаний, объединив в ней информацию – знания:
«Телефонный справочник»: Фамилия, №тел, Адрес – структура (Город, Улица, №дома, №кв),
«Автомобили»: Фамилия_владельца, Марка, Цвет, Стоимость, и др.,
«Вкладчики банков»: Фамилия, Банк, счет, сумма, др.

Владелец может иметь несколько телефонов, автомобилей, вкладов (факты).
Используя правила, обеспечить возможность поиска:
а) По № телефона найти: Фамилию, Марку автомобиля, Стоимость автомобиля (может быть несколько);
	- getPersonAuto(317575, Surname, Auto, Cost)
в) Используя сформированное в пункте а) правило, по № телефона найти: только Марку автомобиля (автомобилей может быть несколько);
    - getPersonAuto(317575, Auto)
    - getPersonAuto(317575, _, Auto, _)
с) Используя простой, не составной вопрос: по Фамилии (уникальна в городе, но в разных городах есть однофамильцы) и Городу проживания найти:  Улицу проживания, Банки, в которых есть вклады и №телефона.
    - getPersonBank("Шеин", "Белгород", Street, Bank, Phone)
*/

phone("Шеин", 317575, address("Белгород", "Есенина", 36, 1)).
phone("Петров", 317576, address("Москва", "Ленина", 45, 2)).
phone("Сидоров", 317577, address("Москва", "Петровка", 52, 3)).

auto("Шеин", "BMW X1", 1000000).
auto("Шеин", "Audi A6", 3000000).
auto("Петров", "ВАЗ-2107", 30000).
auto("Сидоров", "Porsche 911", 5000000).
auto("Сидоров", "BMW X7", 7000000).

account("Шеин", "ВТБ", 9000897455, 3000000).
account("Шеин", "СБЕР", 9000897456, 400000).
account("Петров", "СБЕР", 9000897457, 30000).
account("Сидоров", "Тинькофф", 9000897458, 5000000).

getPersonAuto(Phone, Surname, Auto, Cost) :- phone(Surname, Phone, address(_,_,_,_)), auto(Surname, Auto, Cost).
getPersonAuto(Phone, Auto) :- getPersonAuto(Phone, _, Auto, _).
getPersonBank(Surname, City, Street, Bank, Phone) :- phone(Surname, Phone, address(City,Street, _, _)), account(Surname, Bank, _, _).



