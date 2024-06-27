create table clients(
    id bigint primary key generated always as identity,
    client_name varchar(200)
);

create table client_contacts(
    id bigint primary key generated always as identity,
    client_id bigint,
    contact_type varchar(255),
    contact_value varchar(255),
    foreign key (client_id) references clients(id)
);

insert into clients (client_name) values ('client1');
insert into clients (client_name) values ('client2');
insert into clients (client_name) values ('client3');


insert into client_contacts(client_id, contact_type, contact_value) values (1, 'contactType', 'contact');
insert into client_contacts(client_id, contact_type, contact_value) values (1, 'contactType', 'contact');
insert into client_contacts(client_id, contact_type, contact_value) values (2, 'contactType', 'contact');
insert into client_contacts(client_id, contact_type, contact_value) values (2, 'contactType', 'contact');
insert into client_contacts(client_id, contact_type, contact_value) values (2, 'contactType', 'contact');


