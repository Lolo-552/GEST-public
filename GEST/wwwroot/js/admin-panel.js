//sidebar toogle
$(document).ready(function () {
    $("#sidebarCollapse").on("click", function () {
        $("#sidebar").toggleClass("active");
        $(this).toggleClass("active");
    });
});
//photo upload validation
//edytując liste rozszerzeń zmień ją również po stronie serwera
$(".formWithFile").submit(function (event) {
    var fileInput = $("input[name='photos']")[0];
    var files = fileInput.files;
    var validExtensions = ["jpg", "jpeg", "png"];

    for (var i = 0; i < files.length; i++) {
        var file = files[i];
        var fileExtension = file.name.split(".").pop();

        if ($.inArray(fileExtension, validExtensions) === -1) {
            $(".photosValidationMassage").text("Akceptowane są tylko pliki jpg, jpeg, png");
            event.preventDefault();
        }
    }
    fileInput = $("input[name='files']")[0];
    files = fileInput.files;
    validExtensions = ["pdf", "txt", "docx"];

    for (var i = 0; i < files.length; i++) {
        var file = files[i];
        var fileExtension = file.name.split(".").pop();

        if ($.inArray(fileExtension, validExtensions) === -1) {
            $(".filesValidationMassage").text("Akceptowane są tylko pliki pdf, txt, docx");
            event.preventDefault();
        }
    }
});

//dataTable.js init
$(document).ready(function () {
    $('table').DataTable();
});

//foto delete change tyle
$(document).ready(function () {
    $('.removePhoto').on('change', function () {
        var deleteIcon = $(this).siblings('label').find('.delete-photo-icon');
        if ($(this).is(':checked')) {
            $(this).closest('.photo').css('opacity', '0.3');
            deleteIcon.css({
                'background-color': '#dc3545',
                'color': '#fff',
            });
        } else {
            $(this).closest('.photo').css('opacity', '1');
            deleteIcon.css({
                'background-color': '',
                'color': '#dc3545',
            });
        }
    });
});

//file delete change style
$(document).ready(function () {
    $('.removeFile').on('change', function () {
        var deleteIcon = $(this).siblings('label').find('.delete-file-icon');
        if ($(this).is(':checked')) {
            deleteIcon.css({
                'background-color': '#dc3545',
                'color': '#fff',
                'border-color': '#dc3545'
            });
        } else {
            deleteIcon.css({
                'background-color': '',
                'color': '#dc3545',
                'border-color': '#dc3545'
            });
        }
    });
});

//textarea auto height on focus
$(document).ready(function () {
    function adjustTextareaHeight() {
        $('textarea').each(function () {
            this.style.height = 'auto';
            this.style.height = (this.scrollHeight) + 'px';
        });
    }
    
    adjustTextareaHeight();
    
    $(window).on('resize', function() {
        adjustTextareaHeight();
    });
    
    $('textarea').on('input focus', function () {
        this.style.height = 'auto';
        this.style.height = (this.scrollHeight) + 'px';
    });
});

//iframe auto height
$('iframe').ready(function () {
    
    // nasłuchuj na zdarzenia przesyłania wiadomości z iframe'a
    window.addEventListener('message', function (event) {

        // sprawdź, czy źródło wiadomości pochodzi z iframe'a
        if (event.source !== $('iframe')[0].contentWindow) return;

        // ustaw wysokość iframe'a na podstawie przesłanej wysokości zawartości
        if (event.data.height) {
            $('iframe').height(event.data.height);
            $('iframe').contents().find('html').css('overflow', 'hidden');
            $('iframe').contents().scrollTop(0);
        }

    }, true);

});


