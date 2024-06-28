# Тестовое задание для IT_Expert

### Архитектура бекенд приложения:

- TestProject.Api.Contracts - дто, запросы, которые лежат наружу, при 
желании можно компилировать и подтягивать другим сервисом как библиотеку.
- TestProject.AppServices - слой бизнес логики
- TestProject.AppServices.Contracts - интерфейсы для слоя бизнес логики
- TestProject.Database - там описана конфигурация бд
- TestProject.Entities - доменная область, лежат сущности
- TestProject.Host - лежит входной файл для запуска апи сервера

### Запуск приложения
Весь проект обернут в Docker и docker-compose и запускается одной командой
```bash
docker compose up -d
```
бекенд запускается на localhost:8000, фронтенд на localhost:3000
