-- 1. Написать запрос, который возвращает наименование клиентов и кол-во контактов клиентов
select
    c.client_name as client_name,
    count(cc.id) as contacts_count
from clients c
left join client_contacts cc on c.id = cc.client_id
group by c.client_name;



-- 2. Написать запрос, который возвращает список клиентов, у которых есть более 2 контактов
select c.client_name
from clients c
left join client_contacts cc on c.id = cc.client_id
group by c.client_name
having count(cc.id) > 2;