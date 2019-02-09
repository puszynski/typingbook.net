// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.



// Dynamic menu using ajax
function startTypingAjaxMenuButton() {
        //alert("check");
    $("#type_button").click(function () {
        //alert("check");
        $(".body-content").load(
            "/Typing/Index"//, { model data goes here..}
        );
    });

    $("#switchBook_button").click(function () {
        $(".body-content").load(
            "/Books/Index"
        );
    });
}

// Powinno pokazywać img ładowania w trakcie ładowania zawartości ajaxem
//$('#loading-image').bind('ajaxStart', function () {
//    $(this).show();
//}).bind('ajaxStop', function () {
//    $(this).hide();
//});



function typingBook(currentBookPage, bookPagesJson, isIntroduction) {
    document.onkeypress = function (e) {
        e = e || window.event;

        var book_content = document.getElementById('book_content').textContent;
        pageLength = bookPagesJson[currentBookPage].length;

        //typing
        if (String.fromCharCode(e.which /*|| e.keyCode*/) === book_content.charAt(0)) {
            var decreasedValue = parseInt($(".correctTyped").text(), 10) + 1;
            $('.correctTyped').html(decreasedValue);

            updateBookPageStatusBar(pageLength);

            document.body.style.backgroundColor = "dimgray";
            document.getElementById('typed_content').innerHTML += book_content.charAt(0);
            document.getElementById('book_content').innerHTML = book_content.substr(1);

            
            if (document.getElementById('book_content').innerHTML === '') {
                //when book pages end
                var bookPages = bookPagesJson;
                var nextPage = ++currentBookPage;

                saveBookPageProgress();
                saveStatisticsProgress();

                $('.progress-bar-correct').css({ 'width': '0%' });
                $('.progress-bar-wrong').css({ 'width': '0%' });
                $('.correctTyped').html('0');
                $('.wrongTyped').html('0');

                if (bookPages.length <= nextPage) {
                    if (isIntroduction === 1) {
                        window.location.href = '?bookID=2&bookPage=0';
                    }
                    else {
                        window.location.href = '@Url.Action("Index", "Books")';
                        //redirectToAction();
                    }
                }
                else {
                    document.getElementById('typed_content').innerHTML = '';
                    document.getElementById('book_content').innerHTML = bookPages[nextPage];
                }
            }
        }
        else {
            var increasedValue = parseInt($(".wrongTyped").text(), 10) + 1;
            $('.wrongTyped').html(increasedValue);

            document.body.style.backgroundColor = "white";
            updateBookPageStatusBar(pageLength);
        }
    };
}


function updateBookPageStatusBar(pageLength) {
    var correctTyped = parseInt($(".correctTyped").text(), 10);
    var wrongTyped = parseInt($(".wrongTyped").text(), 10);

    var correctPercent = correctTyped / (pageLength + wrongTyped) * 100;
    var wrongPercent = wrongTyped / (pageLength + wrongTyped) * 100;

    $('.progress-bar-correct').css({ 'width': correctPercent + '%' });
    $('.progress-bar-wrong').css({ 'width': wrongPercent + '%' });
}

function saveBookPageProgress() {
    var url = '/Statistics/SaveBookPageProgress';

    $.ajax({
        url: url,
        data: { // TODO
            input: "razdwatrzy"
        },
        type: 'GET',
        datatype: 'json'
    });
}


function saveStatisticsProgress() {
    var url = '/Statistics/SaveStatisticProgress';
    
    var correctTyped = parseInt($(".correctTyped").text(), 10);
    var wrongTyped = parseInt($(".wrongTyped").text(), 10);

    $.ajax({
        url: url,
        data: { // TODO
            correctTyped: correctTyped,
            wrongTyped: wrongTyped
        },
        type: 'GET',
        datatype: 'json',
        //success: function () {
        //    alert("Data has been added successfully.");  
        //    LoadData();
        //},
        //error: function () {
        //    alert("Error while inserting data");
        //}
    });
}