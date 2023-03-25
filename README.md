## O projekcie GEST
Jest to strona, którą stworzyłem na potrzeby koła naukowego GEST Politechniki Rzeszowskiej. Posiada Panel admina za pomocą którego można dodawać treści na stronie: projekty, aktualności, osiągnięcia, artykuły w zakładce więcej oraz publikacje.
## Link do strony
Demonstracyjną wersje strony opublikowałem na platformie azure. Dostępna jest pod linkiem:  
[gestdemo.azurewebsites.net](https://gestdemo.azurewebsites.net/)  
Panel admina dostępny jest pod linkiem:  
[gestdemo.azurewebsites.net/admin](https://gestdemo.azurewebsites.net/admin)  
***Dane do logowania:***  
login: admin  
hasło: admin  

## Wykorzystane technologie
- C# MVC
- jQuery
- Bootstrap 5
- HTML/CSS
- Microsoft SQL Server
- Entity Framework

## Zaimplementowane funkcjonalności
- Przypominanie hasła. Po kliknięciu linku "nie pamiętasz hasła" i powiązaniu adresu email z tym przypisanym do konta generowany jest token, który jest wysyłany w linku na poczte email. Po kliknięciu w link zamieszczony w wiadomości otwiera się strona. Jeśli token w linku będzie taki sam jak ten przypisany do konta admina, uruchamia się formularz zmiany hasła.
- Dodawanie, edytowanie, usuwanie artykułów
- Możliwość dodawanie zdjęć w artykule, oraz do galerii
- Możliwość dodawania plików
- Walidacja formularzy
- Można edytować większość tekstów (nagłówków, paragrafów) na stronie głównej w podglądzie strony w iframe
- Panel admina ma zaimplementowany edytor wiswig TinyMCE, dzięki czemu dodawane artykuły mogą zawierać tagi html
- Strona posiada również angielską wersję językową. Strona nie jest tłumaczona automatycznie, wszystkie przetłumaczone treści pobierane są z bazy danych. W celu szybszego i łatwiejszego tłumaczenia tekstu zaimplementowałem przycisk tłumacz automatycznie w formularzu dodawania artykułu. Klikając w niego treść umieszczona w polskiej wersji językowej jest tłumaczona przy użyciu Google Translate API i umieszczona w polu obok przeznaczonym dla angielskiej wersji strony. Admin może ręcznie poprawić wygenerowane tłumaczenie.

## Strona główna
![image](https://user-images.githubusercontent.com/80482388/227707870-a1f0e3a5-b4b5-4522-ad05-5d4d655f9d3e.png)
![image](https://user-images.githubusercontent.com/80482388/227707911-3a5efbf7-0ca8-43fd-8d0a-7ae6e355874b.png)

## Panel admina
![image](https://user-images.githubusercontent.com/80482388/227707970-13c16932-23b7-4055-a481-cb534b2a7e8b.png)
![image](https://user-images.githubusercontent.com/80482388/227707981-81f1973a-89fc-4e5c-be92-0a0f2a17fd54.png)
![image](https://user-images.githubusercontent.com/80482388/227707999-5e766d6d-9ae2-4afd-8d23-0d980397c17c.png)
![image](https://user-images.githubusercontent.com/80482388/227708009-1be45741-d901-4ef5-af59-bf574f40b270.png)