//edytowanie treści na stronie głównej
$(document).ready(function () {
    // funkcja, która uruchamia się po kliknięciu przycisku "Edytuj"
    $('#btn-editable-iframe').click(function () {
        // wybierz iframe
        var iframe = $('#editable-iframe')[0].contentWindow.document;

        // znajdź elementy H1 i P wewnątrz iframe i ustaw atrybut contenteditable na true
        $(iframe).find('.editable').attr('contenteditable', true).css('border', '2px dashed #7e7e7e');

        // aktywuj przycisk "Zapisz"
        $('#save-button').prop('disabled', false);
    });

    // funkcja, która uruchamia się po kliknięciu przycisku "Zapisz"
    $('#save-button').click(function () {
        // wybierz iframe
        var iframe = $('#editable-iframe')[0].contentWindow.document;

        // zapisz zmiany w iframe
        $(iframe).find('.editable').removeAttr('contenteditable').css('border', 'none');

        // zablokuj ponowne kliknięcie przycisku "Zapisz"
        $(this).prop('disabled', true);

        var heroHeader = $(iframe).find('#heroHeader')[0].innerText;
        var heroP = $(iframe).find('#heroP')[0].innerText;
        var aboutUsHeader = $(iframe).find('#aboutUsHeader')[0].innerText;
        var aboutUsP = $(iframe).find('#aboutUsP')[0].innerText;
        var joinUsHeader = $(iframe).find('#joinUsHeader')[0].innerText;
        var joinUsP = $(iframe).find('#joinUsP')[0].innerText;
        var projectHeader = $(iframe).find('#projectHeader')[0].innerText;
        var newsHeader = $(iframe).find('#newsHeader')[0].innerText;
        var achievementsHeader = $(iframe).find('#achievementsHeader')[0].innerText;
        var publicationsHeader = $(iframe).find('#publicationsHeader')[0].innerText;
        var managementHeader = $(iframe).find('#managementHeader')[0].innerText;
        var email = $(iframe).find('#email')[0].innerText;
        $.ajax({
            type: 'POST',
            url: '/Admin/Home/SaveHomePageChanges',
            data: {
                'heroHeader': heroHeader,
                'heroP': heroP,
                'aboutUsHeader': aboutUsHeader,
                'aboutUsP': aboutUsP,
                'joinUsHeader': joinUsHeader,
                'joinUsP': joinUsP,
                'projectHeader': projectHeader,
                'newsHeader': newsHeader,
                'achievementsHeader': achievementsHeader,
                'publicationsHeader': publicationsHeader,
                'managementHeader': managementHeader,
                'email': email
            },
            success: function () {
                alert('Zmiany zostały zapisane.');
            },
            error: function () {
                alert('Wystąpił błąd podczas zapisywania zmian.');
            }
        });

    });
});


$(function () {
    $('.translate-label').click(function () {
        // Pobierz tekst z textarea dla języka polskiego
        var text = $(this).closest('.form-group').find('textarea').val();

        // Określ pole, do którego ma zostać wstawiony przetłumaczony tekst
        var target = $(this).data('target');

        // Wywołaj API Google Translate
        $.ajax({
            url: 'https://translate.googleapis.com/translate_a/t?origin=*',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded',
            data: {
                client: 'gtx',
                sl: 'pl',
                tl: 'en',
                q: text,
            },
            dataType: 'json',
            success: function (data) {
                // Wstaw przetłumaczony tekst do odpowiedniego pola
                $('textarea[name="' + target + '"]').val(data);
                function adjustTextareaHeight() {
                    $('textarea').each(function () {
                        this.style.height = 'auto';
                        this.style.height = (this.scrollHeight) + 'px';
                    });
                }
                adjustTextareaHeight();
            },
            error: function () {
                alert('Wystąpił błąd podczas tłumaczenia tekstu.');
            }
        });
    });
});
//automatyczne tlumaczenie
$(function () {
    $('.translate-trigger').click(function () {
        // Pobierz tekst z TinyMCE
        var editor = tinymce.get($(this).closest('.form-group').find('textarea').attr('id'));
        var text = editor.getContent();

        // Określ pole, do którego ma zostać wstawiony przetłumaczony tekst
        var target = $(this).closest('.form-group').find('textarea').attr('name').replace('Description', 'Description_en');

        // Wywołaj API Google Translate
        $.ajax({
            url: 'https://translate.googleapis.com/translate_a/t?origin=*',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded',
            data: {
                client: 'gtx',
                sl: 'pl',
                tl: 'en',
                q: text,
            },
            dataType: 'json',
            success: function (data) {
                // Wstaw przetłumaczony tekst do odpowiedniego pola TinyMCE
                var editor = tinymce.get($('[name="' + target + '"]').attr('id'));
                editor.setContent(data);
            },
            error: function () {
                alert('Wystąpił błąd podczas tłumaczenia tekstu.');
            }
        });
    });
});

