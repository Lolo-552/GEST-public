## O projekcie GEST
Jest to strona, którą stworzyłem na potrzeby koła naukowego GEST Politechniki Rzeszowskiej. Posiada Panel admina za pomocą którego można dodawać treści na stronie: projekty, aktualności, osiągnięcia, artykuły w zakładce więcej oraz publikacje.
## Link do strony
Demonstracyjną wersje strony opublikowałem na platformie azure. Dostępna jest pod linkiem:  
[gestdemo.azurewebsites.net](https://gestdemo.azurewebsites.net/)  
Panel admina dostępny jest pod linkiem:  
[gestdemo.azurewebsites.net/admin](https://gestdemo.azurewebsites.net/admin)  
***Dane do logowanie:***  
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
- Przypominanie hasła. Po kliknięciu linku "nie pamiętasz hasła" i powiązaniu adresu email z tym przypisanym do konta generowany jest token, który jest wysyłany w linku na poczte. Po kliknięciu w link zamieszczony w wiadomości email otwiera się strona. Jeśli token w linku będzie taki sam jak ten przypisany do konta admina, uruchamia się formularz zmiany hasła.
- Dodawanie, edytowanie, usuwanie artykułów
- Możliwość dodawanie zdjęć w artykule, oraz do galerii
- Możliwość dodawania plików
- Walidacja formularzy
- Można edytować większość tekstów (nagłówków, paragrafów) na stronie głównej w podglądzie strony w iframe
- Panel admina ma zaimplementowany edytor wiswig TinyMCE, dzięki czemu dodawane artykuły mogą zawierać tagi html
- Strona posiada również angielską wersję językową. Tłumaczenie nie jest generowane automatycznie, wszystkie przetłumaczone treści pobierane są z bazy danych. W celu szybszego i łatwiejszego tłumaczenia tekstu zaimplementowałem przycisk tłumacz automatycznie w formularzu dodawania artykułu. Klikając w niego treść umieszczona w polskiej wersji językowej jest tłumaczona przy użyciu Google Translate API i umieszczona w polu obok przeznaczonym dla angielskiej wersji strony. Admin może ręcznie poprawić wygenerowane tłumaczenie.



