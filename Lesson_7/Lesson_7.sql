-- 1. Japanese Cities' Names
select name from city where countrycode = 'JPN';

-- 2. Query a list of CITY names from STATION for cities that have an even ID number
-- MSSQL
select distinct city from station 
where (id % 2) = 0
order by city;
-- Oracle
select distinct city from station 
where mod(id, 2) = 0
order by city;

-- 3. Query the average population for all cities in CITY, rounded down to the nearest integer
select round(avg(population)) from city;

-- 4. Query the Western Longitude (LONG_W)where the smallest Northern Latitude (LAT_N) in STATION is greater than 38.7780
-- Oracle
select round(long_w, 4) from (
    select 
        long_w, 
        row_number() over(order by lat_n asc) r_num
    from station
    where lat_n > 38.7780) t
where t.r_num = 1;
-- Other variant
select round(long_w, 4) 
from station
where lat_n = (select min(lat_n) from station where lat_n > 38.7780);

-- 5. Given the CITY and COUNTRY tables, query the sum of the populations of all cities where the CONTINENT is 'Asia
select sum(city.population) from city 
join country on city.countrycode = country.code 
where country.continent = 'Asia';

-- 6. Given the CITY and COUNTRY tables, query the names of all cities where the CONTINENT is 'Africa'
select city.name from city 
join country on city.countrycode = country.code 
where country.continent = 'Africa';