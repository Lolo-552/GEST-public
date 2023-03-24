// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


//menu
const mobileNav = document.querySelector('.menu');
const burgerBtn = document.querySelector('.burger');

burgerBtn.addEventListener('click', function () {
    mobileNav.classList.toggle('menuActive');
    burgerBtn.classList.toggle('burgerActive');
});

$(document).ready(function() {
	$('.gallery').magnificPopup({
        delegate: '.gallery-item',
		type: 'image',
        gallery: {
            enabled: true
        }
	});
});

//iframe auto height (admin)
// wyślij wiadomość rodzicowi z wysokością zawartości
function sendHeightToParent() {
    var height = $('html').height();
    parent.postMessage({ height: height }, '*');
}

// wywołaj funkcję sendHeightToParent po załadowaniu strony i przy zmianie zawartości
$(document).resize(function () {
    sendHeightToParent();
});

$(window).ready(function () {
    setTimeout(function () {
        sendHeightToParent();
    },800);
    
});

//header
if (window.location.pathname === "/" || window.location.pathname.startsWith("/home")) {
    window.addEventListener("scroll", function () {
        if (window.pageYOffset > 1) {
            var header = document.querySelector("header");
            header.style.transition = "background 1s ease, box-shadow 0.5s ease";
            header.style.background = "#fff";
            header.style.boxShadow = "rgba(0, 0, 0, 0.24) 0px 3px 8px";
        } else {
            var header = document.querySelector("header");
            header.style.transition = "background 1s ease, box-shadow 0.5s ease";
            header.style.background = "#E1ECD4";
            header.style.boxShadow = "none";
        }
    });
}
else {
    var header = document.querySelector("header");
    var body = document.querySelector("body");
    var main = document.querySelector("main");
    header.style.position = "relative";
    body.style.padding = 0;
    main.style.padding = "90px 0 0 0";
}

//zarząd, rozijanie email i telefon
$(document).ready(function () {
    // Ukryj początkowo elementy <p> z numerem telefonu i mailem:
    $('p.contact-phone').hide();
    $('p.contact-mail').hide();

    // Po kliknięciu na ikonę telefonu:
    $('div[id^="contact-box-phone"]').on('click', function () {
        var id = $(this).attr("id").split("-").pop();
        // Wysuń numer telefonu:
        $('#contact-phone-' + id).animate({ width: 'toggle' });
        $('#contact-box-mail-' + id).toggle(500);
        // Dodaj style do elementu .contact-box:
        $('#contact-box-phone-' + id).toggleClass('contact-box-active');
        $('#contact-icon-phone-' + id).toggleClass('contact-icon-active')
    });

    // Po kliknięciu na ikonę mail
    $('div[id^="contact-box-mail"]').on('click', function () {
        var id = $(this).attr("id").split("-").pop();
        // Wysuń adres e-mail:
        $('#contact-mail-' + id).animate({ width: 'toggle' });
        $('#contact-box-phone-' + id).toggle(500);
        // Dodaj style do elementu .contact-box:
        $('#contact-box-mail-' + id).toggleClass('contact-box-active');
        $('#contact-icon-mail-' + id).toggleClass('contact-icon-active')
    });
});


//management card height
$(document).ready(function () {
    var maxheight = 0;
    $(".management-card").each(function () {
        var height = $(this).height();
        if (height > maxheight) {
            maxheight = height;
        }
    });
    $(".management-card").height(maxheight);
});

//dropdown (więcej)
$(document).ready(function () {
    // ukrywamy początkowo dropdown-box
    $('.dropdown-box').hide();

    // dodajemy obsługę kliknięcia w element z klasą nav-link
    $('#dropdown').click(function (e) {
        e.preventDefault(); // zapobiegamy domyślnej akcji kliknięcia w link
        $('.dropdown-box').slideToggle(); // wysuwamy lub ukrywamy dropdown-box
        $('#rotate-arrow').toggleClass('rotate');
    });
});

//dołącz do nas, o nas button scroll to
$(document).ready(function () {
    // dodajemy obsługę kliknięcia w przyciski
    $('.btn-1, .btn-2').click(function (e) {
        e.preventDefault(); // zapobiegamy domyślnej akcji kliknięcia w link

        // wybieramy docelowe sekcje
        var target = $(this).hasClass('btn-1') ? $('#aboutUsHeader') : $('#joinUsHeader');

        // przewijamy do wybranej sekcji z animacją
        $('html, body').animate({
            scrollTop: target.offset().top - 200
        }, 500);
    });
});