//potwierdzanie hasla
$(document).ready(function () {
    $('#accountForm').submit(function (event) {
        var password = $('#password').val();
        var confirmPassword = $('#confirmPassword').val();
        if (password !== confirmPassword) {
            $('.passwordChangeError').text('Hasła nie są takie same.');
            event.preventDefault();
        }
    });
});

//Opis wymagany jeśli jedna wersja językowa została podana 
$(document).ready(function () {
    $('.articleForm').submit(function (e) {
        var description = tinymce.get('Description').getContent().trim();
        var description_en = tinymce.get('Description_en').getContent().trim();
        if (description.length === 0 && description_en.length > 0) {
            // uzupełniamy opis w języku polskim, jeśli nie został podany, ale podano opis w języku angielskim
            $('span[data-valmsg-for="Description"]').text("Uzupełnij polską wersję językową, jeśli angielska została podana");
            e.preventDefault();
        } else if (description.length > 0 && description_en.length === 0) {
            // uzupełniamy opis w języku angielskim, jeśli nie został podany, ale podano opis w języku polskim
            $('span[data-valmsg-for="Description_en"]').text("Uzupełnij angielską wersję językową, jeśli polska została podana");
            e.preventDefault();
        }
    });
});

$(document).ready(function () {
    // Dodajemy nasłuchiwanie zmian w polach formularza
    var $description = tinymce.get('Description');
    var $description_en = tinymce.get('Description_en');

    $description.on("input", function () {
        var description = $description.getContent().trim();
        var description_en = $description_en.getContent().trim();

        if (description.length > 0) {
            // uzupełniamy opis w języku angielskim, jeśli nie został podany, ale podano opis w języku polskim
            $('span[data-valmsg-for="Description"]').text("");
        }
    });

    $description_en.on("input", function () {
        var description = $description.getContent().trim();
        var description_en = $description_en.getContent().trim();

        if (description_en.length > 0) {
            $('span[data-valmsg-for="Description_en"]').text("");
        }
    });
});

$(document).ready(function () {

    $(".management-form").submit(function (e) {
        var description = $("#Description").val();
        var description_en = $("#Description_en").val();

        if ((description.length === 0 && description_en.length > 0)) {
            $('span[data-valmsg-for="Description"]').text("Uzupełnij polską wersję językową, jeśli angielska została podana");
            e.preventDefault();
        }

        if ((description_en.length === 0 && description.length > 0)) {
            $('span[data-valmsg-for="Description_en"]').text("Uzupełnij angielską wersję językową, jeśli polska została podana");
            e.preventDefault();
        }
    });

    $("#Description").on("input", function () {
        $('span[data-valmsg-for="Description"]').text("");
    });
    $("#Description_en").on("input", function () {
        $('span[data-valmsg-for="Description_en"]').text("");
    });
});






//tiny-edit-urlpath
// znajdź textarea o klasie .tiny-edit i zamień src="../../" na src="../../.."
$('textarea.tiny-edit').each(function () {
    var $textarea = $(this);
    var text = $textarea.text();
    tekst = $(tekst).find('img').attr('src', function (i, val) {
        return val.replace('../../', '../../../');
    }).end().prop('outerHTML');
    text = text;
    $textarea.text(text);
});



