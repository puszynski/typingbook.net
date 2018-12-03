//ToDO funkcja blokująca srolla po spacji
function spaceScrollDisable() {
    $(document).keydown(function (e) {
        if (e.which === 32) {
            return false;
        }
    });
}


function mainPageMenuShortcuts(spaceLink, shiftLink, escLink) {
    document.onkeydown = function (event) {
        //ToDo - ukryty tekst dla niewidomych który mówi aby nacisnąć 'B' aby przejść do trybu dla niewidomych + event
        if (event.keyCode === 32) {
            window.location.href = spaceLink;
        }
        if (event.keyCode === 16) {
            window.location.href = shiftLink; // name?
        }
        if (event.keyCode === 27) {
            window.location.href = escLink; // ?
        }
    };
}


function typingBook(currentBookPage, bookPagesJson, isIntroduction) {
    document.onkeypress = function (e) {
        e = e || window.event;
        
        var book_content = document.getElementById('book_content').textContent;
        var pageLength = bookPagesJson[currentBookPage].length;

        //typing
        if (String.fromCharCode(e.which /*|| e.keyCode*/) === book_content.charAt(0))
        {
            var decreasedValue = parseInt($(".correctTyped").text(), 10) + 1;
            $('.correctTyped').html(decreasedValue);

            updateBookPageStatusBar(pageLength);

            document.body.style.backgroundColor = "dimgray";
            document.getElementById('typed_content').innerHTML += book_content.charAt(0);
            document.getElementById('book_content').innerHTML = book_content.substr(1);

            //when book pages end
            if (document.getElementById('book_content').innerHTML === '') {
                var bookPages = bookPagesJson;
                var nextPage = ++currentBookPage;  

                $('.progress-bar-correct').css({ 'width': '0%' });
                $('.progress-bar-wrong').css({ 'width': '0%' });
                $('.correctTyped').html('0');
                $('.wrongTyped').html('0');

                if (bookPages.length <= nextPage) {
                    if (isIntroduction === 1) { 
                        window.location.href = '?bookID=2&bookPage=0';
                    }
                    else {
                        window.location.href = '@Url.Action("ChoseBook", "Home")';
                    }
                }
                else {
                    document.getElementById('typed_content').innerHTML = '';
                    document.getElementById('book_content').innerHTML = bookPages[nextPage];
                }
            }
        }
        else
        {
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

    $('.progress-bar-correct').css({ 'width': correctPercent+'%' });
    $('.progress-bar-wrong').css({ 'width': wrongPercent+'%' });
}