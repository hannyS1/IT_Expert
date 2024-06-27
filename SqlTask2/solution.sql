-- 1.	Написать запрос, который возвращает интервалы для одинаковых Id. Например, есть такой набор данных:
with date_intervals as (
    select
        id,
        date as sd,
        lead(date) over (partition by id order by date) as ed
    from
        dates
)
select
    id,
    sd,
    ed
from date_intervals
where ed is not null
order by id, sd;